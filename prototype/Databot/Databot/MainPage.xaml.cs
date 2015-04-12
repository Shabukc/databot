using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Databot.Resources;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows.Media;

namespace Databot
{
    ///This class is required by Sparrow Chart library
    ///https://sparrowtoolkit.codeplex.com/
    //Create a model
    public class Model
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Model(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    ///This class is required by Sparrow Chart library
    ///https://sparrowtoolkit.codeplex.com/
    // Create a ViewModel
    public class ViewModel
    {
        public static ObservableCollection<Model> Collection { get; set; }
        public ViewModel()
        {
            Collection = new ObservableCollection<Model>();
        }

    }

    //StoreItem
    struct StoreItem
    {
        public int max;
        public int min;
        public Colors color;
        public int warn;
        public int mourn;
        public int weep;
        public int screem;
    }
    
    /// <summary>
    /// Main Class
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        //Timer to poll
        DispatcherTimer dpTimer = new DispatcherTimer();

        //To simulate data reading from a data stream.
        Random rnd = new Random(DateTime.Now.Second);
        List<StoreItem> listofStoreItem = new List<StoreItem>(10);

        // Constructor
        public MainPage()
        {
            InitializeComponent();
   
        }

        /// <summary>
        /// When its time , new data point is generated.
        /// Also after reading data, it has to be cheched and raise 
        /// Warning, Mourning, weeping and screaming based on the control limit set in StoreItem structur
        /// </summary>
        double xcount = 0;
        void dpTimer_Tick(object sender, EventArgs e)
        {    
            //Get data from any steram 
            //For this prototype we generate data steram.
            int newy = rnd.Next(80, 99);
            //Making randmoness still more rand to generate out of control limits
            if (xcount % Convert.ToDouble(rnd.Next(0, 100)) > 0)
            {
                newy = rnd.Next(70, 106);
            }

            StoreItem si =  listofStoreItem[0];
            Color color;

            ///Now check for control limits and set the message for the user to take action.
            if (si.screem <=  newy)
        	{
                color = Colors.Red;
                imgScream.Visibility = System.Windows.Visibility.Visible;
            }
            else if (si.weep <= newy)
            {
                color = Colors.Orange;
                imgWeep.Visibility = System.Windows.Visibility.Visible;
            }
            else if (si.mourn <= newy)
            {
                color = Colors.Purple;
                imgMourn.Visibility = System.Windows.Visibility.Visible;
            }
            else if (si.warn <= newy)
            {
                color = Colors.Yellow;
                imgWarn.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                color = Colors.White;
            }

            ///Set icons to make user acknowledge the raised alaram
            appName.Foreground = new SolidColorBrush(color);

            //Send new data to the data source of the chart.
            if (ViewModel.Collection != null)
            {
                ViewModel.Collection.Add(new Model(xcount++, newy));
            }

            //Removing the very old data
            if (ViewModel.Collection.Count > 600)
            {
                ViewModel.Collection.RemoveAt(0);
            }          
        }

        /// <summary>
        /// Hand start,pause click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseRestart(object sender, RoutedEventArgs e)
        {
            
            if (dpTimer.IsEnabled)
            {
                dpTimer.Stop();
                prButton.Content = ">";
            }
            else
            {
                dpTimer.Start();
                prButton.Content = "=";
            }
        }

        /// <summary>
        /// Handle Configure event,
        /// Here is where user should be allowed to set values for control limits and frequencies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configer(object sender, RoutedEventArgs e)
        {
            prButton.IsEnabled = true;
           
            int pollingFreq = 1000000; //Get from the user;

            StoreItem storeItem = new StoreItem();
            storeItem.max = 106;
            storeItem.min = 70;

            storeItem.warn = 100;
            storeItem.mourn = 102;
            storeItem.weep = 103;
            storeItem.screem = 104;

            listofStoreItem.Add(storeItem);

            MessageBox.Show("Get configuration(frequency=" + pollingFreq.ToString()
                + ", color= "
                +", min=" + storeItem.min.ToString()
                +", max=" + storeItem.max.ToString()
                +", warn" + storeItem.warn.ToString()
                +", mourn" + storeItem.mourn.ToString()
                +", weep" + storeItem.weep.ToString()
                + "and screem" + storeItem.screem.ToString()
                +"numbers from user");

            dpTimer.Interval = new TimeSpan(pollingFreq);
            dpTimer.Tick += dpTimer_Tick;
           

        }

        /// <summary>
        /// Seting the alaram. By defaul this will be invisible.
        /// These emoicons will be there on screen till the user acknowleges the alaram.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void imgWarn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sender is Image)
            {
                ((Image)sender).Visibility = System.Windows.Visibility.Collapsed;
            }
        }

    }
}