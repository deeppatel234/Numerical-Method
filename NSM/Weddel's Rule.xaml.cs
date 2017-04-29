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
    public sealed partial class Weddel_s_Rule : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Weddel_s_Rule()
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

        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>  /// <summary>
   
        
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


        decimal d = 0;
        int v = 0;
        private async void calculate_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(x0.Text) == false && string.IsNullOrEmpty(x1.Text) == false && string.IsNullOrEmpty(y0.Text) == false && string.IsNullOrEmpty(y1.Text) == false
                && string.IsNullOrEmpty(y2.Text) == false && string.IsNullOrEmpty(y3.Text) == false && string.IsNullOrEmpty(y4.Text) == false && string.IsNullOrEmpty(y5.Text) == false && string.IsNullOrEmpty(y6.Text) == false && string.IsNullOrEmpty(fixpoints.Text) == false &&
                decimal.TryParse(x0.Text, out d) == true && decimal.TryParse(x1.Text, out d) == true && decimal.TryParse(y0.Text, out d) == true && decimal.TryParse(y1.Text, out d) == true
                && decimal.TryParse(y2.Text, out d) == true && decimal.TryParse(y3.Text, out d) == true && decimal.TryParse(y4.Text, out d) == true && decimal.TryParse(y5.Text, out d) == true && decimal.TryParse(y6.Text, out d) == true && int.TryParse(fixpoints.Text,out v) == true)
           {
               if (Convert.ToInt32(fixpoints.Text) > 0)
               {
                   Weddels_Rule_Class.X0 = Convert.ToDecimal(x0.Text);
                   Weddels_Rule_Class.X1 = Convert.ToDecimal(x1.Text);
                   Weddels_Rule_Class.Y0 = Convert.ToDecimal(y0.Text);
                   Weddels_Rule_Class.Y1 = Convert.ToDecimal(y1.Text);
                   Weddels_Rule_Class.Y2 = Convert.ToDecimal(y2.Text);
                   Weddels_Rule_Class.Y3 = Convert.ToDecimal(y3.Text);
                   Weddels_Rule_Class.Y4 = Convert.ToDecimal(y4.Text);
                   Weddels_Rule_Class.Y5 = Convert.ToDecimal(y5.Text);
                   Weddels_Rule_Class.Y6 = Convert.ToDecimal(y6.Text);
                   Weddels_Rule_Class.FixDecimal = Convert.ToInt32(fixpoints.Text);
                   this.Frame.Navigate(typeof(Weddels_Rule_Calculation));
               }
                else
               {
                   var dialog = new MessageDialog("Values is not Set to negetive");
                   dialog.Title = "Invalid Values";
                   dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                   var res = await dialog.ShowAsync();
               }
            }
            else
            {
                var dialog = new MessageDialog("Values is not Set To null or invalid");
                dialog.Title = "Enter Values";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();
            }
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NSM.Help.Wedd_Help));
        }
    }
}
