using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawkinsWeasel.Models
{
    class RandomChar : Random
    {
        public RandomChar() : base((int)DateTime.Now.Ticks)
        {

        }

        public char NextCharacter()
        {
            const string AllowedChars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя?!,.";
            return AllowedChars[this.Next() % AllowedChars.Length];
        }
    }
}
