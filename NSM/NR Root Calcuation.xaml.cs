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
    public sealed partial class NR_Root_Calcuation : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public NR_Root_Calcuation()
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

            double leftValue = 0;
            double rightValue = 0;
            double X = 0 ;
            double matchans = 12345;

            double temp = BisectionMethod_Class.RootVal;
            int errorint = 0;

            TextBlock value = new TextBlock();
            value.Text = " To Find  √" + BisectionMethod_Class.RootVal + " , Let N = " + BisectionMethod_Class.RootVal +  Environment.NewLine;
            value.FontSize = 25;

            PrintStack.Children.Add(value);

            while(true)
            {
                if (errorint == 150)
                {
                    errorleft();
                    break;
                }

                temp--;
                if (Math.Pow(temp,2) < BisectionMethod_Class.RootVal)
                {
                    leftValue = temp;
                    break;
                }
            }
            
            rightValue = leftValue + 1;

            X = (leftValue + rightValue) / 2;

            TextBlock FIrstlastVal = new TextBlock();
            FIrstlastVal.FontSize = 25;
            FIrstlastVal.Text = "                         " + leftValue + " ≤  √" + BisectionMethod_Class.RootVal + " ≤ " + rightValue + Environment.NewLine;

            PrintStack.Children.Add(FIrstlastVal);

            int n = 0;
            TextBlock lies = new TextBlock();
            lies.FontSize = 25;
            lies.Text = " Root Lies Between " + leftValue + " & " + rightValue + Environment.NewLine + Environment.NewLine + 
                        "                      x0 = " + leftValue + " + " + rightValue + " / 2 = "  + X;

            PrintStack.Children.Add(lies);


            errorint = 0;
            while(1 == 1)
            {
                if(errorint == 150)
                {
                    error();
                    break;
                }

                TextBlock Print = new TextBlock();
                
                Print.FontSize = 25;
                Print.Text = "n = " + n + Environment.NewLine + "         x" + (n + 1) + "  =  (" + X + "² + " + BisectionMethod_Class.RootVal + " )  /  2 * " + X;
              
                X = (Math.Pow(X, 2) + BisectionMethod_Class.RootVal) / (2 * X);
                X = Math.Round(X,4);

                Print.Text += Environment.NewLine + "               = " + X;

                PrintStack.Children.Add(Print);
                n++;

                if(matchans == X)
                {
                    break;
                }
                matchans = X;
                errorint++;
            }

            TextBlock Ans = new TextBlock();
            Ans.FontSize = 25;
            Ans.Text = Environment.NewLine + "                  Root  √" + BisectionMethod_Class.RootVal + " = " +X;
            PrintStack.Children.Add(Ans);
        }

        private async void errorleft()
        {
            var dialog = new MessageDialog("check the value");
            dialog.Title = "Error";
            dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(NRRoots));
            }
        }

        private async void error()
        {
            var dialog = new MessageDialog("Answer is not find until 150 Iterations so fix the Iterations");
            dialog.Title = "Error";
            dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(NRRoots));
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
