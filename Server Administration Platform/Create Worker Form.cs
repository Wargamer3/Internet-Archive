using Core;
using Server;
using System;
using System.Windows.Forms;

namespace ServerAdministrationPlatform
{
    public partial class CreateWorkerForm : Form
    {
        private readonly WorkBalancer Server;
        private readonly Worker[] ArrayWorkerChoice;
        private Worker ActiveWorker;

        public CreateWorkerForm(WorkBalancer Server)
        {
            InitializeComponent();

            this.Server = Server;
            gbWorkload.Enabled = false;
            txtName.Enabled = false;

            ActiveWorker = null;
            ArrayWorkerChoice = new Worker[4];
            ArrayWorkerChoice[0] = new LocalChanWorker();
            ArrayWorkerChoice[1] = new RemoteChanWorker();
            ArrayWorkerChoice[2] = new LocalChanWorker();
            ArrayWorkerChoice[3] = new RemoteChanWorker();
            //ArrayWorkerChoice[4] = new LocalImageDownloaderWorker();
            //ArrayWorkerChoice[5] = new RemoteImageDownloaderWorker();
            //ArrayWorkerChoice[6] = new LocalLuceneWorker();
            //ArrayWorkerChoice[7] = new RemoteLuceneWorker();
        }

        private void cbWorkerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            txtName.Enabled = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ArrayWorkerChoice[cbWorkerType.SelectedIndex].Name = txtName.Text;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            gbWorkload.Enabled = true;

            ActiveWorker = ArrayWorkerChoice[cbWorkerType.SelectedIndex];

            Workload AllWorkload = ActiveWorker.GetAllPossibleWorkload();
            while (AllWorkload.HasWorkToDo)
            {
                string Work = AllWorkload.PullWork();
                tvAvailableWorkload.Nodes.Add(Work);
            }

            Server.AddWorker(ActiveWorker);

            if (Server.IsWorking)
            {
                ActiveWorker.StartWorking();
            }
        }

        private void btnAssignWorkload_Click(object sender, EventArgs e)
        {
            if (tvAvailableWorkload.SelectedNode != null)
            {
                string Work = tvAvailableWorkload.SelectedNode.Text;

                ActiveWorker.AddWork(Work);

                tvWorkerWorkload.Nodes.Add(Work);
                tvAvailableWorkload.SelectedNode.Remove();
            }
        }

        private void btnUnassignWorkload_Click(object sender, EventArgs e)
        {
            if (tvWorkerWorkload.SelectedNode != null)
            {
                string Work = tvWorkerWorkload.SelectedNode.Text;

                ActiveWorker.RemoveWork(Work);

                tvAvailableWorkload.Nodes.Add(Work);
                tvWorkerWorkload.SelectedNode.Remove();
            }
        }

        private void btnAssignAllWorkload_Click(object sender, EventArgs e)
        {

        }

        private void btnUnassignAllWorkload_Click(object sender, EventArgs e)
        {

        }
    }
}
