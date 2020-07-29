using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using CustomActivityIndicator.Droid;
using CustomActivityIndicator.Intefaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ActivityIndicatorAndroid))]
namespace CustomActivityIndicator.Droid
{
    public class ActivityIndicatorAndroid : IMyActivityIndicator
    {
        Android.Views.View _nativeView;
        bool initialized;
        Dialog dialog;
        public ActivityIndicatorAndroid()
        {
        }


        private void CreateNativeView(ContentPage page)
        {
            try
            {
                if (page != null)
                {
                    page.Parent = Xamarin.Forms.Application.Current.MainPage;

                    page.Layout(new Rectangle(0, 0, Xamarin.Forms.Application.Current.MainPage.Width, Xamarin.Forms.Application.Current.MainPage.Height));
                    var nativeRenderer = Xamarin.Forms.Platform.Android.Platform.CreateRendererWithContext(page,MainActivity.ContextActivity);
                    _nativeView = nativeRenderer?.View;

                    dialog = new Dialog(MainActivity.ContextActivity);

                    dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

                    dialog.SetCancelable(false);
                    dialog.SetContentView(_nativeView);

                    Window window = dialog.Window;

                    window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                    window.ClearFlags(WindowManagerFlags.DimBehind);
                    window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

                    initialized = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void CloseIndicator()
        {
            dialog.Hide();
        }

        public void OpenIndicator(ContentPage page)
        {
            if (!initialized)
                CreateNativeView(page);

            if (_nativeView != null)
            {
                _nativeView.Alpha = 0.6f;

                dialog.Show();
            }
        }
    }
}
