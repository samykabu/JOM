﻿#pragma checksum "..\..\..\DataEntryForms\DataUpload.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "817333B860F05691B026BDAF316654EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MapMenu.EntryForms;
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


namespace MapMenu.EntryForms {
    
    
    /// <summary>
    /// DataUpload
    /// </summary>
    public partial class DataUpload : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 5 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal MapMenu.EntryForms.DataUpload DataUploadW;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.ComboBox comboBox1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.ListBox listBox1;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.ComboBox Month;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.ComboBox Year;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Button CancelBT;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Button SaveBT;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Label label4;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Button ClearList;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\DataEntryForms\DataUpload.xaml"
        internal System.Windows.Controls.Label SavingInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/ArcView Demo;component/dataentryforms/dataupload.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DataEntryForms\DataUpload.xaml"
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
            this.DataUploadW = ((MapMenu.EntryForms.DataUpload)(target));
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.comboBox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.comboBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CatChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.listBox1 = ((System.Windows.Controls.ListBox)(target));
            
            #line 14 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.listBox1.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.NewFilesDropedIn));
            
            #line default
            #line hidden
            return;
            case 7:
            this.Month = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.Month.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CatChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Year = ((System.Windows.Controls.ComboBox)(target));
            
            #line 80 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.Year.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CatChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelBT = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.CancelBT.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveBT = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.SaveBT.Click += new System.Windows.RoutedEventHandler(this.SaveContent);
            
            #line default
            #line hidden
            return;
            case 11:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.ClearList = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\DataEntryForms\DataUpload.xaml"
            this.ClearList.Click += new System.Windows.RoutedEventHandler(this.ClearListBT);
            
            #line default
            #line hidden
            return;
            case 13:
            this.SavingInfo = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 20 "..\..\..\DataEntryForms\DataUpload.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveItem);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
