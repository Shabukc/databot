﻿#pragma checksum "c:\users\reshmi\documents\visual studio 2012\Projects\Databot\Databot\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7DA5D3A4FB1780FB85B8430C91456BDD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Sparrow.Chart;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Databot {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock appName;
        
        internal System.Windows.Controls.Image imgWarn;
        
        internal System.Windows.Controls.Image imgMourn;
        
        internal System.Windows.Controls.Image imgWeep;
        
        internal System.Windows.Controls.Image imgScream;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Sparrow.Chart.SparrowChart spchart;
        
        internal System.Windows.Controls.Button prButton;
        
        internal System.Windows.Controls.Button configButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Databot;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.appName = ((System.Windows.Controls.TextBlock)(this.FindName("appName")));
            this.imgWarn = ((System.Windows.Controls.Image)(this.FindName("imgWarn")));
            this.imgMourn = ((System.Windows.Controls.Image)(this.FindName("imgMourn")));
            this.imgWeep = ((System.Windows.Controls.Image)(this.FindName("imgWeep")));
            this.imgScream = ((System.Windows.Controls.Image)(this.FindName("imgScream")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.spchart = ((Sparrow.Chart.SparrowChart)(this.FindName("spchart")));
            this.prButton = ((System.Windows.Controls.Button)(this.FindName("prButton")));
            this.configButton = ((System.Windows.Controls.Button)(this.FindName("configButton")));
        }
    }
}

