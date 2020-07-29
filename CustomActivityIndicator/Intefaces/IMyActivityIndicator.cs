using System;
using Xamarin.Forms;

namespace CustomActivityIndicator.Intefaces
{
    public interface IMyActivityIndicator
    {
        void OpenIndicator(ContentPage page);
        void CloseIndicator();
    }
}
