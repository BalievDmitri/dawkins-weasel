using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawkinsWeasel.Models;
using System.Windows.Threading;

namespace DawkinsWeasel.DesignViewModels
{
    public class MutatingViewModel
    {
        private string state = "Oh my state!";
        private ObservableCollection<string> generations = new ObservableCollection<string>();

        public MutatingViewModel()
        {
            for (int i = 0; i < 20; i++)
                generations.Add("Test phrase " + i.ToString());
        }
        

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public ObservableCollection<string> Generations
        {
            get
            {
                return generations;
            }

            set
            {
                generations = value;
            }
        }
    }
}
