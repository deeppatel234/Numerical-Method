using NSM.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
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
    public sealed partial class Secant_Method_Calcualtion : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Secant_Method_Calcualtion()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            if (Settings_Class.themeon == 0)
            {
                this.RequestedTheme = ElementTheme.Dark;
                lines.Stroke = new SolidColorBrush(Colors.White);
            }

            if (Settings_Class.themeon == 1)
            {
                this.RequestedTheme = ElementTheme.Light;
                lines.Stroke = new SolidColorBrush(Colors.Black);
            }

            double X = 0;
            int temp = 0;
            double matchAns = 12345;
            int i = 0;

            TextBlock printx = new TextBlock();
            printx.FontSize = 25;
            TextBlock ans = new TextBlock();
            ans.FontSize = 25;
         

         
            int n = 0;

            printx.Text = Environment.NewLine + "here x0 = " + BisectionMethod_Class.secx[0] + " and x1 = " + BisectionMethod_Class.secx[1] + Environment.NewLine;

            printpanal.Children.Add(printx);

            if (BisectionMethod_Class.fixinteration != 0)
            {
                for (int j = 0; j < BisectionMethod_Class.fixinteration; j++)
                {
                    TextBlock steps = new TextBlock();
                    
                    steps.FontSize = 25;

                    if (temp == 0)
                    {
                        steps.Text = "For n = " + (n + 1) + Environment.NewLine + "          x2 = " + BisectionMethod_Class.secx[i + 1] + " - (" + Function(BisectionMethod_Class.secx[i + 1]) + " * " +
                               " ( " + BisectionMethod_Class.secx[i] + " - " + BisectionMethod_Class.secx[i + 1] + " ) / ( " + Function(BisectionMethod_Class.secx[i]) + " - " + Function(BisectionMethod_Class.secx[i + 1]) + " ))";

                        X = BisectionMethod_Class.secx[i + 1] - (Function(BisectionMethod_Class.secx[i + 1]) *
                            ((BisectionMethod_Class.secx[i] - BisectionMethod_Class.secx[i + 1]) / (Function(BisectionMethod_Class.secx[i]) - Function(BisectionMethod_Class.secx[i + 1]))));
                        X = Math.Round(X, BisectionMethod_Class.fixdecimal);
                        BisectionMethod_Class.secx[2] = X;

                        steps.Text += Environment.NewLine + "          x2 = " + X + Environment.NewLine;
                        i++;
                        temp = 1;
                    }
                    else
                    {
                        steps.Text = "For n = " + (n + 1) + Environment.NewLine + "          x" + (n + 2) + " = " + BisectionMethod_Class.secx[i + 1] + " - (" + Function(BisectionMethod_Class.secx[i + 1]) + " * " +
                          " ( " + BisectionMethod_Class.secx[i] + " - " + BisectionMethod_Class.secx[i + 1] + " ) / ( " + Function(BisectionMethod_Class.secx[i]) + " - " + Function(BisectionMethod_Class.secx[i + 1]) + " ))";

                        X = BisectionMethod_Class.secx[i + 1] - (Function(BisectionMethod_Class.secx[i + 1]) *
                            ((BisectionMethod_Class.secx[i] - BisectionMethod_Class.secx[i + 1]) / (Function(BisectionMethod_Class.secx[i]) - Function(BisectionMethod_Class.secx[i + 1]))));
                        X = Math.Round(X, BisectionMethod_Class.fixdecimal);
                        BisectionMethod_Class.secx[i + 2] = X;
                        steps.Text += Environment.NewLine + "          x" + (n + 2) + " = " + X + Environment.NewLine;
                        i++;
                    }

                    printpanal.Children.Add(steps);

                    n++;
                }
            }
            else
            {
                int errorint = 0;
                while(1 == 1)
                {
                    if (errorint == 150)
                    {
                        error();
                        break;
                    }

                    TextBlock steps = new TextBlock();
                    
                    steps.FontSize = 25 ;

                    if (temp == 0)
                    {
                        steps.Text = "For n = " + (n + 1) + Environment.NewLine + "          x2 = " + BisectionMethod_Class.secx[i + 1] + " - (" + Function(BisectionMethod_Class.secx[i + 1]) + " * " +
                               " ( " + BisectionMethod_Class.secx[i] + " - " + BisectionMethod_Class.secx[i + 1] + " ) / ( " + Function(BisectionMethod_Class.secx[i]) + " - " + Function(BisectionMethod_Class.secx[i + 1]) + " ))";
                                               
                        X = BisectionMethod_Class.secx[i + 1] - (Function(BisectionMethod_Class.secx[i + 1]) *
                            ((BisectionMethod_Class.secx[i] - BisectionMethod_Class.secx[i + 1]) / (Function(BisectionMethod_Class.secx[i]) - Function(BisectionMethod_Class.secx[i + 1]))));
                        X = Math.Round(X, BisectionMethod_Class.fixdecimal);
                        BisectionMethod_Class.secx[2] = X;

                        steps.Text += Environment.NewLine + "          x2 = " + X + Environment.NewLine;
                        i++;
                        temp = 1;
                    }
                    else
                    {
                             steps.Text = "For n = " + (n + 1) + Environment.NewLine + "          x"+ (n+2) +" = " + BisectionMethod_Class.secx[i + 1] + " - (" + Function(BisectionMethod_Class.secx[i + 1]) + " * " +
                               " ( " + BisectionMethod_Class.secx[i] + " - " + BisectionMethod_Class.secx[i + 1] + " ) / ( " + Function(BisectionMethod_Class.secx[i]) + " - " + Function(BisectionMethod_Class.secx[i + 1]) + " ))";
                   
                        X = BisectionMethod_Class.secx[i + 1] - (Function(BisectionMethod_Class.secx[i + 1]) *
                            ((BisectionMethod_Class.secx[i] - BisectionMethod_Class.secx[i + 1]) / (Function(BisectionMethod_Class.secx[i]) - Function(BisectionMethod_Class.secx[i + 1]))));
                        X = Math.Round(X, BisectionMethod_Class.fixdecimal);
                        BisectionMethod_Class.secx[i + 2] = X;
                        steps.Text += Environment.NewLine + "          x"+ (n+2) + " = " + X + Environment.NewLine;
                        i++;
                    }

                    printpanal.Children.Add(steps);

                    if (matchAns == X)
                    {
                        break;
                    }

                    matchAns = X;
                    n++;
                    errorint++;
                }
            }

            ans.FontSize = 25;
            ans.Text = "                  Ans = " + X;
            printpanal.Children.Add(ans);
        }

        private double Function(double temppass)
        {
            double ans = 0;
            double tempans = 0;

            for (int i = 0; i < BisectionMethod_Class.terms; i++)
            {
                if (BisectionMethod_Class.X[i] == "sinx" || BisectionMethod_Class.X[i] == "Sinx" || BisectionMethod_Class.X[i] == "SINX")
                {
                    ans = Convert.ToDouble(Math.Sin(temppass));
                    ans = Math.Pow(ans, Convert.ToDouble(BisectionMethod_Class.Power[i]));
                    ans = Convert.ToDouble(BisectionMethod_Class.coeffi[i]) * ans;
                    tempans += ans;
                }
                else if (BisectionMethod_Class.X[i] == "-sinx" || BisectionMethod_Class.X[i] == "-Sinx" || BisectionMethod_Class.X[i] == "-SINX")
                {
                    ans = Convert.ToDouble(Math.Sin(temppass));
                    ans = -1 * ans;
                    ans = Math.Pow(ans, Convert.ToDouble(BisectionMethod_Class.Power[i]));
                    ans = Convert.ToDouble(BisectionMethod_Class.coeffi[i]) * ans;
                    tempans += ans;
                }
                else if (BisectionMethod_Class.X[i] == "cosx" || BisectionMethod_Class.X[i] == "Cosx" || BisectionMethod_Class.X[i] == "COSX")
                {
                    ans = Convert.ToDouble(Math.Cos(temppass));
                    ans = Math.Pow(ans, Convert.ToDouble(BisectionMethod_Class.Power[i]));
                    ans = Convert.ToDouble(BisectionMethod_Class.coeffi[i]) * ans;
                    tempans += ans;
                }
                else if (BisectionMethod_Class.X[i] == "-cosx" || BisectionMethod_Class.X[i] == "-Cosx" || BisectionMethod_Class.X[i] == "-COSX")
                {
                    ans = Convert.ToDouble(Math.Cos(temppass));
                    ans = -1 * ans;
                    ans = Math.Pow(ans, Convert.ToDouble(BisectionMethod_Class.Power[i]));
                    ans = Convert.ToDouble(BisectionMethod_Class.coeffi[i]) * ans;
                    tempans += ans;
                }
                else if (BisectionMethod_Class.X[i] == "X" || BisectionMethod_Class.X[i] == "x")
                {
                    ans = Math.Pow(temppass, Convert.ToDouble(BisectionMethod_Class.Power[i]));
                    ans = Convert.ToDouble(BisectionMethod_Class.coeffi[i]) * ans;
                    tempans += ans;
                }
                else
                {
                    tempans += Convert.ToDouble(BisectionMethod_Class.coeffi[i]);
                }
            }
            return Math.Round(tempans, BisectionMethod_Class.fixdecimal);
        }

        private async void error()
        {
            var dialog = new MessageDialog("Answer is not find until 150 Iterations so fix the Iterations");
            dialog.Title = "Error";
            dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(Secant_Method));
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
    }
}
