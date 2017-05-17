// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RecipePal.iOS.Views
{
    [Register ("LoginView")]
    partial class LoginView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FacebookBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoogleBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LoginDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView LoginPlaceholder { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LoginTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MicrosoftBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FacebookBtn != null) {
                FacebookBtn.Dispose ();
                FacebookBtn = null;
            }

            if (GoogleBtn != null) {
                GoogleBtn.Dispose ();
                GoogleBtn = null;
            }

            if (LoginBtn != null) {
                LoginBtn.Dispose ();
                LoginBtn = null;
            }

            if (LoginDesc != null) {
                LoginDesc.Dispose ();
                LoginDesc = null;
            }

            if (LoginPlaceholder != null) {
                LoginPlaceholder.Dispose ();
                LoginPlaceholder = null;
            }

            if (LoginTitle != null) {
                LoginTitle.Dispose ();
                LoginTitle = null;
            }

            if (MicrosoftBtn != null) {
                MicrosoftBtn.Dispose ();
                MicrosoftBtn = null;
            }
        }
    }
}