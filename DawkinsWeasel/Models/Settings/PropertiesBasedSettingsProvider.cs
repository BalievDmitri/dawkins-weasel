using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models.Settings
{
    public class PropertiesBasedSettingsProvider : IMutationSettingsProvider
    {
        public PropertiesBasedSettingsProvider()
        {
            Goal = Properties.Settings.Default.Goal;
            Children = Properties.Settings.Default.Childerns;
            Probability = Properties.Settings.Default.Probability;
        }

        public int Children { get; }

        public double Probability { get; }

        public string Goal { get; }
    }
}
