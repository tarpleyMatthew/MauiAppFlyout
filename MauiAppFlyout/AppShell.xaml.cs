using MauiAppFlyout.ViewModels;

namespace MauiAppFlyout
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new FlyoutViewModel();
        }
    }
}
