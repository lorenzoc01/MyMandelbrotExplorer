namespace MandelbrotApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.renderButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.xLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.yLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.underflowAlertLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomButtonIn = new System.Windows.Forms.Button();
            this.zoomButtonOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.ZoomUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DestZoomUpDown = new System.Windows.Forms.NumericUpDown();
            this.screenshotButton = new System.Windows.Forms.Button();
            this.setDestButton = new System.Windows.Forms.Button();
            this.RightIterButton = new System.Windows.Forms.Button();
            this.LeftIterButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.JuliaYUpDown = new System.Windows.Forms.NumericUpDown();
            this.JuliaXUpDown = new System.Windows.Forms.NumericUpDown();
            this.resetJuliaButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.colormapChooser = new System.Windows.Forms.ComboBox();
            this.gradientPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestZoomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 1000);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(1509, 102);
            this.renderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(88, 55);
            this.renderButton.TabIndex = 1;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1509, 197);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 27);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            202,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1509, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1509, 9);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(181, 85);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(1603, 102);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(88, 55);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset Position";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1509, 240);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(182, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1605, 970);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 31);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.xLabel,
            this.toolStripStatusLabel3,
            this.yLabel,
            this.toolStripStatusLabel4,
            this.zoomLabel,
            this.underflowAlertLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1000);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1700, 29);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 23);
            this.toolStripStatusLabel1.Text = "X:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = false;
            this.xLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(150, 23);
            this.xLabel.Text = "0";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 23);
            this.toolStripStatusLabel3.Text = "Y:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = false;
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(150, 23);
            this.yLabel.Text = "0";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(52, 23);
            this.toolStripStatusLabel4.Text = "Zoom:";
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = false;
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(180, 23);
            this.zoomLabel.Text = "1";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // underflowAlertLabel
            // 
            this.underflowAlertLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.underflowAlertLabel.ForeColor = System.Drawing.Color.Red;
            this.underflowAlertLabel.Name = "underflowAlertLabel";
            this.underflowAlertLabel.Size = new System.Drawing.Size(0, 23);
            // 
            // zoomButtonIn
            // 
            this.zoomButtonIn.Location = new System.Drawing.Point(1509, 466);
            this.zoomButtonIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zoomButtonIn.Name = "zoomButtonIn";
            this.zoomButtonIn.Size = new System.Drawing.Size(26, 31);
            this.zoomButtonIn.TabIndex = 12;
            this.zoomButtonIn.Text = "+";
            this.zoomButtonIn.UseVisualStyleBackColor = true;
            this.zoomButtonIn.Click += new System.EventHandler(this.zoomButtonIn_Click);
            // 
            // zoomButtonOut
            // 
            this.zoomButtonOut.Location = new System.Drawing.Point(1542, 466);
            this.zoomButtonOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zoomButtonOut.Name = "zoomButtonOut";
            this.zoomButtonOut.Size = new System.Drawing.Size(26, 31);
            this.zoomButtonOut.TabIndex = 13;
            this.zoomButtonOut.Text = "-";
            this.zoomButtonOut.UseVisualStyleBackColor = true;
            this.zoomButtonOut.Click += new System.EventHandler(this.zoomButtonOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1509, 571);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "Render Video";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // XUpDown
            // 
            this.XUpDown.DecimalPlaces = 1;
            this.XUpDown.Location = new System.Drawing.Point(1509, 307);
            this.XUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.XUpDown.Name = "XUpDown";
            this.XUpDown.Size = new System.Drawing.Size(198, 27);
            this.XUpDown.TabIndex = 15;
            this.XUpDown.ValueChanged += new System.EventHandler(this.XUpDown_ValueChanged);
            // 
            // YUpDown
            // 
            this.YUpDown.DecimalPlaces = 1;
            this.YUpDown.Location = new System.Drawing.Point(1509, 368);
            this.YUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.YUpDown.Name = "YUpDown";
            this.YUpDown.Size = new System.Drawing.Size(198, 27);
            this.YUpDown.TabIndex = 16;
            this.YUpDown.ValueChanged += new System.EventHandler(this.YUpDown_ValueChanged);
            // 
            // ZoomUpDown
            // 
            this.ZoomUpDown.DecimalPlaces = 1;
            this.ZoomUpDown.Location = new System.Drawing.Point(1509, 429);
            this.ZoomUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ZoomUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ZoomUpDown.Name = "ZoomUpDown";
            this.ZoomUpDown.Size = new System.Drawing.Size(198, 27);
            this.ZoomUpDown.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1506, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Center X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1506, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Center Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1506, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Zoom:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1506, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Destination Zoom:";
            // 
            // DestZoomUpDown
            // 
            this.DestZoomUpDown.DecimalPlaces = 1;
            this.DestZoomUpDown.Location = new System.Drawing.Point(1509, 533);
            this.DestZoomUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DestZoomUpDown.Name = "DestZoomUpDown";
            this.DestZoomUpDown.Size = new System.Drawing.Size(199, 27);
            this.DestZoomUpDown.TabIndex = 21;
            this.DestZoomUpDown.ValueChanged += new System.EventHandler(this.DestZoomUpDown_ValueChanged);
            // 
            // screenshotButton
            // 
            this.screenshotButton.Location = new System.Drawing.Point(1509, 970);
            this.screenshotButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.screenshotButton.Name = "screenshotButton";
            this.screenshotButton.Size = new System.Drawing.Size(90, 31);
            this.screenshotButton.TabIndex = 23;
            this.screenshotButton.Text = "Screenshot";
            this.screenshotButton.UseVisualStyleBackColor = true;
            this.screenshotButton.Click += new System.EventHandler(this.sreenshotButton_Click);
            // 
            // setDestButton
            // 
            this.setDestButton.Location = new System.Drawing.Point(1664, 466);
            this.setDestButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setDestButton.Name = "setDestButton";
            this.setDestButton.Size = new System.Drawing.Size(26, 31);
            this.setDestButton.TabIndex = 24;
            this.setDestButton.Text = "↓";
            this.setDestButton.UseVisualStyleBackColor = true;
            this.setDestButton.Click += new System.EventHandler(this.setDestButton_Click);
            // 
            // RightIterButton
            // 
            this.RightIterButton.Location = new System.Drawing.Point(1665, 197);
            this.RightIterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RightIterButton.Name = "RightIterButton";
            this.RightIterButton.Size = new System.Drawing.Size(26, 31);
            this.RightIterButton.TabIndex = 26;
            this.RightIterButton.Text = "▶";
            this.RightIterButton.UseVisualStyleBackColor = true;
            this.RightIterButton.Click += new System.EventHandler(this.RightIterButton_Click);
            // 
            // LeftIterButton
            // 
            this.LeftIterButton.Location = new System.Drawing.Point(1632, 197);
            this.LeftIterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LeftIterButton.Name = "LeftIterButton";
            this.LeftIterButton.Size = new System.Drawing.Size(26, 31);
            this.LeftIterButton.TabIndex = 25;
            this.LeftIterButton.Text = "◀";
            this.LeftIterButton.UseVisualStyleBackColor = true;
            this.LeftIterButton.Click += new System.EventHandler(this.LeftIterButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1506, 709);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Julia Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1506, 649);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Julia X:";
            // 
            // JuliaYUpDown
            // 
            this.JuliaYUpDown.DecimalPlaces = 1;
            this.JuliaYUpDown.Location = new System.Drawing.Point(1510, 733);
            this.JuliaYUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JuliaYUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.JuliaYUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.JuliaYUpDown.Name = "JuliaYUpDown";
            this.JuliaYUpDown.Size = new System.Drawing.Size(182, 27);
            this.JuliaYUpDown.TabIndex = 28;
            this.JuliaYUpDown.ValueChanged += new System.EventHandler(this.JuliaYUpDown_ValueChanged);
            // 
            // JuliaXUpDown
            // 
            this.JuliaXUpDown.DecimalPlaces = 1;
            this.JuliaXUpDown.Location = new System.Drawing.Point(1510, 673);
            this.JuliaXUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JuliaXUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.JuliaXUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.JuliaXUpDown.Name = "JuliaXUpDown";
            this.JuliaXUpDown.Size = new System.Drawing.Size(182, 27);
            this.JuliaXUpDown.TabIndex = 27;
            this.JuliaXUpDown.ValueChanged += new System.EventHandler(this.JuliaXUpDown_ValueChanged);
            // 
            // resetJuliaButton
            // 
            this.resetJuliaButton.Location = new System.Drawing.Point(1606, 772);
            this.resetJuliaButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetJuliaButton.Name = "resetJuliaButton";
            this.resetJuliaButton.Size = new System.Drawing.Size(86, 31);
            this.resetJuliaButton.TabIndex = 31;
            this.resetJuliaButton.Text = "Reset";
            this.resetJuliaButton.UseVisualStyleBackColor = true;
            this.resetJuliaButton.Click += new System.EventHandler(this.resetJuliaButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1509, 611);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 34);
            this.button2.TabIndex = 32;
            this.button2.Text = "Switch to Julia Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1689, 267);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 296);
            this.panel1.TabIndex = 33;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Location = new System.Drawing.Point(1688, 307);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(199, 27);
            this.numericUpDown2.TabIndex = 41;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Location = new System.Drawing.Point(1688, 368);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(199, 27);
            this.numericUpDown3.TabIndex = 42;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 1;
            this.numericUpDown4.Location = new System.Drawing.Point(1688, 429);
            this.numericUpDown4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(199, 27);
            this.numericUpDown4.TabIndex = 43;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 1;
            this.numericUpDown5.Location = new System.Drawing.Point(1688, 533);
            this.numericUpDown5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(199, 27);
            this.numericUpDown5.TabIndex = 44;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1509, 922);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 31);
            this.button3.TabIndex = 38;
            this.button3.Text = "New Colormap";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // colormapChooser
            // 
            this.colormapChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colormapChooser.FormattingEnabled = true;
            this.colormapChooser.Location = new System.Drawing.Point(1509, 811);
            this.colormapChooser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colormapChooser.Name = "colormapChooser";
            this.colormapChooser.Size = new System.Drawing.Size(183, 28);
            this.colormapChooser.TabIndex = 39;
            this.colormapChooser.SelectedIndexChanged += new System.EventHandler(this.colormapChooser_SelectedIndexChanged);
            // 
            // gradientPictureBox
            // 
            this.gradientPictureBox.Location = new System.Drawing.Point(1509, 847);
            this.gradientPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gradientPictureBox.Name = "gradientPictureBox";
            this.gradientPictureBox.Size = new System.Drawing.Size(183, 67);
            this.gradientPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gradientPictureBox.TabIndex = 40;
            this.gradientPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 1029);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.gradientPictureBox);
            this.Controls.Add(this.colormapChooser);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.resetJuliaButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.JuliaYUpDown);
            this.Controls.Add(this.JuliaXUpDown);
            this.Controls.Add(this.RightIterButton);
            this.Controls.Add(this.LeftIterButton);
            this.Controls.Add(this.setDestButton);
            this.Controls.Add(this.screenshotButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DestZoomUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ZoomUpDown);
            this.Controls.Add(this.YUpDown);
            this.Controls.Add(this.XUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zoomButtonOut);
            this.Controls.Add(this.zoomButtonIn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMandelbrotExplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestZoomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel xLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel yLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel zoomLabel;
        private System.Windows.Forms.ToolStripStatusLabel underflowAlertLabel;
        private System.Windows.Forms.Button zoomButtonIn;
        private System.Windows.Forms.Button zoomButtonOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.NumericUpDown ZoomUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown DestZoomUpDown;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.Button setDestButton;
        private System.Windows.Forms.Button RightIterButton;
        private System.Windows.Forms.Button LeftIterButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown JuliaYUpDown;
        private System.Windows.Forms.NumericUpDown JuliaXUpDown;
        private System.Windows.Forms.Button resetJuliaButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox colormapChooser;
        private System.Windows.Forms.PictureBox gradientPictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}
