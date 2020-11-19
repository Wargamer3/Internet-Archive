using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Hayden.Tests
{
    public class WorkBlancerTests
    {
        [Fact]
        void GivenAWorkBalancer_WhenItStartWorking_ThenTheWorkersAreWorking()
        {
            List<DummyWorker> ListWorker = new List<DummyWorker>();
            ListWorker.Add(new DummyWorker());

            Server.WorkBalancer TestWorkBalancer = new Server.WorkBalancer(ListWorker.ToArray());
            TestWorkBalancer.StartWorking();
            Assert.True(ListWorker[0].DummyIsWorking);
            Assert.True(ListWorker[0].IsWorking());
            TestWorkBalancer.StopWorking();
            Assert.False(ListWorker[0].DummyIsWorking);
            Assert.False(ListWorker[0].IsWorking());
        }

        [Fact]
        void GivenAWorkingWorkBalancer_WhenItStopWorking_ThenTheWorkersAreNotWorking()
        {
            List<DummyWorker> ListWorker = new List<DummyWorker>();
            ListWorker.Add(new DummyWorker());

            Server.WorkBalancer TestWorkBalancer = new Server.WorkBalancer(ListWorker.ToArray());
            TestWorkBalancer.StartWorking();
            TestWorkBalancer.StopWorking();
            Assert.False(ListWorker[0].DummyIsWorking);
            Assert.False(ListWorker[0].IsWorking());
        }

        [Fact]
        void GivenAWorkingWorkBalancerWithNoIdleWorkers_WhenAWorkerDies_ThenTheRemaining4KeepWorking()
        {
            List<DummyWorker> ListWorker = new List<DummyWorker>();
            for (int W = 0; W < 5; W++)
            {
                ListWorker.Add(new DummyWorker());
            }

            Server.WorkBalancer TestWorkBalancer = new Server.WorkBalancer(ListWorker.ToArray());
            Assert.Equal(5, TestWorkBalancer.ActiveWorkersCount);
            Assert.Equal(0, TestWorkBalancer.IdleWorkersCount);
            TestWorkBalancer.StartWorking();
            ListWorker[0].DummyIsAlive = false;
            while (TestWorkBalancer.DeadWorkersCount == 0) ;
            Assert.Equal(4, TestWorkBalancer.ActiveWorkersCount);
            Assert.Equal(0, TestWorkBalancer.IdleWorkersCount);
            Assert.Equal(1, TestWorkBalancer.DeadWorkersCount);
        }

        [Fact]
        void GivenAWorkingWorkBalancerWithIdleWorkers_WhenAWorkerDies_ThenAnotherWorkerTakesItsPlace()
        {
            List<DummyWorker> ListWorker = new List<DummyWorker>();
            for (int W = 0; W < 15; W++)
            {
                ListWorker.Add(new DummyWorker());
            }

            Server.WorkBalancer TestWorkBalancer = new Server.WorkBalancer(ListWorker.ToArray());
            Assert.Equal(10, TestWorkBalancer.ActiveWorkersCount);
            Assert.Equal(5, TestWorkBalancer.IdleWorkersCount);
            TestWorkBalancer.StartWorking();
            ListWorker[0].DummyIsAlive = false;
            while (TestWorkBalancer.IdleWorkersCount == 5) ;
            Assert.Equal(10, TestWorkBalancer.ActiveWorkersCount);
            Assert.Equal(4, TestWorkBalancer.IdleWorkersCount);
            Assert.Equal(1, TestWorkBalancer.DeadWorkersCount);
        }

        [Fact]
        void GivenAWorkingWorkBalancerWithIdleWorkers_WhenAWorkerDies_ThenItsWorkIsShared()
        {
            List<DummyWorker> ListWorker = new List<DummyWorker>();
            for (int W = 0; W < 2; W++)
            {
                ListWorker.Add(new DummyWorker("Dummy work"));
            }

            Server.WorkBalancer TestWorkBalancer = new Server.WorkBalancer(ListWorker.ToArray());
            TestWorkBalancer.StartWorking();
            ListWorker[0].DummyIsAlive = false;
            while (ListWorker[1].DummyListWorkToDo.Count == 1) ;
            Assert.Equal(2, ListWorker[1].DummyListWorkToDo.Count);
        }
    }
}
