﻿

#pragma checksum "C:\Users\Deep Patel\Documents\Visual Studio 2013\Projects\NSM\NSM\FiniteInterpolation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "359EB8777E9D879EF92158F877E0BDDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSM
{
    partial class FiniteInterpolation : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard storyBoard; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard langrange; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard NewtonForward; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.Animation.Storyboard NewtonBackward; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Grid LayoutRoot; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform NewtonBackwardName; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform NewtonForwardName; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform NewtonBackwardSymbol; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform NewtonForwardSymbol; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform lanName; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform lanSymbol; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Media.TranslateTransform Animation; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///FiniteInterpolation.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            storyBoard = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("storyBoard");
            langrange = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("langrange");
            NewtonForward = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("NewtonForward");
            NewtonBackward = (global::Windows.UI.Xaml.Media.Animation.Storyboard)this.FindName("NewtonBackward");
            LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)this.FindName("LayoutRoot");
            NewtonBackwardName = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("NewtonBackwardName");
            NewtonForwardName = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("NewtonForwardName");
            NewtonBackwardSymbol = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("NewtonBackwardSymbol");
            NewtonForwardSymbol = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("NewtonForwardSymbol");
            lanName = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("lanName");
            lanSymbol = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("lanSymbol");
            Animation = (global::Windows.UI.Xaml.Media.TranslateTransform)this.FindName("Animation");
        }
    }
}


