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
    public sealed partial class TrapezoidalRule : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public TrapezoidalRule()
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

            decimal h = GetDataClass_Calss.ValuesX[1] - GetDataClass_Calss.ValuesX[0];
            h = Math.Round(h, GetDataClass_Calss.fixdecimal);

            decimal MidTotal = 0;
            string MidPrint = null;



            for(int i = 1 ; i < GetDataClass_Calss.n-1 ; i++ )
            {
                MidTotal = MidTotal + GetDataClass_Calss.ValuesY[i] ;
                MidTotal = Math.Round(MidTotal, GetDataClass_Calss.fixdecimal);
            
                
                if (i % 4 == 0 && i > 3)
                {
                        MidPrint += Environment.NewLine + "           ";
                }
                MidPrint = MidPrint + GetDataClass_Calss.ValuesY[i];
                if (i < GetDataClass_Calss.n - 2)
                {
                    MidPrint = MidPrint + "+";
                }
           }

            decimal ans= (h/2) * (GetDataClass_Calss.ValuesY[0] + 2 * MidTotal + GetDataClass_Calss.ValuesY[GetDataClass_Calss.n-1]);
            ans = Math.Round(ans, GetDataClass_Calss.fixdecimal);

         
            FindH.Text = "  h = X1 - X0 = " + GetDataClass_Calss.ValuesX[1] + " - " + GetDataClass_Calss.ValuesX[0] + " = " + h + Environment.NewLine;
            FirstStep.Text = "Ans = " + h + "/2 " + "[ " + GetDataClass_Calss.ValuesY[0] + " + 2 [ " + MidPrint + " ] + " + GetDataClass_Calss.ValuesY[GetDataClass_Calss.n - 1] + " ]" + Environment.NewLine;
            SecondStep.Text = "     = " + h + "/2 " + "[ " + GetDataClass_Calss.ValuesY[0] + " + 2 [ " + MidTotal + " ] + " + GetDataClass_Calss.ValuesY[GetDataClass_Calss.n - 1] + " ]" + Environment.NewLine;
            ThirdStep.Text = "     = " + h + "/2 " + "[ " + (GetDataClass_Calss.ValuesY[0] + 2 * (MidTotal) + GetDataClass_Calss.ValuesY[GetDataClass_Calss.n - 1]) + " ]" + Environment.NewLine;
            FinalAnswer.Text = "     = " + ans + Environment.NewLine;  
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
