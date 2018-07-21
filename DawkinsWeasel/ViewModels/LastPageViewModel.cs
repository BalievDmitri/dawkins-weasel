using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DawkinsWeasel.ViewModels
{
    public class LastPageViewModel:ObservableObject
    {
        List<string> generations;

        public LastPageViewModel(List<string> generations, Action restart)
        {
            Generations = generations;
            Restart = restart;
        }

        Action Restart;
        
        public List<string> Generations
        {
            get
            {
                return generations;
            }
            set
            {
                generations = value;
                RaisePropertyChangedEvent("Generations");
            }
        }

        public ICommand PlayAgain
        {
            get
            {
                return new DelegateCommand(() => { Restart(); });
            }
        }
    }
}
