using System.Linq;
using LuxaforSharp;
using System.Windows;
using slaxafor;
using slaxafor.Credentials;
using slaxafor_app.Notifier;

namespace slaxafor_app.NotifyIcon
{
    public class NotifyIconViewModel
    {
        private IDevice _luxafor;
        private ISlackNotifier _notifier;


        public System.Windows.Input.ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => Application.Current.MainWindow == null,
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow = new MainWindow();
                        Application.Current.MainWindow.Show();
                    }
                };
            }
        }

        public System.Windows.Input.ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
            }
        }

        public System.Windows.Input.ICommand BlinkCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = Blink,
                    CanExecuteFunc = () => true
                };
            }
        }

        public void Start()
        {
            IDeviceList list = new DeviceList();
            list.Scan();
            _luxafor = list.First();

            var appCredentials = AppCredentialModel.Load(".app-secret.json");

            _notifier = new SlackNotifier(_luxafor, Slaxafor.GetSlackListener("dev-sandbox-jg", appCredentials));
        }

        private void Blink()
        {
            _luxafor.CarryOutPattern(PatternType.RainbowWave, 1);
        }

    }
}
