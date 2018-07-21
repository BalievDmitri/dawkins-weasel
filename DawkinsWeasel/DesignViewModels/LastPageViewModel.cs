using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DawkinsWeasel.DesignViewModels
{
    public class LastPageViewModel
    {
        string goal;

        private ObservableCollection<string> generations = new ObservableCollection<string>();
        

        public LastPageViewModel()
        {
            for (int i = 0; i < 20; i++)
                generations.Add("Test phrase " + i.ToString());
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
