﻿#pragma checksum "..\..\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "71754B56C147AA6A7E132A0811953B3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MapMenu {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainMenu.xaml"
        internal LocalizedImageButton.ImageButton LangBT;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainMenu.xaml"
        internal System.Windows.Controls.Canvas HideAllCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/ArcView Demo;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenu.xaml"
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
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 13 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoConstruction);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoPresp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 15 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoDesign);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 16 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoGeneralLocation);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 17 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoPreStudies);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 18 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoReports);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 20 "..\..\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LangBT = ((LocalizedImageButton.ImageButton)(target));
            
            #line 21 "..\..\MainMenu.xaml"
            this.LangBT.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ChangeLanguage);
            
            #line default
            #line hidden
            return;
            case 10:
            this.HideAllCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
