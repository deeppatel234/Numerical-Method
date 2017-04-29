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
    public sealed partial class Lagranges_Method_Calculation : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Lagranges_Method_Calculation()
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


            decimal uans = 1;
            decimal uanstemp = 1;
            decimal dans = 1;
            decimal danstemp = 1;
            decimal finalans = 0;
            decimal finalanstemp = 0;

            string uansprint = "", dansprint = "", Step1print = "", Step2print = "", Step3print = "";

            int temp = 0;

            for(int d = 0; d < Finite_Method_GetData_Class.n ; d++)
            {
                for(int e = 0 ; e < Finite_Method_GetData_Class.n ; e++ )
                {
                    if(temp != e)
                    {
                        uans = (Finite_Method_GetData_Class.findx - Finite_Method_GetData_Class.X[e]);
                        uans = Math.Round(uans, Finite_Method_GetData_Class.Fixdecimal);

                        dans = (Finite_Method_GetData_Class.X[d] - Finite_Method_GetData_Class.X[e]);
                        dans = Math.Round(dans, Finite_Method_GetData_Class.Fixdecimal);
                        
                        uanstemp = uanstemp * uans;
                        uanstemp = Math.Round(uanstemp, Finite_Method_GetData_Class.Fixdecimal);

                        danstemp = danstemp * dans;
                        danstemp = Math.Round(danstemp, Finite_Method_GetData_Class.Fixdecimal);

                        uansprint = uansprint + " ( " + Finite_Method_GetData_Class.findx + " - " + Finite_Method_GetData_Class.X[e] + " )";
                        dansprint = dansprint + " ( " + Finite_Method_GetData_Class.X[d] + " - " + Finite_Method_GetData_Class.X[e] + " )";
                    }
                }
                
                finalans = (uanstemp / danstemp) * Finite_Method_GetData_Class.Y[d];
                finalans = Math.Round(finalans, Finite_Method_GetData_Class.Fixdecimal);

                finalanstemp = finalanstemp + finalans;
                finalanstemp = Math.Round(finalanstemp, Finite_Method_GetData_Class.Fixdecimal);

                if(temp > 0)
                {
                    Step1print += "     ";
                }
                Step1print += " ( " + uansprint + " / " + dansprint + " ) * " + Finite_Method_GetData_Class.Y[d];
                Step2print += " ( " + uanstemp + "  / " + danstemp + " ) * " + Finite_Method_GetData_Class.Y[d];
                Step3print += finalans;

                temp++;

                if (d < Finite_Method_GetData_Class.n - 1)
                {
                    uanstemp = 1;
                    danstemp = 1;
                    uansprint = null;
                    dansprint = null;
                    finalans = 0;
                    Step3print += " + " ;
                    Step2print += " + ";
                    Step1print += " + " + Environment.NewLine;
                }
            }

            TextBlock first = new TextBlock();
            TextBlock second = new TextBlock();
            TextBlock third = new TextBlock();
            TextBlock final = new TextBlock();
           

            first.Text = " = " + Step1print + Environment.NewLine;
            second.Text = " = " + Step2print + Environment.NewLine;
            third.Text = " = " + Step3print + Environment.NewLine;
            final.Text = " = " + finalanstemp + Environment.NewLine;

            first.FontSize = 25;
            second.FontSize = 25;
            third.FontSize = 25;
            final.FontSize = 25;
          
          
            PrtintStack.Children.Add(first);
            PrtintStack.Children.Add(second);
            PrtintStack.Children.Add(third);
            PrtintStack.Children.Add(final);

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
