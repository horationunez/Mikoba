﻿using System;
using System.ComponentModel;
using mikoba.ViewModels;
using Xamarin.Forms;

namespace mikoba.UI.Pages.Connections
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ConnectionsListPage : ContentPage
    {
        public ConnectionsListPage()
        {
            InitializeComponent();
            BindingContext = new ConnectionsListViewModel();
        }

        async void OnCredentialsPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConnectionDetailsPage());
        }
    }
}