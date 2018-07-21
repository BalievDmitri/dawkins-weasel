using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DawkinsWeasel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DawkinsWeasel.ViewModels
{
    public class NewInputPageModel : ViewModelBase
    {
        private string inputPhrase = "";

        public NewInputPageModel(Action startMutation, Action openSettingsAction)
        {
            StartMutation = startMutation;
            OpenSettingsAction = openSettingsAction;
        }

        public string InputPhrase
        {
            get => inputPhrase;
            set => Set(() => InputPhrase, ref inputPhrase, value);
        }

        Action StartMutation;
        Action OpenSettingsAction;

        RelayCommand mutateCommand;

        public RelayCommand Mutate
        {
            get
            {
                if (mutateCommand == null)
                    mutateCommand = new RelayCommand(StartMutation);

                return mutateCommand;
            }
        }

        RelayCommand openSettingsCommand;

        public RelayCommand OpenSettings
        {
            get
            {
                if (openSettingsCommand == null)
                    openSettingsCommand = new RelayCommand(OpenSettingsAction);

                return openSettingsCommand;
            }
        }

        RelayCommand exitCommand;

        public RelayCommand Exit
        {
            get
            {
                if (exitCommand == null)
                    exitCommand = new RelayCommand(() => Application.Current.Shutdown());

                return exitCommand;
            }
        }
        
    }
}
