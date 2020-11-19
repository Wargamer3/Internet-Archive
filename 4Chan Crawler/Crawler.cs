using Core;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Chan_Crawler
{
	public class Crawler : Worker
	{
		private readonly HttpClient Client;
		private readonly LinkedList<ThreadReader> ListThreadReader;
		private readonly LinkedList<BoardReader> ListBoardReader;
		private CancellationTokenSource TokenSource;
		private readonly Thread CrawlerThread;
		private readonly Archiver ThreadArchiver;

		public string WorkerType => throw new NotImplementedException();

		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Crawler(Archiver ThreadArchiver)
		{
			this.ThreadArchiver = ThreadArchiver;
			Client = CreateNewClient();
			ListBoardReader = new LinkedList<BoardReader>();
			ListThreadReader = new LinkedList<ThreadReader>();

			TokenSource = new CancellationTokenSource();
			CrawlerThread = new Thread(new ThreadStart(Update));
		}

		public Crawler(Archiver ThreadArchiver, HttpClient Client)
		{
			this.ThreadArchiver = ThreadArchiver;
			this.Client = Client;
			ListBoardReader = new LinkedList<BoardReader>();
			ListThreadReader = new LinkedList<ThreadReader>();

			TokenSource = new CancellationTokenSource();
			CrawlerThread = new Thread(new ThreadStart(Update));
		}

		protected HttpClient CreateNewClient()
		{
			HttpClientHandler ClientHandler = new HttpClientHandler
			{
				MaxConnectionsPerServer = 24,
				Proxy = null,
				UseCookies = false,
				UseProxy = true,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
			};

			HttpClient Client = new HttpClient(ClientHandler, true);

			Client.DefaultRequestHeaders.UserAgent.ParseAdd("Hayden/0.6.0");
			Client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate");

			return Client;
		}

		public async void Update()
		{
			while (!TokenSource.IsCancellationRequested)
			{
				LinkedListNode<ThreadReader> ActiveThreadNode = ListThreadReader.First;
				while (ActiveThreadNode != null)
				{
					await Task.Delay(TimeSpan.FromSeconds(10));

					ThreadReader ActiveThread = ActiveThreadNode.Value;
					LinkedListNode<ThreadReader> NextNode = ActiveThreadNode.Next;

					if (ActiveThread.IsAlive)
					{
						ActiveThread.ReadThread(TokenSource.Token);
					}
					else
					{
						ListThreadReader.Remove(ActiveThread);
					}

					ActiveThreadNode = NextNode;
				}

				LinkedListNode<BoardReader> ActiveBoardNode = ListBoardReader.First;
				while (ActiveBoardNode != null)
				{
					await Task.Delay(TimeSpan.FromSeconds(10));

					BoardReader ActiveBoard = ActiveBoardNode.Value;
					LinkedListNode<BoardReader> NextNode = ActiveBoardNode.Next;

					IEnumerable<ulong> ListNewThread = await ActiveBoard.GetNewThreads(TokenSource.Token);

					foreach (ulong ActiveThread in ListNewThread)
					{
						ListThreadReader.AddLast(new ThreadReader(Client, ThreadArchiver, ActiveBoard.ToString(), ActiveThread));
					}

					ActiveBoardNode = NextNode;
				}

				await Task.Delay(TimeSpan.FromSeconds(1));
			}
		}

		public async void AddWork(string WorkToDo)
		{
			string[] ArrayWorkToDo = WorkToDo.Split("/");

			if (ArrayWorkToDo.Length == 1)
			{
				BoardReader NewBoardReader = new BoardReader(Client, ArrayWorkToDo[0]);
				ListBoardReader.AddLast(NewBoardReader);
				IEnumerable<ulong> ListNewThread = await NewBoardReader.GetNewThreads(TokenSource.Token);

				foreach (ulong ActiveThread in ListNewThread)
				{
					ListThreadReader.AddLast(new ThreadReader(Client, ThreadArchiver, ArrayWorkToDo[0], ActiveThread));
				}
			}
			else if (ArrayWorkToDo.Length == 2)
			{
				ListThreadReader.AddLast(new ThreadReader(Client, ThreadArchiver, ArrayWorkToDo[0], ulong.Parse(ArrayWorkToDo[1])));
			}
		}
		
		private async void ReadBoard(string Board, Task<List<ulong>> ListThread)
		{
			foreach (ulong ActiveThreadNumber in await ListThread)
			{
				ListThreadReader.AddLast(new ThreadReader(Client, ThreadArchiver, Board, ActiveThreadNumber));
			}
		}

		public void RemoveWork(string WorkToAbandon)
		{
			string[] ArrayWorkToAbandon = WorkToAbandon.Split("/");
			if (ArrayWorkToAbandon.Length == 1)
			{
				BoardReader BoardToAbandon = null;
				foreach (BoardReader ActiveBoard in ListBoardReader)
				{
					if (ActiveBoard.ToString() == ArrayWorkToAbandon[0])
					{
						BoardToAbandon = ActiveBoard;
						break;
					}
				}

				if (BoardToAbandon != null)
				{
					ListBoardReader.Remove(BoardToAbandon);
				}
			}
			else if (ArrayWorkToAbandon.Length == 2)
			{
			}
			throw new NotImplementedException();
		}

		public Workload GetOverload()
		{
			throw new NotImplementedException();
		}

		public Workload GetWorkload()
		{
			LinkedList<string> ListWorkToDo = new LinkedList<string>();

			LinkedListNode<BoardReader> ActiveBoardNode = ListBoardReader.First;
			while (ActiveBoardNode != null)
			{
				BoardReader ActiveBoard = ActiveBoardNode.Value;
				LinkedListNode<BoardReader> NextNode = ActiveBoardNode.Next;

				ListWorkToDo.AddLast(ActiveBoard.ToString());

				ActiveBoardNode = NextNode;
			}

			LinkedListNode<ThreadReader> ActiveThreadNode = ListThreadReader.First;
			while (ActiveThreadNode != null)
			{
				ThreadReader ActiveThread = ActiveThreadNode.Value;
				LinkedListNode<ThreadReader> NextNode = ActiveThreadNode.Next;

				ListWorkToDo.AddLast(ActiveThread.ToString());

				ActiveThreadNode = NextNode;
			}

			Workload CurrentWorkload = new Workload(ListWorkToDo);
			return CurrentWorkload;
		}

		public bool IsAlive()
		{
			throw new NotImplementedException();
		}

		public bool IsWorking()
		{
			return CrawlerThread.IsAlive && !TokenSource.IsCancellationRequested;
		}

		public bool NeedsHelp()
		{
			throw new NotImplementedException();
		}

		public void StartWorking()
		{
			CrawlerThread.Start();
		}

		public void StopWorking()
		{
			TokenSource.Cancel();
		}

		public Workload GetAllPossibleWorkload()
		{
			throw new NotImplementedException();
		}
	}
}
