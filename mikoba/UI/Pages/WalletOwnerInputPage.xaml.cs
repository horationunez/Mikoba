using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mikoba.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mikoba.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletOwnerInputPage : ContentPage
    {
        public WalletOwnerInputPage()
        {
            InitializeComponent();
            BindingContext = new WalletOwnerInputViewModel(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(200);
            OwnerEntry.Focus();
        }
    }
}