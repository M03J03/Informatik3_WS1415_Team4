using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Manager
{
    class Dragon : Entity
    {
        private Dragon dragon;

        /// <summary>
        /// Generates an dragon object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="busy"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        protected Dragon(int id, String name, bool busy, int row, int column)
            : base(id, name, busy, row,column)
        {
            setDragon(this);
        }

        /// <summary>
        /// Sets the dragon object
        /// </summary>
        /// <param name="dragon"></param>
        private void setDragon(Dragon dragon)
        {
            this.dragon = dragon;
        }

        /// <summary>
        /// returnsthe dragon.
        /// </summary>
        /// <returns></returns>
        protected Dragon getDragon()
        {
            return dragon;
        }

        /// <summary>
        /// This method deletes a dragon.
        /// </summary>
        /// <param name="dragon"></param>
        protected void deleteDragon(Dragon dragon)
        {
            setDragon(null);
        }
    }
}
