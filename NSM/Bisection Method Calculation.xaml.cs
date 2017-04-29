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
    public sealed partial class Bisection_Method_Calculation : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();



        public Bisection_Method_Calculation()
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
            double temppass = 0;
            double Matchans = 0;
            double AnsFun = 0;

         

            int temp = 0;
            int index = 0;
            double firstsum = 0;
            double secondsum = 0;
            double finalans = 0;
            double tempFinalans = 0;
            double funans = 0;

            int errorint = 0;
           
            TextBlock put = new TextBlock();
            put.FontSize = 25;
            put.Text = " Put x = 0,1,2,3...... in Equation" + Environment.NewLine ;
            PrintStack.Children.Add(put);

            index = 0;

            if(BisectionMethod_Class.fixinteration != 0)
            {
                while(1 == 1)
                {
                    TextBlock a = new TextBlock();

                    if (errorint == 150)
                    {
                        errorx0();
                        break;
                    }

                    
                    Matchans = Func(temppass);
                    a.Text = "  ƒ(" + temppass + ") = " + Matchans;
                    a.FontSize = 25;
                    PrintStack.Children.Add(a);
                
                    if (temp == 0)
                    {
                        if (Matchans > 0)
                        {
                            temp = 1;
                        }
                        else
                        {
                            temp = 2;
                        }
                    }

                    if (temp == 2)
                    {
                        if (Matchans > 0 && AnsFun < 0)
                        {
                            break;
                        }
                        temppass++;
                    }
                    if (temp == 1)
                    {
                        if (Matchans < 0 && AnsFun > 0)
                        {
                            break;
                        }
                        temppass--;
                    }
                    AnsFun = Matchans;
                    errorint++;
                }


                if (temp == 2)
                {
                    firstsum = temppass - 1;
                    secondsum = temppass;
                }
                if (temp == 1)
                {
                    firstsum = temppass;
                    secondsum = temppass + 1;
                }

                index = 0;

                TextBlock lies = new TextBlock();
                lies.FontSize = 25;
                lies.Text = Environment.NewLine + " Root Lies Between " + firstsum + " & " + secondsum + Environment.NewLine +
                            "       x0 = " + firstsum + " + " + secondsum + " / 2 = " + ((firstsum+secondsum)/2) + Environment.NewLine;
                PrintStack.Children.Add(lies);

                for (int i = 0; i < BisectionMethod_Class.fixinteration; i++)
                {
                    finalans = (firstsum + secondsum) / 2;
                    TextBlock ans = new TextBlock();
                    ans.FontSize = 25;
                    ans.Text = " ƒ(" + finalans + ") = ";
                   

                  
                    finalans = Math.Round(finalans, BisectionMethod_Class.fixdecimal);
                    funans = Func(finalans);
                    funans = Math.Round(funans, BisectionMethod_Class.fixdecimal);
                    if (funans < 0)
                    {
                        firstsum = finalans;
                    }
                    else
                    {
                        secondsum = finalans;
                    }

                    ans.Text += funans + Environment.NewLine + " Root Lies Betwwen " + firstsum + " & " + secondsum + Environment.NewLine +
                                        "       X" + (index + 1) + " = " + firstsum + " + " + secondsum + " / 2 = " + Math.Round(((firstsum + secondsum) / 2), BisectionMethod_Class.fixdecimal) + Environment.NewLine;
                    PrintStack.Children.Add(ans);
                    index++;
                }

                TextBlock ansprint = new TextBlock();
                ansprint.FontSize = 25;
                ansprint.Text = "Real Root are = " + Math.Round(((firstsum + secondsum) / 2), BisectionMethod_Class.fixdecimal);
                PrintStack.Children.Add(ansprint);
            }
            else
            {
                errorint = 0;
                while (1 == 1)
                {
                    TextBlock a = new TextBlock();
                    
                    Matchans = Func(temppass);
                    a.Text = "  ƒ(" + temppass + ") = " + Matchans;
                    a.FontSize = 25;
                    PrintStack.Children.Add(a);

                    if (errorint == 150)
                    {
                        errorx0();
                        break;
                    }


                    if (temp == 0)
                    {
                        if (Matchans > 0)
                        {
                            temp = 1;
                        }
                        else
                        {
                            temp = 2;
                        }
                    }

                    if (temp == 2)
                    {
                        if (Matchans > 0 && AnsFun < 0)
                        {
                            break;
                        }
                        temppass++;
                    }
                    if (temp == 1)
                    {
                        if (Matchans < 0 && AnsFun > 0)
                        {
                            break;
                        }
                        temppass--;
                    }
                    AnsFun = Matchans;
                    errorint++;
                }


                if (temp == 2)
                {
                    firstsum = temppass - 1;
                    secondsum = temppass;
                }
                if (temp == 1)
                {
                    firstsum = temppass;
                    secondsum = temppass + 1;
                }

                index = 0;

                TextBlock lies = new TextBlock();
                lies.FontSize = 25;
                lies.Text = Environment.NewLine + " Root Lies Between " + firstsum + " & " + secondsum + Environment.NewLine +
                            "       x0 = " + firstsum + " + " + secondsum + " / 2 = " + ((firstsum + secondsum) / 2) + Environment.NewLine;
                PrintStack.Children.Add(lies);
                errorint = 0;
                while (1 == 1)
                {
                    TextBlock ans = new TextBlock();
                    finalans = (firstsum + secondsum) / 2;
                    ans = new TextBlock();
                    ans.FontSize = 25;
                    ans.Text = " ƒ(" + finalans + ") = ";

                    if (errorint == 150)
                    {
                        error();
                        break;
                    }

                    finalans = Math.Round(finalans, BisectionMethod_Class.fixdecimal);
                    funans = Func(finalans);
                    funans = Math.Round(funans, BisectionMethod_Class.fixdecimal);
                    if (funans < 0)
                    {
                        firstsum = finalans;
                    }
                    else
                    {
                        secondsum = finalans;
                    }

                    if (finalans == tempFinalans)
                    {
                        break;
                    }

                    tempFinalans = finalans;

                    ans.Text += funans + Environment.NewLine + " Root Lies Betwwen " + firstsum + " & " + secondsum + Environment.NewLine +
                                        "       X" + (index + 1) + " = " + firstsum + " + " + secondsum + " / 2 = " + Math.Round(((firstsum + secondsum) / 2), BisectionMethod_Class.fixdecimal) + Environment.NewLine;
                    PrintStack.Children.Add(ans);
                    index++;
                    errorint++;
                }

                TextBlock ansprint = new TextBlock();
                ansprint.FontSize = 25;
                ansprint.Text = "Real Root are = " + Math.Round(((firstsum + secondsum) / 2), BisectionMethod_Class.fixdecimal);
                PrintStack.Children.Add(ansprint);
            }
        }

        private async void errorx0()
        {
            var dialog = new MessageDialog("x0 is not found");
            dialog.Title = "Error";
            dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(BisectionMethod));
            }
        }

        private double Func(double temppass)
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
                return Math.Round(tempans,BisectionMethod_Class.fixdecimal);
        }

        private async void error()
        {
            var dialog = new MessageDialog("Answer is not find until 150 iterations so fix the iterations");
            dialog.Title = "Error";
            dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(BisectionMethod));
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
