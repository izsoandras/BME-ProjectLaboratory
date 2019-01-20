namespace RoboPro
{
    partial class robotClientForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pbCameraView = new System.Windows.Forms.PictureBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnWSSend = new System.Windows.Forms.Button();
            this.tbWSSend = new System.Windows.Forms.TextBox();
            this.labelWSSend = new System.Windows.Forms.Label();
            this.labelWSAddress = new System.Windows.Forms.Label();
            this.btnWSConnect = new System.Windows.Forms.Button();
            this.tbWSAddress = new System.Windows.Forms.TextBox();
            this.labelCamAddress = new System.Windows.Forms.Label();
            this.tbCamAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnWSSend);
            this.splitContainer1.Panel2.Controls.Add(this.tbWSSend);
            this.splitContainer1.Panel2.Controls.Add(this.labelWSSend);
            this.splitContainer1.Panel2.Controls.Add(this.labelWSAddress);
            this.splitContainer1.Panel2.Controls.Add(this.btnWSConnect);
            this.splitContainer1.Panel2.Controls.Add(this.tbWSAddress);
            this.splitContainer1.Panel2.Controls.Add(this.labelCamAddress);
            this.splitContainer1.Panel2.Controls.Add(this.tbCamAddress);
            this.splitContainer1.Panel2.Controls.Add(this.btnConnect);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 598;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pbCameraView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbConsole);
            this.splitContainer2.Size = new System.Drawing.Size(598, 450);
            this.splitContainer2.SplitterDistance = 319;
            this.splitContainer2.TabIndex = 1;
            // 
            // pbCameraView
            // 
            this.pbCameraView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCameraView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCameraView.Location = new System.Drawing.Point(12, 12);
            this.pbCameraView.Name = "pbCameraView";
            this.pbCameraView.Size = new System.Drawing.Size(579, 300);
            this.pbCameraView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCameraView.TabIndex = 1;
            this.pbCameraView.TabStop = false;
            // 
            // tbConsole
            // 
            this.tbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConsole.Location = new System.Drawing.Point(12, 3);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(579, 108);
            this.tbConsole.TabIndex = 0;
            // 
            // btnWSSend
            // 
            this.btnWSSend.Enabled = false;
            this.btnWSSend.Location = new System.Drawing.Point(116, 208);
            this.btnWSSend.Name = "btnWSSend";
            this.btnWSSend.Size = new System.Drawing.Size(75, 23);
            this.btnWSSend.TabIndex = 9;
            this.btnWSSend.Text = "Send";
            this.btnWSSend.UseVisualStyleBackColor = true;
            this.btnWSSend.Click += new System.EventHandler(this.btnWSSend_Click);
            // 
            // tbWSSend
            // 
            this.tbWSSend.Enabled = false;
            this.tbWSSend.Location = new System.Drawing.Point(6, 182);
            this.tbWSSend.Name = "tbWSSend";
            this.tbWSSend.Size = new System.Drawing.Size(185, 20);
            this.tbWSSend.TabIndex = 8;
            // 
            // labelWSSend
            // 
            this.labelWSSend.AutoSize = true;
            this.labelWSSend.Location = new System.Drawing.Point(3, 166);
            this.labelWSSend.Name = "labelWSSend";
            this.labelWSSend.Size = new System.Drawing.Size(140, 13);
            this.labelWSSend.TabIndex = 7;
            this.labelWSSend.Text = "Send WebSocket message:";
            // 
            // labelWSAddress
            // 
            this.labelWSAddress.AutoSize = true;
            this.labelWSAddress.Location = new System.Drawing.Point(3, 88);
            this.labelWSAddress.Name = "labelWSAddress";
            this.labelWSAddress.Size = new System.Drawing.Size(95, 13);
            this.labelWSAddress.TabIndex = 6;
            this.labelWSAddress.Text = "Web Socket URL:";
            // 
            // btnWSConnect
            // 
            this.btnWSConnect.Location = new System.Drawing.Point(116, 130);
            this.btnWSConnect.Name = "btnWSConnect";
            this.btnWSConnect.Size = new System.Drawing.Size(75, 23);
            this.btnWSConnect.TabIndex = 5;
            this.btnWSConnect.Text = "Connect";
            this.btnWSConnect.UseVisualStyleBackColor = true;
            this.btnWSConnect.Click += new System.EventHandler(this.btnWSConnect_Click);
            // 
            // tbWSAddress
            // 
            this.tbWSAddress.Location = new System.Drawing.Point(6, 104);
            this.tbWSAddress.Name = "tbWSAddress";
            this.tbWSAddress.Size = new System.Drawing.Size(185, 20);
            this.tbWSAddress.TabIndex = 4;
            this.tbWSAddress.Text = "ws://";
            // 
            // labelCamAddress
            // 
            this.labelCamAddress.AutoSize = true;
            this.labelCamAddress.Location = new System.Drawing.Point(3, 7);
            this.labelCamAddress.Name = "labelCamAddress";
            this.labelCamAddress.Size = new System.Drawing.Size(68, 13);
            this.labelCamAddress.TabIndex = 3;
            this.labelCamAddress.Text = "Stream URL:";
            // 
            // tbCamAddress
            // 
            this.tbCamAddress.Location = new System.Drawing.Point(3, 23);
            this.tbCamAddress.Name = "tbCamAddress";
            this.tbCamAddress.Size = new System.Drawing.Size(188, 20);
            this.tbCamAddress.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 49);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // robotClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "robotClientForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.robotClientForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.robotClientForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.robotClientForm_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbCameraView;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label labelCamAddress;
        private System.Windows.Forms.TextBox tbCamAddress;
        private System.Windows.Forms.Label labelWSAddress;
        private System.Windows.Forms.Button btnWSConnect;
        private System.Windows.Forms.TextBox tbWSAddress;
        private System.Windows.Forms.Button btnWSSend;
        private System.Windows.Forms.TextBox tbWSSend;
        private System.Windows.Forms.Label labelWSSend;
    }
}

