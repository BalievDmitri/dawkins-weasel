using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DawkinsWeasel.ViewModels
{
    public class LastPageViewModel : ViewModelBase
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
            get => generations;
            set => Set(() => Generations, ref generations, value);
        }

        RelayCommand playAgainCommand;

        public RelayCommand PlayAgain
        {
            get
            {
                if (playAgainCommand == null)
                    playAgainCommand = new RelayCommand(Restart);

                return playAgainCommand;
            }
        }
    }
}
