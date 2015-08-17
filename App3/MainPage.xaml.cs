using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace App3
{
    namespace Controls
    {
        public abstract partial class PageBase : Page, Microsoft.Practices.Prism.Mvvm.IView
        {
        }
    }

    namespace Views
    {
        public sealed partial class MainPage : Controls.PageBase
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
        }
    }

    namespace Interfaces
    {
        public interface IMainPageViewModel
        {
            string Title { get; set; }
        }

        public interface IDialogService
        {
            void Show(string content);
        }

        public interface ILoginPageViewModel
        {
            string Username { get; set; }
            string Password { get; set; }
        }
    }

    namespace Services
    {
        public class DialogService : Interfaces.IDialogService
        {
            public async void Show(string content)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(content);
                await dialog.ShowAsync();
            }
        }
        
    }

    namespace Messages
    {
        public class Logout : Microsoft.Practices.Prism.PubSubEvents.PubSubEvent<string>
        {
            
        }
    }

    namespace ViewModels
    {
        using Microsoft.Practices.Prism.Mvvm;
        using Microsoft.Practices.Prism.Mvvm.Interfaces;
        using Microsoft.Practices.Prism.PubSubEvents;


        public class LoginPageViewModel : ViewModel, Interfaces.ILoginPageViewModel
        {

            private string _Username;
            [RestorableState]
            public string Username
            {
                get { return this._Username; }
                set { SetProperty(ref _Username, value); }
            }

            private string _Password;
            [RestorableState]
            public string Password
            {
                get { return this._Password; }
                set { SetProperty(ref _Password, value); }
            }
        }

        public class MainPageViewModel : Microsoft.Practices.Prism.Mvvm.ViewModel, Interfaces.IMainPageViewModel
        {
            private Interfaces.IDialogService _dialogService;
            private IEventAggregator _eventAggregator;
            private INavigationService _navigationService;
            public MainPageViewModel(Interfaces.IDialogService dialogService,
                IEventAggregator eventAggregator,INavigationService navigationService)
            {
                _dialogService = dialogService;
                _eventAggregator = eventAggregator;
                _navigationService = navigationService;

            }
            public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
            {
                this.Title = "Hello RunTime!";
                _eventAggregator.GetEvent<Messages.Logout>().Subscribe(HandleLogout);
            }

            private void HandleLogout(string value)
            {
                _dialogService.Show(value);
                _navigationService.Navigate(App.Experience.Login.ToString(),null);
            }

            public string Title { get { return _Title; } set { SetProperty(ref _Title, value); } }
            private string _Title = default(string);
        }
    }

    namespace DesignTime
    {
        public class LoginPageViewModel : Interfaces.ILoginPageViewModel
        {
            public LoginPageViewModel()
            {
                this.Username = "Design username";
                this.Password = "Design password";
            }


            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class MainPageViewModel : Interfaces.IMainPageViewModel
        {
            public MainPageViewModel()
            {
                this.Title = "Hello Designtime!";
            }

            public string Title {get; set; }

           
            }
        }
    }
    
    

    

