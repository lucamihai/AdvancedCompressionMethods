﻿
namespace AdvancedCompressionMethods.UserControls
{
    partial class WaveletCoderUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxWaveletImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAnalysisAllTheWay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownLevelsAllTheWay = new System.Windows.Forms.NumericUpDown();
            this.buttonLoadOriginalImage = new System.Windows.Forms.Button();
            this.buttonTestErrors = new System.Windows.Forms.Button();
            this.buttonLoadWaveletImage = new System.Windows.Forms.Button();
            this.buttonSaveWaveletImage = new System.Windows.Forms.Button();
            this.panelLevel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelLevel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelLevel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelLevel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelLevel5 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonSynthesisAllTheWay = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxMinError = new System.Windows.Forms.TextBox();
            this.textBoxMaxError = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDownHighlighOffset = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDownHighlightScale = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDownHighlightY = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownHighlightX = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonRedrawWavelet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaveletImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelsAllTheWay)).BeginInit();
            this.panelLevel1.SuspendLayout();
            this.panelLevel2.SuspendLayout();
            this.panelLevel3.SuspendLayout();
            this.panelLevel4.SuspendLayout();
            this.panelLevel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlighOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightX)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(20, 26);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxWaveletImage
            // 
            this.pictureBoxWaveletImage.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxWaveletImage.Location = new System.Drawing.Point(554, 26);
            this.pictureBoxWaveletImage.Name = "pictureBoxWaveletImage";
            this.pictureBoxWaveletImage.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxWaveletImage.TabIndex = 1;
            this.pictureBoxWaveletImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(571, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wavelet Image";
            // 
            // buttonAnalysisAllTheWay
            // 
            this.buttonAnalysisAllTheWay.Location = new System.Drawing.Point(1088, 479);
            this.buttonAnalysisAllTheWay.Name = "buttonAnalysisAllTheWay";
            this.buttonAnalysisAllTheWay.Size = new System.Drawing.Size(107, 23);
            this.buttonAnalysisAllTheWay.TabIndex = 11;
            this.buttonAnalysisAllTheWay.Text = "Analysis for";
            this.buttonAnalysisAllTheWay.UseVisualStyleBackColor = true;
            this.buttonAnalysisAllTheWay.Click += new System.EventHandler(this.buttonAnalysisAllTheWay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(1201, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Levels";
            // 
            // numericUpDownLevelsAllTheWay
            // 
            this.numericUpDownLevelsAllTheWay.Location = new System.Drawing.Point(1201, 499);
            this.numericUpDownLevelsAllTheWay.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLevelsAllTheWay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevelsAllTheWay.Name = "numericUpDownLevelsAllTheWay";
            this.numericUpDownLevelsAllTheWay.Size = new System.Drawing.Size(61, 23);
            this.numericUpDownLevelsAllTheWay.TabIndex = 12;
            this.numericUpDownLevelsAllTheWay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonLoadOriginalImage
            // 
            this.buttonLoadOriginalImage.Location = new System.Drawing.Point(34, 544);
            this.buttonLoadOriginalImage.Name = "buttonLoadOriginalImage";
            this.buttonLoadOriginalImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadOriginalImage.TabIndex = 14;
            this.buttonLoadOriginalImage.Text = "Load";
            this.buttonLoadOriginalImage.UseVisualStyleBackColor = true;
            this.buttonLoadOriginalImage.Click += new System.EventHandler(this.buttonLoadOriginalImage_Click);
            // 
            // buttonTestErrors
            // 
            this.buttonTestErrors.Location = new System.Drawing.Point(34, 574);
            this.buttonTestErrors.Name = "buttonTestErrors";
            this.buttonTestErrors.Size = new System.Drawing.Size(75, 23);
            this.buttonTestErrors.TabIndex = 15;
            this.buttonTestErrors.Text = "Test Errors";
            this.buttonTestErrors.UseVisualStyleBackColor = true;
            this.buttonTestErrors.Click += new System.EventHandler(this.buttonTestErrors_Click);
            // 
            // buttonLoadWaveletImage
            // 
            this.buttonLoadWaveletImage.Location = new System.Drawing.Point(580, 544);
            this.buttonLoadWaveletImage.Name = "buttonLoadWaveletImage";
            this.buttonLoadWaveletImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadWaveletImage.TabIndex = 16;
            this.buttonLoadWaveletImage.Text = "Load";
            this.buttonLoadWaveletImage.UseVisualStyleBackColor = true;
            this.buttonLoadWaveletImage.Click += new System.EventHandler(this.buttonLoadWaveletImage_Click);
            // 
            // buttonSaveWaveletImage
            // 
            this.buttonSaveWaveletImage.Location = new System.Drawing.Point(580, 574);
            this.buttonSaveWaveletImage.Name = "buttonSaveWaveletImage";
            this.buttonSaveWaveletImage.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveWaveletImage.TabIndex = 17;
            this.buttonSaveWaveletImage.Text = "Save";
            this.buttonSaveWaveletImage.UseVisualStyleBackColor = true;
            this.buttonSaveWaveletImage.Click += new System.EventHandler(this.buttonSaveWaveletImage_Click);
            // 
            // panelLevel1
            // 
            this.panelLevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel1.Controls.Add(this.label9);
            this.panelLevel1.Controls.Add(this.label8);
            this.panelLevel1.Controls.Add(this.label7);
            this.panelLevel1.Location = new System.Drawing.Point(1088, 26);
            this.panelLevel1.Name = "panelLevel1";
            this.panelLevel1.Size = new System.Drawing.Size(161, 80);
            this.panelLevel1.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(85, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Synthesis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(21, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Analysis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Level 1";
            // 
            // panelLevel2
            // 
            this.panelLevel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel2.Controls.Add(this.label3);
            this.panelLevel2.Controls.Add(this.label4);
            this.panelLevel2.Controls.Add(this.label10);
            this.panelLevel2.Location = new System.Drawing.Point(1088, 112);
            this.panelLevel2.Name = "panelLevel2";
            this.panelLevel2.Size = new System.Drawing.Size(161, 80);
            this.panelLevel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(85, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Synthesis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Analysis";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 19);
            this.label10.TabIndex = 5;
            this.label10.Text = "Level 2";
            // 
            // panelLevel3
            // 
            this.panelLevel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel3.Controls.Add(this.label11);
            this.panelLevel3.Controls.Add(this.label12);
            this.panelLevel3.Controls.Add(this.label13);
            this.panelLevel3.Location = new System.Drawing.Point(1088, 198);
            this.panelLevel3.Name = "panelLevel3";
            this.panelLevel3.Size = new System.Drawing.Size(161, 80);
            this.panelLevel3.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(85, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Synthesis";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(21, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Analysis";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Level 3";
            // 
            // panelLevel4
            // 
            this.panelLevel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel4.Controls.Add(this.label14);
            this.panelLevel4.Controls.Add(this.label15);
            this.panelLevel4.Controls.Add(this.label16);
            this.panelLevel4.Location = new System.Drawing.Point(1088, 284);
            this.panelLevel4.Name = "panelLevel4";
            this.panelLevel4.Size = new System.Drawing.Size(161, 80);
            this.panelLevel4.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(85, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "Synthesis";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(21, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 20;
            this.label15.Text = "Analysis";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 19);
            this.label16.TabIndex = 5;
            this.label16.Text = "Level 4";
            // 
            // panelLevel5
            // 
            this.panelLevel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel5.Controls.Add(this.label17);
            this.panelLevel5.Controls.Add(this.label18);
            this.panelLevel5.Controls.Add(this.label19);
            this.panelLevel5.Location = new System.Drawing.Point(1088, 370);
            this.panelLevel5.Name = "panelLevel5";
            this.panelLevel5.Size = new System.Drawing.Size(161, 80);
            this.panelLevel5.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(85, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 15);
            this.label17.TabIndex = 22;
            this.label17.Text = "Synthesis";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(21, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 20;
            this.label18.Text = "Analysis";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 19);
            this.label19.TabIndex = 5;
            this.label19.Text = "Level 5";
            // 
            // buttonSynthesisAllTheWay
            // 
            this.buttonSynthesisAllTheWay.Location = new System.Drawing.Point(1088, 508);
            this.buttonSynthesisAllTheWay.Name = "buttonSynthesisAllTheWay";
            this.buttonSynthesisAllTheWay.Size = new System.Drawing.Size(107, 23);
            this.buttonSynthesisAllTheWay.TabIndex = 27;
            this.buttonSynthesisAllTheWay.Text = "Synthesis for";
            this.buttonSynthesisAllTheWay.UseVisualStyleBackColor = true;
            this.buttonSynthesisAllTheWay.Click += new System.EventHandler(this.buttonSynthesisAllTheWay_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 574);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Min error:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(126, 601);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 15);
            this.label20.TabIndex = 29;
            this.label20.Text = "Max error:";
            // 
            // textBoxMinError
            // 
            this.textBoxMinError.Location = new System.Drawing.Point(191, 571);
            this.textBoxMinError.Name = "textBoxMinError";
            this.textBoxMinError.ReadOnly = true;
            this.textBoxMinError.Size = new System.Drawing.Size(80, 23);
            this.textBoxMinError.TabIndex = 30;
            this.textBoxMinError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMaxError
            // 
            this.textBoxMaxError.Location = new System.Drawing.Point(191, 600);
            this.textBoxMaxError.Name = "textBoxMaxError";
            this.textBoxMaxError.ReadOnly = true;
            this.textBoxMaxError.Size = new System.Drawing.Size(80, 23);
            this.textBoxMaxError.TabIndex = 31;
            this.textBoxMaxError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.numericUpDownHighlighOffset);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.numericUpDownHighlightScale);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.numericUpDownHighlightY);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.numericUpDownHighlightX);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(692, 544);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 32;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(115, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 15);
            this.label26.TabIndex = 33;
            this.label26.Text = "Offset";
            // 
            // numericUpDownHighlighOffset
            // 
            this.numericUpDownHighlighOffset.Location = new System.Drawing.Point(124, 74);
            this.numericUpDownHighlighOffset.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownHighlighOffset.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numericUpDownHighlighOffset.Name = "numericUpDownHighlighOffset";
            this.numericUpDownHighlighOffset.Size = new System.Drawing.Size(44, 23);
            this.numericUpDownHighlighOffset.TabIndex = 32;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(115, 10);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 15);
            this.label27.TabIndex = 31;
            this.label27.Text = "Scale";
            // 
            // numericUpDownHighlightScale
            // 
            this.numericUpDownHighlightScale.DecimalPlaces = 2;
            this.numericUpDownHighlightScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownHighlightScale.Location = new System.Drawing.Point(124, 26);
            this.numericUpDownHighlightScale.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownHighlightScale.Name = "numericUpDownHighlightScale";
            this.numericUpDownHighlightScale.Size = new System.Drawing.Size(44, 23);
            this.numericUpDownHighlightScale.TabIndex = 30;
            this.numericUpDownHighlightScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label25.Location = new System.Drawing.Point(108, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1, 81);
            this.label25.TabIndex = 29;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(4, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 15);
            this.label24.TabIndex = 28;
            this.label24.Text = "Y";
            // 
            // numericUpDownHighlightY
            // 
            this.numericUpDownHighlightY.Location = new System.Drawing.Point(26, 74);
            this.numericUpDownHighlightY.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownHighlightY.Name = "numericUpDownHighlightY";
            this.numericUpDownHighlightY.Size = new System.Drawing.Size(44, 23);
            this.numericUpDownHighlightY.TabIndex = 27;
            this.numericUpDownHighlightY.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(4, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 15);
            this.label23.TabIndex = 26;
            this.label23.Text = "X";
            // 
            // numericUpDownHighlightX
            // 
            this.numericUpDownHighlightX.Location = new System.Drawing.Point(26, 49);
            this.numericUpDownHighlightX.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownHighlightX.Name = "numericUpDownHighlightX";
            this.numericUpDownHighlightX.Size = new System.Drawing.Size(44, 23);
            this.numericUpDownHighlightX.TabIndex = 25;
            this.numericUpDownHighlightX.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(3, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 15);
            this.label22.TabIndex = 24;
            this.label22.Text = "Starting from";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(3, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 19);
            this.label21.TabIndex = 23;
            this.label21.Text = "Highlight pixels";
            // 
            // buttonRedrawWavelet
            // 
            this.buttonRedrawWavelet.Location = new System.Drawing.Point(923, 544);
            this.buttonRedrawWavelet.Name = "buttonRedrawWavelet";
            this.buttonRedrawWavelet.Size = new System.Drawing.Size(75, 23);
            this.buttonRedrawWavelet.TabIndex = 33;
            this.buttonRedrawWavelet.Text = "Redraw";
            this.buttonRedrawWavelet.UseVisualStyleBackColor = true;
            this.buttonRedrawWavelet.Click += new System.EventHandler(this.buttonRedrawWavelet_Click);
            // 
            // WaveletCoderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.buttonRedrawWavelet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxMaxError);
            this.Controls.Add(this.textBoxMinError);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSynthesisAllTheWay);
            this.Controls.Add(this.panelLevel5);
            this.Controls.Add(this.panelLevel4);
            this.Controls.Add(this.panelLevel3);
            this.Controls.Add(this.panelLevel2);
            this.Controls.Add(this.panelLevel1);
            this.Controls.Add(this.buttonSaveWaveletImage);
            this.Controls.Add(this.buttonLoadWaveletImage);
            this.Controls.Add(this.buttonTestErrors);
            this.Controls.Add(this.buttonLoadOriginalImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownLevelsAllTheWay);
            this.Controls.Add(this.buttonAnalysisAllTheWay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxWaveletImage);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Name = "WaveletCoderUserControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaveletImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelsAllTheWay)).EndInit();
            this.panelLevel1.ResumeLayout(false);
            this.panelLevel1.PerformLayout();
            this.panelLevel2.ResumeLayout(false);
            this.panelLevel2.PerformLayout();
            this.panelLevel3.ResumeLayout(false);
            this.panelLevel3.PerformLayout();
            this.panelLevel4.ResumeLayout(false);
            this.panelLevel4.PerformLayout();
            this.panelLevel5.ResumeLayout(false);
            this.panelLevel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlighOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighlightX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxWaveletImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAnalysisAllTheWay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownLevelsAllTheWay;
        private System.Windows.Forms.Button buttonLoadOriginalImage;
        private System.Windows.Forms.Button buttonTestErrors;
        private System.Windows.Forms.Button buttonLoadWaveletImage;
        private System.Windows.Forms.Button buttonSaveWaveletImage;
        private System.Windows.Forms.Panel panelLevel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelLevel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelLevel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelLevel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelLevel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonSynthesisAllTheWay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxMinError;
        private System.Windows.Forms.TextBox textBoxMaxError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numericUpDownHighlightY;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownHighlightX;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDownHighlighOffset;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDownHighlightScale;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button buttonRedrawWavelet;
    }
}
