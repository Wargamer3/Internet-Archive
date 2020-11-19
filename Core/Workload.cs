using System;
using System.Collections.Generic;

namespace Core
{
    public class Workload
    {
        public bool HasWorkToDo { get { return ListWorkToDo.Count > 0; } }

        private LinkedList<string> ListWorkToDo;

        public Workload()
        {
            ListWorkToDo = new LinkedList<string>();
        }

        public Workload(LinkedList<string> ListWorkToDo)
        {
            this.ListWorkToDo = ListWorkToDo;
        }

        public string PullWork()
        {
            string WorkToDo = ListWorkToDo.First.Value;
            ListWorkToDo.RemoveFirst();
            return WorkToDo;
        }

        public List<string> PeekAtWorkload()
        {
            List<string> ListWork = new List<string>();

            LinkedListNode<string> ActiveNode = ListWorkToDo.First;
            while (ActiveNode != null)
            {
                string ActiveWorker = ActiveNode.Value;
                LinkedListNode<string> NextNode = ActiveNode.Next;

                ListWork.Add(ActiveWorker);

                ActiveNode = NextNode;
            }

            return ListWork;
        }
    }
}
