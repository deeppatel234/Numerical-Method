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
    public sealed partial class NewtonForwardMethod : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public NewtonForwardMethod()
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


            decimal pValue = (Finite_Method_GetData_Class.findx - Finite_Method_GetData_Class.X[0]) / (Finite_Method_GetData_Class.X[1] - Finite_Method_GetData_Class.X[0]);

            decimal ans = 0,temp = 0;
            decimal[,] AlldeltaValues = new decimal[Finite_Method_GetData_Class.n,Finite_Method_GetData_Class.n];
            decimal[] delta = new decimal[Finite_Method_GetData_Class.n];

            // Set Two Dimentional Arrey Values Zero //

            for (int i = 0; i < Finite_Method_GetData_Class.n; i++)
            {
                for (int j = 0; j < Finite_Method_GetData_Class.n; j++)
                {
                    AlldeltaValues[i,j] = 0;
                }
            }

            // Finding the Differatiation of Y Values //
            
            for(int i=0 ; i<Finite_Method_GetData_Class.n - 1; i++)
            {
                for (int j = 0; j < Finite_Method_GetData_Class.n - 1; j++)
                {
                    if (temp == 0)
                    {
                        AlldeltaValues[i, j] = Finite_Method_GetData_Class.Y[j + 1] - Finite_Method_GetData_Class.Y[j];
                    }
                    else
                    {
                        AlldeltaValues[i,j] = AlldeltaValues[i-1,j+1] - AlldeltaValues[i-1,j];
                    }
                }
                temp++;
            }

          
            // Add Delta Values to Delta Arrey //

            for (int i = 0; i < Finite_Method_GetData_Class.n; i++)
            {
                   delta[i] = AlldeltaValues[i,0];
            }

            decimal[] p = new decimal[Finite_Method_GetData_Class.n];
            decimal tempp = 0;
            int fact = 0;
            decimal tempans = 0;
            string tempansprint = null;
            string[] pprint = new string[Finite_Method_GetData_Class.n];
            string pprinttemp = null;
           
            // Finding P Values //

            for(int i = 0; i < Finite_Method_GetData_Class.n - 1; i++)
            {
                p[i] = 1;
                for (int j = 0; j < i + 1; j++)
                {
                    tempp = (pValue - j);
                    pprinttemp = " ( " + pValue + " - " + j + " ) ";
                    pprint[i] += pprinttemp;
                    p[i] = p[i] * tempp;
                }
                pprinttemp = null;
            }

            ans = Finite_Method_GetData_Class.Y[0];

            // Solve Final Equation //

            for (int i = 0; i < Finite_Method_GetData_Class.n - 1; i++)
            {
                fact = factorial(i+1);
                tempans = (p[i] * delta[i]) / fact ;
                tempansprint +=  " + " + tempans;
                ans = ans + tempans;
            }



            TextBlock[] xValues = new TextBlock[Finite_Method_GetData_Class.n];
            TextBlock[] YValues = new TextBlock[Finite_Method_GetData_Class.n];
            TextBlock[] DeltaValues = new TextBlock[Finite_Method_GetData_Class.n];

            // Printing The Delta Values //

            for(int i = 0; i < Finite_Method_GetData_Class.n ; i++)
            {
                DeltaValues[i] = new TextBlock();
                DeltaValues[i].FontSize = 25;
                if(i == 0)
                {
                    DeltaValues[i].Text = "ΔY0 = " + Finite_Method_GetData_Class.Y[0];
                }
                else
                {
                    DeltaValues[i].Text = "ΔY0 ^ [" + i + "] = " + delta[i - 1];
                }

                DeltaStackpanal.Children.Add(DeltaValues[i]);
            }

            TextBlock Pprint = new TextBlock();
            TextBlock Hprint = new TextBlock();
            Pprint.FontSize = 25;
            Hprint.FontSize = 25;
            Hprint.Text = "   " + Environment.NewLine + " h  = ( x1 - x0 ) = " + Finite_Method_GetData_Class.X[1] + " - " + Finite_Method_GetData_Class.X[0] + " = " + (Finite_Method_GetData_Class.X[1] - Finite_Method_GetData_Class.X[0]) + Environment.NewLine + "   ";
            Pprint.Text = " p  = ( x - x0 ) / h  = " + " ( "+ Finite_Method_GetData_Class.findx + " - " + Finite_Method_GetData_Class.X[0] + " )  / " + (Finite_Method_GetData_Class.X[1] - Finite_Method_GetData_Class.X[0])
                            + " = " + ((Finite_Method_GetData_Class.findx - Finite_Method_GetData_Class.X[0]) / (Finite_Method_GetData_Class.X[1] - Finite_Method_GetData_Class.X[0])) + Environment.NewLine + "   ";
            printStack.Children.Add(Hprint);
            printStack.Children.Add(Pprint);

            TextBlock Step1 = new TextBlock();
            TextBlock Step2 = new TextBlock();
            TextBlock Step3 = new TextBlock();
            Step1.FontSize = 25;
            Step2.FontSize = 25;
            Step3.FontSize = 25;

            string step1tempprint = null;
            string step1print = null;

            // Printing the Equations //

            for (int i = 0; i < Finite_Method_GetData_Class.n - 1; i++ )
            {
                if (i > 0)
                {
                    step1print += "    ";
                }
                step1tempprint = " +" + pprint[i] + " * " + delta[i] + " / " + (i+1) + "!" + Environment.NewLine;
                step1print += step1tempprint;
           }


            Step1.Text = "Ans   = " + Finite_Method_GetData_Class.Y[0] + step1print + Environment.NewLine + "  ";
            Step2.Text = "      = " + Finite_Method_GetData_Class.Y[0] + tempansprint + Environment.NewLine + "  ";
            Step3.Text = "      = " + ans;

            printStack.Children.Add(Step1);
            printStack.Children.Add(Step2);
            printStack.Children.Add(Step3);

        }

        // Find Factorial of Value //
        private int factorial(int p)
        {
            int factans = 1;
            if(p == 1)
            {
                factans = 1;
            }
            else
            {
                for(int i = 1 ; i <= p  ; i++)
                {
                    factans = factans * i;
                }
            }
            return factans;
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
