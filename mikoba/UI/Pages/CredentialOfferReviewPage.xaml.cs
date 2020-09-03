﻿using System;
using System.ComponentModel;
using mikoba.ViewModels;
using Xamarin.Forms;

namespace mikoba.UI.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CredentialOfferReviewPage : ContentPage
    {
        public CredentialOfferReviewPage()
        {
            InitializeComponent();
            BindingContext = CredentialOfferReviewViewModel.Instance;
            CredentialOfferReviewViewModel.Instance.NavigationService = this.Navigation;
        }
        
    }
}
