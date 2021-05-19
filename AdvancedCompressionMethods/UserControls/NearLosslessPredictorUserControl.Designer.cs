
namespace AdvancedCompressionMethods.UserControls
{
    partial class NearLosslessPredictorUserControl
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
            this.pictureBoxErrorMatrix = new System.Windows.Forms.PictureBox();
            this.pictureBoxDecodedImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonPredict = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.numericUpDownErrorMatrixScale = new System.Windows.Forms.NumericUpDown();
            this.buttonShowErrorMatrix = new System.Windows.Forms.Button();
            this.buttonSaveDecoded = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonLoadEncodedImage = new System.Windows.Forms.Button();
            this.panelImagePredictorSelection = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonImagePredictor8 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor7 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor6 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor5 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor4 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor3 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor2 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor1 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor0 = new System.Windows.Forms.RadioButton();
            this.panelHistogramSelection = new System.Windows.Forms.Panel();
            this.radioButtonHistogramDecoded = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogramErrorMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogramOriginal = new System.Windows.Forms.RadioButton();
            this.numericUpDownHistogram = new System.Windows.Forms.NumericUpDown();
            this.buttonShowHistogram = new System.Windows.Forms.Button();
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            this.numericUpDownAcceptedError = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDomainMinValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownDomainMaxValue = new System.Windows.Forms.NumericUpDown();
            this.panelSaveModeSelection = new System.Windows.Forms.Panel();
            this.radioButtonSaveModeArithmetic = new System.Windows.Forms.RadioButton();
            this.radioButtonSaveModeJpegTable = new System.Windows.Forms.RadioButton();
            this.radioButtonSaveMode9Bits = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorMatrixScale)).BeginInit();
            this.panelImagePredictorSelection.SuspendLayout();
            this.panelHistogramSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAcceptedError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomainMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomainMaxValue)).BeginInit();
            this.panelSaveModeSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(4, 22);
            this.pictureBoxOriginalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(298, 295);
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxErrorMatrix
            // 
            this.pictureBoxErrorMatrix.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxErrorMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxErrorMatrix.Location = new System.Drawing.Point(317, 22);
            this.pictureBoxErrorMatrix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxErrorMatrix.Name = "pictureBoxErrorMatrix";
            this.pictureBoxErrorMatrix.Size = new System.Drawing.Size(298, 295);
            this.pictureBoxErrorMatrix.TabIndex = 1;
            this.pictureBoxErrorMatrix.TabStop = false;
            // 
            // pictureBoxDecodedImage
            // 
            this.pictureBoxDecodedImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxDecodedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDecodedImage.Location = new System.Drawing.Point(631, 22);
            this.pictureBoxDecodedImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxDecodedImage.Name = "pictureBoxDecodedImage";
            this.pictureBoxDecodedImage.Size = new System.Drawing.Size(298, 295);
            this.pictureBoxDecodedImage.TabIndex = 2;
            this.pictureBoxDecodedImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(59, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(399, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Error matrix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(714, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Decoded image";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(5, 318);
            this.buttonLoadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(88, 27);
            this.buttonLoadImage.TabIndex = 6;
            this.buttonLoadImage.Text = "Load image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.LoadImageClick);
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(110, 318);
            this.buttonPredict.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(88, 27);
            this.buttonPredict.TabIndex = 7;
            this.buttonPredict.Text = "Predict";
            this.buttonPredict.UseVisualStyleBackColor = true;
            this.buttonPredict.Click += new System.EventHandler(this.PredictClick);
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(215, 318);
            this.buttonStore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(88, 27);
            this.buttonStore.TabIndex = 8;
            this.buttonStore.Text = "Store";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDownErrorMatrixScale
            // 
            this.numericUpDownErrorMatrixScale.DecimalPlaces = 2;
            this.numericUpDownErrorMatrixScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownErrorMatrixScale.Location = new System.Drawing.Point(340, 321);
            this.numericUpDownErrorMatrixScale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownErrorMatrixScale.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownErrorMatrixScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownErrorMatrixScale.Name = "numericUpDownErrorMatrixScale";
            this.numericUpDownErrorMatrixScale.Size = new System.Drawing.Size(78, 23);
            this.numericUpDownErrorMatrixScale.TabIndex = 9;
            this.numericUpDownErrorMatrixScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // buttonShowErrorMatrix
            // 
            this.buttonShowErrorMatrix.Location = new System.Drawing.Point(451, 318);
            this.buttonShowErrorMatrix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonShowErrorMatrix.Name = "buttonShowErrorMatrix";
            this.buttonShowErrorMatrix.Size = new System.Drawing.Size(120, 27);
            this.buttonShowErrorMatrix.TabIndex = 10;
            this.buttonShowErrorMatrix.Text = "Show error matrix";
            this.buttonShowErrorMatrix.UseVisualStyleBackColor = true;
            this.buttonShowErrorMatrix.Click += new System.EventHandler(this.ShowErrorMatrixClick);
            // 
            // buttonSaveDecoded
            // 
            this.buttonSaveDecoded.Location = new System.Drawing.Point(826, 317);
            this.buttonSaveDecoded.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSaveDecoded.Name = "buttonSaveDecoded";
            this.buttonSaveDecoded.Size = new System.Drawing.Size(103, 27);
            this.buttonSaveDecoded.TabIndex = 13;
            this.buttonSaveDecoded.Text = "Save decoded";
            this.buttonSaveDecoded.UseVisualStyleBackColor = true;
            this.buttonSaveDecoded.Click += new System.EventHandler(this.SaveDecodedClick);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(736, 317);
            this.buttonDecode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(83, 27);
            this.buttonDecode.TabIndex = 12;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.DecodeClick);
            // 
            // buttonLoadEncodedImage
            // 
            this.buttonLoadEncodedImage.Location = new System.Drawing.Point(631, 317);
            this.buttonLoadEncodedImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonLoadEncodedImage.Name = "buttonLoadEncodedImage";
            this.buttonLoadEncodedImage.Size = new System.Drawing.Size(98, 27);
            this.buttonLoadEncodedImage.TabIndex = 11;
            this.buttonLoadEncodedImage.Text = "Load encoded";
            this.buttonLoadEncodedImage.UseVisualStyleBackColor = true;
            this.buttonLoadEncodedImage.Click += new System.EventHandler(this.LoadEncodedImageClick);
            // 
            // panelImagePredictorSelection
            // 
            this.panelImagePredictorSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImagePredictorSelection.Controls.Add(this.label4);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor8);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor7);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor6);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor5);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor4);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor3);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor2);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor1);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor0);
            this.panelImagePredictorSelection.Location = new System.Drawing.Point(5, 353);
            this.panelImagePredictorSelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelImagePredictorSelection.Name = "panelImagePredictorSelection";
            this.panelImagePredictorSelection.Size = new System.Drawing.Size(171, 138);
            this.panelImagePredictorSelection.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Predictor";
            // 
            // radioButtonImagePredictor8
            // 
            this.radioButtonImagePredictor8.AutoSize = true;
            this.radioButtonImagePredictor8.Checked = true;
            this.radioButtonImagePredictor8.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor8.Location = new System.Drawing.Point(68, 109);
            this.radioButtonImagePredictor8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor8.Name = "radioButtonImagePredictor8";
            this.radioButtonImagePredictor8.Size = new System.Drawing.Size(51, 16);
            this.radioButtonImagePredictor8.TabIndex = 18;
            this.radioButtonImagePredictor8.TabStop = true;
            this.radioButtonImagePredictor8.Text = "jpegLS";
            this.radioButtonImagePredictor8.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor7
            // 
            this.radioButtonImagePredictor7.AutoSize = true;
            this.radioButtonImagePredictor7.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor7.Location = new System.Drawing.Point(68, 85);
            this.radioButtonImagePredictor7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor7.Name = "radioButtonImagePredictor7";
            this.radioButtonImagePredictor7.Size = new System.Drawing.Size(63, 16);
            this.radioButtonImagePredictor7.TabIndex = 17;
            this.radioButtonImagePredictor7.Text = "(A + B) / 2";
            this.radioButtonImagePredictor7.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor6
            // 
            this.radioButtonImagePredictor6.AutoSize = true;
            this.radioButtonImagePredictor6.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor6.Location = new System.Drawing.Point(68, 59);
            this.radioButtonImagePredictor6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor6.Name = "radioButtonImagePredictor6";
            this.radioButtonImagePredictor6.Size = new System.Drawing.Size(76, 16);
            this.radioButtonImagePredictor6.TabIndex = 16;
            this.radioButtonImagePredictor6.Text = "B + (A - C) / 2";
            this.radioButtonImagePredictor6.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor5
            // 
            this.radioButtonImagePredictor5.AutoSize = true;
            this.radioButtonImagePredictor5.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor5.Location = new System.Drawing.Point(68, 32);
            this.radioButtonImagePredictor5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor5.Name = "radioButtonImagePredictor5";
            this.radioButtonImagePredictor5.Size = new System.Drawing.Size(76, 16);
            this.radioButtonImagePredictor5.TabIndex = 15;
            this.radioButtonImagePredictor5.Text = "A + (B - C) / 2";
            this.radioButtonImagePredictor5.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor4
            // 
            this.radioButtonImagePredictor4.AutoSize = true;
            this.radioButtonImagePredictor4.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor4.Location = new System.Drawing.Point(68, 6);
            this.radioButtonImagePredictor4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor4.Name = "radioButtonImagePredictor4";
            this.radioButtonImagePredictor4.Size = new System.Drawing.Size(58, 16);
            this.radioButtonImagePredictor4.TabIndex = 4;
            this.radioButtonImagePredictor4.Text = "A + B - C";
            this.radioButtonImagePredictor4.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor3
            // 
            this.radioButtonImagePredictor3.AutoSize = true;
            this.radioButtonImagePredictor3.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor3.Location = new System.Drawing.Point(8, 110);
            this.radioButtonImagePredictor3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor3.Name = "radioButtonImagePredictor3";
            this.radioButtonImagePredictor3.Size = new System.Drawing.Size(29, 16);
            this.radioButtonImagePredictor3.TabIndex = 3;
            this.radioButtonImagePredictor3.Text = "C";
            this.radioButtonImagePredictor3.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor2
            // 
            this.radioButtonImagePredictor2.AutoSize = true;
            this.radioButtonImagePredictor2.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor2.Location = new System.Drawing.Point(8, 84);
            this.radioButtonImagePredictor2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor2.Name = "radioButtonImagePredictor2";
            this.radioButtonImagePredictor2.Size = new System.Drawing.Size(29, 16);
            this.radioButtonImagePredictor2.TabIndex = 2;
            this.radioButtonImagePredictor2.Text = "B";
            this.radioButtonImagePredictor2.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor1
            // 
            this.radioButtonImagePredictor1.AutoSize = true;
            this.radioButtonImagePredictor1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor1.Location = new System.Drawing.Point(7, 57);
            this.radioButtonImagePredictor1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor1.Name = "radioButtonImagePredictor1";
            this.radioButtonImagePredictor1.Size = new System.Drawing.Size(30, 16);
            this.radioButtonImagePredictor1.TabIndex = 1;
            this.radioButtonImagePredictor1.Text = "A";
            this.radioButtonImagePredictor1.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor0
            // 
            this.radioButtonImagePredictor0.AutoSize = true;
            this.radioButtonImagePredictor0.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonImagePredictor0.Location = new System.Drawing.Point(8, 31);
            this.radioButtonImagePredictor0.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonImagePredictor0.Name = "radioButtonImagePredictor0";
            this.radioButtonImagePredictor0.Size = new System.Drawing.Size(38, 16);
            this.radioButtonImagePredictor0.TabIndex = 0;
            this.radioButtonImagePredictor0.Text = "128";
            this.radioButtonImagePredictor0.UseVisualStyleBackColor = true;
            // 
            // panelHistogramSelection
            // 
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramDecoded);
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramErrorMatrix);
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramOriginal);
            this.panelHistogramSelection.Location = new System.Drawing.Point(298, 353);
            this.panelHistogramSelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHistogramSelection.Name = "panelHistogramSelection";
            this.panelHistogramSelection.Size = new System.Drawing.Size(120, 88);
            this.panelHistogramSelection.TabIndex = 15;
            // 
            // radioButtonHistogramDecoded
            // 
            this.radioButtonHistogramDecoded.AutoSize = true;
            this.radioButtonHistogramDecoded.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonHistogramDecoded.Location = new System.Drawing.Point(4, 50);
            this.radioButtonHistogramDecoded.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonHistogramDecoded.Name = "radioButtonHistogramDecoded";
            this.radioButtonHistogramDecoded.Size = new System.Drawing.Size(71, 17);
            this.radioButtonHistogramDecoded.TabIndex = 21;
            this.radioButtonHistogramDecoded.Text = "Decoded";
            this.radioButtonHistogramDecoded.UseVisualStyleBackColor = true;
            // 
            // radioButtonHistogramErrorMatrix
            // 
            this.radioButtonHistogramErrorMatrix.AutoSize = true;
            this.radioButtonHistogramErrorMatrix.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonHistogramErrorMatrix.Location = new System.Drawing.Point(4, 27);
            this.radioButtonHistogramErrorMatrix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonHistogramErrorMatrix.Name = "radioButtonHistogramErrorMatrix";
            this.radioButtonHistogramErrorMatrix.Size = new System.Drawing.Size(106, 17);
            this.radioButtonHistogramErrorMatrix.TabIndex = 20;
            this.radioButtonHistogramErrorMatrix.Text = "Error prediction";
            this.radioButtonHistogramErrorMatrix.UseVisualStyleBackColor = true;
            // 
            // radioButtonHistogramOriginal
            // 
            this.radioButtonHistogramOriginal.AutoSize = true;
            this.radioButtonHistogramOriginal.Checked = true;
            this.radioButtonHistogramOriginal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonHistogramOriginal.Location = new System.Drawing.Point(4, 4);
            this.radioButtonHistogramOriginal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonHistogramOriginal.Name = "radioButtonHistogramOriginal";
            this.radioButtonHistogramOriginal.Size = new System.Drawing.Size(67, 17);
            this.radioButtonHistogramOriginal.TabIndex = 19;
            this.radioButtonHistogramOriginal.TabStop = true;
            this.radioButtonHistogramOriginal.Text = "Original";
            this.radioButtonHistogramOriginal.UseVisualStyleBackColor = true;
            // 
            // numericUpDownHistogram
            // 
            this.numericUpDownHistogram.DecimalPlaces = 2;
            this.numericUpDownHistogram.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownHistogram.Location = new System.Drawing.Point(332, 485);
            this.numericUpDownHistogram.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownHistogram.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownHistogram.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHistogram.Name = "numericUpDownHistogram";
            this.numericUpDownHistogram.Size = new System.Drawing.Size(78, 23);
            this.numericUpDownHistogram.TabIndex = 16;
            this.numericUpDownHistogram.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonShowHistogram
            // 
            this.buttonShowHistogram.Location = new System.Drawing.Point(289, 514);
            this.buttonShowHistogram.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonShowHistogram.Name = "buttonShowHistogram";
            this.buttonShowHistogram.Size = new System.Drawing.Size(120, 27);
            this.buttonShowHistogram.TabIndex = 17;
            this.buttonShowHistogram.Text = "Show histogram";
            this.buttonShowHistogram.UseVisualStyleBackColor = true;
            this.buttonShowHistogram.Click += new System.EventHandler(this.buttonShowHistogram_Click);
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(417, 353);
            this.pictureBoxHistogram.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(512, 208);
            this.pictureBoxHistogram.TabIndex = 18;
            this.pictureBoxHistogram.TabStop = false;
            // 
            // numericUpDownAcceptedError
            // 
            this.numericUpDownAcceptedError.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownAcceptedError.Location = new System.Drawing.Point(110, 497);
            this.numericUpDownAcceptedError.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownAcceptedError.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAcceptedError.Name = "numericUpDownAcceptedError";
            this.numericUpDownAcceptedError.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownAcceptedError.TabIndex = 19;
            this.numericUpDownAcceptedError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAcceptedError.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 498);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Accepted error";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(5, 526);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Domain min value";
            // 
            // numericUpDownDomainMinValue
            // 
            this.numericUpDownDomainMinValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownDomainMinValue.Location = new System.Drawing.Point(110, 525);
            this.numericUpDownDomainMinValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownDomainMinValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDomainMinValue.Name = "numericUpDownDomainMinValue";
            this.numericUpDownDomainMinValue.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownDomainMinValue.TabIndex = 21;
            this.numericUpDownDomainMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(5, 546);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Domain max value";
            // 
            // numericUpDownDomainMaxValue
            // 
            this.numericUpDownDomainMaxValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownDomainMaxValue.Increment = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.numericUpDownDomainMaxValue.Location = new System.Drawing.Point(110, 545);
            this.numericUpDownDomainMaxValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownDomainMaxValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDomainMaxValue.Name = "numericUpDownDomainMaxValue";
            this.numericUpDownDomainMaxValue.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownDomainMaxValue.TabIndex = 23;
            this.numericUpDownDomainMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDomainMaxValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // panelSaveModeSelection
            // 
            this.panelSaveModeSelection.Controls.Add(this.radioButtonSaveModeArithmetic);
            this.panelSaveModeSelection.Controls.Add(this.radioButtonSaveModeJpegTable);
            this.panelSaveModeSelection.Controls.Add(this.radioButtonSaveMode9Bits);
            this.panelSaveModeSelection.Controls.Add(this.label8);
            this.panelSaveModeSelection.Location = new System.Drawing.Point(183, 353);
            this.panelSaveModeSelection.Name = "panelSaveModeSelection";
            this.panelSaveModeSelection.Size = new System.Drawing.Size(108, 102);
            this.panelSaveModeSelection.TabIndex = 25;
            // 
            // radioButtonSaveModeArithmetic
            // 
            this.radioButtonSaveModeArithmetic.AutoSize = true;
            this.radioButtonSaveModeArithmetic.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonSaveModeArithmetic.Location = new System.Drawing.Point(11, 77);
            this.radioButtonSaveModeArithmetic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonSaveModeArithmetic.Name = "radioButtonSaveModeArithmetic";
            this.radioButtonSaveModeArithmetic.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSaveModeArithmetic.TabIndex = 24;
            this.radioButtonSaveModeArithmetic.Text = "Arithmetic";
            this.radioButtonSaveModeArithmetic.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveModeJpegTable
            // 
            this.radioButtonSaveModeJpegTable.AutoSize = true;
            this.radioButtonSaveModeJpegTable.Checked = true;
            this.radioButtonSaveModeJpegTable.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonSaveModeJpegTable.Location = new System.Drawing.Point(11, 54);
            this.radioButtonSaveModeJpegTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonSaveModeJpegTable.Name = "radioButtonSaveModeJpegTable";
            this.radioButtonSaveModeJpegTable.Size = new System.Drawing.Size(79, 17);
            this.radioButtonSaveModeJpegTable.TabIndex = 23;
            this.radioButtonSaveModeJpegTable.TabStop = true;
            this.radioButtonSaveModeJpegTable.Text = "JPEG Table";
            this.radioButtonSaveModeJpegTable.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveMode9Bits
            // 
            this.radioButtonSaveMode9Bits.AutoSize = true;
            this.radioButtonSaveMode9Bits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonSaveMode9Bits.Location = new System.Drawing.Point(11, 31);
            this.radioButtonSaveMode9Bits.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonSaveMode9Bits.Name = "radioButtonSaveMode9Bits";
            this.radioButtonSaveMode9Bits.Size = new System.Drawing.Size(53, 17);
            this.radioButtonSaveMode9Bits.TabIndex = 22;
            this.radioButtonSaveMode9Bits.Text = "9 bits";
            this.radioButtonSaveMode9Bits.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(1, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Save mode";
            // 
            // NearLosslessPredictorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelSaveModeSelection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownDomainMaxValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownDomainMinValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownAcceptedError);
            this.Controls.Add(this.pictureBoxHistogram);
            this.Controls.Add(this.buttonShowHistogram);
            this.Controls.Add(this.numericUpDownHistogram);
            this.Controls.Add(this.panelHistogramSelection);
            this.Controls.Add(this.panelImagePredictorSelection);
            this.Controls.Add(this.buttonSaveDecoded);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonLoadEncodedImage);
            this.Controls.Add(this.buttonShowErrorMatrix);
            this.Controls.Add(this.numericUpDownErrorMatrixScale);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.buttonPredict);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxDecodedImage);
            this.Controls.Add(this.pictureBoxErrorMatrix);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NearLosslessPredictorUserControl";
            this.Size = new System.Drawing.Size(933, 577);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorMatrixScale)).EndInit();
            this.panelImagePredictorSelection.ResumeLayout(false);
            this.panelImagePredictorSelection.PerformLayout();
            this.panelHistogramSelection.ResumeLayout(false);
            this.panelHistogramSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAcceptedError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomainMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDomainMaxValue)).EndInit();
            this.panelSaveModeSelection.ResumeLayout(false);
            this.panelSaveModeSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxErrorMatrix;
        private System.Windows.Forms.PictureBox pictureBoxDecodedImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonPredict;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.NumericUpDown numericUpDownErrorMatrixScale;
        private System.Windows.Forms.Button buttonShowErrorMatrix;
        private System.Windows.Forms.Button buttonSaveDecoded;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonLoadEncodedImage;
        private System.Windows.Forms.Panel panelImagePredictorSelection;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor7;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor6;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor5;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor4;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor3;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor2;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor1;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor0;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor8;
        private System.Windows.Forms.Panel panelHistogramSelection;
        private System.Windows.Forms.RadioButton radioButtonHistogramDecoded;
        private System.Windows.Forms.RadioButton radioButtonHistogramErrorMatrix;
        private System.Windows.Forms.RadioButton radioButtonHistogramOriginal;
        private System.Windows.Forms.NumericUpDown numericUpDownHistogram;
        private System.Windows.Forms.Button buttonShowHistogram;
        private System.Windows.Forms.PictureBox pictureBoxHistogram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownAcceptedError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDomainMinValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownDomainMaxValue;
        private System.Windows.Forms.Panel panelSaveModeSelection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonSaveMode9Bits;
        private System.Windows.Forms.RadioButton radioButtonSaveModeJpegTable;
        private System.Windows.Forms.RadioButton radioButtonSaveModeArithmetic;
    }
}
