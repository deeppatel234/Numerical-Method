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
    public sealed partial class PowerMethod_3X3Calculation : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public PowerMethod_3X3Calculation()
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

            mat00.Text = "| " + PowerMethod_class.values[0, 0];
            mat01.Text = PowerMethod_class.values[0, 1] + "";
            mat02.Text = PowerMethod_class.values[0, 2] + " |";
            mat10.Text = "| " + PowerMethod_class.values[1, 0];
            mat11.Text = PowerMethod_class.values[1, 1] + "";
            mat12.Text = PowerMethod_class.values[1, 2] + " |";
            mat20.Text = "| " + PowerMethod_class.values[2, 0];
            mat21.Text = PowerMethod_class.values[2, 1] + "";
            mat22.Text = PowerMethod_class.values[2, 2] + " |";


            decimal[] Multiplyear = new decimal[3];
            decimal[] SumAnswer = new decimal[3];
            decimal[] Answer = new decimal[3];
            decimal lemda = 0;

            Multiplyear[0] = 1;
            Multiplyear[1] = 0;
            Multiplyear[2] = 0;


            if (PowerMethod_class.fixinteration != 0)
            {
                for (int i = 0; i < PowerMethod_class.fixinteration + 1; i++)
                {
                    TextBlock intprint = new TextBlock();
                    TextBlock aprint = new TextBlock();
                    TextBlock multi = new TextBlock();
                    TextBlock multians = new TextBlock();
                    TextBlock lem = new TextBlock();
                    TextBlock lemfinal = new TextBlock();
                    TextBlock final = new TextBlock();

                    intprint.Text = Environment.NewLine + i + " Iterations";
                    aprint.Text = "  A X(" + i + ") =  A * x(" + i + ")";


                    SumAnswer[0] = (PowerMethod_class.values[0, 0] * Multiplyear[0]) + (PowerMethod_class.values[0, 1] * Multiplyear[1] + (PowerMethod_class.values[0, 2] * Multiplyear[2]));
                    SumAnswer[1] = (PowerMethod_class.values[1, 0] * Multiplyear[0]) + (PowerMethod_class.values[1, 1] * Multiplyear[1] + (PowerMethod_class.values[1, 2] * Multiplyear[2]));
                    SumAnswer[2] = (PowerMethod_class.values[2, 0] * Multiplyear[0]) + (PowerMethod_class.values[2, 1] * Multiplyear[1] + (PowerMethod_class.values[2, 2] * Multiplyear[2]));

                    multi.Text = "             = A * [ " + Multiplyear[0] + " , " + Multiplyear[1] + " , " + Multiplyear[2] + " ]";
                    multians.Text = "             = [ " + SumAnswer[0] + " , " + SumAnswer[1] + " , " + SumAnswer[2] + " ]";

                    if (SumAnswer[0] > SumAnswer[1])
                    {
                        if (SumAnswer[0] > SumAnswer[2])
                        {
                            lemda = SumAnswer[0];
                            Answer[0] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + "/" + lemda + " ] ";
                            Answer[1] = SumAnswer[1] / lemda;
                            Answer[2] = SumAnswer[2] / lemda;
                        }
                        else
                        {
                            lemda = SumAnswer[2];
                            Answer[2] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[1] = SumAnswer[1] / lemda;
                        }
                    }
                    else
                    {
                        if (SumAnswer[1] > SumAnswer[2])
                        {
                            lemda = SumAnswer[1];
                            Answer[1] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + " , " + SumAnswer[2] + "/" + lemda + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[2] = SumAnswer[2] / lemda;
                        }
                        else
                        {
                            lemda = SumAnswer[2];
                            Answer[2] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[1] = SumAnswer[1] / lemda;
                        }
                    }

                    Answer[0] = Math.Round(Answer[0], PowerMethod_class.fixdecimal);
                    Answer[1] = Math.Round(Answer[1], PowerMethod_class.fixdecimal);
                    Answer[2] = Math.Round(Answer[2], PowerMethod_class.fixdecimal);

                    lemfinal.Text = "             = " + lemda + " [ " + Answer[0] + " , " + Answer[1] + " , " + Answer[2] + " ]";

                    if (i < PowerMethod_class.fixinteration)
                    {
                        Multiplyear[0] = Answer[0];
                        Multiplyear[1] = Answer[1];
                        Multiplyear[2] = Answer[2];
                    }


                    final.Text = "             = " + lemda + " * " + "X(" + (i + 1) + ")";

                    intprint.FontSize = 25;
                    aprint.FontSize = 25;
                    multi.FontSize = 25;
                    multians.FontSize = 25;
                    lem.FontSize = 25;
                    lemfinal.FontSize = 25;
                    final.FontSize = 25;

                 
                    AnswersPanal.Children.Add(intprint);
                    AnswersPanal.Children.Add(aprint);
                    AnswersPanal.Children.Add(multi);
                    AnswersPanal.Children.Add(multians);
                    AnswersPanal.Children.Add(lem);
                    AnswersPanal.Children.Add(lemfinal);
                    AnswersPanal.Children.Add(final);

                }

                TextBlock Lastansvelue = new TextBlock();
                TextBlock Lastansvactor = new TextBlock();
              
                Lastansvelue.Text = Environment.NewLine + "Eighen Value = " + lemda;
                Lastansvactor.Text = "Eighen Vector = [ " + Answer[0] + " , " + Answer[1] + " , " + Answer[2] + " ]";
                Lastansvactor.FontSize = 25;
                Lastansvelue.FontSize = 25;
             
                AnswersPanal.Children.Add(Lastansvelue);
                AnswersPanal.Children.Add(Lastansvactor);
            }
            else
            {
                decimal matchlemda = 0,match0 = 0,match1 = 0,match2 = 0;
                int j = 0;
                int errorint = 0;
                while("a" == "a")
                   {

                       if (errorint == 150)
                       {
                           error();
                           break;
                       }

                    TextBlock intprint = new TextBlock();
                    TextBlock aprint = new TextBlock();
                    TextBlock multi = new TextBlock();
                    TextBlock multians = new TextBlock();
                    TextBlock lem = new TextBlock();
                    TextBlock lemfinal = new TextBlock();
                    TextBlock final = new TextBlock();

                    intprint.Text = Environment.NewLine + j + " Iterations";
                    aprint.Text = "  A X(" + j + ") =  A * x(" + j + ")";

                    
                    SumAnswer[0] = (PowerMethod_class.values[0, 0] * Multiplyear[0]) + (PowerMethod_class.values[0, 1] * Multiplyear[1] + (PowerMethod_class.values[0, 2] * Multiplyear[2]));
                    SumAnswer[1] = (PowerMethod_class.values[1, 0] * Multiplyear[0]) + (PowerMethod_class.values[1, 1] * Multiplyear[1] + (PowerMethod_class.values[1, 2] * Multiplyear[2]));
                    SumAnswer[2] = (PowerMethod_class.values[2, 0] * Multiplyear[0]) + (PowerMethod_class.values[2, 1] * Multiplyear[1] + (PowerMethod_class.values[2, 2] * Multiplyear[2]));

                    multi.Text = "             = A * [ " + Multiplyear[0] + " , " + Multiplyear[1] + " , " + Multiplyear[2] + " ]";
                    multians.Text = "             = [ " + SumAnswer[0] + " , " + SumAnswer[1] + " , " + SumAnswer[2] + " ]";

                    if (SumAnswer[0] > SumAnswer[1])
                    {
                        if (SumAnswer[0] > SumAnswer[2])
                        {
                            lemda = SumAnswer[0];
                            Answer[0] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + "/" + lemda + " ] ";
                            Answer[1] = SumAnswer[1] / lemda;
                            Answer[2] = SumAnswer[2] / lemda;
                        }
                        else
                        {
                            lemda = SumAnswer[2];
                            Answer[2] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[1] = SumAnswer[1] / lemda;
                        }
                    }
                    else
                    {
                        if (SumAnswer[1] > SumAnswer[2])
                        {
                            lemda = SumAnswer[1];
                            Answer[1] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + " , " + SumAnswer[2] + "/" + lemda + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[2] = SumAnswer[2] / lemda;
                        }
                        else
                        {
                            lemda = SumAnswer[2];
                            Answer[2] = 1;
                            lem.Text = "             = " + lemda + " [ " + Answer[0] + "/" + lemda + " , " + SumAnswer[1] + "/" + lemda + " , " + SumAnswer[2] + " ] ";
                            Answer[0] = SumAnswer[0] / lemda;
                            Answer[1] = SumAnswer[1] / lemda;
                        }
                    }

                    Answer[0] = Math.Round(Answer[0], PowerMethod_class.fixdecimal);
                    Answer[1] = Math.Round(Answer[1], PowerMethod_class.fixdecimal);
                    Answer[2] = Math.Round(Answer[2], PowerMethod_class.fixdecimal);

                    lemfinal.Text = "             = " + lemda + " [ " + Answer[0] + " , " + Answer[1] + " , " + Answer[2] + " ]";

                        Multiplyear[0] = Answer[0];
                        Multiplyear[1] = Answer[1];
                        Multiplyear[2] = Answer[2];
                
                    final.Text = "             = " + lemda + " * " + "X(" + (j + 1) + ")";
                    j++;
                    intprint.FontSize = 25;
                    aprint.FontSize = 25;
                    multi.FontSize = 25;
                    multians.FontSize = 25;
                    lem.FontSize = 25;
                    lemfinal.FontSize = 25;
                    final.FontSize = 25;

                 
                    AnswersPanal.Children.Add(intprint);
                    AnswersPanal.Children.Add(aprint);
                    AnswersPanal.Children.Add(multi);
                    AnswersPanal.Children.Add(multians);
                    AnswersPanal.Children.Add(lem);
                    AnswersPanal.Children.Add(lemfinal);
                    AnswersPanal.Children.Add(final);
                    
                    if (matchlemda == lemda && match0 == Answer[0] && match1 == Answer[1] && match2 == Answer[2])
                    {
                        break;
                    }

                    matchlemda = lemda;
                    match0 = Answer[0];
                    match1 = Answer[1];
                    match2 = Answer[2];
                    errorint++;

                }

                
                TextBlock Lastansvelue = new TextBlock();
                TextBlock Lastansvactor = new TextBlock();
             
                Lastansvelue.Text = Environment.NewLine + "Eighen Value = " + lemda;
                Lastansvactor.Text = "Eighen Vector = [ " + Answer[0] + " , " + Answer[1] + " , " + Answer[2] + " ]";
                Lastansvactor.FontSize = 25;
                Lastansvelue.FontSize = 25;
                AnswersPanal.Children.Add(Lastansvelue);
                AnswersPanal.Children.Add(Lastansvactor);
       
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
                this.Frame.Navigate(typeof(PowerMethod));
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
