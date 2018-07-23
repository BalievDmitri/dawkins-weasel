using DawkinsWeasel.Models.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DawkinsWeasel.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(Action closeAction, IMutationSettingsEditor settingsEditor)
        {
            Settings = settingsEditor;

            OkCommand = new RelayCommand(() =>
            {
                Settings.SaveSettings();
                closeAction.Invoke();
            });

            CancelCommand = new RelayCommand(closeAction);
        }

        public IMutationSettingsEditor Settings { get; }

        public RelayCommand OkCommand { get; }

        public RelayCommand CancelCommand { get; }
    }
}
