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
    public sealed partial class GaussJacobi_calculation : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public GaussJacobi_calculation()
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

            decimal swep1 = 0, swep2 = 0, swep3 = 0, swap = 0;
            decimal tempx = 0, tempy = 0, tempz = 0, tempn = 0;
            decimal x = 0, y = 0, z = 0;
            decimal Tempx = 0, Tempy = 0, Tempz = 0;
            decimal MatchZ = 1, MatchY = 1, MatchX = 1;
            

            decimal x0 = 0, y0 = 0, z0 = 0;


            TextBlock eq = new TextBlock();
            TextBlock eq1f = new TextBlock();
            TextBlock eq2f = new TextBlock();
            TextBlock eq3f = new TextBlock();
           
            eq.FontSize = 25;
            eq1f.FontSize = 25;
            eq2f.FontSize = 25;
            eq3f.FontSize = 25;
            eq.Text = "The Equation is";
            StackPanalPrint.Children.Add(eq);
            eq1f.Text = GaussSeidal_class.XFirst + "X + " + GaussSeidal_class.YFirst + "Y + " + GaussSeidal_class.ZFirst + "Z = " + GaussSeidal_class.NFirst;
            StackPanalPrint.Children.Add(eq1f);
            eq2f.Text = GaussSeidal_class.XSecound + "X + " + GaussSeidal_class.YSecound + "Y + " + GaussSeidal_class.ZSecound + "Z = " + GaussSeidal_class.NSecound;
            StackPanalPrint.Children.Add(eq2f);
            eq3f.Text = GaussSeidal_class.XThird + "X + " + GaussSeidal_class.YThird + "Y + " + GaussSeidal_class.ZThird + "Z = " + GaussSeidal_class.NThird + Environment.NewLine;
            StackPanalPrint.Children.Add(eq3f);
           

            if (Math.Abs(GaussSeidal_class.XFirst) < Math.Abs(GaussSeidal_class.YFirst) + Math.Abs(GaussSeidal_class.ZFirst))
            {
                swep1 = 1;
            }

            if (Math.Abs(GaussSeidal_class.YSecound) < Math.Abs(GaussSeidal_class.XSecound) + Math.Abs(GaussSeidal_class.ZSecound))
            {
                swep2 = 1;
            }

            if (Math.Abs(GaussSeidal_class.ZThird) < Math.Abs(GaussSeidal_class.XThird) + Math.Abs(GaussSeidal_class.YThird))
            {
                swep3 = 1;
            }

            if (swep1 == 1 || swep2 == 1 || swep3 == 1)
            {
                TextBlock eq1 = new TextBlock();
                TextBlock eq2 = new TextBlock();
                TextBlock eq3 = new TextBlock();
                TextBlock swepeq = new TextBlock();
                TextBlock swepeq1 = new TextBlock();
                TextBlock not = new TextBlock();
                eq1.FontSize = 25;
                eq2.FontSize = 25;
                eq3.FontSize = 25;
                swepeq.FontSize = 25;
                swepeq1.FontSize = 30;
                not.FontSize = 25;
                not.Text = "This Equation is not Setisfied this condition";
                StackPanalPrint.Children.Add(not);
                eq1.Text = "|" + GaussSeidal_class.XFirst + "| >= |" + GaussSeidal_class.YFirst + "| + |" + GaussSeidal_class.ZFirst + "|";
                StackPanalPrint.Children.Add(eq1);
                eq2.Text = "|" + GaussSeidal_class.XSecound + "| >= |" + GaussSeidal_class.YSecound + "| + |" + GaussSeidal_class.ZSecound + "|";
                StackPanalPrint.Children.Add(eq2);
                eq3.Text = "|" + GaussSeidal_class.XThird + "| >= |" + GaussSeidal_class.YThird + "| + |" + GaussSeidal_class.ZThird + "|";
                StackPanalPrint.Children.Add(eq3);
                swepeq1.Text = " ";
                StackPanalPrint.Children.Add(swepeq1);
                swepeq.Text = "So Interchange the equations to setisfie the condition";
                StackPanalPrint.Children.Add(swepeq);
                swap = 1;
            }

            if (swep1 == 1 || swep2 == 1 || swep3 == 1)
            {
                if (Math.Abs(GaussSeidal_class.XFirst) < Math.Abs(GaussSeidal_class.YFirst) + Math.Abs(GaussSeidal_class.ZFirst))
                {
                    if (Math.Abs(GaussSeidal_class.XSecound) >= Math.Abs(GaussSeidal_class.YSecound) + Math.Abs(GaussSeidal_class.ZSecound))
                    {
                        tempx = GaussSeidal_class.XFirst; GaussSeidal_class.XFirst = GaussSeidal_class.XSecound; GaussSeidal_class.XSecound = tempx;
                        tempy = GaussSeidal_class.YFirst; GaussSeidal_class.YFirst = GaussSeidal_class.YSecound; GaussSeidal_class.YSecound = tempy;
                        tempz = GaussSeidal_class.ZFirst; GaussSeidal_class.ZFirst = GaussSeidal_class.ZSecound; GaussSeidal_class.ZSecound = tempz;
                        tempn = GaussSeidal_class.NFirst; GaussSeidal_class.NFirst = GaussSeidal_class.NSecound; GaussSeidal_class.NSecound = tempn;
                    }
                   if (Math.Abs(GaussSeidal_class.XThird) >= Math.Abs(GaussSeidal_class.YThird) + Math.Abs(GaussSeidal_class.ZThird))
                    {
                        tempx = GaussSeidal_class.XFirst; GaussSeidal_class.XFirst = GaussSeidal_class.XThird; GaussSeidal_class.XThird = tempx;
                        tempy = GaussSeidal_class.YFirst; GaussSeidal_class.YFirst = GaussSeidal_class.YThird; GaussSeidal_class.YThird = tempy;
                        tempz = GaussSeidal_class.ZFirst; GaussSeidal_class.ZFirst = GaussSeidal_class.ZThird; GaussSeidal_class.ZThird = tempz;
                        tempn = GaussSeidal_class.NFirst; GaussSeidal_class.NFirst = GaussSeidal_class.NThird; GaussSeidal_class.NThird = tempn;
                    }
                 }
                if (Math.Abs(GaussSeidal_class.YSecound) < Math.Abs(GaussSeidal_class.XSecound) + Math.Abs(GaussSeidal_class.ZSecound))
                {
                    tempx = GaussSeidal_class.XSecound; GaussSeidal_class.XSecound = GaussSeidal_class.XThird; GaussSeidal_class.XThird = tempx;
                    tempy = GaussSeidal_class.YSecound; GaussSeidal_class.YSecound = GaussSeidal_class.YThird; GaussSeidal_class.YThird = tempy;
                    tempz = GaussSeidal_class.ZSecound; GaussSeidal_class.ZSecound = GaussSeidal_class.ZThird; GaussSeidal_class.ZThird = tempz;
                    tempn = GaussSeidal_class.NSecound; GaussSeidal_class.NSecound = GaussSeidal_class.NThird; GaussSeidal_class.NThird = tempn;
                }
                swep1 = 0; swep2 = 0; swep3 = 0;
            }


            if (swap == 1)
            {
                TextBlock new1eq = new TextBlock();
                TextBlock new2eq = new TextBlock();
                TextBlock new3eq = new TextBlock();
                new1eq.FontSize = 25;
                new2eq.FontSize = 25;
                new3eq.FontSize = 25;
                new1eq.Text = GaussSeidal_class.XFirst + "X + " + GaussSeidal_class.YFirst + "Y + " + GaussSeidal_class.ZFirst + "Z = " + GaussSeidal_class.NFirst;
                StackPanalPrint.Children.Add(new1eq);
                new2eq.Text = GaussSeidal_class.XSecound + "X + " + GaussSeidal_class.YSecound + "Y + " + GaussSeidal_class.ZSecound + "Z = " + GaussSeidal_class.NSecound;
                StackPanalPrint.Children.Add(new2eq);
                new3eq.Text = GaussSeidal_class.XThird + "X + " + GaussSeidal_class.YThird + "Y + " + GaussSeidal_class.ZThird + "Z = " + GaussSeidal_class.NThird;
                StackPanalPrint.Children.Add(new3eq);
                swap = 0;
            }


            if (GaussSeidal_class.Interations != 0)
            {
                int a = 0;
                for (int i = 0; i < GaussSeidal_class.Interations; i++)
                {
                   
                    TextBlock interationsPrint = new TextBlock();
                    TextBlock xprint = new TextBlock();
                    TextBlock yprint = new TextBlock();
                    TextBlock zprint = new TextBlock();

                    interationsPrint.Text = Environment.NewLine + (i + 1) + " Iteration";
                    a = i;
                    Tempx = (GaussSeidal_class.NFirst - (GaussSeidal_class.YFirst * y0) - (GaussSeidal_class.ZFirst * z0));
                    x = Tempx / GaussSeidal_class.XFirst;
                    x = Math.Round(x, GaussSeidal_class.FixDecimal);
                    xprint.Text = " = " + "1 / " + GaussSeidal_class.XFirst + " [ (" + GaussSeidal_class.NFirst + ") - (" + GaussSeidal_class.YFirst + ") * " + y0 + " - (" + GaussSeidal_class.ZFirst + ") * " + z0 + "] = " + x;

                    Tempy = (GaussSeidal_class.NSecound - (GaussSeidal_class.XSecound * x0) - (GaussSeidal_class.ZSecound * z0));
                    y = Tempy / GaussSeidal_class.YSecound;
                    y = Math.Round(y, GaussSeidal_class.FixDecimal);
                    yprint.Text = " = " + "1 / " + GaussSeidal_class.YSecound + " [ (" + GaussSeidal_class.NSecound + ") - (" + GaussSeidal_class.XSecound + ") * " + x0 + " - (" + GaussSeidal_class.ZSecound + ") * " + z0 + "] = " + y;

                    Tempz = (GaussSeidal_class.NThird - (GaussSeidal_class.XThird * x0) - (GaussSeidal_class.YThird * y0));
                    z = Tempz / GaussSeidal_class.ZThird;
                    z = Math.Round(z, GaussSeidal_class.FixDecimal);
                    zprint.Text = " = " + "1 / " + GaussSeidal_class.ZThird + " [ (" + GaussSeidal_class.NThird + ") - (" + GaussSeidal_class.XThird + ") * " + x0 + " - (" + GaussSeidal_class.YThird + ") * " + y0 + "] = " + z;

                    x0 = x;
                    y0 = y;
                    z0 = z;

                    xprint.FontSize = 25;
                    yprint.FontSize = 25;
                    zprint.FontSize = 25;
                   
                    interationsPrint.FontSize = 30;

                   
                    StackPanalPrint.Children.Add(interationsPrint);

                    StackPanalPrint.Children.Add(xprint);
                    StackPanalPrint.Children.Add(yprint);
                    StackPanalPrint.Children.Add(zprint);
                }
             
                TextBlock FinalAnsX = new TextBlock();
                TextBlock FinalAnsY = new TextBlock();
                TextBlock FinalAnsZ = new TextBlock();
                TextBlock Ans = new TextBlock();

                Ans.Text = Environment.NewLine + "Answer : ";
                Ans.FontSize = 25;
                FinalAnsX.FontSize = 25;
                FinalAnsX.Text = "X" + a + " = " + x;
                FinalAnsY.FontSize = 25;
                FinalAnsY.Text = "Y" + a + " = " + y;
                FinalAnsZ.FontSize = 25;
                FinalAnsZ.Text = "Z" + a + " = " + z;
               
                StackPanalPrint.Children.Add(Ans);
                StackPanalPrint.Children.Add(FinalAnsX);
                StackPanalPrint.Children.Add(FinalAnsY);
                StackPanalPrint.Children.Add(FinalAnsZ);
            }
            else
            {
                int j = 1;
                int errorint = 0;
                while ("a" == "a")
                {

                    if (errorint == 150)
                    {
                        error();
                    }

                    TextBlock interationsPrint = new TextBlock();
                    TextBlock xprint = new TextBlock();
                    TextBlock yprint = new TextBlock();
                    TextBlock zprint = new TextBlock();


                    interationsPrint.Text = Environment.NewLine + j + " Iteration";

                    Tempx = (GaussSeidal_class.NFirst - (GaussSeidal_class.YFirst * y0) - (GaussSeidal_class.ZFirst * z0));
                    x = Tempx / GaussSeidal_class.XFirst;
                    x = Math.Round(x, GaussSeidal_class.FixDecimal);
                    xprint.Text = " = " + "1 / " + GaussSeidal_class.XFirst + " [ (" + GaussSeidal_class.NFirst + ") - (" + GaussSeidal_class.YFirst + ") * " + y0 + " - (" + GaussSeidal_class.ZFirst + ") * " + z0 + "] = " + x;

                    Tempy = (GaussSeidal_class.NSecound - (GaussSeidal_class.XSecound * x0) - (GaussSeidal_class.ZSecound * z0));
                    y = Tempy / GaussSeidal_class.YSecound;
                    y = Math.Round(y, GaussSeidal_class.FixDecimal);
                    yprint.Text = " = " + "1 / " + GaussSeidal_class.YSecound + " [ (" + GaussSeidal_class.NSecound + ") - (" + GaussSeidal_class.XSecound + ") * " + x0 + " - (" + GaussSeidal_class.ZSecound + ") * " + z0 + "] = " + y;

                    Tempz = (GaussSeidal_class.NThird - (GaussSeidal_class.XThird * x0) - (GaussSeidal_class.YThird * y0));
                    z = Tempz / GaussSeidal_class.ZThird;
                    z = Math.Round(z, GaussSeidal_class.FixDecimal);
                    zprint.Text = " = " + "1 / " + GaussSeidal_class.ZThird + " [ (" + GaussSeidal_class.NThird + ") - (" + GaussSeidal_class.XThird + ") * " + x0 + " - (" + GaussSeidal_class.YThird + ") * " + y0 + "] = " + z;

                    x0 = x;
                    y0 = y;
                    z0 = z;

                    xprint.FontSize = 25;
                    yprint.FontSize = 25;
                    zprint.FontSize = 25;
                   
                    interationsPrint.FontSize = 30;

                   
                    StackPanalPrint.Children.Add(interationsPrint);
                    j++;
                    StackPanalPrint.Children.Add(xprint);
                    StackPanalPrint.Children.Add(yprint);
                    StackPanalPrint.Children.Add(zprint);

                    if (x == MatchX && y == MatchY && z == MatchZ)
                    {
                        break;
                    }
                    MatchX = x;
                    MatchY = y;
                    MatchZ = z;
                };
                TextBlock FinalAnsX = new TextBlock();
                TextBlock FinalAnsY = new TextBlock();
                TextBlock FinalAnsZ = new TextBlock();
               
                TextBlock Ans = new TextBlock();

                Ans.Text = Environment.NewLine + "Answer : ";

                Ans.FontSize = 25;
                FinalAnsX.FontSize = 25;
                FinalAnsX.Text = "X" + (j - 2) + " = " + x + " = " + "X" + (j - 1);
                FinalAnsY.FontSize = 25;
                FinalAnsY.Text = "Y" + (j - 2) + " = " + y + " = " + "Y" + (j - 1);
                FinalAnsZ.FontSize = 25;
                FinalAnsZ.Text = "Z" + (j - 2) + " = " + z + " = " + "Z" + (j - 1);
         
                StackPanalPrint.Children.Add(Ans);
                StackPanalPrint.Children.Add(FinalAnsX);
                StackPanalPrint.Children.Add(FinalAnsY);
                StackPanalPrint.Children.Add(FinalAnsZ);
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
                this.Frame.Navigate(typeof(GaussSeidal));
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
