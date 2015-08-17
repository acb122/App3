using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.ViewModels
{
    using Microsoft.Practices.Prism.Mvvm;

    public class TestPageViewModel: ViewModel, Interfaces.ITestPageViewModel
    {
        public string Title { get; set; }
        public TestPageViewModel()
        {
            Title = "test";
        }
    }
}
