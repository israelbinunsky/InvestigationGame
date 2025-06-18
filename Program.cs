using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IranianAgent agent = new SquadLeader();
            control.createWeaknesses(agent);
            game.start(agent);
        }
    }
}