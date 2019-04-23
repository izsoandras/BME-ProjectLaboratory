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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(robotClientForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabViews = new System.Windows.Forms.TabControl();
            this.tabCameraView = new System.Windows.Forms.TabPage();
            this.pbCameraView = new System.Windows.Forms.PictureBox();
            this.tabSensors = new System.Windows.Forms.TabPage();
            this.chartPress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHumid = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStreamConnect = new System.Windows.Forms.Button();
            this.tbCamAddress = new System.Windows.Forms.TextBox();
            this.labelCamAddress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudPWMfreq = new System.Windows.Forms.NumericUpDown();
            this.nudDutyLeft = new System.Windows.Forms.NumericUpDown();
            this.nudDutyRight = new System.Windows.Forms.NumericUpDown();
            this.lPWMfreq = new System.Windows.Forms.Label();
            this.lDutyLeft = new System.Windows.Forms.Label();
            this.lDutyRight = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
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
            this.timerSensor = new System.Windows.Forms.Timer(this.components);
            this.compass = new RoboPro.Compass();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabViews.SuspendLayout();
            this.tabCameraView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).BeginInit();
            this.tabSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPWMfreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDutyLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDutyRight)).BeginInit();
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
            this.splitContainer2.Panel1.Controls.Add(this.tabViews);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbConsole);
            this.splitContainer2.Size = new System.Drawing.Size(598, 450);
            this.splitContainer2.SplitterDistance = 319;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabViews
            // 
            this.tabViews.Controls.Add(this.tabCameraView);
            this.tabViews.Controls.Add(this.tabSensors);
            this.tabViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabViews.Location = new System.Drawing.Point(0, 0);
            this.tabViews.Name = "tabViews";
            this.tabViews.SelectedIndex = 0;
            this.tabViews.Size = new System.Drawing.Size(594, 315);
            this.tabViews.TabIndex = 0;
            this.tabViews.SelectedIndexChanged += new System.EventHandler(this.tabViews_SelectedIndexChanged);
            // 
            // tabCameraView
            // 
            this.tabCameraView.Controls.Add(this.pbCameraView);
            this.tabCameraView.Location = new System.Drawing.Point(4, 22);
            this.tabCameraView.Name = "tabCameraView";
            this.tabCameraView.Padding = new System.Windows.Forms.Padding(3);
            this.tabCameraView.Size = new System.Drawing.Size(586, 289);
            this.tabCameraView.TabIndex = 0;
            this.tabCameraView.Text = "Camera";
            this.tabCameraView.UseVisualStyleBackColor = true;
            // 
            // pbCameraView
            // 
            this.pbCameraView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCameraView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCameraView.Location = new System.Drawing.Point(3, 3);
            this.pbCameraView.Name = "pbCameraView";
            this.pbCameraView.Size = new System.Drawing.Size(580, 283);
            this.pbCameraView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCameraView.TabIndex = 1;
            this.pbCameraView.TabStop = false;
            // 
            // tabSensors
            // 
            this.tabSensors.Controls.Add(this.chartPress);
            this.tabSensors.Controls.Add(this.chartHumid);
            this.tabSensors.Controls.Add(this.chartTemp);
            this.tabSensors.Controls.Add(this.compass);
            this.tabSensors.Location = new System.Drawing.Point(4, 22);
            this.tabSensors.Name = "tabSensors";
            this.tabSensors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSensors.Size = new System.Drawing.Size(586, 289);
            this.tabSensors.TabIndex = 1;
            this.tabSensors.Text = "Sensors";
            this.tabSensors.UseVisualStyleBackColor = true;
            // 
            // chartPress
            // 
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.Maximum = 4D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chartPress.ChartAreas.Add(chartArea1);
            this.chartPress.Location = new System.Drawing.Point(300, 153);
            this.chartPress.Name = "chartPress";
            this.chartPress.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Aqua;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsVisibleInLegend = false;
            series1.Name = "Press";
            this.chartPress.Series.Add(series1);
            this.chartPress.Size = new System.Drawing.Size(286, 137);
            this.chartPress.TabIndex = 3;
            this.chartPress.Text = "chart3";
            title1.Name = "Title1";
            title1.Text = "Pressure";
            this.chartPress.Titles.Add(title1);
            // 
            // chartHumid
            // 
            this.chartHumid.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.Maximum = 4D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chartHumid.ChartAreas.Add(chartArea2);
            this.chartHumid.Location = new System.Drawing.Point(0, 140);
            this.chartHumid.Name = "chartHumid";
            this.chartHumid.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsVisibleInLegend = false;
            series2.Name = "Humid";
            this.chartHumid.Series.Add(series2);
            this.chartHumid.Size = new System.Drawing.Size(294, 149);
            this.chartHumid.TabIndex = 2;
            this.chartHumid.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Humidity";
            this.chartHumid.Titles.Add(title2);
            // 
            // chartTemp
            // 
            chartArea3.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.Maximum = 4D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.Name = "ChartArea1";
            this.chartTemp.ChartAreas.Add(chartArea3);
            this.chartTemp.Location = new System.Drawing.Point(-1, 0);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Temp";
            this.chartTemp.Series.Add(series3);
            this.chartTemp.Size = new System.Drawing.Size(295, 146);
            this.chartTemp.TabIndex = 1;
            this.chartTemp.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Temperature";
            this.chartTemp.Titles.Add(title3);
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
            this.panel2.Controls.Add(this.btnStreamConnect);
            this.panel2.Controls.Add(this.tbCamAddress);
            this.panel2.Controls.Add(this.labelCamAddress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 77);
            this.panel2.TabIndex = 10;
            // 
            // btnStreamConnect
            // 
            this.btnStreamConnect.Location = new System.Drawing.Point(116, 49);
            this.btnStreamConnect.Name = "btnStreamConnect";
            this.btnStreamConnect.Size = new System.Drawing.Size(75, 23);
            this.btnStreamConnect.TabIndex = 1;
            this.btnStreamConnect.Text = "Connect";
            this.btnStreamConnect.UseVisualStyleBackColor = true;
            this.btnStreamConnect.Click += new System.EventHandler(this.btnStreamConnect_Click);
            // 
            // tbCamAddress
            // 
            this.tbCamAddress.Location = new System.Drawing.Point(3, 23);
            this.tbCamAddress.Name = "tbCamAddress";
            this.tbCamAddress.Size = new System.Drawing.Size(188, 20);
            this.tbCamAddress.TabIndex = 0;
            this.tbCamAddress.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbCamAddress.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.nudPWMfreq);
            this.panel1.Controls.Add(this.nudDutyLeft);
            this.panel1.Controls.Add(this.nudDutyRight);
            this.panel1.Controls.Add(this.lPWMfreq);
            this.panel1.Controls.Add(this.lDutyLeft);
            this.panel1.Controls.Add(this.lDutyRight);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnWSSend);
            this.panel1.Controls.Add(this.tbWSSend);
            this.panel1.Controls.Add(this.labelWSAddress);
            this.panel1.Controls.Add(this.labelWSSend);
            this.panel1.Controls.Add(this.tbWSAddress);
            this.panel1.Controls.Add(this.btnWSConnect);
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 249);
            this.panel1.TabIndex = 16;
            // 
            // nudPWMfreq
            // 
            this.nudPWMfreq.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPWMfreq.Location = new System.Drawing.Point(71, 144);
            this.nudPWMfreq.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.nudPWMfreq.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPWMfreq.Name = "nudPWMfreq";
            this.nudPWMfreq.Size = new System.Drawing.Size(120, 20);
            this.nudPWMfreq.TabIndex = 6;
            this.nudPWMfreq.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nudDutyLeft
            // 
            this.nudDutyLeft.Location = new System.Drawing.Point(71, 170);
            this.nudDutyLeft.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudDutyLeft.Name = "nudDutyLeft";
            this.nudDutyLeft.Size = new System.Drawing.Size(120, 20);
            this.nudDutyLeft.TabIndex = 7;
            // 
            // nudDutyRight
            // 
            this.nudDutyRight.Location = new System.Drawing.Point(71, 196);
            this.nudDutyRight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudDutyRight.Name = "nudDutyRight";
            this.nudDutyRight.Size = new System.Drawing.Size(120, 20);
            this.nudDutyRight.TabIndex = 8;
            // 
            // lPWMfreq
            // 
            this.lPWMfreq.AutoSize = true;
            this.lPWMfreq.Location = new System.Drawing.Point(3, 146);
            this.lPWMfreq.Name = "lPWMfreq";
            this.lPWMfreq.Size = new System.Drawing.Size(58, 13);
            this.lPWMfreq.TabIndex = 2;
            this.lPWMfreq.Text = "PWM freq:";
            // 
            // lDutyLeft
            // 
            this.lDutyLeft.AutoSize = true;
            this.lDutyLeft.Location = new System.Drawing.Point(3, 172);
            this.lDutyLeft.Name = "lDutyLeft";
            this.lDutyLeft.Size = new System.Drawing.Size(53, 13);
            this.lDutyLeft.TabIndex = 3;
            this.lDutyLeft.Text = "Duty Left:";
            // 
            // lDutyRight
            // 
            this.lDutyRight.AutoSize = true;
            this.lDutyRight.Location = new System.Drawing.Point(3, 198);
            this.lDutyRight.Name = "lDutyRight";
            this.lDutyRight.Size = new System.Drawing.Size(60, 13);
            this.lDutyRight.TabIndex = 4;
            this.lDutyRight.Text = "Duty Right:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(116, 221);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnWSSend
            // 
            this.btnWSSend.Enabled = false;
            this.btnWSSend.Location = new System.Drawing.Point(116, 114);
            this.btnWSSend.Name = "btnWSSend";
            this.btnWSSend.Size = new System.Drawing.Size(75, 23);
            this.btnWSSend.TabIndex = 5;
            this.btnWSSend.Text = "Send";
            this.btnWSSend.UseVisualStyleBackColor = true;
            this.btnWSSend.Click += new System.EventHandler(this.btnWSSend_Click);
            // 
            // tbWSSend
            // 
            this.tbWSSend.Enabled = false;
            this.tbWSSend.Location = new System.Drawing.Point(3, 88);
            this.tbWSSend.Name = "tbWSSend";
            this.tbWSSend.Size = new System.Drawing.Size(188, 20);
            this.tbWSSend.TabIndex = 4;
            this.tbWSSend.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbWSSend.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // labelWSAddress
            // 
            this.labelWSAddress.AutoSize = true;
            this.labelWSAddress.Location = new System.Drawing.Point(3, 4);
            this.labelWSAddress.Name = "labelWSAddress";
            this.labelWSAddress.Size = new System.Drawing.Size(95, 13);
            this.labelWSAddress.TabIndex = 6;
            this.labelWSAddress.Text = "Web Socket URL:";
            // 
            // labelWSSend
            // 
            this.labelWSSend.AutoSize = true;
            this.labelWSSend.Location = new System.Drawing.Point(2, 72);
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
            this.tbWSAddress.TabIndex = 2;
            this.tbWSAddress.Text = "ws://";
            this.tbWSAddress.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbWSAddress.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // btnWSConnect
            // 
            this.btnWSConnect.Location = new System.Drawing.Point(116, 46);
            this.btnWSConnect.Name = "btnWSConnect";
            this.btnWSConnect.Size = new System.Drawing.Size(75, 23);
            this.btnWSConnect.TabIndex = 3;
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
            this.pSerial.Location = new System.Drawing.Point(0, 323);
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
            this.tbCOMport.TabIndex = 11;
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
            this.btnSerialSend.TabIndex = 14;
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
            this.tbSerialSend.TabIndex = 13;
            this.tbSerialSend.Enter += new System.EventHandler(this.tb_Enter_removeKeyListeners);
            this.tbSerialSend.Leave += new System.EventHandler(this.tb_Leave_addKeyListeners);
            // 
            // timerSensor
            // 
            this.timerSensor.Interval = 1000;
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // compass
            // 
            this.compass.Heading = ((System.Drawing.PointF)(resources.GetObject("compass.Heading")));
            this.compass.Location = new System.Drawing.Point(379, 0);
            this.compass.Name = "compass";
            this.compass.Size = new System.Drawing.Size(150, 150);
            this.compass.TabIndex = 0;
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
            this.tabViews.ResumeLayout(false);
            this.tabCameraView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraView)).EndInit();
            this.tabSensors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPWMfreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDutyLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDutyRight)).EndInit();
            this.pSerial.ResumeLayout(false);
            this.pSerial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnStreamConnect;
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
        private System.Windows.Forms.NumericUpDown nudPWMfreq;
        private System.Windows.Forms.NumericUpDown nudDutyLeft;
        private System.Windows.Forms.NumericUpDown nudDutyRight;
        private System.Windows.Forms.Label lPWMfreq;
        private System.Windows.Forms.Label lDutyLeft;
        private System.Windows.Forms.Label lDutyRight;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TabControl tabViews;
        private System.Windows.Forms.TabPage tabCameraView;
        private System.Windows.Forms.TabPage tabSensors;
        private Compass compass;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHumid;
        private System.Windows.Forms.Timer timerSensor;
    }
}

