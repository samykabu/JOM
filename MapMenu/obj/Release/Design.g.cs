﻿#pragma checksum "..\..\Design.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9D274B157879452059504D21677E64C8"
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
using WpfZommPanCanvas;


namespace MapMenu {
    
    
    /// <summary>
    /// DesignMain
    /// </summary>
    public partial class DesignMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Design.xaml"
        internal Controls.AnimatedWrapPanel wPanel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Design.xaml"
        internal WpfZommPanCanvas.ZPCanvas InterActiveMap;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Design.xaml"
        internal InterActiveMap.MapViewer MapViewer1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Design.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ArcView Demo;component/design.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Design.xaml"
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
            this.wPanel = ((Controls.AnimatedWrapPanel)(target));
            return;
            case 2:
            this.InterActiveMap = ((WpfZommPanCanvas.ZPCanvas)(target));
            return;
            case 3:
            this.MapViewer1 = ((InterActiveMap.MapViewer)(target));
            return;
            case 4:
            this.ZoneNameLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            
            #line 20 "..\..\Design.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseThisWindow);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\Design.xaml"
            ((Controls.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
