using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CustomActivityIndicator
{
    public partial class IndicatorPage : ContentPage
    {
        public IndicatorPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty IsVisible1Property = BindableProperty.Create(nameof(IsVisible1), typeof(bool), typeof(IndicatorPage), false);

        public bool IsVisible1
        {
            get => (bool)GetValue(IsVisible1Property);
            set => SetValue(IsVisible1Property, value);
        }


        public static readonly BindableProperty IsVisible2Property = BindableProperty.Create(nameof(IsVisible2), typeof(bool), typeof(IndicatorPage), false);

        public bool IsVisible2
        {
            get => (bool)GetValue(IsVisible2Property);
            set => SetValue(IsVisible2Property, value);
        }
    }
}
