namespace App3.DesignTime
{
    public class MainPageViewModel : App3.Interfaces.IMainPageViewModel
    {
        public MainPageViewModel()
        {
            this.Title = "Hello Designtime!";
        }

        public string Title {get; set; }

           
    }
}