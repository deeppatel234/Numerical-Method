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
    public sealed partial class GaussSeidal : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public GaussSeidal()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            if (GaussSeidal_class.MethodName == "GaussSeidal")
            {
               Head.Text = "Gauss Seidal Method";
            }
            if (GaussSeidal_class.MethodName == "GaussJacobi")
            {
                Head.Text = "Gauss Jacobi Method";
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
        TextBox IntValue = new TextBox();
        int temp = 0;

        int toggletemp = 0;
        private void FIxIteration_click(object sender, RoutedEventArgs e)
        {
            if(toggletemp % 2 == 0)
            {
                TextBlock IntText = new TextBlock();
                IntText.Text = "Enter Iterations";
                IntText.FontSize = 25;
                IntText.HorizontalAlignment = HorizontalAlignment.Center;
                IntText.VerticalAlignment = VerticalAlignment.Center;
                IntValue.HorizontalAlignment = HorizontalAlignment.Center;
                IntText.Margin = new Thickness(0, 10, 0, 0);
                IntValue.VerticalAlignment = VerticalAlignment.Center;
                IntValue.Width = 80;
                IntValue.Height = 30;
                temp = 1;
                IntTextBlock.Children.Add(IntText);
                IntTextBox.Children.Add(IntValue);
                toggletemp++;
            }
            else
            {
                IntTextBlock.Children.Clear();
                IntTextBox.Children.Clear();
                toggletemp++;
                temp = 0;
            }
        }

        int error = 0;
        decimal d = 0;
        int abc = 0;
        private async void Calculate_click(object sender, RoutedEventArgs e)
        {
            GaussSeidal_class.FixDecimal = 0;
            GaussSeidal_class.Interations = 0;
            error = 0;
            if (temp == 1)
            {
                if (string.IsNullOrEmpty(IntValue.Text) == false && int.TryParse(IntValue.Text, out abc) == true)
                {
                    if (Convert.ToInt32(IntValue.Text) > 0)
                    {
                        GaussSeidal_class.Interations = Convert.ToInt32(IntValue.Text);
                    }
                    else
                    {
                        var dialogs = new MessageDialog("Iterations is not Set To nagetive");
                        dialogs.Title = "Invalid Values";
                        dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var ress = await dialogs.ShowAsync();
                        error = 1;
                    }
                }
                else
                {
                    var dialogs = new MessageDialog("Iterations is not Set To null or wrong");
                    dialogs.Title = "Invalid Values";
                    dialogs.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var ress = await dialogs.ShowAsync();
                    error = 1;
                }
            }
          
            if (string.IsNullOrEmpty(XFirstEq.Text) == true || string.IsNullOrEmpty(YFirstEq.Text) == true || string.IsNullOrEmpty(ZFirstEq.Text) == true || string.IsNullOrEmpty(NFirstEq.Text) == true ||
                string.IsNullOrEmpty(XSeconudEq.Text) == true || string.IsNullOrEmpty(YSeconudEq.Text) == true || string.IsNullOrEmpty(ZSeconudEq.Text) == true || string.IsNullOrEmpty(NSeconudEq.Text) == true ||
                string.IsNullOrEmpty(XThirdEq.Text) == true || string.IsNullOrEmpty(YThirdEq.Text) == true || string.IsNullOrEmpty(ZThirdEq.Text) == true || string.IsNullOrEmpty(NThirdEq.Text) == true || 
                decimal.TryParse(XFirstEq.Text, out d) == false || decimal.TryParse(YFirstEq.Text, out d) == false || decimal.TryParse(ZFirstEq.Text, out d) == false || decimal.TryParse(NFirstEq.Text, out d) == false ||
                decimal.TryParse(XSeconudEq.Text, out d) == false || decimal.TryParse(YSeconudEq.Text, out d) == false || decimal.TryParse(ZSeconudEq.Text, out d) == false || decimal.TryParse(NSeconudEq.Text, out d) == false ||
                decimal.TryParse(XThirdEq.Text, out d) == false || decimal.TryParse(YThirdEq.Text, out d) == false || decimal.TryParse(ZThirdEq.Text, out d) == false || decimal.TryParse(NThirdEq.Text, out d) == false)
            {
                error = 1;
            }

            if (int.TryParse(FixDecimalValue.Text, out abc) == false || string.IsNullOrEmpty(FixDecimalValue.Text) == true)
            {
                error = 1;
            }
            else
            {
                if(Convert.ToInt32(FixDecimalValue.Text) < 0)
                {
                    error = 1;
                }
            }

            if (error == 1)
            {
                var dialog = new MessageDialog("Values is not Set To null or invalid");
                dialog.Title = "Invalid Values";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();

            }

            if (error == 0)
            {
                GaussSeidal_class.XFirst = Convert.ToDecimal(XFirstEq.Text);
                GaussSeidal_class.YFirst = Convert.ToDecimal(YFirstEq.Text);
                GaussSeidal_class.ZFirst = Convert.ToDecimal(ZFirstEq.Text);
                GaussSeidal_class.NFirst = Convert.ToDecimal(NFirstEq.Text);

                GaussSeidal_class.XSecound = Convert.ToDecimal(XSeconudEq.Text);
                GaussSeidal_class.YSecound = Convert.ToDecimal(YSeconudEq.Text);
                GaussSeidal_class.ZSecound = Convert.ToDecimal(ZSeconudEq.Text);
                GaussSeidal_class.NSecound = Convert.ToDecimal(NSeconudEq.Text);

                GaussSeidal_class.XThird = Convert.ToDecimal(XThirdEq.Text);
                GaussSeidal_class.YThird = Convert.ToDecimal(YThirdEq.Text);
                GaussSeidal_class.ZThird = Convert.ToDecimal(ZThirdEq.Text);
                GaussSeidal_class.NThird = Convert.ToDecimal(NThirdEq.Text);

                GaussSeidal_class.FixDecimal = Convert.ToInt32(FixDecimalValue.Text);


                if (GaussSeidal_class.MethodName == "GaussSeidal")
                {
                    this.Frame.Navigate(typeof(GaussSeidal_Calculation));
                }
                if (GaussSeidal_class.MethodName == "GaussJacobi")
                {
                    this.Frame.Navigate(typeof(GaussJacobi_calculation));
                }
            } 

        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            if (GaussSeidal_class.MethodName == "GaussSeidal")
            {
                NSM.Help.Help_Class.lenear = "Gauss - Seidal Method";
                this.Frame.Navigate(typeof(NSM.Help.Seidal_Help));
            }
            if (GaussSeidal_class.MethodName == "GaussJacobi")
            {
                NSM.Help.Help_Class.lenear = "Gauss - Jacobi Method";
                this.Frame.Navigate(typeof(NSM.Help.Seidal_Help));
            }

        }
    }
}
