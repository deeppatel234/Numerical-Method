using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NSM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        MainPage rootPage = MainPage.Current;
        ApplicationData applicationData = null;
        ApplicationDataContainer roamingSettings = null;
        

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;

            applicationData = ApplicationData.Current;
            roamingSettings = applicationData.RoamingSettings;

            if(Settings_Class.bkchang == 1)
            {
                roamingSettings.Values["BKANIMATIONS"] = Settings_Class.bkon;
                Settings_Class.bkchang = 0;
            }

            if (Settings_Class.bkon == 0)
            {
                if (roamingSettings.Values["BKANIMATIONS"] != null)
                {
                    Object value = roamingSettings.Values["BKANIMATIONS"];
                    int temp = Convert.ToInt32(value);
                    Settings_Class.bkon = temp;
                } 
            }

            if (Settings_Class.themechang == 1)
            {
                roamingSettings.Values["Theme"] = Settings_Class.themeon;
                Settings_Class.themechang = 0;
            }

            if (Settings_Class.themeon == 0)
            {
                if (roamingSettings.Values["Theme"] != null)
                {
                    Object values = roamingSettings.Values["Theme"];
                    int temps = Convert.ToInt32(values);
                    Settings_Class.themeon = temps;
                }
            }
         
            if (Settings_Class.bkon == 0)
            {
                storyBoard.Begin();
            }
        }

     
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        
        private async void Rate_click(object sender, RoutedEventArgs e)
        {
            RateAnimate.Begin();
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
        }

        private void About_click(object sender, RoutedEventArgs e)
        {
            AboutAnimate.Begin();
           this.Frame.Navigate(typeof(About));
        }

        private void Settings_click(object sender, RoutedEventArgs e)
        {
            SettingsAnimate.Begin();
            this.Frame.Navigate(typeof(SEttings));
        }

        private void NumericalIntergration_click(object sender, RoutedEventArgs e)
        {
            ButtonsPlay1.Begin();
            this.Frame.Navigate(typeof(NumericalIntegration));
        }

        private void SystemofLinearEquations_click(object sender, RoutedEventArgs e)
        {
            ButtonsPlay4.Begin();
            this.Frame.Navigate(typeof(System_of_Linear_Equations));
        }

        private void SystemofNonLinearEquations_click(object sender, RoutedEventArgs e)
        {
            ButtonsPlay5.Begin();
            this.Frame.Navigate(typeof(System_of_NonLinear_Equations));
        }

     
        private void FiniteInterpolation_click(object sender, RoutedEventArgs e)
        {
            ButtonsPlay3.Begin();
            this.Frame.Navigate(typeof(FiniteInterpolation));
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            HelpAnimate.Begin();
            this.Frame.Navigate(typeof(NSM.Help.Help_Page));
        }
    }
}
