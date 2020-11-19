using Core;
using Server;
using System;
using System.Windows.Forms;

namespace ServerAdministrationPlatform
{
    public partial class AdministrationPlatform : Form
    {
        private WorkBalancer Server;

        public AdministrationPlatform()
        {
            InitializeComponent();

            Server = new WorkBalancer();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Server.StartWorking();
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            Server.StopWorking();
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void lvAliveWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAliveWorkers.SelectedItems.Count > 0)
            {
                Worker ActiveWorker = (Worker)lvAliveWorkers.SelectedItems[0].Tag;

                lvWorkload.Items.Clear();

                foreach (string ActiveWork in ActiveWorker.GetWorkload().PeekAtWorkload())
                {
                    lvWorkload.Items.Add(ActiveWork);
                }
            }
        }

        private void lvIdleWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvDeadWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            CreateWorkerForm NewWorkerForm = new CreateWorkerForm(Server);
            NewWorkerForm.ShowDialog();

            RefreshWorkerLists();
        }

        private void btnChangeWorkerWorload_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeMaximumWorkerLimit_Click(object sender, EventArgs e)
        {

        }

        private void RefreshWorkerLists()
        {
            lvAliveWorkers.Items.Clear();
            lvIdleWorkers.Items.Clear();
            lvDeadWorkers.Items.Clear();

            foreach (Worker ActiveWorker in Server.GetActiveWorkers())
            {
                ListViewItem NewListViewItem = new ListViewItem(ActiveWorker.Name);
                NewListViewItem.Tag = ActiveWorker;
                lvAliveWorkers.Items.Add(NewListViewItem);
            }

            foreach (Worker ActiveWorker in Server.GetIdleWorkers())
            {
                ListViewItem NewListViewItem = new ListViewItem(ActiveWorker.Name);
                NewListViewItem.Tag = ActiveWorker;
                lvIdleWorkers.Items.Add(NewListViewItem);
            }

            foreach (Worker ActiveWorker in Server.GetDeadWorkers())
            {
                ListViewItem NewListViewItem = new ListViewItem(ActiveWorker.Name);
                NewListViewItem.Tag = ActiveWorker;
                lvDeadWorkers.Items.Add(NewListViewItem);
            }
        }
    }
}
