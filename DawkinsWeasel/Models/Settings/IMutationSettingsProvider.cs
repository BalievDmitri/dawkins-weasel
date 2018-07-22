using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models.Settings
{
    /// <summary>
    /// This interface describes a provider for settings used in the mutation process
    /// </summary>
    public interface IMutationSettingsProvider
    {
        int Children { get; }

        double Probability { get; }

        string Goal { get; }
    }
}
