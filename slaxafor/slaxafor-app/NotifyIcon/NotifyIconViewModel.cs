using LuxaforSharp;
using System.Windows;

namespace slaxafor_app.NotifyIcon
{
    public class NotifyIconViewModel
    {
        private IDevice _luxafor;

        public NotifyIconViewModel(IDevice luxafor)
        {
            _luxafor = luxafor;
        }

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
                    CommandAction = () => Blink(),
                    CanExecuteFunc = () => true
                };
            }
        }

        private void Blink()
        {
            _luxafor.CarryOutPattern(PatternType.RainbowWave, 1);
        }

    }
}
