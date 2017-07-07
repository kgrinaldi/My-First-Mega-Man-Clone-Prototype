using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_First_Mega_Man_Clone
{
    public class playerCharacter : Character
    {
        private int x;
        private int y;

        private int width;
        private int height;

        private bool controls = false;

        public playerCharacter(int X, int Y)
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

        public void controlsActive()
        {
            if (controls == false)
            {
                controls = true;
            }

            else
            {
                controls = false;
            }
        }

        public void readInput(KeyEventArgs e)
        {
            char key = (char)e.KeyValue;
            switch (key)
            {
                case 'W':
                    Console.WriteLine("W" + key);
                    break;
                case 'A':
                    Console.WriteLine("A" + key);
                    break;
                case 'S':
                    Console.WriteLine("S" + key);
                    break;
                case 'D':
                    Console.WriteLine("D" + key);
                    break;
                case 'J':
                    Console.WriteLine("J" + key);
                    break;
                case 'K':
                    Console.WriteLine("K" + key);
                    break;
                case 'L':
                    Console.WriteLine("L" + key);
                    break;
                default:
                    Console.WriteLine("Unknown Input: " + key);
                    break;
            }
        }



        public void invincibility()
        {
            throw new NotImplementedException();
        }
    }
}
