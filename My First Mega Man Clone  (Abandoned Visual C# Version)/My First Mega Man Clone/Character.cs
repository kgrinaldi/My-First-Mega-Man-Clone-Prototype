using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_First_Mega_Man_Clone
{
    public interface Character
    {
        void setX(int X);
        void setY(int Y);

        int getX();
        int getY();

        void setWidth(int width);
        void setHeight(int height);

        int getWidth();
        int getHeight();

        void invincibility();
    }
}
