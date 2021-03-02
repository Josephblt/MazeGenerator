namespace MazeGenerator.Util
{
    partial class MazeToolbox
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
            this.gbxCreation = new System.Windows.Forms.GroupBox();
            this.cbxExitSide = new System.Windows.Forms.ComboBox();
            this.lblExitSide = new System.Windows.Forms.Label();
            this.lblMazeType = new System.Windows.Forms.Label();
            this.cbxMazeType = new System.Windows.Forms.ComboBox();
            this.lblStartSide = new System.Windows.Forms.Label();
            this.cbxStartSide = new System.Windows.Forms.ComboBox();
            this.lblRun = new System.Windows.Forms.Label();
            this.tkbRun = new System.Windows.Forms.TrackBar();
            this.lblSeed = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblRoomDistance = new System.Windows.Forms.Label();
            this.nudRoomDistance = new System.Windows.Forms.NumericUpDown();
            this.nudRoomDensity = new System.Windows.Forms.NumericUpDown();
            this.lblRoomDensity = new System.Windows.Forms.Label();
            this.lblRoomMaxSize = new System.Windows.Forms.Label();
            this.nudRoomMaxSize = new System.Windows.Forms.NumericUpDown();
            this.nudRoomMinSize = new System.Windows.Forms.NumericUpDown();
            this.lblRoomMinSize = new System.Windows.Forms.Label();
            this.gbxCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMinSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCreation
            // 
            this.gbxCreation.Controls.Add(this.lblRoomMaxSize);
            this.gbxCreation.Controls.Add(this.nudRoomMaxSize);
            this.gbxCreation.Controls.Add(this.nudRoomMinSize);
            this.gbxCreation.Controls.Add(this.lblRoomMinSize);
            this.gbxCreation.Controls.Add(this.lblRoomDistance);
            this.gbxCreation.Controls.Add(this.nudRoomDistance);
            this.gbxCreation.Controls.Add(this.nudRoomDensity);
            this.gbxCreation.Controls.Add(this.lblRoomDensity);
            this.gbxCreation.Controls.Add(this.cbxExitSide);
            this.gbxCreation.Controls.Add(this.lblExitSide);
            this.gbxCreation.Controls.Add(this.lblMazeType);
            this.gbxCreation.Controls.Add(this.cbxMazeType);
            this.gbxCreation.Controls.Add(this.lblStartSide);
            this.gbxCreation.Controls.Add(this.cbxStartSide);
            this.gbxCreation.Controls.Add(this.lblRun);
            this.gbxCreation.Controls.Add(this.tkbRun);
            this.gbxCreation.Controls.Add(this.lblSeed);
            this.gbxCreation.Controls.Add(this.lblHeight);
            this.gbxCreation.Controls.Add(this.nudHeight);
            this.gbxCreation.Controls.Add(this.nudSeed);
            this.gbxCreation.Controls.Add(this.nudWidth);
            this.gbxCreation.Controls.Add(this.lblWidth);
            this.gbxCreation.Location = new System.Drawing.Point(12, 12);
            this.gbxCreation.Name = "gbxCreation";
            this.gbxCreation.Size = new System.Drawing.Size(160, 336);
            this.gbxCreation.TabIndex = 0;
            this.gbxCreation.TabStop = false;
            this.gbxCreation.Text = "Creation Parameters";
            // 
            // cbxExitSide
            // 
            this.cbxExitSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExitSide.FormattingEnabled = true;
            this.cbxExitSide.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Up",
            "Down"});
            this.cbxExitSide.Location = new System.Drawing.Point(6, 150);
            this.cbxExitSide.Name = "cbxExitSide";
            this.cbxExitSide.Size = new System.Drawing.Size(148, 21);
            this.cbxExitSide.TabIndex = 13;
            // 
            // lblExitSide
            // 
            this.lblExitSide.AutoSize = true;
            this.lblExitSide.Location = new System.Drawing.Point(6, 134);
            this.lblExitSide.Name = "lblExitSide";
            this.lblExitSide.Size = new System.Drawing.Size(48, 13);
            this.lblExitSide.TabIndex = 12;
            this.lblExitSide.Text = "Exit Side";
            // 
            // lblMazeType
            // 
            this.lblMazeType.AutoSize = true;
            this.lblMazeType.Location = new System.Drawing.Point(6, 174);
            this.lblMazeType.Name = "lblMazeType";
            this.lblMazeType.Size = new System.Drawing.Size(60, 13);
            this.lblMazeType.TabIndex = 11;
            this.lblMazeType.Text = "Maze Type";
            // 
            // cbxMazeType
            // 
            this.cbxMazeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMazeType.FormattingEnabled = true;
            this.cbxMazeType.Items.AddRange(new object[] {
            "Partial Braid",
            "Perfect"});
            this.cbxMazeType.Location = new System.Drawing.Point(6, 190);
            this.cbxMazeType.Name = "cbxMazeType";
            this.cbxMazeType.Size = new System.Drawing.Size(148, 21);
            this.cbxMazeType.TabIndex = 10;
            // 
            // lblStartSide
            // 
            this.lblStartSide.AutoSize = true;
            this.lblStartSide.Location = new System.Drawing.Point(6, 94);
            this.lblStartSide.Name = "lblStartSide";
            this.lblStartSide.Size = new System.Drawing.Size(53, 13);
            this.lblStartSide.TabIndex = 9;
            this.lblStartSide.Text = "Start Side";
            // 
            // cbxStartSide
            // 
            this.cbxStartSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStartSide.FormattingEnabled = true;
            this.cbxStartSide.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Up",
            "Down"});
            this.cbxStartSide.Location = new System.Drawing.Point(6, 110);
            this.cbxStartSide.Name = "cbxStartSide";
            this.cbxStartSide.Size = new System.Drawing.Size(148, 21);
            this.cbxStartSide.TabIndex = 8;
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.Location = new System.Drawing.Point(6, 214);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(48, 13);
            this.lblRun.TabIndex = 6;
            this.lblRun.Text = "Run - 50";
            // 
            // tkbRun
            // 
            this.tkbRun.AutoSize = false;
            this.tkbRun.LargeChange = 10;
            this.tkbRun.Location = new System.Drawing.Point(6, 230);
            this.tkbRun.Maximum = 100;
            this.tkbRun.Name = "tkbRun";
            this.tkbRun.Size = new System.Drawing.Size(148, 22);
            this.tkbRun.TabIndex = 7;
            this.tkbRun.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbRun.Value = 50;
            this.tkbRun.ValueChanged += new System.EventHandler(this.tkbRun_ValueChanged);
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(6, 55);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 13);
            this.lblSeed.TabIndex = 4;
            this.lblSeed.Text = "Seed";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(83, 16);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(83, 32);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(71, 20);
            this.nudHeight.TabIndex = 3;
            this.nudHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(6, 71);
            this.nudSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(148, 20);
            this.nudSeed.TabIndex = 5;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(6, 32);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(71, 20);
            this.nudWidth.TabIndex = 1;
            this.nudWidth.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(6, 16);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 354);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 22);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreation_Click);
            // 
            // lblRoomDistance
            // 
            this.lblRoomDistance.AutoSize = true;
            this.lblRoomDistance.Location = new System.Drawing.Point(83, 255);
            this.lblRoomDistance.Name = "lblRoomDistance";
            this.lblRoomDistance.Size = new System.Drawing.Size(49, 13);
            this.lblRoomDistance.TabIndex = 16;
            this.lblRoomDistance.Text = "Distance";
            // 
            // nudRoomDistance
            // 
            this.nudRoomDistance.Location = new System.Drawing.Point(83, 271);
            this.nudRoomDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomDistance.Name = "nudRoomDistance";
            this.nudRoomDistance.Size = new System.Drawing.Size(71, 20);
            this.nudRoomDistance.TabIndex = 17;
            this.nudRoomDistance.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudRoomDensity
            // 
            this.nudRoomDensity.Location = new System.Drawing.Point(6, 271);
            this.nudRoomDensity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomDensity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomDensity.Name = "nudRoomDensity";
            this.nudRoomDensity.Size = new System.Drawing.Size(71, 20);
            this.nudRoomDensity.TabIndex = 15;
            this.nudRoomDensity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblRoomDensity
            // 
            this.lblRoomDensity.AutoSize = true;
            this.lblRoomDensity.Location = new System.Drawing.Point(6, 255);
            this.lblRoomDensity.Name = "lblRoomDensity";
            this.lblRoomDensity.Size = new System.Drawing.Size(42, 13);
            this.lblRoomDensity.TabIndex = 14;
            this.lblRoomDensity.Text = "Density";
            // 
            // lblRoomMaxSize
            // 
            this.lblRoomMaxSize.AutoSize = true;
            this.lblRoomMaxSize.Location = new System.Drawing.Point(83, 294);
            this.lblRoomMaxSize.Name = "lblRoomMaxSize";
            this.lblRoomMaxSize.Size = new System.Drawing.Size(50, 13);
            this.lblRoomMaxSize.TabIndex = 20;
            this.lblRoomMaxSize.Text = "Max Size";
            // 
            // nudRoomMaxSize
            // 
            this.nudRoomMaxSize.Location = new System.Drawing.Point(83, 310);
            this.nudRoomMaxSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMaxSize.Name = "nudRoomMaxSize";
            this.nudRoomMaxSize.Size = new System.Drawing.Size(71, 20);
            this.nudRoomMaxSize.TabIndex = 21;
            this.nudRoomMaxSize.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // nudRoomMinSize
            // 
            this.nudRoomMinSize.Location = new System.Drawing.Point(6, 310);
            this.nudRoomMinSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoomMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomMinSize.Name = "nudRoomMinSize";
            this.nudRoomMinSize.Size = new System.Drawing.Size(71, 20);
            this.nudRoomMinSize.TabIndex = 19;
            this.nudRoomMinSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblRoomMinSize
            // 
            this.lblRoomMinSize.AutoSize = true;
            this.lblRoomMinSize.Location = new System.Drawing.Point(3, 294);
            this.lblRoomMinSize.Name = "lblRoomMinSize";
            this.lblRoomMinSize.Size = new System.Drawing.Size(47, 13);
            this.lblRoomMinSize.TabIndex = 18;
            this.lblRoomMinSize.Text = "Min Size";
            // 
            // MazeToolbox
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 388);
            this.ControlBox = false;
            this.Controls.Add(this.gbxCreation);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MazeToolbox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Maze Tools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MazeToolbox_FormClosed);
            this.gbxCreation.ResumeLayout(false);
            this.gbxCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomMinSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCreation;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.TrackBar tkbRun;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Label lblStartSide;
        private System.Windows.Forms.ComboBox cbxStartSide;
        private System.Windows.Forms.Label lblMazeType;
        private System.Windows.Forms.ComboBox cbxMazeType;
        private System.Windows.Forms.ComboBox cbxExitSide;
        private System.Windows.Forms.Label lblExitSide;
        private System.Windows.Forms.Label lblRoomMaxSize;
        private System.Windows.Forms.NumericUpDown nudRoomMaxSize;
        private System.Windows.Forms.NumericUpDown nudRoomMinSize;
        private System.Windows.Forms.Label lblRoomMinSize;
        private System.Windows.Forms.Label lblRoomDistance;
        private System.Windows.Forms.NumericUpDown nudRoomDistance;
        private System.Windows.Forms.NumericUpDown nudRoomDensity;
        private System.Windows.Forms.Label lblRoomDensity;
    }
}