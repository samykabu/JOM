﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB380EF4B781069FC7E05D947F51B286"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace TestWPF {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Window1.xaml"
        internal System.Windows.Controls.Canvas VVV;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window1.xaml"
        internal System.Windows.Shapes.Rectangle ZoomedMap;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        internal WpfZommPanCanvas.ZPCanvas InterActiveMap;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window1.xaml"
        internal InterActiveMap.MapViewer MapViewer1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Window1.xaml"
        internal LocalizedImage.LocImage timage;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox txt;
        
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
            System.Uri resourceLocater = new System.Uri("/TestWPF;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.VVV = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.ZoomedMap = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.InterActiveMap = ((WpfZommPanCanvas.ZPCanvas)(target));
            
            #line 20 "..\..\Window1.xaml"
            this.InterActiveMap.PosChanged += new WpfZommPanCanvas.ZPCanvas.OnPosChange(this.InterActiveMap_PosChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MapViewer1 = ((InterActiveMap.MapViewer)(target));
            return;
            case 5:
            this.timage = ((LocalizedImage.LocImage)(target));
            return;
            case 6:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Window1.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
