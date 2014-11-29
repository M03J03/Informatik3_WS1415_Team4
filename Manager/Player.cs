using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Manager
{
    class Player : Entity
    {
        private int points = 0;
        //private Decission decision;


        protected Player(int id, String name, bool busy, int row, int column, int points)
            : base(id, name, busy, row, column)
        { 
            setPoints(points);
            setDecision(Decision.UNDEFINED);
        }

    }
}
