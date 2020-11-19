using Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WorkBalancer
    {
        private readonly Thread SuperviseWorkersThread;

        private readonly LinkedList<Worker> ListActiveWorker;
        private readonly LinkedList<Worker> ListIdleWorker;
        private readonly LinkedList<Worker> ListDeadWorker;
        private int MaxActiveWorkers;
        private bool _IsWorking;

        public bool IsWorking { get { return _IsWorking; } }

        public int ActiveWorkersCount { get { return ListActiveWorker.Count; } }
        public int IdleWorkersCount { get { return ListIdleWorker.Count; } }
        public int DeadWorkersCount { get { return ListDeadWorker.Count; } }

        public WorkBalancer()
        {
            SuperviseWorkersThread = new Thread(new ThreadStart(SuperviseWorkers));

            ListActiveWorker = new LinkedList<Worker>();
            ListIdleWorker = new LinkedList<Worker>();
            ListDeadWorker = new LinkedList<Worker>();
            MaxActiveWorkers = 10;
            _IsWorking = false;
        }

        public WorkBalancer(Worker[] ArrayWorker)
            : this()
        {
            for (int W = ArrayWorker.Length - 1; W >= 0; --W)
            {
                if (W < MaxActiveWorkers)
                {
                    ListActiveWorker.AddLast(ArrayWorker[W]);
                }
                else
                {

                    ListIdleWorker.AddLast(ArrayWorker[W]);
                }
            }
        }

        public List<Worker> GetActiveWorkers()
        {
            List<Worker> ListWorker = new List<Worker>();

            LinkedListNode<Worker> ActiveNode = ListActiveWorker.First;
            while (ActiveNode != null)
            {
                Worker ActiveWorker = ActiveNode.Value;
                LinkedListNode<Worker> NextNode = ActiveNode.Next;

                ListWorker.Add(ActiveWorker);

                ActiveNode = NextNode;
            }

            return ListWorker;
        }

        public List<Worker> GetIdleWorkers()
        {
            List<Worker> ListWorker = new List<Worker>();

            LinkedListNode<Worker> ActiveNode = ListIdleWorker.First;
            while (ActiveNode != null)
            {
                Worker ActiveWorker = ActiveNode.Value;
                LinkedListNode<Worker> NextNode = ActiveNode.Next;

                ListWorker.Add(ActiveWorker);

                ActiveNode = NextNode;
            }

            return ListWorker;
        }

        public List<Worker> GetDeadWorkers()
        {
            List<Worker> ListWorker = new List<Worker>();

            LinkedListNode<Worker> ActiveNode = ListDeadWorker.First;
            while (ActiveNode != null)
            {
                Worker ActiveWorker = ActiveNode.Value;
                LinkedListNode<Worker> NextNode = ActiveNode.Next;

                ListWorker.Add(ActiveWorker);

                ActiveNode = NextNode;
            }

            return ListWorker;
        }

        public void AddWorker(Worker NewWorker)
        {
            if (ListActiveWorker.Count < MaxActiveWorkers)
            {
                ListActiveWorker.AddLast(NewWorker);
            }
            else
            {
                ListIdleWorker.AddLast(NewWorker);
            }
        }

        public void StartWorking()
        {
            foreach (Worker ActiveWorker in ListActiveWorker) 
            {
                ActiveWorker.StartWorking();
            }

            SuperviseWorkersThread.Start();
        }

        public void StopWorking()
        {
            _IsWorking = false;

            foreach (Worker ActiveWorker in ListActiveWorker)
            {
                ActiveWorker.StopWorking();
            }
        }

        public void KillWorkers()
        {
            SuperviseWorkersThread.Abort();
        }

        private async void SuperviseWorkers()
        {
            _IsWorking = true;

            while (_IsWorking)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                LinkedListNode<Worker> ActiveNode = ListActiveWorker.First;
                while (ActiveNode != null)
                {
                    Worker ActiveWorker = ActiveNode.Value;
                    LinkedListNode<Worker> NextNode = ActiveNode.Next;

                    if (!ActiveWorker.IsAlive())
                    {
                        ListActiveWorker.Remove(ActiveWorker);
                        ListDeadWorker.AddLast(ActiveWorker);

                        if (ListIdleWorker.Count > 0)
                        {
                            ListActiveWorker.AddLast(ListIdleWorker.First.Value);
                            ListIdleWorker.RemoveFirst();
                        }

                        Workload ActiveWorkload = ActiveWorker.GetWorkload();
                        SplitWorkload(ActiveWorkload, null);
                    }
                    else if (!ActiveWorker.IsWorking() && !ActiveWorker.GetWorkload().HasWorkToDo)
                    {
                        ListActiveWorker.Remove(ActiveWorker);
                        ListIdleWorker.AddLast(ActiveWorker);
                    }
                    else
                    {
                        Workload Overload = ActiveWorker.GetOverload();
                        if (Overload.HasWorkToDo)
                        {
                            SplitWorkload(Overload, ActiveWorker);
                        }
                    }

                    ActiveNode = NextNode;
                }

                CheckDeadWorkers();
            }

            WaitForWorkersToStopWorking();
        }

        private void CheckDeadWorkers()
        {
            LinkedListNode<Worker> ActiveNode = ListDeadWorker.First;
            while (ActiveNode != null)
            {
                Worker ActiveWorker = ActiveNode.Value;
                LinkedListNode<Worker> NextNode = ActiveNode.Next;

                if (ActiveWorker.IsAlive())
                {
                    ListDeadWorker.Remove(ActiveWorker);

                    if (ListActiveWorker.Count < MaxActiveWorkers)
                    {
                        ListActiveWorker.AddLast(ActiveWorker);
                    }
                    else
                    {
                        ListIdleWorker.AddLast(ActiveWorker);
                    }
                }

                ActiveNode = NextNode;
            }
        }

        private void WaitForWorkersToStopWorking()
        {
            bool HasWorkersStoppedWorking = true;

            do
            {
                foreach (Worker ActiveWorker in ListActiveWorker)
                {
                    if (!ActiveWorker.IsWorking())
                    {
                        HasWorkersStoppedWorking = false;
                    }
                }
            }
            while (!HasWorkersStoppedWorking);
        }

        private void SplitWorkload(Workload ActiveWorkload, Worker Owner)
        {
            while (ActiveWorkload.HasWorkToDo)
            {
                foreach (Worker ActiveWorker in ListActiveWorker)
                {
                    if (ActiveWorker == Owner)
                    {
                        continue;
                    }
                    else if (ActiveWorker.IsAlive())
                    {
                        ActiveWorker.AddWork(ActiveWorkload.PullWork());
                    }
                }
            }
        }
    }
}
