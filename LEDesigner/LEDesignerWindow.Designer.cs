namespace LEDMatrixController {
    partial class LEDMD {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LEDMD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveDesign = new System.Windows.Forms.Button();
            this.colorPrev = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.frameConfig = new System.Windows.Forms.GroupBox();
            this.postVal = new System.Windows.Forms.NumericUpDown();
            this.preVal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scrollConfig = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovrwrMatrix = new System.Windows.Forms.Button();
            this.updMatrix = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colVal = new System.Windows.Forms.NumericUpDown();
            this.rowVal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.designArea = new System.Windows.Forms.Panel();
            this.chooseColor = new System.Windows.Forms.ColorDialog();
            this.savePattern = new System.Windows.Forms.SaveFileDialog();
            this.realRow = new System.Windows.Forms.NumericUpDown();
            this.realCol = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextFrame = new System.Windows.Forms.Button();
            this.prevFrame = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.updateFrameCount = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.frameConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preVal)).BeginInit();
            this.scrollConfig.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowVal)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realCol)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.saveDesign);
            this.panel1.Controls.Add(this.colorPrev);
            this.panel1.Controls.Add(this.colorButton);
            this.panel1.Controls.Add(this.settingsPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-4, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 559);
            this.panel1.TabIndex = 0;
            // 
            // saveDesign
            // 
            this.saveDesign.BackColor = System.Drawing.Color.DarkGray;
            this.saveDesign.FlatAppearance.BorderSize = 0;
            this.saveDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveDesign.Image = ((System.Drawing.Image)(resources.GetObject("saveDesign.Image")));
            this.saveDesign.Location = new System.Drawing.Point(725, 429);
            this.saveDesign.Name = "saveDesign";
            this.saveDesign.Size = new System.Drawing.Size(56, 114);
            this.saveDesign.TabIndex = 4;
            this.saveDesign.UseVisualStyleBackColor = false;
            this.saveDesign.Click += new System.EventHandler(this.saveDesign_Click);
            // 
            // colorPrev
            // 
            this.colorPrev.BackColor = System.Drawing.Color.White;
            this.colorPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPrev.Location = new System.Drawing.Point(151, 525);
            this.colorPrev.Name = "colorPrev";
            this.colorPrev.Size = new System.Drawing.Size(58, 18);
            this.colorPrev.TabIndex = 3;
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.DarkGray;
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Image = ((System.Drawing.Image)(resources.GetObject("colorButton.Image")));
            this.colorButton.Location = new System.Drawing.Point(152, 429);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(56, 93);
            this.colorButton.TabIndex = 0;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.groupBox2);
            this.settingsPanel.Controls.Add(this.frameConfig);
            this.settingsPanel.Controls.Add(this.scrollConfig);
            this.settingsPanel.Location = new System.Drawing.Point(214, 429);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(505, 114);
            this.settingsPanel.TabIndex = 2;
            // 
            // frameConfig
            // 
            this.frameConfig.Controls.Add(this.postVal);
            this.frameConfig.Controls.Add(this.preVal);
            this.frameConfig.Controls.Add(this.label5);
            this.frameConfig.Controls.Add(this.label1);
            this.frameConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.frameConfig.Location = new System.Drawing.Point(248, 3);
            this.frameConfig.Name = "frameConfig";
            this.frameConfig.Size = new System.Drawing.Size(129, 102);
            this.frameConfig.TabIndex = 1;
            this.frameConfig.TabStop = false;
            this.frameConfig.Text = "In-Between";
            // 
            // postVal
            // 
            this.postVal.Location = new System.Drawing.Point(78, 61);
            this.postVal.Name = "postVal";
            this.postVal.Size = new System.Drawing.Size(36, 20);
            this.postVal.TabIndex = 3;
            this.postVal.ValueChanged += new System.EventHandler(this.postVal_ValueChanged);
            // 
            // preVal
            // 
            this.preVal.Location = new System.Drawing.Point(78, 35);
            this.preVal.Name = "preVal";
            this.preVal.Size = new System.Drawing.Size(36, 20);
            this.preVal.TabIndex = 2;
            this.preVal.ValueChanged += new System.EventHandler(this.preVal_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Post-Frames:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pre-Frames:";
            // 
            // scrollConfig
            // 
            this.scrollConfig.Controls.Add(this.label7);
            this.scrollConfig.Controls.Add(this.label6);
            this.scrollConfig.Controls.Add(this.realCol);
            this.scrollConfig.Controls.Add(this.realRow);
            this.scrollConfig.Controls.Add(this.radioButton4);
            this.scrollConfig.Controls.Add(this.radioButton3);
            this.scrollConfig.Controls.Add(this.radioButton2);
            this.scrollConfig.Controls.Add(this.radioButton1);
            this.scrollConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scrollConfig.Location = new System.Drawing.Point(13, 3);
            this.scrollConfig.Name = "scrollConfig";
            this.scrollConfig.Size = new System.Drawing.Size(229, 102);
            this.scrollConfig.TabIndex = 0;
            this.scrollConfig.TabStop = false;
            this.scrollConfig.Text = "Scrolling Settings";
            this.scrollConfig.Enter += new System.EventHandler(this.scrollConfig_Enter);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(15, 71);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(92, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Bottom to Top";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 54);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Top to Bottom";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Left to Right";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Right to Left";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 558);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.ovrwrMatrix);
            this.groupBox1.Controls.Add(this.updMatrix);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.colVal);
            this.groupBox1.Controls.Add(this.rowVal);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 138);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matrix Size:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ovrwrMatrix
            // 
            this.ovrwrMatrix.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ovrwrMatrix.Location = new System.Drawing.Point(33, 107);
            this.ovrwrMatrix.Name = "ovrwrMatrix";
            this.ovrwrMatrix.Size = new System.Drawing.Size(60, 21);
            this.ovrwrMatrix.TabIndex = 11;
            this.ovrwrMatrix.Text = "Overwrite";
            this.ovrwrMatrix.UseVisualStyleBackColor = true;
            this.ovrwrMatrix.Click += new System.EventHandler(this.ovrwrMatrix_Click);
            // 
            // updMatrix
            // 
            this.updMatrix.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updMatrix.Location = new System.Drawing.Point(38, 80);
            this.updMatrix.Name = "updMatrix";
            this.updMatrix.Size = new System.Drawing.Size(51, 21);
            this.updMatrix.TabIndex = 10;
            this.updMatrix.Text = "Update";
            this.updMatrix.UseVisualStyleBackColor = true;
            this.updMatrix.Click += new System.EventHandler(this.updMatrix_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(18, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Column:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(31, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Row:";
            // 
            // colVal
            // 
            this.colVal.Location = new System.Drawing.Point(69, 47);
            this.colVal.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.colVal.Name = "colVal";
            this.colVal.Size = new System.Drawing.Size(37, 20);
            this.colVal.TabIndex = 7;
            // 
            // rowVal
            // 
            this.rowVal.Location = new System.Drawing.Point(69, 21);
            this.rowVal.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.rowVal.Name = "rowVal";
            this.rowVal.Size = new System.Drawing.Size(37, 20);
            this.rowVal.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Design Type:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkGray;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(3, 481);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 34);
            this.button5.TabIndex = 3;
            this.button5.Text = "Load";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkGray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(3, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 34);
            this.button4.TabIndex = 1;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(3, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Frame By Frame";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(3, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Scrolling";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(3, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Static";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.prevFrame);
            this.panel3.Controls.Add(this.nextFrame);
            this.panel3.Controls.Add(this.designArea);
            this.panel3.Location = new System.Drawing.Point(152, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 409);
            this.panel3.TabIndex = 5;
            // 
            // designArea
            // 
            this.designArea.AutoScroll = true;
            this.designArea.BackColor = System.Drawing.Color.DarkGray;
            this.designArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designArea.Location = new System.Drawing.Point(15, 14);
            this.designArea.Name = "designArea";
            this.designArea.Size = new System.Drawing.Size(600, 360);
            this.designArea.TabIndex = 1;
            this.designArea.Paint += new System.Windows.Forms.PaintEventHandler(this.designArea_Paint);
            // 
            // chooseColor
            // 
            this.chooseColor.FullOpen = true;
            // 
            // savePattern
            // 
            this.savePattern.DefaultExt = "txt";
            this.savePattern.Filter = "\"txt files|*.txt\"";
            // 
            // realRow
            // 
            this.realRow.Location = new System.Drawing.Point(182, 34);
            this.realRow.Name = "realRow";
            this.realRow.Size = new System.Drawing.Size(36, 20);
            this.realRow.TabIndex = 4;
            // 
            // realCol
            // 
            this.realCol.Location = new System.Drawing.Point(182, 62);
            this.realCol.Name = "realCol";
            this.realCol.Size = new System.Drawing.Size(36, 20);
            this.realCol.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Real Row:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Real Col:";
            // 
            // nextFrame
            // 
            this.nextFrame.BackColor = System.Drawing.Color.Gray;
            this.nextFrame.FlatAppearance.BorderSize = 0;
            this.nextFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextFrame.Location = new System.Drawing.Point(574, 374);
            this.nextFrame.Name = "nextFrame";
            this.nextFrame.Size = new System.Drawing.Size(41, 34);
            this.nextFrame.TabIndex = 2;
            this.nextFrame.Text = ">";
            this.nextFrame.UseVisualStyleBackColor = false;
            // 
            // prevFrame
            // 
            this.prevFrame.BackColor = System.Drawing.Color.Gray;
            this.prevFrame.FlatAppearance.BorderSize = 0;
            this.prevFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevFrame.Location = new System.Drawing.Point(15, 374);
            this.prevFrame.Name = "prevFrame";
            this.prevFrame.Size = new System.Drawing.Size(41, 34);
            this.prevFrame.TabIndex = 3;
            this.prevFrame.Text = "<";
            this.prevFrame.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateFrameCount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(383, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 102);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "F-By-F";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Frames:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(54, 32);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // updateFrameCount
            // 
            this.updateFrameCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateFrameCount.Location = new System.Drawing.Point(25, 62);
            this.updateFrameCount.Name = "updateFrameCount";
            this.updateFrameCount.Size = new System.Drawing.Size(55, 21);
            this.updateFrameCount.TabIndex = 2;
            this.updateFrameCount.Text = "Update";
            this.updateFrameCount.UseVisualStyleBackColor = true;
            // 
            // LEDMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(792, 641);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LEDMD";
            this.Text = "LEDesigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.frameConfig.ResumeLayout(false);
            this.frameConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preVal)).EndInit();
            this.scrollConfig.ResumeLayout(false);
            this.scrollConfig.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowVal)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.realRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realCol)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown colVal;
        private System.Windows.Forms.NumericUpDown rowVal;
        private System.Windows.Forms.Panel designArea;
        private System.Windows.Forms.Button updMatrix;
        private System.Windows.Forms.ColorDialog chooseColor;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Panel colorPrev;
        private System.Windows.Forms.GroupBox scrollConfig;
        private System.Windows.Forms.Button saveDesign;
        private System.Windows.Forms.GroupBox frameConfig;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button ovrwrMatrix;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown postVal;
        private System.Windows.Forms.NumericUpDown preVal;
        private System.Windows.Forms.SaveFileDialog savePattern;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown realCol;
        private System.Windows.Forms.NumericUpDown realRow;
        private System.Windows.Forms.Button prevFrame;
        private System.Windows.Forms.Button nextFrame;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updateFrameCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

