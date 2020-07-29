using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomActivityIndicator.Intefaces;
using Xamarin.Forms;

namespace CustomActivityIndicator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IMyActivityIndicator myActivityIndicator = DependencyService.Get<IMyActivityIndicator>(DependencyFetchTarget.GlobalInstance);
            var page = new IndicatorPage() {IsVisible2 = true };
            myActivityIndicator.OpenIndicator(page);

            Device.StartTimer(TimeSpan.FromSeconds(4),()=> {

                myActivityIndicator.CloseIndicator();
                return false;
            });
        }
    }
}
