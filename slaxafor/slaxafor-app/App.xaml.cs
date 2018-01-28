using Hardcodet.Wpf.TaskbarNotification;
using LuxaforSharp;
using slaxafor_app.NotifyIcon;
using System.Linq;
using System.Windows;
using slaxafor;
using slaxafor_app.Notifier;

namespace slaxafor_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon _taskbarIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var model = new NotifyIconViewModel();
            
            _taskbarIcon = (TaskbarIcon)FindResource("NotifyIcon");
            _taskbarIcon.DataContext = model;

            model.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }

}
