namespace App3
{
    public class MainPageViewModel : Interfaces.IMainPageViewModel
    {
        public MainPageViewModel()
        {
            this.Title = "Hello Designtime!";
        }

        public string Title {get; set; }

           
    }
}