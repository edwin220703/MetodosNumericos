﻿#pragma checksum "..\..\..\..\Pages\Interpolacion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5CD77B599606576AC160A77D229F73A0974546B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MetodosApp.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MetodosApp.Pages {
    
    
    /// <summary>
    /// Interpolacion
    /// </summary>
    public partial class Interpolacion : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_X1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_X;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_X2;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Fx1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Fx;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Fx2;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Pages\Interpolacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Busca;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MetodosApp;component/pages/interpolacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Interpolacion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TB_X1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TB_X = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TB_X2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TB_Fx1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TB_Fx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TB_Fx2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btn_Busca = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Pages\Interpolacion.xaml"
            this.btn_Busca.Click += new System.Windows.RoutedEventHandler(this.btn_Busca_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
