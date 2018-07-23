using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models.Settings
{
    public class PropertiesBasedSettingsProvider : IMutationSettingsProvider, IMutationSettingsEditor
    {
        public PropertiesBasedSettingsProvider()
        {
            Goal = Properties.Settings.Default.Goal;
            Children = Properties.Settings.Default.Childerns;
            Probability = Properties.Settings.Default.Probability;
        }

        public int Children { get; set; }

        public double Probability { get; set; }

        public string Goal { get; set; }

        public void SaveSettings()
        {
            Properties.Settings.Default.Goal = Goal;
            Properties.Settings.Default.Childerns = Children;
            Properties.Settings.Default.Probability = Probability;
            Properties.Settings.Default.Save();
        }
    }
}
