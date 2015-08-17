namespace App3.ViewModels
{
    using Microsoft.Practices.Prism.Mvvm;

    public class LoginPageViewModel : ViewModel, Interfaces.ILoginPageViewModel
    {
        public LoginPageViewModel()
        {
            Username = "testme";
        }
        private string _Username;
        [RestorableState]
        public string Username
        {
            get { return this._Username; }
            set { SetProperty(ref this._Username, value); }
        }

        private string _Password;
        [RestorableState]
        public string Password
        {
            get { return this._Password; }
            set { SetProperty(ref this._Password, value); }
        }
    }
}