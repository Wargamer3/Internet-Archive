using Core;
using System;
using System.Collections.Generic;

namespace Hayden.Tests
{
    class DummyWorker : Worker
    {
        public string WorkerType => "Dummy";

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool DummyIsAlive;
        public bool DummyIsWorking;
        public bool DummyNeedsHelp;
        public LinkedList<string> DummyListWorkToDo;

        public DummyWorker()
        {
            DummyIsAlive = true;
            DummyIsWorking = false;
            DummyNeedsHelp = false;
            DummyListWorkToDo = new LinkedList<string>();
        }

        public DummyWorker(string DummyWorkToDo)
        {
            DummyIsAlive = true;
            DummyIsWorking = false;
            DummyNeedsHelp = false;
            DummyListWorkToDo = new LinkedList<string>();
            DummyListWorkToDo.AddFirst(DummyWorkToDo);
        }

        public void AddWork(string WorkToDo)
        {
            DummyListWorkToDo.AddLast(WorkToDo);
        }

        public Workload GetOverload()
        {
            return new Workload();
        }

        public Workload GetWorkload()
        {
            return new Workload(DummyListWorkToDo);
        }

        public bool IsAlive()
        {
            return DummyIsAlive;
        }

        public bool IsWorking()
        {
            return DummyIsWorking;
        }

        public bool NeedsHelp()
        {
            return DummyNeedsHelp;
        }

        public void StartWorking()
        {
            DummyIsWorking = true;
        }

        public void StopWorking()
        {
            DummyIsWorking = false;
        }

        public Workload GetAllPossibleWorkload()
        {
            throw new NotImplementedException();
        }

        public void RemoveWork(string WorkToAbandon)
        {
            throw new NotImplementedException();
        }
    }
}
