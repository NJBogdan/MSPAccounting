using MSPAccounting.Data_Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for ErrorDisplay.xaml
    /// </summary>
    public partial class ErrorDisplay : Window
    {
        public ErrorDisplay(List<System.ComponentModel.DataAnnotations.ValidationResult> errors)
        {
            InitializeComponent();
            RenderErrors(errors);
        }

        private void RenderErrors(List<System.ComponentModel.DataAnnotations.ValidationResult> errors)
        {
            var errorString = "";
            foreach(var error in errors)
            {
                //Validating subclasses
                if (error is CompositeValidationResult)
                {
                    foreach (var subError in ((CompositeValidationResult)error).Results)
                    {
                        errorString += subError.ErrorMessage + System.Environment.NewLine;
                    }
                }
                else
                {
                    errorString += error.ErrorMessage + System.Environment.NewLine;
                }
            }
            errorString = errorString.Trim();

            ErrorList.Text = errorString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
