using Api;
using Core;
using System;
using System.Net.Http;
using System.Threading;
using Thread = Hayden.Models.Thread;

namespace _4Chan_Crawler
{
    class ThreadReader : ApiHelper
	{
		public bool IsAlive { get; internal set; }

		private readonly Archiver ThreadArchiver;
		private readonly string Board;
		private readonly ulong ThreadNumber;

		private DateTimeOffset LastTimeChecked;
		private int PostCount;

		public ThreadReader(HttpClient Client, Archiver ThreadArchiver, string Board, ulong ThreadNumber)
			: base(Client, "https://boards.4chan.org")
		{
			this.ThreadArchiver = ThreadArchiver;
			this.Board = Board;
			this.ThreadNumber = ThreadNumber;

			LastTimeChecked = DateTimeOffset.MinValue;
			PostCount = 0;
			IsAlive = true;
		}

        public async void ReadThread(CancellationToken Token)
		{
			DateTimeOffset BeforeCheckTime = DateTimeOffset.Now;

			ApiResponse<Thread> ThreadResponse = await MakeApiCall<Thread>(new Uri($"https://a.4cdn.org/{Board}/thread/{ThreadNumber}.json"), LastTimeChecked, Token);

			if (ThreadResponse.ResponseType == YotsubaResponseType.Ok)
			{
				if (PostCount == 0)
				{
					ThreadArchiver.WriteAll(Board, ThreadNumber, ThreadResponse.Reponse.Posts);
				}
				else
				{
					ThreadArchiver.AppendAll(Board, ThreadNumber, PostCount, ThreadResponse.Reponse.Posts);
				}

				PostCount = ThreadResponse.Reponse.Posts.Length;
			}
			else if (ThreadResponse.ResponseType == YotsubaResponseType.NotFound)
			{
				ThreadArchiver.Archive(Board, ThreadNumber);
				IsAlive = false;
			}

			LastTimeChecked = BeforeCheckTime;
		}

		public override string ToString()
		{
			return $"{Board}/{ThreadNumber}";
		}
	}
}
