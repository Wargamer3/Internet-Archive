namespace ServerAdministrationPlatform
{
    partial class AdministrationPlatform
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.gbWorkersInformation = new System.Windows.Forms.GroupBox();
            this.lblDeadWorkers = new System.Windows.Forms.Label();
            this.lvDeadWorkers = new System.Windows.Forms.ListView();
            this.lblIdleWorkers = new System.Windows.Forms.Label();
            this.lvIdleWorkers = new System.Windows.Forms.ListView();
            this.lblAliveWorkers = new System.Windows.Forms.Label();
            this.lvAliveWorkers = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangeWorkerWorload = new System.Windows.Forms.Button();
            this.btnChangeMaximumWorkerLimit = new System.Windows.Forms.Button();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.gbWorkerInformation = new System.Windows.Forms.GroupBox();
            this.lblWorkload = new System.Windows.Forms.Label();
            this.lvWorkload = new System.Windows.Forms.ListView();
            this.txtMaxRAM = new System.Windows.Forms.TextBox();
            this.lblMaxRAM = new System.Windows.Forms.Label();
            this.txtRAMUsed = new System.Windows.Forms.TextBox();
            this.lblRAMUsed = new System.Windows.Forms.Label();
            this.txtCPUUsage = new System.Windows.Forms.TextBox();
            this.lblCPUUsage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbWorkersInformation.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbWorkerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadConfig);
            this.groupBox1.Controls.Add(this.btnStopServer);
            this.groupBox1.Controls.Add(this.btnStartServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server lifecycle";
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(168, 19);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 3;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(87, 19);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 2;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(6, 19);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // gbWorkersInformation
            // 
            this.gbWorkersInformation.Controls.Add(this.lblDeadWorkers);
            this.gbWorkersInformation.Controls.Add(this.lvDeadWorkers);
            this.gbWorkersInformation.Controls.Add(this.lblIdleWorkers);
            this.gbWorkersInformation.Controls.Add(this.lvIdleWorkers);
            this.gbWorkersInformation.Controls.Add(this.lblAliveWorkers);
            this.gbWorkersInformation.Controls.Add(this.lvAliveWorkers);
            this.gbWorkersInformation.Location = new System.Drawing.Point(12, 70);
            this.gbWorkersInformation.Name = "gbWorkersInformation";
            this.gbWorkersInformation.Size = new System.Drawing.Size(426, 179);
            this.gbWorkersInformation.TabIndex = 1;
            this.gbWorkersInformation.TabStop = false;
            this.gbWorkersInformation.Text = "Workers information";
            // 
            // lblDeadWorkers
            // 
            this.lblDeadWorkers.AutoSize = true;
            this.lblDeadWorkers.Location = new System.Drawing.Point(286, 23);
            this.lblDeadWorkers.Name = "lblDeadWorkers";
            this.lblDeadWorkers.Size = new System.Drawing.Size(76, 13);
            this.lblDeadWorkers.TabIndex = 5;
            this.lblDeadWorkers.Text = "Dead Workers";
            // 
            // lvDeadWorkers
            // 
            this.lvDeadWorkers.HideSelection = false;
            this.lvDeadWorkers.Location = new System.Drawing.Point(286, 39);
            this.lvDeadWorkers.Name = "lvDeadWorkers";
            this.lvDeadWorkers.Size = new System.Drawing.Size(134, 134);
            this.lvDeadWorkers.TabIndex = 4;
            this.lvDeadWorkers.UseCompatibleStateImageBehavior = false;
            this.lvDeadWorkers.SelectedIndexChanged += new System.EventHandler(this.lvDeadWorkers_SelectedIndexChanged);
            // 
            // lblIdleWorkers
            // 
            this.lblIdleWorkers.AutoSize = true;
            this.lblIdleWorkers.Location = new System.Drawing.Point(146, 23);
            this.lblIdleWorkers.Name = "lblIdleWorkers";
            this.lblIdleWorkers.Size = new System.Drawing.Size(67, 13);
            this.lblIdleWorkers.TabIndex = 3;
            this.lblIdleWorkers.Text = "Idle Workers";
            // 
            // lvIdleWorkers
            // 
            this.lvIdleWorkers.HideSelection = false;
            this.lvIdleWorkers.Location = new System.Drawing.Point(146, 39);
            this.lvIdleWorkers.Name = "lvIdleWorkers";
            this.lvIdleWorkers.Size = new System.Drawing.Size(134, 134);
            this.lvIdleWorkers.TabIndex = 2;
            this.lvIdleWorkers.UseCompatibleStateImageBehavior = false;
            this.lvIdleWorkers.SelectedIndexChanged += new System.EventHandler(this.lvIdleWorkers_SelectedIndexChanged);
            // 
            // lblAliveWorkers
            // 
            this.lblAliveWorkers.AutoSize = true;
            this.lblAliveWorkers.Location = new System.Drawing.Point(6, 23);
            this.lblAliveWorkers.Name = "lblAliveWorkers";
            this.lblAliveWorkers.Size = new System.Drawing.Size(73, 13);
            this.lblAliveWorkers.TabIndex = 1;
            this.lblAliveWorkers.Text = "Alive Workers";
            // 
            // lvAliveWorkers
            // 
            this.lvAliveWorkers.HideSelection = false;
            this.lvAliveWorkers.Location = new System.Drawing.Point(6, 39);
            this.lvAliveWorkers.Name = "lvAliveWorkers";
            this.lvAliveWorkers.Size = new System.Drawing.Size(134, 134);
            this.lvAliveWorkers.TabIndex = 0;
            this.lvAliveWorkers.UseCompatibleStateImageBehavior = false;
            this.lvAliveWorkers.View = System.Windows.Forms.View.List;
            this.lvAliveWorkers.SelectedIndexChanged += new System.EventHandler(this.lvAliveWorkers_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangeWorkerWorload);
            this.groupBox3.Controls.Add(this.btnChangeMaximumWorkerLimit);
            this.groupBox3.Controls.Add(this.btnAddWorker);
            this.groupBox3.Location = new System.Drawing.Point(12, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 157);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Workers Management";
            // 
            // btnChangeWorkerWorload
            // 
            this.btnChangeWorkerWorload.Location = new System.Drawing.Point(90, 19);
            this.btnChangeWorkerWorload.Name = "btnChangeWorkerWorload";
            this.btnChangeWorkerWorload.Size = new System.Drawing.Size(175, 23);
            this.btnChangeWorkerWorload.TabIndex = 5;
            this.btnChangeWorkerWorload.Text = "Change worker Worload";
            this.btnChangeWorkerWorload.UseVisualStyleBackColor = true;
            this.btnChangeWorkerWorload.Click += new System.EventHandler(this.btnChangeWorkerWorload_Click);
            // 
            // btnChangeMaximumWorkerLimit
            // 
            this.btnChangeMaximumWorkerLimit.Location = new System.Drawing.Point(9, 48);
            this.btnChangeMaximumWorkerLimit.Name = "btnChangeMaximumWorkerLimit";
            this.btnChangeMaximumWorkerLimit.Size = new System.Drawing.Size(175, 23);
            this.btnChangeMaximumWorkerLimit.TabIndex = 4;
            this.btnChangeMaximumWorkerLimit.Text = "Change maximum worker limit";
            this.btnChangeMaximumWorkerLimit.UseVisualStyleBackColor = true;
            this.btnChangeMaximumWorkerLimit.Click += new System.EventHandler(this.btnChangeMaximumWorkerLimit_Click);
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Location = new System.Drawing.Point(9, 19);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(75, 23);
            this.btnAddWorker.TabIndex = 3;
            this.btnAddWorker.Text = "Add Worker";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // gbWorkerInformation
            // 
            this.gbWorkerInformation.Controls.Add(this.lblWorkload);
            this.gbWorkerInformation.Controls.Add(this.lvWorkload);
            this.gbWorkerInformation.Controls.Add(this.txtMaxRAM);
            this.gbWorkerInformation.Controls.Add(this.lblMaxRAM);
            this.gbWorkerInformation.Controls.Add(this.txtRAMUsed);
            this.gbWorkerInformation.Controls.Add(this.lblRAMUsed);
            this.gbWorkerInformation.Controls.Add(this.txtCPUUsage);
            this.gbWorkerInformation.Controls.Add(this.lblCPUUsage);
            this.gbWorkerInformation.Location = new System.Drawing.Point(444, 70);
            this.gbWorkerInformation.Name = "gbWorkerInformation";
            this.gbWorkerInformation.Size = new System.Drawing.Size(197, 342);
            this.gbWorkerInformation.TabIndex = 3;
            this.gbWorkerInformation.TabStop = false;
            this.gbWorkerInformation.Text = "Worker Information";
            // 
            // lblWorkload
            // 
            this.lblWorkload.AutoSize = true;
            this.lblWorkload.Location = new System.Drawing.Point(6, 109);
            this.lblWorkload.Name = "lblWorkload";
            this.lblWorkload.Size = new System.Drawing.Size(53, 13);
            this.lblWorkload.TabIndex = 7;
            this.lblWorkload.Text = "Workload";
            // 
            // lvWorkload
            // 
            this.lvWorkload.HideSelection = false;
            this.lvWorkload.Location = new System.Drawing.Point(6, 125);
            this.lvWorkload.Name = "lvWorkload";
            this.lvWorkload.Size = new System.Drawing.Size(185, 211);
            this.lvWorkload.TabIndex = 6;
            this.lvWorkload.UseCompatibleStateImageBehavior = false;
            this.lvWorkload.View = System.Windows.Forms.View.List;
            // 
            // txtMaxRAM
            // 
            this.txtMaxRAM.Location = new System.Drawing.Point(125, 72);
            this.txtMaxRAM.Name = "txtMaxRAM";
            this.txtMaxRAM.ReadOnly = true;
            this.txtMaxRAM.Size = new System.Drawing.Size(66, 20);
            this.txtMaxRAM.TabIndex = 7;
            // 
            // lblMaxRAM
            // 
            this.lblMaxRAM.AutoSize = true;
            this.lblMaxRAM.Location = new System.Drawing.Point(6, 75);
            this.lblMaxRAM.Name = "lblMaxRAM";
            this.lblMaxRAM.Size = new System.Drawing.Size(54, 13);
            this.lblMaxRAM.TabIndex = 6;
            this.lblMaxRAM.Text = "Max RAM";
            // 
            // txtRAMUsed
            // 
            this.txtRAMUsed.Location = new System.Drawing.Point(125, 46);
            this.txtRAMUsed.Name = "txtRAMUsed";
            this.txtRAMUsed.ReadOnly = true;
            this.txtRAMUsed.Size = new System.Drawing.Size(66, 20);
            this.txtRAMUsed.TabIndex = 5;
            // 
            // lblRAMUsed
            // 
            this.lblRAMUsed.AutoSize = true;
            this.lblRAMUsed.Location = new System.Drawing.Point(6, 49);
            this.lblRAMUsed.Name = "lblRAMUsed";
            this.lblRAMUsed.Size = new System.Drawing.Size(57, 13);
            this.lblRAMUsed.TabIndex = 4;
            this.lblRAMUsed.Text = "RAM used";
            // 
            // txtCPUUsage
            // 
            this.txtCPUUsage.Location = new System.Drawing.Point(125, 20);
            this.txtCPUUsage.Name = "txtCPUUsage";
            this.txtCPUUsage.ReadOnly = true;
            this.txtCPUUsage.Size = new System.Drawing.Size(66, 20);
            this.txtCPUUsage.TabIndex = 3;
            // 
            // lblCPUUsage
            // 
            this.lblCPUUsage.AutoSize = true;
            this.lblCPUUsage.Location = new System.Drawing.Point(6, 23);
            this.lblCPUUsage.Name = "lblCPUUsage";
            this.lblCPUUsage.Size = new System.Drawing.Size(61, 13);
            this.lblCPUUsage.TabIndex = 2;
            this.lblCPUUsage.Text = "CPU usage";
            // 
            // AdministrationPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 422);
            this.Controls.Add(this.gbWorkerInformation);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbWorkersInformation);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdministrationPlatform";
            this.Text = "Administration Platform";
            this.groupBox1.ResumeLayout(false);
            this.gbWorkersInformation.ResumeLayout(false);
            this.gbWorkersInformation.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbWorkerInformation.ResumeLayout(false);
            this.gbWorkerInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.GroupBox gbWorkersInformation;
        private System.Windows.Forms.Label lblAliveWorkers;
        private System.Windows.Forms.ListView lvAliveWorkers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDeadWorkers;
        private System.Windows.Forms.ListView lvDeadWorkers;
        private System.Windows.Forms.Label lblIdleWorkers;
        private System.Windows.Forms.ListView lvIdleWorkers;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.GroupBox gbWorkerInformation;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Button btnChangeMaximumWorkerLimit;
        private System.Windows.Forms.Label lblCPUUsage;
        private System.Windows.Forms.TextBox txtCPUUsage;
        private System.Windows.Forms.TextBox txtMaxRAM;
        private System.Windows.Forms.Label lblMaxRAM;
        private System.Windows.Forms.TextBox txtRAMUsed;
        private System.Windows.Forms.Label lblRAMUsed;
        private System.Windows.Forms.Label lblWorkload;
        private System.Windows.Forms.ListView lvWorkload;
        private System.Windows.Forms.Button btnChangeWorkerWorload;
    }
}

