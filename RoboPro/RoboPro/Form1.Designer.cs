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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbCamAddress = new System.Windows.Forms.TextBox();
            this.labelCamAddress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWSSend = new System.Windows.Forms.Button();
            this.tbWSSend = new System.Windows.Forms.TextBox();
            this.labelWSAddress = new System.Windows.Forms.Label();
            this.labelWSSend = new System.Windows.Forms.Label();
            this.tbWSAddress = new System.Windows.Forms.TextBox();
            this.btnWSConnect = new System.Windows.Forms.Button();
            this.pSerial = new System.Windows.Forms.Panel();
            this.btnSerialOpen = new System.Windows.Forms.Button();
            this.tbCOMport = new System.Windows.Forms.TextBox();
            this.labelCOMport = new System.Windows.Forms.Label();
            this.labelSerialSend = new System.Windows.Forms.Label();
            this.btnSerialSend = new System.Windows.Forms.Button();
            this.tbSerialSend = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pSerial.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.pSerial);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Controls.Add(this.tbCamAddress);
            this.panel2.Controls.Add(this.labelCamAddress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 84);
            this.panel2.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 54);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbCamAddress
            // 
            this.tbCamAddress.Location = new System.Drawing.Point(3, 28);
            this.tbCamAddress.Name = "tbCamAddress";
            this.tbCamAddress.Size = new System.Drawing.Size(188, 20);
            this.tbCamAddress.TabIndex = 2;
            this.tbCamAddress.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbCamAddress.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // labelCamAddress
            // 
            this.labelCamAddress.AutoSize = true;
            this.labelCamAddress.Location = new System.Drawing.Point(0, 12);
            this.labelCamAddress.Name = "labelCamAddress";
            this.labelCamAddress.Size = new System.Drawing.Size(68, 13);
            this.labelCamAddress.TabIndex = 3;
            this.labelCamAddress.Text = "Stream URL:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnWSSend);
            this.panel1.Controls.Add(this.tbWSSend);
            this.panel1.Controls.Add(this.labelWSAddress);
            this.panel1.Controls.Add(this.labelWSSend);
            this.panel1.Controls.Add(this.tbWSAddress);
            this.panel1.Controls.Add(this.btnWSConnect);
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 150);
            this.panel1.TabIndex = 16;
            // 
            // btnWSSend
            // 
            this.btnWSSend.Enabled = false;
            this.btnWSSend.Location = new System.Drawing.Point(116, 121);
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
            this.tbWSSend.Location = new System.Drawing.Point(3, 95);
            this.tbWSSend.Name = "tbWSSend";
            this.tbWSSend.Size = new System.Drawing.Size(188, 20);
            this.tbWSSend.TabIndex = 8;
            this.tbWSSend.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbWSSend.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // labelWSAddress
            // 
            this.labelWSAddress.AutoSize = true;
            this.labelWSAddress.Location = new System.Drawing.Point(0, 4);
            this.labelWSAddress.Name = "labelWSAddress";
            this.labelWSAddress.Size = new System.Drawing.Size(95, 13);
            this.labelWSAddress.TabIndex = 6;
            this.labelWSAddress.Text = "Web Socket URL:";
            // 
            // labelWSSend
            // 
            this.labelWSSend.AutoSize = true;
            this.labelWSSend.Location = new System.Drawing.Point(3, 79);
            this.labelWSSend.Name = "labelWSSend";
            this.labelWSSend.Size = new System.Drawing.Size(140, 13);
            this.labelWSSend.TabIndex = 7;
            this.labelWSSend.Text = "Send WebSocket message:";
            // 
            // tbWSAddress
            // 
            this.tbWSAddress.Location = new System.Drawing.Point(3, 20);
            this.tbWSAddress.Name = "tbWSAddress";
            this.tbWSAddress.Size = new System.Drawing.Size(188, 20);
            this.tbWSAddress.TabIndex = 4;
            this.tbWSAddress.Text = "ws://";
            this.tbWSAddress.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbWSAddress.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // btnWSConnect
            // 
            this.btnWSConnect.Location = new System.Drawing.Point(116, 46);
            this.btnWSConnect.Name = "btnWSConnect";
            this.btnWSConnect.Size = new System.Drawing.Size(75, 23);
            this.btnWSConnect.TabIndex = 5;
            this.btnWSConnect.Text = "Connect";
            this.btnWSConnect.UseVisualStyleBackColor = true;
            this.btnWSConnect.Click += new System.EventHandler(this.btnWSConnect_Click);
            // 
            // pSerial
            // 
            this.pSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pSerial.Controls.Add(this.btnSerialOpen);
            this.pSerial.Controls.Add(this.tbCOMport);
            this.pSerial.Controls.Add(this.labelCOMport);
            this.pSerial.Controls.Add(this.labelSerialSend);
            this.pSerial.Controls.Add(this.btnSerialSend);
            this.pSerial.Controls.Add(this.tbSerialSend);
            this.pSerial.Location = new System.Drawing.Point(0, 233);
            this.pSerial.Name = "pSerial";
            this.pSerial.Size = new System.Drawing.Size(194, 125);
            this.pSerial.TabIndex = 16;
            // 
            // btnSerialOpen
            // 
            this.btnSerialOpen.Location = new System.Drawing.Point(116, 17);
            this.btnSerialOpen.Name = "btnSerialOpen";
            this.btnSerialOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSerialOpen.TabIndex = 12;
            this.btnSerialOpen.Text = "Open";
            this.btnSerialOpen.UseVisualStyleBackColor = true;
            this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
            // 
            // tbCOMport
            // 
            this.tbCOMport.Location = new System.Drawing.Point(3, 19);
            this.tbCOMport.Name = "tbCOMport";
            this.tbCOMport.Size = new System.Drawing.Size(107, 20);
            this.tbCOMport.TabIndex = 15;
            this.tbCOMport.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbCOMport.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // labelCOMport
            // 
            this.labelCOMport.AutoSize = true;
            this.labelCOMport.Location = new System.Drawing.Point(3, 3);
            this.labelCOMport.Name = "labelCOMport";
            this.labelCOMport.Size = new System.Drawing.Size(55, 13);
            this.labelCOMport.TabIndex = 10;
            this.labelCOMport.Text = "COM port:";
            // 
            // labelSerialSend
            // 
            this.labelSerialSend.AutoSize = true;
            this.labelSerialSend.Location = new System.Drawing.Point(3, 52);
            this.labelSerialSend.Name = "labelSerialSend";
            this.labelSerialSend.Size = new System.Drawing.Size(109, 13);
            this.labelSerialSend.TabIndex = 11;
            this.labelSerialSend.Text = "Send Serial message:";
            // 
            // btnSerialSend
            // 
            this.btnSerialSend.Enabled = false;
            this.btnSerialSend.Location = new System.Drawing.Point(116, 91);
            this.btnSerialSend.Name = "btnSerialSend";
            this.btnSerialSend.Size = new System.Drawing.Size(75, 23);
            this.btnSerialSend.TabIndex = 13;
            this.btnSerialSend.Text = "Send";
            this.btnSerialSend.UseVisualStyleBackColor = true;
            this.btnSerialSend.Click += new System.EventHandler(this.btnSerialSend_Click);
            // 
            // tbSerialSend
            // 
            this.tbSerialSend.Enabled = false;
            this.tbSerialSend.Location = new System.Drawing.Point(5, 68);
            this.tbSerialSend.Name = "tbSerialSend";
            this.tbSerialSend.Size = new System.Drawing.Size(186, 20);
            this.tbSerialSend.TabIndex = 14;
            this.tbSerialSend.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbSerialSend.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pSerial.ResumeLayout(false);
            this.pSerial.PerformLayout();
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
        private System.Windows.Forms.Label labelSerialSend;
        private System.Windows.Forms.Label labelCOMport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pSerial;
        private System.Windows.Forms.Button btnSerialOpen;
        private System.Windows.Forms.TextBox tbCOMport;
        private System.Windows.Forms.Button btnSerialSend;
        private System.Windows.Forms.TextBox tbSerialSend;
    }
}

