using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DawkinsWeasel.ViewModels
{
    public class SettingsViewModel:ObservableObject
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

        public ICommand OK
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Properties.Settings.Default.Goal = Goal;
                    Properties.Settings.Default.Childerns = Children;
                    Properties.Settings.Default.Probability = Probability;
                    Properties.Settings.Default.Save();
                    CloseAction.Invoke();
                });
            }
        }

        public ICommand Cancel
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CloseAction.Invoke();
                });
            }
        }

        public string Goal
        {
            get
            {
                return goal;
            }

            set
            {
                goal = value;
                RaisePropertyChangedEvent("Goal");
            }
        }

        public int Children
        {
            get
            {
                return children;
            }

            set
            {
                children = value;
                RaisePropertyChangedEvent("Children");
            }
        }

        public double Probability
        {
            get
            {
                return probability;
            }

            set
            {
                probability = value;
                RaisePropertyChangedEvent("Probability");
            }
        }
    }
}
