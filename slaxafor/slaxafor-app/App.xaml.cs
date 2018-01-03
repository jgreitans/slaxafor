using Hardcodet.Wpf.TaskbarNotification;
using LuxaforSharp;
using slaxafor_app.NotifyIcon;
using System.Linq;
using System.Windows;

namespace slaxafor_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IDevice _luxafor;
        private TaskbarIcon _taskbarIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IDeviceList list = new DeviceList();
            list.Scan();
            _luxafor = list.First();
            _taskbarIcon = (TaskbarIcon)FindResource("NotifyIcon");
            _taskbarIcon.DataContext = new NotifyIconViewModel(_luxafor);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            _luxafor.Blink(LedTarget.All, new Color(0, 0, 0), 1);
            _luxafor.Dispose();
            base.OnExit(e);
        }
    }
}
