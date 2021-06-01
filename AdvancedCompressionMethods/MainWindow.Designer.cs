
namespace AdvancedCompressionMethods
{
    partial class MainWindow
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
            this.panelRadioButtons = new System.Windows.Forms.Panel();
            this.radioButtonWaveletDecomposition = new System.Windows.Forms.RadioButton();
            this.radioButtonFractalImageCoder = new System.Windows.Forms.RadioButton();
            this.radioButtonNearLossless = new System.Windows.Forms.RadioButton();
            this.radioButtonArithmeticCoding = new System.Windows.Forms.RadioButton();
            this.panelActiveUserControl = new System.Windows.Forms.Panel();
            this.panelRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRadioButtons
            // 
            this.panelRadioButtons.Controls.Add(this.radioButtonWaveletDecomposition);
            this.panelRadioButtons.Controls.Add(this.radioButtonFractalImageCoder);
            this.panelRadioButtons.Controls.Add(this.radioButtonNearLossless);
            this.panelRadioButtons.Controls.Add(this.radioButtonArithmeticCoding);
            this.panelRadioButtons.Location = new System.Drawing.Point(12, 12);
            this.panelRadioButtons.Name = "panelRadioButtons";
            this.panelRadioButtons.Size = new System.Drawing.Size(150, 500);
            this.panelRadioButtons.TabIndex = 0;
            // 
            // radioButtonWaveletDecomposition
            // 
            this.radioButtonWaveletDecomposition.AutoSize = true;
            this.radioButtonWaveletDecomposition.Location = new System.Drawing.Point(10, 144);
            this.radioButtonWaveletDecomposition.Name = "radioButtonWaveletDecomposition";
            this.radioButtonWaveletDecomposition.Size = new System.Drawing.Size(67, 19);
            this.radioButtonWaveletDecomposition.TabIndex = 3;
            this.radioButtonWaveletDecomposition.TabStop = true;
            this.radioButtonWaveletDecomposition.Text = "Wavelet";
            this.radioButtonWaveletDecomposition.UseVisualStyleBackColor = true;
            // 
            // radioButtonFractalImageCoder
            // 
            this.radioButtonFractalImageCoder.AutoSize = true;
            this.radioButtonFractalImageCoder.Location = new System.Drawing.Point(10, 109);
            this.radioButtonFractalImageCoder.Name = "radioButtonFractalImageCoder";
            this.radioButtonFractalImageCoder.Size = new System.Drawing.Size(93, 19);
            this.radioButtonFractalImageCoder.TabIndex = 2;
            this.radioButtonFractalImageCoder.TabStop = true;
            this.radioButtonFractalImageCoder.Text = "Fractal coder";
            this.radioButtonFractalImageCoder.UseVisualStyleBackColor = true;
            // 
            // radioButtonNearLossless
            // 
            this.radioButtonNearLossless.AutoSize = true;
            this.radioButtonNearLossless.Location = new System.Drawing.Point(10, 72);
            this.radioButtonNearLossless.Name = "radioButtonNearLossless";
            this.radioButtonNearLossless.Size = new System.Drawing.Size(95, 19);
            this.radioButtonNearLossless.TabIndex = 1;
            this.radioButtonNearLossless.TabStop = true;
            this.radioButtonNearLossless.Text = "Near Lossless";
            this.radioButtonNearLossless.UseVisualStyleBackColor = true;
            // 
            // radioButtonArithmeticCoding
            // 
            this.radioButtonArithmeticCoding.AutoSize = true;
            this.radioButtonArithmeticCoding.Location = new System.Drawing.Point(10, 36);
            this.radioButtonArithmeticCoding.Name = "radioButtonArithmeticCoding";
            this.radioButtonArithmeticCoding.Size = new System.Drawing.Size(123, 19);
            this.radioButtonArithmeticCoding.TabIndex = 0;
            this.radioButtonArithmeticCoding.TabStop = true;
            this.radioButtonArithmeticCoding.Text = "Arithmetic Coding";
            this.radioButtonArithmeticCoding.UseVisualStyleBackColor = true;
            // 
            // panelActiveUserControl
            // 
            this.panelActiveUserControl.Location = new System.Drawing.Point(182, 12);
            this.panelActiveUserControl.Name = "panelActiveUserControl";
            this.panelActiveUserControl.Size = new System.Drawing.Size(1280, 720);
            this.panelActiveUserControl.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1479, 752);
            this.Controls.Add(this.panelActiveUserControl);
            this.Controls.Add(this.panelRadioButtons);
            this.Name = "MainWindow";
            this.Text = "Advanced Compression Methods";
            this.panelRadioButtons.ResumeLayout(false);
            this.panelRadioButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRadioButtons;
        private System.Windows.Forms.Panel panelActiveUserControl;
        private System.Windows.Forms.RadioButton radioButtonArithmeticCoding;
        private System.Windows.Forms.RadioButton radioButtonNearLossless;
        private System.Windows.Forms.RadioButton radioButtonFractalImageCoder;
        private System.Windows.Forms.RadioButton radioButtonWaveletDecomposition;
    }
}

