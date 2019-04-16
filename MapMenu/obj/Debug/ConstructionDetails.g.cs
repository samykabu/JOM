﻿#pragma checksum "..\..\ConstructionDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "786AB3B80EC2154CA5D13ED20ADBEDC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Controls;
using InterActiveMap;
using LocalizedImage;
using LocalizedImageButton;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfZommPanCanvas;
using YearSelector;


namespace MapMenu {
    
    
    /// <summary>
    /// ConstructionDetails
    /// </summary>
    public partial class ConstructionDetails : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 81 "..\..\ConstructionDetails.xaml"
        internal YearSelector.YearSelector ySelector;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\ConstructionDetails.xaml"
        internal WpfZommPanCanvas.ZPCanvas zpCanvas;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\ConstructionDetails.xaml"
        internal InterActiveMap.MapViewer MapViewer1;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\ConstructionDetails.xaml"
        internal Controls.AnimatedWrapPanel wPanel;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\ConstructionDetails.xaml"
        internal System.Windows.Controls.Label ZoneNameLBL;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/JOM Interactive Report;component/constructiondetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConstructionDetails.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\ConstructionDetails.xaml"
            ((MapMenu.ConstructionDetails)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ySelector = ((YearSelector.YearSelector)(target));
            
            #line 81 "..\..\ConstructionDetails.xaml"
            this.ySelector.DateChanged += new YearSelector.YearSelector.OnDateChange(this.ySelector_DateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.zpCanvas = ((WpfZommPanCanvas.ZPCanvas)(target));
            return;
            case 4:
            this.MapViewer1 = ((InterActiveMap.MapViewer)(target));
            return;
            case 5:
            this.wPanel = ((Controls.AnimatedWrapPanel)(target));
            return;
            case 6:
            
            #line 88 "..\..\ConstructionDetails.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseThisWindow);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 90 "..\..\ConstructionDetails.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ZoneNameLBL = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
