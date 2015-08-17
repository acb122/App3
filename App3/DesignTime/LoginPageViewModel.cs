namespace App3.DesignTime
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
}