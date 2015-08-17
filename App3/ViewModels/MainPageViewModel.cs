namespace App3.ViewModels
{
    using System.Collections.Generic;
    using Windows.UI.Xaml.Navigation;
    using Microsoft.Practices.Prism.Mvvm.Interfaces;
    using Microsoft.Practices.Prism.PubSubEvents;

    public class MainPageViewModel : Microsoft.Practices.Prism.Mvvm.ViewModel, Interfaces.IMainPageViewModel
    {
        private Interfaces.IDialogService _dialogService;
        private IEventAggregator _eventAggregator;
        private INavigationService _navigationService;
        public MainPageViewModel(Interfaces.IDialogService dialogService,
            IEventAggregator eventAggregator,INavigationService navigationService)
        {
            this._dialogService = dialogService;
            this._eventAggregator = eventAggregator;
            this._navigationService = navigationService;

        }
        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            this.Title = "Hello RunTime!";
            this._eventAggregator.GetEvent<Messages.Logout>().Subscribe(HandleLogout);
        }

        private void HandleLogout(string value)
        {
            this._dialogService.Show(value);
            this._navigationService.Navigate(App.Experience.Login.ToString(),null);
        }

        public string Title { get { return this._Title; } set { SetProperty(ref this._Title, value); } }
        private string _Title = default(string);
    }
}