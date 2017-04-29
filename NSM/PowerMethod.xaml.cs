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
    public sealed partial class PowerMethod : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        TextBox matrix02 = new TextBox();
        TextBox matrix12 = new TextBox();
        TextBox matrix20 = new TextBox();
        TextBox matrix21 = new TextBox();
        TextBox matrix22 = new TextBox();

        TextBox matrix00 = new TextBox();
        TextBox matrix01 = new TextBox();
        TextBox matrix10 = new TextBox();
        TextBox matrix11 = new TextBox();

        TextBox interationBox = new TextBox();
        TextBlock text = new TextBlock();
            

        public PowerMethod()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            
            matrix00stack.Children.Add(matrix00);
            matrix01stack.Children.Add(matrix01);
            matrix10stack.Children.Add(matrix10);
            matrix11stack.Children.Add(matrix11);
            

            matrix02stack.Children.Add(matrix02);
            matrix12stack.Children.Add(matrix12);
            matrix20stack.Children.Add(matrix20);
            matrix21stack.Children.Add(matrix21);
            matrix22stack.Children.Add(matrix22);
           
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


        int temp = 3;
        int temp1 = 0;
        
        private void ThreeMatrix_click(object sender, RoutedEventArgs e)
        {
            if (temp1 == 0)
            {
                matrix02stack.Children.Add(matrix02);
                matrix12stack.Children.Add(matrix12);
                matrix20stack.Children.Add(matrix20);
                matrix21stack.Children.Add(matrix21);
                matrix22stack.Children.Add(matrix22);
                temp1 = 1;
            }
            
            temp = 3;
        }

       private void TwoMetrix_click(object sender, RoutedEventArgs e)
        {
            matrix02stack.Children.Clear();
            matrix12stack.Children.Clear();
            matrix20stack.Children.Clear();
            matrix21stack.Children.Clear();
            matrix22stack.Children.Clear();
            temp = 2;
            temp1 = 0;
        }


       int toggledtemp = 0;
       int ontoggal = 0;
       
        private void FixIntToggal(object sender, RoutedEventArgs e)
        {
            if(toggledtemp % 2 == 0)
            {
                text.Text = "Enter Iterations : ";
                text.FontSize = 25;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                interationBox.Width = 100;
                interationBox.HorizontalAlignment = HorizontalAlignment.Center;
                interationBox.VerticalAlignment = VerticalAlignment.Center;
                textstac.Children.Add(text);
                ValueintStack.Children.Add(interationBox);
                toggledtemp++;
                ontoggal = 1;
            }
            else
            {
                textstac.Children.Clear();
                ValueintStack.Children.Clear();
                toggledtemp++;
                ontoggal = 0;
            }
        }

        int error = 0;
        decimal d = 0;
        int abc = 0;
        private async void Calcuate_click(object sender, RoutedEventArgs e)
        {
            error = 0;
            if (string.IsNullOrEmpty(FixDecimalValue.Text) == false && int.TryParse(FixDecimalValue.Text,out abc) == true)
            {
                if (Convert.ToInt32(FixDecimalValue.Text) > 0)
                {
                    PowerMethod_class.fixdecimal = Convert.ToInt32(FixDecimalValue.Text);
                }
                else
                {
                    var dialog = new MessageDialog("Fix Decimal is not Set To nagetive");
                    dialog.Title = "Invalid Values";
                    dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var res = await dialog.ShowAsync();
                    error = 1;
                }
            }
            else
            {
                var dialog = new MessageDialog("Fix Decimal is not Set To null");
                dialog.Title = "Invalid Values";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();
                error = 1;
            }

            if(ontoggal == 1)
            {
                if (string.IsNullOrEmpty(interationBox.Text) == false && int.TryParse(interationBox.Text,out abc) == true)
                {
                    if (Convert.ToInt32(interationBox.Text) > 0)
                    {
                        PowerMethod_class.fixinteration = Convert.ToInt32(interationBox.Text);
                    }
                    else
                    {
                        var dialog = new MessageDialog("Iterations is not Set To nagetive");
                        dialog.Title = "Invalid Values";
                        dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                        var res = await dialog.ShowAsync();
                        error = 1;
                    }
                }
                else
                {
                    var dialog = new MessageDialog("Iterations is not Set To null");
                    dialog.Title = "Invalid Values";
                    dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var res = await dialog.ShowAsync();
                    error = 1;
                }
            }

            if(temp == 3)
            {
                if (string.IsNullOrEmpty(matrix00.Text) == true || string.IsNullOrEmpty(matrix01.Text) == true || string.IsNullOrEmpty(matrix10.Text) == true || string.IsNullOrEmpty(matrix11.Text) == true ||
                    string.IsNullOrEmpty(matrix02.Text) == true || string.IsNullOrEmpty(matrix12.Text) == true || string.IsNullOrEmpty(matrix20.Text) == true || string.IsNullOrEmpty(matrix21.Text) == true || string.IsNullOrEmpty(matrix22.Text) == true || 
                    decimal.TryParse(matrix00.Text, out d) == false || decimal.TryParse(matrix01.Text, out d) == false || decimal.TryParse(matrix10.Text, out d) == false || decimal.TryParse(matrix11.Text, out d) == false ||
                    decimal.TryParse(matrix02.Text, out d) == false || decimal.TryParse(matrix12.Text, out d) == false || decimal.TryParse(matrix20.Text, out d) == false || decimal.TryParse(matrix21.Text, out d) == false || decimal.TryParse(matrix22.Text, out d) == false)
                {
                    var dialog = new MessageDialog("Values is not Set To null");
                    dialog.Title = "Invalid Values";
                    dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var res = await dialog.ShowAsync();
                    error = 1;
                }
                else
                {
                    if (error == 0)
                    {
                        PowerMethod_class.values[0, 0] = Convert.ToDecimal(matrix00.Text);
                        PowerMethod_class.values[0, 1] = Convert.ToDecimal(matrix01.Text);
                        PowerMethod_class.values[0, 2] = Convert.ToDecimal(matrix02.Text);
                        PowerMethod_class.values[1, 0] = Convert.ToDecimal(matrix10.Text);
                        PowerMethod_class.values[1, 1] = Convert.ToDecimal(matrix11.Text);
                        PowerMethod_class.values[1, 2] = Convert.ToDecimal(matrix12.Text);
                        PowerMethod_class.values[2, 0] = Convert.ToDecimal(matrix20.Text);
                        PowerMethod_class.values[2, 1] = Convert.ToDecimal(matrix21.Text);
                        PowerMethod_class.values[2, 2] = Convert.ToDecimal(matrix22.Text);
                        this.Frame.Navigate(typeof(PowerMethod_3X3Calculation));
                    }
                }
            }
            if (temp == 2)
            {
                if (string.IsNullOrEmpty(matrix00.Text) == true || string.IsNullOrEmpty( matrix01.Text) == true || string.IsNullOrEmpty(matrix10.Text) == true || string.IsNullOrEmpty(matrix11.Text) == true || 
                    decimal.TryParse(matrix00.Text, out d) == false || decimal.TryParse(matrix01.Text, out d) == false || decimal.TryParse(matrix10.Text, out d) == false || decimal.TryParse(matrix11.Text, out d) == false)
                {
                    var dialog = new MessageDialog("Values is not Set To null");
                    dialog.Title = "Invalid Values";
                    dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var res = await dialog.ShowAsync();
                    error = 1;
                }
                else
                {
                    if (error == 0)
                    {
                        PowerMethod_class.values[0, 0] = Convert.ToDecimal(matrix00.Text);
                        PowerMethod_class.values[0, 1] = Convert.ToDecimal(matrix01.Text);
                        PowerMethod_class.values[1, 0] = Convert.ToDecimal(matrix10.Text);
                        PowerMethod_class.values[1, 1] = Convert.ToDecimal(matrix11.Text);
                        this.Frame.Navigate(typeof(PowerMethod_2X2Calculation));
                    }
                }
            }
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NSM.Help.Power_Help));  
        }
    }
}
