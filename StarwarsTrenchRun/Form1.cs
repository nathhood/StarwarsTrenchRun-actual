// Created to show how to take out the Deathstar with an x-wing. Created by Nathan Hood on Monday November 28th, 2016.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace StarwarsTrenchRun
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            //fit image to background
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)

        {
            // declare the fonts, brushes, sounds and pen I need

            SoundPlayer theme = new SoundPlayer(Properties.Resources.starWarsTheme); //to desgnate the sound file
            SoundPlayer explosion = new SoundPlayer(Properties.Resources.explosion); //to desgnate the sound file
            Graphics g = this.CreateGraphics();
            Pen whitePen = new Pen(Color.White, 2);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
            Font smallFont = new Font("Consolas", 15, FontStyle.Bold); //create a font for graphics
            Font largeFont = new Font("Arial", 40, FontStyle.Bold); //create a font for graphics
            //clear screen
            g.Clear(Color.Black);

            //draw the script and give time to read, play theme
            theme.Play();
            g.DrawString("Attack Plan", largeFont, redBrush, 200, 50);
            g.DrawString("The approach will not be easy. You are required to maneuver \nstraight down the trench and skim the surface to the point. \nThe target area is only two meters wide. It's a small thermal \nexhaust port, right below the main port. Only a precise hit \nwill set up a chain reaction. The shaft is ray-shielded, \nso you'll have to use proton torpedoes.", smallFont, yellowBrush, 20, 200);
            Thread.Sleep(12000);
            Refresh();
            // declare variables and stop sound
            theme.Stop();
            int w = 0;
            int x = 1;
            int y = 1;
            int z = 1;

            // draw the deathstar and the x-wing moving towards the exhaust vent
            for (int i = 1; i <= 475; i += 4)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(whitePen, 220, 180, 300, 300);
                g.DrawRectangle(whitePen, 345, 183, 50, 25);
                g.DrawLine(whitePen, 370, 208, 370, 315);
                g.DrawEllipse(whitePen, 354, 315, 30, 30);

                g.FillPie(whiteBrush, 800 - i, 20 + x, 50, 50, 350, 20);
                x++;
                Thread.Sleep(10);
            }

            // drop the torpedo and move the x-wing off the screen
            for (int i = 1; i <= 170; i++)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(whitePen, 220, 180, 300, 300);
                g.DrawRectangle(whitePen, 345, 183, 50, 25);
                g.DrawLine(whitePen, 370, 208, 370, 315);
                g.DrawEllipse(whitePen, 354, 315, 30, 30);

                g.FillPie(whiteBrush, 325 - i, 140 + y, 50, 50, 350, 20);
                g.FillEllipse(redBrush, 366, 160 + z, 8, 8);
                Thread.Sleep(10);
                y -= 2;
                z++;
            }

            // reset the variables I am using in the next for loop and play the explosion sound
            explosion.Play();
            z = 0;

            // explode the deathstar from the torpedo
            for (int i = 1; i <= 355; i += 2)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(whitePen, 220, 180, 300, 300);
                g.DrawRectangle(whitePen, 345, 183, 50, 25);
                g.DrawLine(whitePen, 370, 208, 370, 315);
                g.DrawEllipse(whitePen, 354, 315, 30, 30);
                Thread.Sleep(5);

                redBrush.Color = Color.FromArgb(255 - w, 0, 0);
                g.FillEllipse(redBrush, 366 - z / 2, 330 - z / 2, 10 + z, 10 + z);
                Thread.Sleep(10);

                //change variables
                z += 2;
                w++;
            }
            //stop the sound
            explosion.Stop();
        }
    }
}