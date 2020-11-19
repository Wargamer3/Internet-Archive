using _4Chan_Crawler;
using Core;
using System.Collections.Generic;

namespace ServerAdministrationPlatform
{
    class LocalChanWorker : Worker
    {
        public string WorkerType => "4Chan Local Worker";

        public string Name { get; set; }

        private Crawler ActiveCrawler;

        public LocalChanWorker()
        {
            ActiveCrawler = new Crawler(new BinaryDiskArchiver("H:/Archive"));
        }
        
        public void AddWork(string WorkToDo)
        {
            ActiveCrawler.AddWork(WorkToDo);
        }

        public void RemoveWork(string WorkToAbandon)
        {
            ActiveCrawler.RemoveWork(WorkToAbandon);
        }

        public Workload GetOverload()
        {
            return new Workload();
        }

        public Workload GetWorkload()
        {
            return ActiveCrawler.GetWorkload();
        }

        public bool IsAlive()
        {
            return true;//Local Workers will always be connected to its crawler
        }

        public bool IsWorking()
        {
            return ActiveCrawler.IsWorking();
        }

        public bool NeedsHelp()
        {
            return ActiveCrawler.NeedsHelp();
        }

        public void StartWorking()
        {
            ActiveCrawler.StartWorking();
        }

        public void StopWorking()
        {
            ActiveCrawler.StopWorking();
        }

        public Workload GetAllPossibleWorkload()
        {
            LinkedList<string> ListBoard = new LinkedList<string>();

            ListBoard.AddLast("v");
            ListBoard.AddLast("a");
            ListBoard.AddLast("wsg");

            return new Workload(ListBoard);
        }
    }
}
