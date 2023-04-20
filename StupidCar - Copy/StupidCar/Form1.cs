using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StupidCar
{
    public partial class Form1 : Form
    {
       // Declaring Variables
        DialogResult msgBox;
        bool moveCarLeft = false;
        bool moveCarRight = false;
        bool moveCarUp = false;
        bool moveCarDown = false;
        int carIncrement = 2;

        bool downBlockage = false;
        bool upBlockage = false;
        bool leftBlockage = false;
        bool rightBlockage = false;
        int bounceBack = 10;

        Random rand = new Random();
        bool automateDriving = false;
        Label waypointLabel = new Label();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine("args {0}",e);
            
            // Key down is for when key is pressed. this code tells the program to move the car in the specified direction when key is pressed
            if (e.KeyCode == Keys.Left)
            {
                moveCarLeft = true;
            }
         if (e.KeyCode == Keys.Right)
            {
                moveCarRight = true;
            }
         if (e.KeyCode == Keys.Up)
            {
                moveCarUp = true;
            }
         if (e.KeyCode == Keys.Down)
            {
                moveCarDown = true;
            }

            //add obstacle key
            if (e.KeyCode == Keys.P)
            {
                placeWaypoint();
            }

            //start automated driving 
            if(e.KeyCode == Keys.D)
            {
                //navigate();
                automateDriving = true;
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Key up 
            if (e.KeyCode == Keys.Left)
            {
                moveCarLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveCarRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveCarUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveCarDown = false;
            }

            if (e.KeyCode == Keys.D)
            {
                automateDriving = false;
            }
        }

        private void UnsetBlockages()
        {
            // blockages set here to make code more efficient
            downBlockage = false;
            upBlockage = false;
            leftBlockage = false;
            rightBlockage = false;

        }

        private void tmrMoveCar_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine("Timer{0}", tmrMoveCar.ToString());
            //left
            if ((moveCarLeft == true) && !leftBlockage && picCar.Left >=0)
            {
                picCar.Left -= carIncrement;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            leftBlockage = true;
                            picCar.Left += bounceBack;
                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }

            //right
            if ((moveCarRight == true) && !rightBlockage && picCar.Right >=0)
            {
                picCar.Left += carIncrement;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            rightBlockage = true;
                            picCar.Left -= bounceBack;
                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }

           //up
            if ((moveCarUp == true) && !upBlockage && picCar.Top >=0)
            {
                picCar.Top -= carIncrement;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            upBlockage = true;
                            picCar.Top += bounceBack;
                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }

            //down
           if ((moveCarDown == true) && !downBlockage && picCar.Bottom >=0)
            {
                picCar.Top += carIncrement;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            downBlockage = true;
                            picCar.Top -= bounceBack;
                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }

            //automate driving 
            if (automateDriving)
            {
                navigate();
            }

        }

        private void picCar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //placeWaypoint();
            //Debug.WriteLine("hello button 1");
        }

        ////start autmated driving

        //palce waypoint with button
        private void placeWaypoint()
        {
            Size formSize = Form1.ActiveForm.Size;

            int xPosition = rand.Next(10, formSize.Width - 10);

            int yPosition = rand.Next(10, formSize.Height - 10);

            waypointLabel.Text = "WAYPOINT";
            waypointLabel.Location = new Point(xPosition, yPosition);
            
            this.Controls.Add(waypointLabel);
        }

        private void placeWaypoint(Point point)
        {
            Size formSize = Form1.ActiveForm.Size;

            waypointLabel.Text = "WAYPOINT";
            waypointLabel.Location = new Point(point.X, point.Y);

            this.Controls.Add(waypointLabel);
        }

        private void navigate()
        {
            int xTarget = waypointLabel.Location.X;
            int yTarget = waypointLabel.Location.Y;
           // Debug.WriteLine("x:{0},y:{1} :: car x {2}, car y {3}", xTarget, yTarget, picCar.Left, picCar.Top);
            //target to the right 

            Point target = new Point(xTarget, yTarget);

            if(picCar.Left < xTarget)
            {
                Debug.WriteLine("right");
                moveRight(target);


            }
            if(picCar.Top < yTarget )
            {
                Debug.WriteLine("down");
                moveDown(target);
                
            }
            if (picCar.Left > xTarget)
            {
                Debug.WriteLine("left");
                moveLeft(target);
            }
            if(picCar.Top > yTarget)
            {
                Debug.WriteLine("up");
                moveUp(target);
            }
            

        }

        private void moveRight(Point target)
        {
            //right
            if (!rightBlockage && picCar.Right >= 0)
            {
                picCar.Left += carIncrement;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            rightBlockage = true;
                            picCar.Left -= bounceBack;

                            Debug.WriteLine("Bounds : {0}",x.Bounds);
                            //if the middle of the car is less than the middle of the bus go down otherwise up

                            int busMiddle = x.Bounds.Top + (x.Bounds.Height /2);
                            
                            int middle = picCar.Top + (picCar.Height / 2);

                            if (target.Y < x.Bounds.Y + x.Bounds.Height && (target.Y >= x.Bounds.Top))
                            {

                                if (middle <= busMiddle)
                                {
                                    picCar.Left += carIncrement;
                                    picCar.Top -= x.Bounds.Height;  //move up
                                }

                                if (middle > busMiddle)
                                {
                                    picCar.Left += carIncrement;    //move back
                                    picCar.Top += x.Bounds.Height;  //move up
                                }
                            }

                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }
        }

        private void moveLeft(Point target)
        {
            //left
            if (!leftBlockage && picCar.Left >= 0)
            {
               
                picCar.Left -= carIncrement;

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            leftBlockage = true;
                            picCar.Left += bounceBack;

                            int busMiddle = x.Bounds.Top + (x.Bounds.Height / 2);

                            int middle = picCar.Top + (picCar.Height / 2);

                            if((target.Y < x.Bounds.Y + x.Bounds.Height) && (target.Y >= x.Bounds.Top ))
                            {
                                if (middle <= busMiddle)
                                {
                                    picCar.Left -= carIncrement;
                                    picCar.Top -= x.Bounds.Height;  //move up
                                }

                                if (middle > busMiddle)
                                {
                                    picCar.Left -= carIncrement;    //move back
                                    picCar.Top += x.Bounds.Height;  //move up
                                }
                            }

                 

                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }
        }
        private void moveDown(Point target)
        {
            //down
            if (!downBlockage && picCar.Bottom >= 0)
            {
                picCar.Top += carIncrement;

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            downBlockage = true;
                            picCar.Top -= bounceBack;

                            int busMiddle = x.Bounds.Left + (x.Bounds.Width / 2);

                            int middle = picCar.Left + (picCar.Width / 2);

                            if ((target.X < x.Bounds.X + x.Bounds.Width) && (target.X >= x.Bounds.Left))
                            {

                                if (middle <= busMiddle)    //eft side
                                {
                                    picCar.Top -= carIncrement;     //move up
                                    picCar.Left -= x.Bounds.Width;  //move left
                                }

                                if (middle > busMiddle) //right side
                                {
                                    picCar.Top -= carIncrement;     //move down
                                    picCar.Left += x.Bounds.Width;  //move right
                                }
                            }


                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }
        }
        private void moveUp(Point target)
        {
            //up
            if (!upBlockage && picCar.Top >= 0)
            {
                picCar.Top -= carIncrement;

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "obstruction")
                    {
                        if (picCar.Bounds.IntersectsWith(x.Bounds))
                        {
                            upBlockage = true;
                            picCar.Top += bounceBack;

                            int busMiddle = x.Bounds.Left + (x.Bounds.Width / 2);

                            int middle = picCar.Left + (picCar.Width / 2);
                            
                            if ((target.X < x.Bounds.X + x.Bounds.Width) && (target.X >= x.Bounds.Left))
                            {

                                if (middle <= busMiddle)    //eft side
                                {
                                    picCar.Top += carIncrement;     //move down
                                    picCar.Left -= x.Bounds.Width;  //move left
                                }

                                if (middle > busMiddle) //right side
                                {
                                    picCar.Top += carIncrement;     //move down
                                    picCar.Left += x.Bounds.Width;  //move right
                                }
                            }
                        }
                        else
                        {
                            UnsetBlockages();
                        }
                    }
                }
            }
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            placeWaypoint(e.Location);
        }
    }





}
