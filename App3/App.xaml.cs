using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=402347&clcid=0x409

namespace App3
{
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.Practices.Prism.Mvvm.Interfaces;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Unity;
    using Services;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Microsoft.Practices.Prism.Mvvm.MvvmAppBase
    {
        static readonly UnityContainer _container = new UnityContainer();
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            _container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            _container.RegisterInstance<IEventAggregator>(new EventAggregator());
            _container.RegisterInstance<INavigationService>(this.NavigationService);
            return Task.FromResult<object>(null);
        }

        protected override object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public enum Experience { Main, Login }

        protected override System.Threading.Tasks.Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            this.NavigationService.Navigate(Experience.Main.ToString(),null);

            _container.Resolve<IEventAggregator>()
                .GetEvent<Messages.Logout>()
                .Publish("You need to log in!");

            return System.Threading.Tasks.Task.FromResult<object>(null);
        }

    }
}
