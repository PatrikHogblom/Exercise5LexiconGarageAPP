using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5LexiconGarage.UserInterface
{
    public interface IUI
    {
        void DisplayMainMenu();
        void DisplaySubMenu(int indexGarage);

    }
}
