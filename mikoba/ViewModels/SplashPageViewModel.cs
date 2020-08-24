using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using mikoba.Annotations;
using mikoba.UI;
using mikoba.UI.Pages;
using Sentry;
using Xamarin.Forms;

namespace mikoba.ViewModels
{
    public class SplashPageViewModel : KivaBaseViewModel, INotifyPropertyChanged
    {
        public INavigation NavigationService { get; private set; }
        public ICommand GetStartedCommand { get; set; }
        public ICommand ClaimWalletCommand { get; set; }

        public SplashPageViewModel(INavigation navigationService)
        {
            this.NavigationService = navigationService;
            this.GetStartedCommand = new Command(async () =>
            {
                var page = NavigationService.NavigationStack.Last();
                await NavigationService.PushAsync(new WalletCreationPage());
                NavigationService.RemovePage(page);
            });
            this.ClaimWalletCommand = new Command(async () =>
            {
                //TODO
            });
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}