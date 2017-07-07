using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace My_First_Mega_Man_Clone
{
    public partial class formGame : Form
    {
        private int width;
        private int height;
        private int index = 23;

        private int[][] collisionGrid = new int[][] {
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        private List<List<Point>> collision = new List<List<Point>>();

        private Point center;

        private playerCharacter player;
        private bossCharacter boss;

        private Image backgroundImage = Properties.Resources.Boss_Arena;

        private Image[] spritesMegaMan = new Image[]{
            Properties.Resources.Mega_Man_Left, Properties.Resources.Mega_Man_Right,
            Properties.Resources.Mega_Man_Jump_Left, Properties.Resources.Mega_Man_Jump_Right,
            Properties.Resources.Mega_Man_Hurt_Left, Properties.Resources.Mega_Man_Hurt_Right,
            Properties.Resources.Mega_Man_Fire_Left, Properties.Resources.Mega_Man_Fire_Right,
            Properties.Resources.Mega_Man_Jump_Fire_Left, Properties.Resources.Mega_Man_Jump_Fire_Right,
            Properties.Resources.Mega_Man_Run_One_Left, Properties.Resources.Mega_Man_Run_One_Right,
            Properties.Resources.Mega_Man_Run_Two_Left, Properties.Resources.Mega_Man_Run_Two_Right,
            Properties.Resources.Mega_Man_Run_Three_Left, Properties.Resources.Mega_Man_Run_Three_Right,
            Properties.Resources.Mega_Man_Run_Fire_One_Left, Properties.Resources.Mega_Man_Run_Fire_One_Right,
            Properties.Resources.Mega_Man_Run_Fire_Two_Left, Properties.Resources.Mega_Man_Run_Fire_Two_Right,
            Properties.Resources.Mega_Man_Run_Fire_Three_Left, Properties.Resources.Mega_Man_Run_Fire_Three_Right,
            Properties.Resources.Mega_Man_Hit
        };
        

        public formGame(){
            InitializeComponent();
            width = panelGame.Width;
            height = panelGame.Height;
            center = new Point(width / 2, height / 2);
            Console.WriteLine(" Dimensions (" + width + ", " + height + ")");
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------");

            formCollisionDetection();

            player = new playerCharacter(center.X / 4, center.Y / 4);
            boss = new bossCharacter(center.X, center.Y);

            refreshGame.Start();
        }

        public void formCollisionDetection()        //this isn't the most efficient algorithm; my plan is to get a simple one working and then refine once i start to reuse this code to make a Mega Man Level
        {                                           //when this project is further along, i will improve it by sotring it as larger rectangles
            collision.Clear();

            for (int x = 0; x < collisionGrid[0].Length; x++){
                // get initial coordinates from the grid array interpreted here
                for (int y = 0; y < collisionGrid.Length; y++){
                    if (collisionGrid[y][x] == 1){
                        int a = 1;
                        int b = 1;

                        List<Point> c = new List<Point>();

                        if (collisionGrid[y + b][x] == 1) {

                            for(int i = b; i < collisionGrid.Length - 1; i++){
                                if(y + b != collisionGrid.Length - 1){
                                    b++;
                                }
                            }

                            c.Add(new Point(x, y));
                            c.Add(new Point(x + a, y + b));

                            /*Console.WriteLine("New Collision Square");
                            Console.WriteLine("(" + x + "," + y + ")");
                            Console.WriteLine("(" + (x + a) + "," + (y + b) + ")");
                            Console.WriteLine(" "); */

                            collision.Add(c);

                            break;
                        }

                        //Note to self: may want to implement bool Underground into this so that the algrorithm doesnt skip out once it gets ONE rectangle

                        else {
                            c.Add(new Point(x, y));
                            c.Add(new Point(x + a, y + b));

                            /*Console.WriteLine("New Collision Square");
                            Console.WriteLine("(" + x + "," + y + ")");
                            Console.WriteLine("(" + (x + a) + "," + (y + b) + ")");
                            Console.WriteLine(" ");*/

                            collision.Add(c);
                        }


                        
                        
                        
                    } 
                }
            }

            Console.WriteLine("------------------------------------------");

            //combine all the points into individual rectangles here
            
            for (int i = 0; i < collision.Count() - 1; i++){  //merges each rectangle horizontally

                int indexX = 0;
                int indexY = 0;

                int a = collision.ElementAt(i).ElementAt(0).X;
                int b = collision.ElementAt(i).ElementAt(0).Y;
                int c = collision.ElementAt(i).ElementAt(1).X;
                int d = collision.ElementAt(i).ElementAt(1).Y;

                int e = collision.ElementAt(i + 1).ElementAt(0).X;
                int f = collision.ElementAt(i + 1).ElementAt(0).Y;
                int g = collision.ElementAt(i + 1).ElementAt(1).X;
                int h = collision.ElementAt(i + 1).ElementAt(1).Y;
                

                if (b == f && d == h) {

                    List<Point> j = new List<Point>();

                    indexX = g - c;                                     // calculates horizontal index

                    collision.RemoveAt(i + 1);                          // removes adjacent rectangle to prevent overlapping

                    j.Add(new Point(a, b));                             //creates the item that will replace the current item in the collision list
                    j.Add(new Point(c + indexX, d + indexY));

                    /*Console.WriteLine("New Collision Rectangle");       // writes each item that was changed for debugging purposes
                    Console.WriteLine("(" + j.ElementAt(0).X + "," + j.ElementAt(0).Y + ")");
                    Console.WriteLine("(" + j.ElementAt(1).X + "," + j.ElementAt(1).Y + ")");
                    Console.WriteLine(" ");*/

                    collision.RemoveAt(i);
                    collision.Insert(i, j);

                    i--;                                                // allows this loop to start over in case there are other adjacent rectangles that can be joined together
                }
            }
            
            Console.WriteLine("------------------------------------------");

            for (int i = 0; i < collision.Count(); i++)                 // allows me to confirm that all items have been merged correctly
            {
                Console.WriteLine("Item " + i);
                Console.WriteLine("(" + collision.ElementAt(i).ElementAt(0).X + "," + collision.ElementAt(i).ElementAt(0).Y + ")");
                Console.WriteLine("(" + collision.ElementAt(i).ElementAt(1).X + "," + collision.ElementAt(i).ElementAt(1).Y + ")");
                Console.WriteLine(" ");
            }
        }

        private void refreshGame_Tick(object sender, EventArgs e){
            panelGame.Invalidate();
        }

        private void panelGame_Paint(object sender, PaintEventArgs e){
            Graphics g = panelGame.CreateGraphics();
            Pen pen = new Pen(Color.White);

            g.DrawImage(backgroundImage, 0, 0, width, height);

            for(int i = 0; i <= width; i++){  //allows me to visualize the collision detection grid so that it can be adjusted accordingly
                g.DrawLine(pen, i * index, 0, i * index, height);
            }

            for(int i = 0; i <= height; i++){
                g.DrawLine(pen, 0, i * index, width, i * index);
            }

            g.DrawImage(spritesMegaMan[0], center.X, center.Y, index * 3, index * 3); //due to the limitations of this method, some of the sprites are definitely going to look weird


            Invalidate();

        }

        
    }
}
