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
    public sealed partial class Secant_Method : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Secant_Method()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
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

        TextBox[] coeff = new TextBox[50];
        TextBox[] X = new TextBox[50];
        TextBox[] Power = new TextBox[50];
        TextBox fixdecivalue = new TextBox();
        TextBox fixintertionvalue = new TextBox();
        TextBox x0getvalues = new TextBox();
        TextBox x1getvalues = new TextBox();


        TextBlock[] tems = new TextBlock[50];
        TextBlock[] plusprint = new TextBlock[50];

        Button cal = new Button();


        int margin = 16;
        int toggletemp = 0;
        int toggleon = 1;
        int error = 0;


        private async void EnterButton_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TermsValue.Text) == false && char.IsDigit(TermsValue.Text, 0) == true)
            {
                if (0 < Convert.ToInt32(TermsValue.Text) && Convert.ToInt32(TermsValue.Text) < 50)
                {
                    fixdecistack.Children.Clear();
                    Toggalstack.Children.Clear();
                    termsprintStack.Children.Clear();
                    CoeffiStack.Children.Clear();
                    XStack.Children.Clear(); ;
                    PowerStack.Children.Clear();
                    plueStack.Children.Clear();
                    calstack.Children.Clear();
                    fixinterstack.Children.Clear();
                    FixInterationtext.Text = "";
                    toggleon = 1;
                    toggletemp = 0;

                    EnterValues.Text = "Enter Values : ";
                    Fixdeciaml.Text = "Fix Decimal";
                    fixdecivalue.Text = "4";
                    fixdecistack.Children.Add(fixdecivalue);

                    Coefficientblock.Text = "Coefficiant";
                    Xblock.Text = "X";
                    Powerblock.Text = "Power";

                    ToggleSwitch fixinttoggle = new ToggleSwitch();
                    fixinttoggle.Header = "Fix Iterations";
                    fixinttoggle.OnContent = "YES";
                    fixinttoggle.OffContent = "NO";
                    fixinttoggle.Toggled += ToggalSeitchevents;

                    Toggalstack.Children.Add(fixinttoggle);

                    cal.Content = "Calculate";
                    cal.HorizontalAlignment = HorizontalAlignment.Center;
                    cal.VerticalAlignment = VerticalAlignment.Center;
                    cal.Click += cal_Click;
                    calstack.Children.Add(cal);

                    x0value.Text = "x0 : ";
                    x1value.Text = "x1 : ";

                    x0getvalues.Width = 50;
                    x1getvalues.Width = 50;

                    x0Stack.Children.Add(x0getvalues);
                    x1Stack.Children.Add(x1getvalues);


                    BisectionMethod_Class.terms = Convert.ToInt32(TermsValue.Text);

                    for (int i = 0; i < BisectionMethod_Class.terms; i++)
                    {
                        coeff[i] = new TextBox();
                        X[i] = new TextBox();
                        Power[i] = new TextBox();

                        coeff[i].Height = 25;
                        X[i].Height = 25;
                        coeff[i].Width = 35;
                        Power[i].Height = 25;


                        if (i < BisectionMethod_Class.terms - 1)
                        {
                            X[i].Text = "x";
                        }
                        else
                        {
                            X[i].Text = "1";
                        }

                        tems[i] = new TextBlock();
                        tems[i].Text = "Term : " + (i + 1);
                        tems[i].Margin = new Thickness(0, margin, 0, 0);
                        tems[i].FontSize = 30;

                        if (i < BisectionMethod_Class.terms - 1)
                        {
                            plusprint[i] = new TextBlock();
                            plusprint[i].Text = "+";
                            plusprint[i].FontSize = 30;
                            plusprint[i].Margin = new Thickness(0, margin, 0, 0);
                            plueStack.Children.Add(plusprint[i]);
                        }

                        termsprintStack.Children.Add(tems[i]);
                        CoeffiStack.Children.Add(coeff[i]);
                        XStack.Children.Add(X[i]);
                        PowerStack.Children.Add(Power[i]);
                    }
                }
                else
                {
                    var dialogs = new MessageDialog("Value is between 1 to 50");
                    dialogs.Title = "Invalid Values";
                    dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var ress = await dialogs.ShowAsync();
                }

            }
            else
            {
                var dialogs = new MessageDialog("Value is not Set To null or wrong");
                dialogs.Title = "Invalid Values";
                dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var ress = await dialogs.ShowAsync();
            }
        }

        private void ToggalSeitchevents(object sender, RoutedEventArgs e)
        {
            if (toggletemp % 2 == 0)
            {
                FixInterationtext.Text = "Fix Value :";
                fixintertionvalue.Text = "";
                fixinterstack.Children.Add(fixintertionvalue);
                toggletemp++;
                toggleon = 0;
            }
            else
            {
                FixInterationtext.Text = " ";
                fixinterstack.Children.Clear();
                toggletemp++;
                toggleon = 1;
            }
        }

        decimal d = 0;

        private async void cal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(fixdecivalue.Text) == false && char.IsDigit(fixdecivalue.Text, 0) == true)
            {
                BisectionMethod_Class.fixdecimal = Convert.ToInt32(fixdecivalue.Text);
                error = 0;
                if (toggleon == 0)
                {
                    if (string.IsNullOrEmpty(fixintertionvalue.Text) == false && char.IsDigit(fixintertionvalue.Text, 0) == true)
                    {
                        BisectionMethod_Class.fixinteration = Convert.ToInt32(fixintertionvalue.Text);
                    }
                    else
                    {
                        var dialogs = new MessageDialog("Fix Iterations Value is not Set To null or wrong");
                        dialogs.Title = "Invalid Values";
                        dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var ress = await dialogs.ShowAsync();
                    }
                }

                if (string.IsNullOrEmpty(x0getvalues.Text) == true || string.IsNullOrEmpty(x1getvalues.Text) == true || decimal.TryParse(x0getvalues.Text, out d) == false
                    || decimal.TryParse(x1getvalues.Text, out d) == false)
                {
                    var dialogs = new MessageDialog("x0 and x1 Value is not Set To null or wrong");
                    dialogs.Title = "Invalid Values";
                    dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var ress = await dialogs.ShowAsync();
                    error = 1;
                }

                for (int i = 0; i < BisectionMethod_Class.terms; i++)
                {
                    if (string.IsNullOrEmpty(X[i].Text) == true || string.IsNullOrEmpty(Power[i].Text) == true || string.IsNullOrEmpty(coeff[i].Text) == true)
                    {
                        var dialogs = new MessageDialog("Value is not Set To null");
                        dialogs.Title = "Invalid Values";
                        dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var ress = await dialogs.ShowAsync();
                        error = 1;
                        break;
                    }

                    if (decimal.TryParse(coeff[i].Text, out d) == false || decimal.TryParse(Power[i].Text, out d) == false)
                    {
                        var dialogs = new MessageDialog("Enter Correct Value");
                        dialogs.Title = "Invalid Values";
                        dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var ress = await dialogs.ShowAsync();
                        error = 1;
                        break;
                    }
                }

                if (error == 0)
                {
                    BisectionMethod_Class.secx[0] = Convert.ToDouble(x0getvalues.Text);
                    BisectionMethod_Class.secx[1] = Convert.ToDouble(x1getvalues.Text);

                    for (int i = 0; i < BisectionMethod_Class.terms; i++)
                    {
                        BisectionMethod_Class.X[i] = X[i].Text;
                        BisectionMethod_Class.Power[i] = Power[i].Text;
                        BisectionMethod_Class.coeffi[i] = coeff[i].Text;
                    }
                    this.Frame.Navigate(typeof(Secant_Method_Calcualtion));
                }

            }
            else
            {
                var dialogs = new MessageDialog("Fix Decimal Value is not Set To null or wrong");
                dialogs.Title = "Invalid Values";
                dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var ress = await dialogs.ShowAsync();
            }
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
           NSM.Help.Help_Class.nonlenear = "Secant Method";
            this.Frame.Navigate(typeof(NSM.Help.bisection_Help));
        }

    }
}
