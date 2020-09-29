using Autofac;
using Hyperledger.Aries.Routing;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using Xamarin.Forms;
using mikoba.Services;
using mikoba.UI.Pages;
using mikoba.UI.Pages.Connections;
using mikoba.UI.Pages.Credentials;
using mikoba.UI.Pages.Wallet;
using mikoba.UI.ViewModels;
using mikoba.ViewModels;
using mikoba.ViewModels.Pages;

namespace mikoba
{
    public partial class App : Application
    {
        public new static App Current => Application.Current as App;
        public static IContainer Container { get; set; }
        private static IHost Host { get; set; }
        public App(IHost host) : this() => Host = host;

        private IMediatorTimerService _mediatorTimerService;

        private INavigationService _navigationService;

        public App()
        {
            InitializeComponent();
            Preferences.Set(AppConstant.EnableFirstActionsView, false);
            this.StartServices();
        }

        private void StartServices()
        {
            _navigationService = Container.Resolve<INavigationService>();
            _mediatorTimerService = Container.Resolve<IMediatorTimerService>();
        }

        protected override async void OnStart()
        {
            await Host.StartAsync();

            _navigationService.AddPageViewModelBinding<WalletPageViewModel, WalletPage>();
            _navigationService.AddPageViewModelBinding<AcceptConnectionInviteViewModel, AcceptConnectionInvitePage>();
            _navigationService.AddPageViewModelBinding<CredentialOfferPageViewModel, CredentialOfferPage>();
            _navigationService.AddPageViewModelBinding<CredentialRequestPageViewModel, CredentialRequestPage>();
            _navigationService.AddPageViewModelBinding<EntryHubPageViewModel, EntryHubPage>();
            _navigationService.AddPageViewModelBinding<SplashPageViewModel, SplashPage>();

            if (Preferences.Get(AppConstant.LocalWalletProvisioned, false))
            {
                await _navigationService.NavigateToAsync<WalletPageViewModel>();
            }
            else
            {
                await _navigationService.NavigateToAsync<SplashPageViewModel>();    
            }
            
            _mediatorTimerService.Start();
        }

        protected override void OnSleep()
        {
            _mediatorTimerService.Pause();
        }

        protected override void OnResume()
        {
            _mediatorTimerService.Resume();
        }
    }
}
