using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_First_Mega_Man_Clone
{
    class bossCharacter : Character
    {
        private int x;
        private int y;

        private int width;
        private int height;

        public bossCharacter(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void setX(int X)
        {
            this.x = X;
        }

        public void setY(int Y)
        {
            this.y = Y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }


        public int getWidth()
        {
            return this.width;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getHeight()
        {
            return this.height;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }
    

        public void invincibility()
        {
            throw new NotImplementedException();
        }


    }
}
