using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    //interface containing win method that has to be overrided in extended ComputerPlayer class
    interface IComputerPlayer
    {
        void Win();
    }
}
