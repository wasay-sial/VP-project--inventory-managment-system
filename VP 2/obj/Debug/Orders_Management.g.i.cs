﻿#pragma checksum "..\..\Orders_Management.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "18E4652ABBE6C19EA72A3E78772832D2DEE3519DD1FBF813924A4CE3C93553FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using System.Windows.Shell;
using VP_2;


namespace VP_2 {
    
    
    /// <summary>
    /// Orders_Management
    /// </summary>
    public partial class Orders_Management : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\Orders_Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteOrderButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Orders_Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateOrderButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Orders_Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchOrderButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Orders_Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid orderDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VP 2;component/orders_management.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Orders_Management.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DeleteOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Orders_Management.xaml"
            this.DeleteOrderButton.Click += new System.Windows.RoutedEventHandler(this.DeleteOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UpdateOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\Orders_Management.xaml"
            this.UpdateOrderButton.Click += new System.Windows.RoutedEventHandler(this.UpdateOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\Orders_Management.xaml"
            this.SearchOrderButton.Click += new System.Windows.RoutedEventHandler(this.SearchOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.orderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

