using System.Runtime.Serialization;

namespace Core
{
    /// <summary>
    /// Workers are used as an interface to a client that actually do something.
    /// It's only used by the server to keep track of what the clients are doing to manage them properly.
    /// </summary>
    public interface Worker
    {
        string WorkerType { get; }

        string Name { get; set; }

        void AddWork(string WorkToDo);

        void RemoveWork(string WorkToAbandon);

        Workload GetOverload();

        Workload GetWorkload();

        bool IsAlive();

        bool IsWorking();

        bool NeedsHelp();

        void StartWorking();

        void StopWorking();

        Workload GetAllPossibleWorkload();
    }
}