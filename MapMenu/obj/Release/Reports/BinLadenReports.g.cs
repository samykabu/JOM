﻿#pragma checksum "..\..\..\Reports\BinLadenReports.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "25C58B4EE254062279EBBC89A8737F58"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Controls;
using InterActiveMap;
using LocalizedImage;
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
using View3D;
using WpfZommPanCanvas;
using YearSelector;


namespace MapMenu.Reports {
    
    
    /// <summary>
    /// BinLadenReports
    /// </summary>
    public partial class BinLadenReports : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Reports\BinLadenReports.xaml"
        internal Controls.AnimatedWrapPanel wPanel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Reports\BinLadenReports.xaml"
        internal YearSelector.YearSelector ySelector;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Reports\BinLadenReports.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Reports\BinLadenReports.xaml"
        internal Controls.ImageButton EditIcon;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Reports\BinLadenReports.xaml"
        internal System.Windows.Controls.Image image1;
        
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
            System.Uri resourceLocater = new System.Uri("/ArcView Demo;component/reports/binladenreports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reports\BinLadenReports.xaml"
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
            
            #line 12 "..\..\..\Reports\BinLadenReports.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseThisWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\Reports\BinLadenReports.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            case 3:
            this.wPanel = ((Controls.AnimatedWrapPanel)(target));
            return;
            case 4:
            this.ySelector = ((YearSelector.YearSelector)(target));
            
            #line 19 "..\..\..\Reports\BinLadenReports.xaml"
            this.ySelector.DateChanged += new YearSelector.YearSelector.OnDateChange(this.ySelector_DateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 23 "..\..\..\Reports\BinLadenReports.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseThisWindow);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 24 "..\..\..\Reports\BinLadenReports.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditIcon = ((Controls.ImageButton)(target));
            
            #line 25 "..\..\..\Reports\BinLadenReports.xaml"
            this.EditIcon.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ShowMetadataDialog);
            
            #line default
            #line hidden
            return;
            case 9:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
