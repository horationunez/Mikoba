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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentialRequestCard : ContentView
    {
        public CredentialRequestCard()
        {
            InitializeComponent();
            this.BindingContext = CredentialRequestCardViewModel.Instance;
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