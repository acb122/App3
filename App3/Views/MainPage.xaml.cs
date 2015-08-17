using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App3.Views
{
    using Microsoft.Practices.Prism.Mvvm;


    public sealed partial class MainPage : PageBase, IView
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}

