using Hayden.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api;
using System.Linq;

namespace _4Chan_Crawler
{
    class BoardReader : ApiHelper
	{
		private readonly string Board;
		private HashSet<ulong> HashActiveThread;
		private DateTimeOffset LastTimeChecked;

		public BoardReader(HttpClient Client, string Board)
			: base(Client, "https://boards.4chan.org")
		{
			this.Board = Board;
			HashActiveThread = new HashSet<ulong>();
			LastTimeChecked = DateTimeOffset.MinValue;
		}

		public async Task<IEnumerable<ulong>> GetNewThreads(CancellationToken Token)
		{
			DateTimeOffset BeforeCheckTime = DateTimeOffset.Now;

			HashSet<ulong> HashAllThreads = new HashSet<ulong>();

			ApiResponse<Page[]> BoardPages = await MakeApiCall<Page[]>(new Uri($"https://a.4cdn.org/{Board}/threads.json"), LastTimeChecked, Token);

			if (BoardPages.ResponseType == YotsubaResponseType.Ok)
			{
				foreach (Page ActivePage in BoardPages.Reponse)
				{
					foreach (PageThread ActiveThread in ActivePage.Threads)
					{
						HashAllThreads.Add(ActiveThread.ThreadNumber);
					}
				}
			}

			IEnumerable<ulong> NewThread = HashAllThreads.Except(HashActiveThread);

			HashActiveThread = HashAllThreads;

			LastTimeChecked = BeforeCheckTime;

			return NewThread;
		}

		public override string ToString()
		{
			return Board;
		}
	}
}
