using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using mikoba.ViewModels;
using Xamarin.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mikoba.UI.Components
{
    public partial class CredentialOfferCard : ContentView
    {
        public static readonly BindableProperty SsnTextProperty =
            BindableProperty.Create("SsnText", typeof(string), typeof(CredentialOfferCard), default(string));
            
        public string SsnText
        {
            get { return (string)GetValue(SsnTextProperty); }
            set { SetValue(SsnTextProperty, value); }
        }
        
        public CredentialOfferCard()
        {
            InitializeComponent();
            this.BindingContext = CredentialOfferCardViewModel.Instance;
            SsnTextLabel.SetBinding(Label.TextProperty, new Binding("SsnText", source: this));
            SsnTextLabel2.SetBinding(Label.TextProperty, new Binding("SsnText", source: this));
        }
    }
}
