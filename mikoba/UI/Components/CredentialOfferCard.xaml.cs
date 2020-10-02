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
        public static readonly BindableProperty NationalIdProperty =
            BindableProperty.Create("NationalId", typeof(string), typeof(CredentialOfferCard), default(string));
            
        public string NationalId
        {
            get { return (string)GetValue(NationalIdProperty); }
            set { SetValue(NationalIdProperty, value); }
        }
        
        public static readonly BindableProperty FirstNameProperty =
            BindableProperty.Create("FirstName", typeof(string), typeof(CredentialOfferCard), default(string));
            
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        
        public static readonly BindableProperty LastNameProperty =
            BindableProperty.Create("LastName", typeof(string), typeof(CredentialOfferCard), default(string));
            
        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
        
        public static readonly BindableProperty BirthDateProperty =
            BindableProperty.Create("BirthDate", typeof(string), typeof(CredentialOfferCard), default(string));
        
        public string BirthDate
        {
            get { return (string)GetValue(BirthDateProperty); }
            set { SetValue(BirthDateProperty, value); }
        }
        
        public CredentialOfferCard()
        {
            InitializeComponent();
            this.BindingContext = CredentialOfferCardViewModel.Instance;
            NationalIdLabel.SetBinding(Label.TextProperty, new Binding("NationalId", source: this));
            NationalIdLabel2.SetBinding(Label.TextProperty, new Binding("NationalId", source: this));
            FirstNameLabel.SetBinding(Label.TextProperty, new Binding("FirstName", source: this));
            FirstNameLabel2.SetBinding(Label.TextProperty, new Binding("FirstName", source: this));
            LastNameLabel.SetBinding(Label.TextProperty, new Binding("LastName", source: this));
            LastNameLabel2.SetBinding(Label.TextProperty, new Binding("LastName", source: this));
            BirthDateLabel.SetBinding(Label.TextProperty, new Binding("BirthDate", source: this));
            BirthDateLabel2.SetBinding(Label.TextProperty, new Binding("BirthDate", source: this));
        }
    }
}
