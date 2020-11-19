namespace ServerAdministrationPlatform
{
    partial class CreateWorkerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbWorkerType = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtWorkerType = new System.Windows.Forms.TextBox();
            this.lblWorkerType = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.cbWorkerType = new System.Windows.Forms.ComboBox();
            this.gbWorkload = new System.Windows.Forms.GroupBox();
            this.tvWorkerWorkload = new System.Windows.Forms.TreeView();
            this.tvAvailableWorkload = new System.Windows.Forms.TreeView();
            this.btnUnassignAllWorkload = new System.Windows.Forms.Button();
            this.btnAssignAllWorkload = new System.Windows.Forms.Button();
            this.btnUnassignWorkload = new System.Windows.Forms.Button();
            this.btnAssignWorkload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbWorkerType.SuspendLayout();
            this.gbWorkload.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWorkerType
            // 
            this.gbWorkerType.Controls.Add(this.txtName);
            this.gbWorkerType.Controls.Add(this.label3);
            this.gbWorkerType.Controls.Add(this.btnConnect);
            this.gbWorkerType.Controls.Add(this.txtWorkerType);
            this.gbWorkerType.Controls.Add(this.lblWorkerType);
            this.gbWorkerType.Controls.Add(this.txtIP);
            this.gbWorkerType.Controls.Add(this.lblIP);
            this.gbWorkerType.Controls.Add(this.cbWorkerType);
            this.gbWorkerType.Location = new System.Drawing.Point(12, 12);
            this.gbWorkerType.Name = "gbWorkerType";
            this.gbWorkerType.Size = new System.Drawing.Size(596, 74);
            this.gbWorkerType.TabIndex = 0;
            this.gbWorkerType.TabStop = false;
            this.gbWorkerType.Text = "Worker Type";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(492, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtWorkerType
            // 
            this.txtWorkerType.Location = new System.Drawing.Point(226, 19);
            this.txtWorkerType.Name = "txtWorkerType";
            this.txtWorkerType.ReadOnly = true;
            this.txtWorkerType.Size = new System.Drawing.Size(114, 20);
            this.txtWorkerType.TabIndex = 3;
            // 
            // lblWorkerType
            // 
            this.lblWorkerType.AutoSize = true;
            this.lblWorkerType.Location = new System.Drawing.Point(180, 22);
            this.lblWorkerType.Name = "lblWorkerType";
            this.lblWorkerType.Size = new System.Drawing.Size(34, 13);
            this.lblWorkerType.TabIndex = 4;
            this.lblWorkerType.Text = "Type:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(372, 19);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(114, 20);
            this.txtIP.TabIndex = 2;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(346, 22);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 13);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "IP:";
            // 
            // cbWorkerType
            // 
            this.cbWorkerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkerType.FormattingEnabled = true;
            this.cbWorkerType.Items.AddRange(new object[] {
            "Local Worker",
            "Remote Worker",
            "4Chan Local Worker",
            "4Chan Remote Worker"});
            this.cbWorkerType.Location = new System.Drawing.Point(6, 19);
            this.cbWorkerType.Name = "cbWorkerType";
            this.cbWorkerType.Size = new System.Drawing.Size(159, 21);
            this.cbWorkerType.TabIndex = 1;
            this.cbWorkerType.SelectedIndexChanged += new System.EventHandler(this.cbWorkerType_SelectedIndexChanged);
            // 
            // gbWorkload
            // 
            this.gbWorkload.Controls.Add(this.tvWorkerWorkload);
            this.gbWorkload.Controls.Add(this.tvAvailableWorkload);
            this.gbWorkload.Controls.Add(this.btnUnassignAllWorkload);
            this.gbWorkload.Controls.Add(this.btnAssignAllWorkload);
            this.gbWorkload.Controls.Add(this.btnUnassignWorkload);
            this.gbWorkload.Controls.Add(this.btnAssignWorkload);
            this.gbWorkload.Controls.Add(this.label2);
            this.gbWorkload.Controls.Add(this.label1);
            this.gbWorkload.Location = new System.Drawing.Point(12, 92);
            this.gbWorkload.Name = "gbWorkload";
            this.gbWorkload.Size = new System.Drawing.Size(492, 270);
            this.gbWorkload.TabIndex = 1;
            this.gbWorkload.TabStop = false;
            this.gbWorkload.Text = "Workload";
            // 
            // tvWorkerWorkload
            // 
            this.tvWorkerWorkload.Location = new System.Drawing.Point(6, 43);
            this.tvWorkerWorkload.Name = "tvWorkerWorkload";
            this.tvWorkerWorkload.Size = new System.Drawing.Size(200, 214);
            this.tvWorkerWorkload.TabIndex = 8;
            // 
            // tvAvailableWorkload
            // 
            this.tvAvailableWorkload.Location = new System.Drawing.Point(286, 43);
            this.tvAvailableWorkload.Name = "tvAvailableWorkload";
            this.tvAvailableWorkload.Size = new System.Drawing.Size(200, 214);
            this.tvAvailableWorkload.TabIndex = 2;
            // 
            // btnUnassignAllWorkload
            // 
            this.btnUnassignAllWorkload.Location = new System.Drawing.Point(215, 218);
            this.btnUnassignAllWorkload.Name = "btnUnassignAllWorkload";
            this.btnUnassignAllWorkload.Size = new System.Drawing.Size(65, 39);
            this.btnUnassignAllWorkload.TabIndex = 7;
            this.btnUnassignAllWorkload.Text = "Unassign All";
            this.btnUnassignAllWorkload.UseVisualStyleBackColor = true;
            this.btnUnassignAllWorkload.Click += new System.EventHandler(this.btnUnassignAllWorkload_Click);
            // 
            // btnAssignAllWorkload
            // 
            this.btnAssignAllWorkload.Location = new System.Drawing.Point(215, 173);
            this.btnAssignAllWorkload.Name = "btnAssignAllWorkload";
            this.btnAssignAllWorkload.Size = new System.Drawing.Size(65, 39);
            this.btnAssignAllWorkload.TabIndex = 6;
            this.btnAssignAllWorkload.Text = "Assign All";
            this.btnAssignAllWorkload.UseVisualStyleBackColor = true;
            this.btnAssignAllWorkload.Click += new System.EventHandler(this.btnAssignAllWorkload_Click);
            // 
            // btnUnassignWorkload
            // 
            this.btnUnassignWorkload.Location = new System.Drawing.Point(215, 90);
            this.btnUnassignWorkload.Name = "btnUnassignWorkload";
            this.btnUnassignWorkload.Size = new System.Drawing.Size(65, 23);
            this.btnUnassignWorkload.TabIndex = 5;
            this.btnUnassignWorkload.Text = "Unassign";
            this.btnUnassignWorkload.UseVisualStyleBackColor = true;
            this.btnUnassignWorkload.Click += new System.EventHandler(this.btnUnassignWorkload_Click);
            // 
            // btnAssignWorkload
            // 
            this.btnAssignWorkload.Location = new System.Drawing.Point(215, 61);
            this.btnAssignWorkload.Name = "btnAssignWorkload";
            this.btnAssignWorkload.Size = new System.Drawing.Size(65, 23);
            this.btnAssignWorkload.TabIndex = 4;
            this.btnAssignWorkload.Text = "Assign";
            this.btnAssignWorkload.UseVisualStyleBackColor = true;
            this.btnAssignWorkload.Click += new System.EventHandler(this.btnAssignWorkload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available Workload";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Worker Workload";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 6;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name:";
            // 
            // CreateWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 370);
            this.Controls.Add(this.gbWorkload);
            this.Controls.Add(this.gbWorkerType);
            this.Name = "CreateWorkerForm";
            this.Text = "Create Worker Form";
            this.gbWorkerType.ResumeLayout(false);
            this.gbWorkerType.PerformLayout();
            this.gbWorkload.ResumeLayout(false);
            this.gbWorkload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWorkerType;
        private System.Windows.Forms.ComboBox cbWorkerType;
        private System.Windows.Forms.GroupBox gbWorkload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnassignWorkload;
        private System.Windows.Forms.Button btnAssignWorkload;
        private System.Windows.Forms.Button btnUnassignAllWorkload;
        private System.Windows.Forms.Button btnAssignAllWorkload;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtWorkerType;
        private System.Windows.Forms.Label lblWorkerType;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TreeView tvAvailableWorkload;
        private System.Windows.Forms.TreeView tvWorkerWorkload;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
    }
}