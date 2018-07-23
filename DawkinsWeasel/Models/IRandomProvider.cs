using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models
{
    public interface IRandomProvider
    {
        char NextCharacter();
        double NextDouble();
        int Next(int minValue, int maxValue);
    }
}
