using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam.Zero.Classes;
using Xam.Zero.Dev.Features.Second;
using Xam.Zero.Services;
using Xam.Zero.ViewModels;
using Xamarin.Forms;

namespace Xam.Zero.Dev.Features.Home
{
    public class HomeViewModel : ZeroBaseModel
    {
        private readonly IShellService _shellService;
        private string _text;
        public string Text
        {
            get => this._text;
            set
            {
                this._text = value;
                this.RaisePropertyChanged(()=>this.Text);
            } 
        }

        public ICommand NavigateCommand { get; set; }
        public ICommand GoToTabbedCommand { get; set; }
        public ICommand TestShellServiceCommand { get; set; }
        
        
        
        

        public HomeViewModel(IShellService shellService)
        {
            this._shellService = shellService;
            this.Text = "Ctor";
            this.NavigateCommand = new Command(async ()=> await this.GoTo<SecondPage>(null));
            this.GoToTabbedCommand = new Command(() =>
            {
                this._shellService.SwitchContainer<TabbedShell>();
            });
            
            this.TestShellServiceCommand = new Command(() =>
            {
//                this._shellService.Test();
            });
        }


        protected override Task Init(object data)
        {
            
            this.Text = "init";
            return base.Init(data);
        }

        protected override Task ReverseInit(object data)
        {
            this.Text = "reverseinit";
            return base.ReverseInit(data);
        }
      
    }
}