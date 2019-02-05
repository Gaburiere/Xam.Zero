using Autofac;
using Xam.Zero.Autofac;
using Xam.Zero.SimpleTabbedApp.Shells;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Xam.Zero.SimpleTabbedApp
{
    public partial class App : Application
    {
        public static readonly ContainerBuilder Container = new ContainerBuilder();

        public App()
        {
            InitializeComponent();
            
            ZeroApp
                .On(this)
                .WithContainer(AutofacZeroContainer.Build(Container))
                .RegisterShell(() => new SimpleShell())
                .RegisterShell(() => new TabbedShell())
                .StartWith<SimpleShell>();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}