using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Variables Declarations
        bool verify_sequ = false;
        int k, h,round, j;
        int[] Table = new int[75];
        double FlashTime = 0.5;



        private void RebButton_Click(object sender, EventArgs e)
        {
            // Flash For user feedback
            RebButton.BackColor = Color.FromArgb(255, 0, 0);
            this.Refresh();
            WaitSecond(0.1);
            RebButton.BackColor = Color.FromArgb(255, 128, 128); // Light red
            this.Refresh();
            WaitSecond(0.1);

            VerifySequence(1);

        }

        private void YellowButton_Click_1(object sender, EventArgs e)
        {
            // Flash For user feedback
            YellowButton.BackColor = Color.FromArgb(255, 255, 0);
            this.Refresh();
            WaitSecond(0.1);
            YellowButton.BackColor = Color.FromArgb(255, 255, 128); // Light yellow
            this.Refresh();
            WaitSecond(0.1);

            VerifySequence(2);
        }

        private void GreenButton_Click_1(object sender, EventArgs e)
        {
            // Flash For user feedback
            GreenButton.BackColor = Color.FromArgb(0, 255, 0);
            this.Refresh();
            WaitSecond(0.1);
            GreenButton.BackColor = Color.FromArgb(128, 255, 128); // Light green
            this.Refresh();
            WaitSecond(0.1);

            VerifySequence(3);

        }


        private void BlueButton_Click(object sender, EventArgs e)
        {
            // Flash For user feedback
            BlueButton.BackColor = Color.FromArgb(0, 0, 255);
            this.Refresh();
            WaitSecond(0.1);
            BlueButton.BackColor = Color.FromArgb(128, 128, 255); // Light blue
            this.Refresh();
            WaitSecond(0.1);

            VerifySequence(4);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        /*
        * ----------------------------------------------------------------------------
        * Name Fuction : WaitSecond
        * Return       : 
        * Description  : counts for X seconds
        * ----------------------------------------------------------------------------
        */

        private void WaitSecond(double x)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(x))
            {
                //Wait
            }
            s.Stop();
        }


        /*
         * ----------------------------------------------------------------------------
         * Name Fuction : StartGame
         * Return       : 
         * Description  : Start the game at round 0 
         * ----------------------------------------------------------------------------
        */
        private void StartGame()
        {
            //Make a table of 75 int table and fill them with radom int from 1 to 4

            // Need to generate new radom number for patern
            Random rnd = new Random();
            for (h = 0; h <= 74; h++) {
                Table[h] = rnd.Next(1, 5);
            }

            // Set Round
            round= 0;

            //321...go
            MessageBox.Show("3,2,1...go!");

            //Show first round
            verify_sequ = false;
            DisplaySequence();
            verify_sequ = true;
        }

        /*
         * ----------------------------------------------------------------------------
         * Name Fuction : VerifySequence
         * Return       : 
         * Description  : When a button is pressed verify if the color is correct else loose the game
         * ----------------------------------------------------------------------------
        */

        private void VerifySequence(int color_ID)
        {
            if (verify_sequ)
            {
                if (Table[k] == color_ID)
                {
                    k++;
                    if (k > round ) 
                    {
                        k = 0;
                       round++;
                        MessageBox.Show("Next Round");

                        verify_sequ = false;
                        DisplaySequence();
                        verify_sequ = true;
                    }
                }
                else
                {
                    MessageBox.Show("Game Over, Nice Try! Score:" + (round));
                    Application.Restart();
                }
            }
        }

        /*
         * ----------------------------------------------------------------------------
         * Name Fuction : DisplaySequence
         * Return       : 
         * Description  : Displays the sequence to imitate
         * ----------------------------------------------------------------------------
        */

        private void DisplaySequence() {
            for (j = 0; j <=round; j++)
            {
                switch (Table[j])
                {
                    case 1: //RED BUTTON DISPLAY CASE
                        RebButton.BackColor = Color.FromArgb(255, 0, 0);
                        this.Refresh();
                        WaitSecond(FlashTime);
                        RebButton.BackColor = Color.FromArgb(255, 128, 128); // Light red
                        this.Refresh();
                        WaitSecond(FlashTime);
                        break;
                    case 2: //YELLOW BUTTON DISPLAY CASE
                        YellowButton.BackColor = Color.FromArgb(255, 255, 0);
                        this.Refresh();
                        WaitSecond(FlashTime);
                        YellowButton.BackColor = Color.FromArgb(255, 255, 128); // Light yellow
                        this.Refresh();
                        WaitSecond(FlashTime);
                        break;
                    case 3: //GREEN BUTTON DISPLAY CASE
                        GreenButton.BackColor = Color.FromArgb(0, 255, 0);
                        this.Refresh();
                        WaitSecond(FlashTime);
                        GreenButton.BackColor = Color.FromArgb(128, 255, 128); // Light green
                        this.Refresh();
                        WaitSecond(FlashTime);
                        break;
                    case 4: //BLUE BUTTON DISPLAY CASE
                        BlueButton.BackColor = Color.FromArgb(0, 0, 255);
                        this.Refresh();
                        WaitSecond(FlashTime);
                        BlueButton.BackColor = Color.FromArgb(128, 128, 255); // Light blue
                        this.Refresh();
                        WaitSecond(FlashTime);
                        break;
                    default:
                        break;
                }
            }

            MessageBox.Show("Your turn!");

        }

    }   
}
