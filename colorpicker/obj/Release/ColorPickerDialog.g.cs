﻿#pragma checksum "..\..\ColorPickerDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BBA59C10B6EAA9CE8BFA4197822AECD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Samples.CustomControls;
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


namespace Microsoft.Samples.CustomControls {
    
    
    /// <summary>
    /// ColorPickerDialog
    /// </summary>
    public partial class ColorPickerDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\ColorPickerDialog.xaml"
        internal System.Windows.Controls.Button OKButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ColorPickerDialog.xaml"
        internal Microsoft.Samples.CustomControls.ColorPicker cPicker;
        
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
            System.Uri resourceLocater = new System.Uri("/ColorPicker;component/colorpickerdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ColorPickerDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.OKButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ColorPickerDialog.xaml"
            this.OKButton.Click += new System.Windows.RoutedEventHandler(this.okButtonClicked);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\ColorPickerDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cPicker = ((Microsoft.Samples.CustomControls.ColorPicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
