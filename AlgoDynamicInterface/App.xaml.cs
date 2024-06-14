using System.Configuration;
using System.Data;
using System.Windows;
using Telerik.Windows.Controls;

namespace AlgoDynamicInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Windows11ThemeSizeHelper.Helper.IsInCompactMode= true;
        }
    }

}
