﻿#pragma checksum "..\..\..\Reports\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "43E1F07E038D1BD3A96A30A5F5FC28DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
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
    /// ReportsMapMenu
    /// </summary>
    public partial class ReportsMapMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Reports\MainMenu.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Reports\MainMenu.xaml"
        internal LocalizedImageButton.ImageButton LangBT;
        
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
            System.Uri resourceLocater = new System.Uri("/JOM Interactive Report;component/reports/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reports\MainMenu.xaml"
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
            
            #line 13 "..\..\..\Reports\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoGeneral);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\Reports\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GotoSubMain);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\Reports\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExitApplication);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LangBT = ((LocalizedImageButton.ImageButton)(target));
            
            #line 17 "..\..\..\Reports\MainMenu.xaml"
            this.LangBT.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ChangeLanguage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 18 "..\..\..\Reports\MainMenu.xaml"
            ((LocalizedImageButton.ImageButton)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GoHome);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
