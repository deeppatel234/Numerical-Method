using NSM.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NSM.Help
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Help_Page : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Help_Page()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            storyBoard.Begin();
            
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

        int Finitetemp = 0;
        int numericaltemp = 0;
        int leneartemp = 0;
        int nonleneartemp = 0;

        private void Finite_Click(object sender, RoutedEventArgs e)
        {
            if (Finitetemp == 0)
            {
                Button forward = new Button();
                Button backward = new Button();
                Button lagrang = new Button();
                forward.Content = "   Newton's Forward Difference Method";
                backward.Content ="   Newton's Backward Difference Method";
                lagrang.Content = "   Lagrange's Ineterpolation Method";
                forward.Click += forward_Click;
                backward.Click += backward_Click;
                lagrang.Click += lagrang_Click;

                forward.Background = null;
                forward.BorderBrush = null;
                backward.Background = null;
                backward.BorderBrush = null;
                lagrang.Background = null;
                lagrang.BorderBrush = null;

                FiniteStack.Children.Add(forward);
                FiniteStack.Children.Add(backward);
                FiniteStack.Children.Add(lagrang);
                NumericalStack.Children.Clear();
                LenearStack.Children.Clear();
                NonlenearStack.Children.Clear();
                Finitetemp = 1;
                nonleneartemp = 0;
                leneartemp = 0;
                numericaltemp = 0;
            }
            else
            {
                FiniteStack.Children.Clear();
                nonleneartemp = 0;
                leneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            }
        }

        void lagrang_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.finite = "Lagrange Method";
            this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
        }

        void backward_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.finite = "Newton Backward Method";
            this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
        }

        void forward_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.finite = "Newton Forward Method";
            this.Frame.Navigate(typeof(NSM.Help.Finite_Help));
        }

        private void Numerical_click(object sender, RoutedEventArgs e)
        {
            if(numericaltemp == 0)
            {
                Button treap = new Button();
                Button simp13 = new Button();
                Button simp38 = new Button();
                Button wedd = new Button();
                treap.Content = "   Trapezoidal Rule";
                simp13.Content = "   Simpson's 1/3 Rule";
                simp38.Content = "   Simpson's 3/8 Rule";
                wedd.Content = "   Weddle's Rule";

                treap.Click += treap_Click;
                simp13.Click += simp13_Click;
                simp38.Click += simp38_Click;
                wedd.Click += wedd_Click;

                treap.Background = null;
                treap.BorderBrush = null;
                simp13.Background = null;
                simp13.BorderBrush = null;
                simp38.Background = null;
                simp38.BorderBrush = null;
                wedd.Background = null;
                wedd.BorderBrush = null;


                NumericalStack.Children.Add(treap);
                NumericalStack.Children.Add(simp13);
                NumericalStack.Children.Add(simp38);
                NumericalStack.Children.Add(wedd);

                FiniteStack.Children.Clear();
                LenearStack.Children.Clear();
                NonlenearStack.Children.Clear();
                numericaltemp = 1;
                nonleneartemp = 0;
                leneartemp = 0;
                Finitetemp = 0;
                
            }
            else
            {
                NumericalStack.Children.Clear();
                nonleneartemp = 0;
                leneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            }
        }

        void wedd_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NSM.Help.Wedd_Help));
        }

        void simp38_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.numerical = "Simpson's 3/8 Method";
            this.Frame.Navigate(typeof(NSM.Help.Trap_Help));
        }

        void simp13_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.numerical = "Simpson's 1/3 Method";
            this.Frame.Navigate(typeof(NSM.Help.Trap_Help));   
        }

        void treap_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.numerical = "Trapezoidal Method";
            this.Frame.Navigate(typeof(NSM.Help.Trap_Help));
        }

        private void Lenear_click(object sender, RoutedEventArgs e)
        {
            if(leneartemp == 0)
            {
                Button jacobi = new Button();
                Button seidal = new Button();
                Button power = new Button();
                jacobi.Content = "   Gauss - Jacobi Method";
                seidal.Content = "   Gauss - Seidal Method";
                power.Content = "   Power Method";

                jacobi.Click += jacobi_Click;
                seidal.Click += seidal_Click;
                power.Click += power_Click;

                jacobi.Background = null;
                jacobi.BorderBrush = null;
                seidal.Background = null;
                seidal.BorderBrush = null;
                power.Background = null;
                power.BorderBrush = null;

                LenearStack.Children.Add(jacobi);
                LenearStack.Children.Add(seidal);
                LenearStack.Children.Add(power);
               
                FiniteStack.Children.Clear();
                NumericalStack.Children.Clear();
                NonlenearStack.Children.Clear();
                leneartemp = 1;
                nonleneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            
            }
            else
            {
                LenearStack.Children.Clear();
                nonleneartemp = 0;
                leneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            }
        }

        void power_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NSM.Help.Power_Help));  
        }

        void seidal_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.lenear = "Gauss - Seidal Method";
            this.Frame.Navigate(typeof(NSM.Help.Seidal_Help));
        }

        void jacobi_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.lenear = "Gauss - Jacobi Method";
            this.Frame.Navigate(typeof(NSM.Help.Seidal_Help));
        }

        private void NonLenear_click(object sender, RoutedEventArgs e)
        {
            if(nonleneartemp == 0)
            {
                Button nr = new Button();
                Button root = new Button();
                Button secant = new Button();
                Button bisection = new Button();
                bisection.Content = "   Bisection Method";
                nr.Content = "   N-R Method";
                root.Content = "   Roots Using N-R Method";
                secant.Content = "   Secant Method";

                nr.Click += nr_Click;
                root.Click += root_Click;
                secant.Click += secant_Click;
                bisection.Click += bisection_Click;

                nr.Background = null;
                nr.BorderBrush = null;
                root.Background = null;
                root.BorderBrush = null;
                secant.Background = null;
                secant.BorderBrush = null;
                bisection.BorderBrush = null;
                bisection.Background = null;

                NonlenearStack.Children.Add(nr);
                NonlenearStack.Children.Add(root);
                NonlenearStack.Children.Add(secant);
                NonlenearStack.Children.Add(bisection);
               
                FiniteStack.Children.Clear();
                NumericalStack.Children.Clear();
                LenearStack.Children.Clear();
                nonleneartemp = 1;
                leneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            }
            else
            {
                NonlenearStack.Children.Clear();
                nonleneartemp = 0;
                leneartemp = 0;
                Finitetemp = 0;
                numericaltemp = 0;
            }
       }

        void bisection_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.nonlenear = "Bisection Method";
            this.Frame.Navigate(typeof(NSM.Help.bisection_Help));
        }

        void secant_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.nonlenear = "Secant Method";
            this.Frame.Navigate(typeof(NSM.Help.bisection_Help));
        }

        void root_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NSM.Help.Roots_Help));
        }

        void nr_Click(object sender, RoutedEventArgs e)
        {
            Help_Class.nonlenear = "N-R Method";
            this.Frame.Navigate(typeof(NSM.Help.bisection_Help));
        }
    }
}
