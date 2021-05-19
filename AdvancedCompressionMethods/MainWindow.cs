using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using AdvancedCompressionMethods.UserControls;

namespace AdvancedCompressionMethods
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private UserControl activeUserControl;
        private Dictionary<RadioButton, UserControl> userControlsRadioButtonsDictionary;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUserControlsRadioButtonsDictionary();

            foreach (var radioButton in panelRadioButtons.Controls.OfType<RadioButton>())
            {
                radioButton.CheckedChanged += RadioButtonOnCheckedChanged;
            }
        }

        private void RadioButtonOnCheckedChanged(object? sender, EventArgs e)
        {
            var checkedRadioButton = panelRadioButtons
                .Controls
                .OfType<RadioButton>()
                .First(x => x.Checked);

            activeUserControl = userControlsRadioButtonsDictionary[checkedRadioButton];
            
            panelActiveUserControl.Controls.Clear();
            panelActiveUserControl.Controls.Add(activeUserControl);
        }

        private void InitializeUserControlsRadioButtonsDictionary()
        {
            userControlsRadioButtonsDictionary = new Dictionary<RadioButton, UserControl>
            {
                {radioButtonArithmeticCoding, new UserControl()},
                {radioButtonNearLossless, new NearLosslessPredictorUserControl()},
                {radioButtonFractalImageCoder, new UserControl()},
                {radioButtonWaveletDecomposition, new UserControl()}
            };
        }
    }
}
