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
    public sealed partial class NumericalGetValuePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public NumericalGetValuePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            if (GetDataClass_Calss.MethodName == "Simson13Rule")
            {
                Method.Text = "Simson's 1/3 Method";
            }
            if(GetDataClass_Calss.MethodName == "Simpson38Rule")
            {
                Method.Text = "Simpson 3/8 Method";
            }
            if (GetDataClass_Calss.MethodName == "TrapezoidalRule")
            {
               Method.Text = "Trapezoidal Rule";
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
        TextBlock[] printX = new TextBlock[2];
        TextBox[] GetValuesY = new TextBox[50];
        TextBox[] GetValuesX = new TextBox[2];
        TextBox getfixvalue = new TextBox();

        int margin = 16;
        int abc = 0;

        private async void Enter_click(object sender, RoutedEventArgs e)
        {
            StackPanalPrint.Children.Clear();
            StackPanalGetValues.Children.Clear();
            CalcStack.Children.Clear();

            if (string.IsNullOrEmpty(NValue.Text) == false && int.TryParse(NValue.Text, out abc) == true)
            {
                    GetDataClass_Calss.n = Convert.ToInt32(NValue.Text);
                    if (GetDataClass_Calss.n <= 50 && GetDataClass_Calss.n >= 1)
                    {

                        EnterValues.Text = "Enter Values";

                        GetValuesX[0] = new TextBox();
                        GetValuesX[0].Height = 25;
                        StackPanalGetValues.Children.Add(GetValuesX[0]);
                        GetValuesX[1] = new TextBox();
                        GetValuesX[1].Height = 25;
                        StackPanalGetValues.Children.Add(GetValuesX[1]);

                        printX[0] = new TextBlock();
                        printX[0].Text = "X0  :";
                        printX[0].FontSize = 30;
                        printX[0].Margin = new Thickness(0, margin - 10, 0, 0);

                        printX[0].HorizontalAlignment = HorizontalAlignment.Center;
                        printX[0].VerticalAlignment = VerticalAlignment.Center;
                        StackPanalPrint.Children.Add(printX[0]);



                        printX[1] = new TextBlock();
                        printX[1].Text = "X1  :";
                        printX[1].FontSize = 30;
                        printX[1].Margin = new Thickness(0, margin, 0, 0);
                        printX[1].HorizontalAlignment = HorizontalAlignment.Center;
                        printX[1].VerticalAlignment = VerticalAlignment.Center;
                        StackPanalPrint.Children.Add(printX[1]);



                        for (int i = 0; i < GetDataClass_Calss.n; i++)
                        {
                            printY[i] = new TextBlock();
                            printY[i].Text = "Y" + i + "  :";
                            printY[i].FontSize = 30;
                            printY[i].HorizontalAlignment = HorizontalAlignment.Center;
                            printY[i].VerticalAlignment = VerticalAlignment.Center;
                            printY[i].Margin = new Thickness(0, margin, 0, 0);

                            GetValuesY[i] = new TextBox();
                            GetValuesY[i].Height = 25;

                            StackPanalPrint.Children.Add(printY[i]);
                            StackPanalGetValues.Children.Add(GetValuesY[i]);
                        }

                        TextBlock fixblock = new TextBlock();

                        fixblock.Text = "Fix Decimals : ";
                        fixblock.FontSize = 30;
                        fixblock.HorizontalAlignment = HorizontalAlignment.Center;
                        fixblock.VerticalAlignment = VerticalAlignment.Center;
                        fixblock.Margin = new Thickness(0, margin, 0, 0);

                        getfixvalue.Height = 25;
                        getfixvalue.Text = "4";

                        StackPanalPrint.Children.Add(fixblock);
                        StackPanalGetValues.Children.Add(getfixvalue);

                        Button Calculate = new Button();
                        Calculate.Content = "Calculate";
                        Calculate.Click += Calculate_Click;
                        Calculate.HorizontalAlignment = HorizontalAlignment.Center;
                        Calculate.VerticalAlignment = VerticalAlignment.Center;
                        CalcStack.Children.Add(Calculate);
                    }
                    else
                    {
                        var dialog = new MessageDialog("Enter Value N between 1 to 50");
                        dialog.Title = "Invalid Value";
                        dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var res = await dialog.ShowAsync();
                    }
            }
            else
            {
                var dialog = new MessageDialog("Values is not null on invalid");
                dialog.Title = "Invalid Value";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();
            }
        }

        int error = 0;
        decimal d = 0;
        async void  Calculate_Click(object sender, RoutedEventArgs e)
        {
            error = 0;
            for (int j = 0; j < GetDataClass_Calss.n; j++)
            {
                if (string.IsNullOrEmpty(GetValuesY[j].Text) == true || decimal.TryParse(GetValuesY[j].Text,out d) == false)
                {
                    error = 1;
                    break;
                }
            }

            if (string.IsNullOrEmpty(GetValuesX[0].Text) == true || decimal.TryParse(GetValuesX[0].Text, out d) == false ||
                string.IsNullOrEmpty(GetValuesX[1].Text) == true || decimal.TryParse(GetValuesX[1].Text,out d) == false ||
                string.IsNullOrEmpty(getfixvalue.Text) == true || int.TryParse(getfixvalue.Text,out abc) == false)
            {
                error = 1;
            }
            else
            {
                if(Convert.ToInt32(getfixvalue.Text) < 0)
                {
                    error = 1;
                }
            }
            
            
            if (error == 1)
            {
                var dialogs = new MessageDialog("Values is not will be NULL or invelid");
                dialogs.Title = "Invalid Values";
                dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var ress = await dialogs.ShowAsync();
                error = 0;
            }
            else
            {
                if (error == 0)
                {
                    GetDataClass_Calss.fixdecimal = Convert.ToInt32(getfixvalue.Text);
                    GetDataClass_Calss.ValuesX[0] = Convert.ToDecimal(GetValuesX[0].Text);
                    GetDataClass_Calss.ValuesX[1] = Convert.ToDecimal(GetValuesX[1].Text);

                    for (int j = 0; j < GetDataClass_Calss.n; j++)
                    {
                        GetDataClass_Calss.ValuesY[j] = Convert.ToDecimal(GetValuesY[j].Text);
                    }

                    if (GetDataClass_Calss.MethodName == "Simson13Rule")
                    {
                        this.Frame.Navigate(typeof(Simsons13RuleCalculation));
                    }
                    if (GetDataClass_Calss.MethodName == "Simpson38Rule")
                    {
                        this.Frame.Navigate(typeof(Simpson38RuleMethod));
                    }
                    if (GetDataClass_Calss.MethodName == "TrapezoidalRule")
                    {
                        this.Frame.Navigate(typeof(TrapezoidalRule));
                    }
                }
            }
        
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            if (GetDataClass_Calss.MethodName == "Simson13Rule")
            {
                NSM.Help.Help_Class.numerical = "Simpson's 1/3 Method";
                this.Frame.Navigate(typeof(NSM.Help.Trap_Help));   
            }
            if (GetDataClass_Calss.MethodName == "Simpson38Rule")
            {
                NSM.Help.Help_Class.numerical = "Simpson's 3/8 Method";
                this.Frame.Navigate(typeof(NSM.Help.Trap_Help));
            }
            if (GetDataClass_Calss.MethodName == "TrapezoidalRule")
            {
                NSM.Help.Help_Class.numerical = "Trapezoidal Method";
                this.Frame.Navigate(typeof(NSM.Help.Trap_Help));
               
            }
        }
    }
}
