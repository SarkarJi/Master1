using System;
using CustomActivityIndicator.Intefaces;
using CustomActivityIndicator.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ActivityIndicatoriOS))]
namespace CustomActivityIndicator.iOS
{
    public class ActivityIndicatoriOS : IMyActivityIndicator
    {
        UIView _nativeView;
        bool initialized;

        public ActivityIndicatoriOS()
        {
        }

        public void CloseIndicator()
        {
            _nativeView.RemoveFromSuperview();
        }

        private void CreateNativeView(ContentPage page)
        {
            try
            {
                if(page != null )
                {
                    page.Parent = Xamarin.Forms.Application.Current.MainPage;

                    page.Layout(new Rectangle(0,0, Xamarin.Forms.Application.Current.MainPage.Width, Xamarin.Forms.Application.Current.MainPage.Height));
                    var nativeRenderer = Xamarin.Forms.Platform.iOS.Platform.CreateRenderer(page);
                    _nativeView = nativeRenderer?.NativeView;
                    initialized = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OpenIndicator(ContentPage page)
        {
            if (!initialized)
                CreateNativeView(page);

            if(_nativeView !=null)
            {
                _nativeView.Alpha = 0.6f;
                UIApplication.SharedApplication.KeyWindow.AddSubview(_nativeView);
            }
        }
    }
}
