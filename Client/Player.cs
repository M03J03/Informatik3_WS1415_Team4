using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client
{
    class Player
    {
        private int id;
        private String name;
        private int score;
        private Boolean busy;
        private int x, y;

        private void setID(int id)
        {
            this.id = id;
        }

        public int getId() 
        {
            return id;
        }

        private void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        private void setScore(int score)
        {
            this.score = score;
        }

        public int getScore()
        {
            return score;
        }

        private void setX(int x)
        {
            this.x = x;
        }

        public int getX()
        {
            return x;
        }

        private void setY(int y)
        {
            this.y = y;
        }

        public int getY()
        {
            return y;
        }

        public void figth()
        {

        }

        public void rest()
        {

        }



    }
}
