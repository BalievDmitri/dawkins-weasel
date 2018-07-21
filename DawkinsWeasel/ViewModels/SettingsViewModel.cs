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
        private string goal;
        private int children;
        private double probability;


        public SettingsViewModel(Action closeAction)
        {
            goal = Properties.Settings.Default.Goal;
            Children = Properties.Settings.Default.Childerns;
            Probability = Properties.Settings.Default.Probability;
            CloseAction = closeAction;
        }

        Action CloseAction;

        RelayCommand okCommand;

        public RelayCommand OK
        {
            get
            {
                if (okCommand == null)
                    okCommand = new RelayCommand(() =>
                    {
                        Properties.Settings.Default.Goal = Goal;
                        Properties.Settings.Default.Childerns = Children;
                        Properties.Settings.Default.Probability = Probability;
                        Properties.Settings.Default.Save();
                        CloseAction.Invoke();
                    });

                return okCommand;
            }
        }

        RelayCommand cancelCommand;

        public RelayCommand Cancel
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new RelayCommand(CloseAction);

                return cancelCommand;
            }
        }

        public string Goal
        {
            get => goal;
            set => Set(() => Goal, ref goal, value);
        }

        public int Children
        {
            get => children;
            set => Set(() => Children, ref children, value);
        }

        public double Probability
        {
            get => probability;
            set => Set(() => Probability, ref probability, value);
        }
    }
}
