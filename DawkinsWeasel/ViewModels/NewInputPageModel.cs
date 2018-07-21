using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DawkinsWeasel;
using System.Windows;

namespace DawkinsWeasel.ViewModels
{
    public class NewInputPageModel : ObservableObject
    {
        private string inputPhrase = "";

        public NewInputPageModel(Action startMutation, Action openSettingsAction)
        {
            StartMutation = startMutation;
            OpenSettingsAction = openSettingsAction;
        }

        public string InputPhrase
        {
            get
            {
                return inputPhrase;
            }

            set
            {
                inputPhrase = value;
                RaisePropertyChangedEvent("InputPhrase");
            }
        }

        Action StartMutation;
        Action OpenSettingsAction;

        public ICommand Mutate
        {
            get
            {
                return new DelegateCommand(StartMutation);
            }
        }

        public ICommand OpenSettings
        {
            get
            {
                return new DelegateCommand(OpenSettingsAction);
                //return new DelegateCommand(() =>
                //{
                //    var settings = new Views.Settings();
                //    settings.DataContext = new SettingsViewModel(settings.Close);
                //    settings.Owner = Application.Current.MainWindow;
                //    settings.ShowDialog();
                //    settings = null;
                //});
            }
        }

        public ICommand Exit
        {
            get
            {
                return new DelegateCommand(() => Application.Current.Shutdown());
            }
        }
        
    }
}
