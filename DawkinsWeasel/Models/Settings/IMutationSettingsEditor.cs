using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models.Settings
{
    /// <summary>
    /// This interface describes an editor for settings used in the mutation process
    /// </summary>
    public interface IMutationSettingsEditor
    {
        int Children { get; set; }

        double Probability { get; set; }

        string Goal { get; set; }

        void SaveSettings();
    }
}
