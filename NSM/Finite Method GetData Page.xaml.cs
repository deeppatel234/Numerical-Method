using NSM.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NSM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Finite_Method_GetData_Page : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Finite_Method_GetData_Page()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            if (Finite_Method_GetData_Class.method == "LagrangesMethod")
            {
                MethodName.Text = "Lagrang's Method";
                MethodName.FontSize = 45;
            }
            if (Finite_Method_GetData_Class.method == "NewtonForwardMethod")
            {
                MethodName.Text = "Newton Forward Method";
                MethodName.FontSize = 35;
            }
            if (Finite_Method_GetData_Class.method == "DividedDifferenceMethod")
            {
                MethodName.Text = "Divided Difference Method";
                MethodName.FontSize = 30;
            }
            if (Finite_Method_GetData_Class.method == "NewtonBackwardMethod")
            {
                MethodName.Text = "Newton Backward Method";
                MethodName.FontSize = 33;
            }
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion


        TextBlock[] printY = new TextBlock[50];
        TextBlock[] printX = new TextBlock[50];
        TextBox[] GetValuesY = new TextBox[50];
        TextBox[] GetValuesX = new TextBox[50];
        TextBox xValue = new TextBox();
        TextBox FixDecimal = new TextBox();
        
        int margin = 16;
        decimal d = 0;
        int error = 0;
        int abc = 0;

        private async void Enter_click(object sender, RoutedEventArgs e)
        {
            StackPanalPrintY.Children.Clear();
            StackPanalGetValuesY.Children.Clear();
            StackPanalGetValuesX.Children.Clear();
            StackPanalPrintX.Children.Clear();
            fixxstack.Children.Clear();
            xstack.Children.Clear();
            CalStack.Children.Clear();

            if (string.IsNullOrEmpty(NValue.Text) == true || int.TryParse(NValue.Text,out abc) == false)
            {
                var dialogs = new MessageDialog("Values is not will be null or invalid");
                dialogs.Title = "Invalid Values";
                dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var ress = await dialogs.ShowAsync();
             
            }
            else
            {
                    Finite_Method_GetData_Class.n = Convert.ToInt32(NValue.Text);
                    if (Finite_Method_GetData_Class.n <= 50 && Finite_Method_GetData_Class.n >= 1)
                    {
                        EnterValues.Text = "Enter Values";
                        x.Text = "X";
                        fx.Text = "F(X)";
                        xvalueprint.Text = "Enetr X Value :";
                        fixxvalueprint.Text = "Fix Decimal";
                        FixDecimal.Text = "4";

                        fixxstack.Children.Add(FixDecimal);
                        xstack.Children.Add(xValue);

                        for (int i = 0; i < Finite_Method_GetData_Class.n; i++)
                        {
                            printY[i] = new TextBlock();
                            printY[i].Text = "Y" + i + " :";
                            printY[i].FontSize = 30;
                            printY[i].HorizontalAlignment = HorizontalAlignment.Center;
                            printY[i].VerticalAlignment = VerticalAlignment.Center;
                            printY[i].Margin = new Thickness(0, margin, 0, 0);

                            GetValuesY[i] = new TextBox();
                            GetValuesY[i].Height = 25;
                            GetValuesY[i].Width = 100;

                            StackPanalPrintY.Children.Add(printY[i]);
                            StackPanalGetValuesY.Children.Add(GetValuesY[i]);
                        }

                        for (int j = 0; j < Finite_Method_GetData_Class.n; j++)
                        {
                            printX[j] = new TextBlock();
                            printX[j].Text = "X" + j + " :";
                            printX[j].FontSize = 30;
                            printX[j].HorizontalAlignment = HorizontalAlignment.Center;
                            printX[j].VerticalAlignment = VerticalAlignment.Center;
                            printX[j].Margin = new Thickness(0, margin, 0, 0);

                            GetValuesX[j] = new TextBox();
                            GetValuesX[j].Height = 25;
                            GetValuesX[j].Width = 100;

                            StackPanalPrintX.Children.Add(printX[j]);
                            StackPanalGetValuesX.Children.Add(GetValuesX[j]);
                        }

                        Button Calculate = new Button();
                        Calculate.Content = "Calculate";
                        Calculate.Click += Calculate_Click;
                        Calculate.HorizontalAlignment = HorizontalAlignment.Center;
                        Calculate.VerticalAlignment = VerticalAlignment.Center;
                        CalStack.Children.Add(Calculate);
                    }
                    else
                    {
                        var dialog = new MessageDialog("Enter Value N between 1 to 50");
                        dialog.Title = "Invalid Values";
                        dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var res = await dialog.ShowAsync();

                    }
            }
        }

        
        async void  Calculate_Click(object sender, RoutedEventArgs e)
        {
            error = 0;
            for (int l = 0; l < Finite_Method_GetData_Class.n; l++)
            {
                if (string.IsNullOrEmpty(GetValuesY[l].Text) == true || decimal.TryParse(GetValuesY[l].Text,out d) == false)
                {
                    error = 1;
                    break;
                }
                if (string.IsNullOrEmpty(GetValuesX[l].Text) == true || decimal.TryParse(GetValuesX[l].Text,out d) == false )
                {
                    error = 1;
                    break;
                }
            }

            if (string.IsNullOrEmpty(xValue.Text) == true || decimal.TryParse(xValue.Text, out d) == false)
            {
                error = 1;
            }

            if (string.IsNullOrEmpty(FixDecimal.Text) == true || int.TryParse(FixDecimal.Text, out abc) == false)
            {
                error = 1;
                
            }
            else
            {
                if (Convert.ToInt32(FixDecimal.Text) < 0)
                {
                    error = 1;
                }
            }

       
                        
            if (error == 1)
            {
                var dialogs = new MessageDialog("Values is not will be NULL or wrong");
                dialogs.Title = "Enter Values";
                dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var ress = await dialogs.ShowAsync();
            }
            else
            {
                   for (int h = 0; h < Finite_Method_GetData_Class.n; h++)
                    {
                        Finite_Method_GetData_Class.Y[h] = Convert.ToDecimal(GetValuesY[h].Text);
                        Finite_Method_GetData_Class.X[h] = Convert.ToDecimal(GetValuesX[h].Text);
                    }

                Finite_Method_GetData_Class.Fixdecimal = Convert.ToInt32(FixDecimal.Text);
                Finite_Method_GetData_Class.findx = Convert.ToDecimal(xValue.Text);

                if (Finite_Method_GetData_Class.method == "LagrangesMethod")
                {
                    this.Frame.Navigate(typeof(Lagranges_Method_Calculation));
                }
                if (Finite_Method_GetData_Class.method == "NewtonForwardMethod")
                {
                    this.Frame.Navigate(typeof(NewtonForwardMethod));
                }
                if (Finite_Method_GetData_Class.method == "NewtonBackwardMethod")
                {
                    this.Frame.Navigate(typeof(Newton_Backward_Method));
                }
            }
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            if (Finite_Method_GetData_Class.method == "LagrangesMethod")
            {
                NSM.Help.Help_Class.finite = "Lagrange Method";
                this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
            }
            if (Finite_Method_GetData_Class.method == "NewtonForwardMethod")
            {
                NSM.Help.Help_Class.finite = "Newton Forward Method";
                this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
            }
            if (Finite_Method_GetData_Class.method == "NewtonBackwardMethod")
            {
                NSM.Help.Help_Class.finite = "Newton Backward Method";
                this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
            }
        }
    }
}

