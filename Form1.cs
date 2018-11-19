using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //MUSHTAQ CODE
        public int player = 2;//even is X's turn, odd is O's turn
        public int turns = 0;//used to check how many turns have passed
        public int s1 = 0;//contain the number of wins for player 1
        public int s2 = 0;
        public int sd = 0;//contains the number of draws


        private void ButoonClick(object sender, EventArgs e)
        {
            //buttonclick is a method
            Button button = (Button)sender;
            if(button.Text == "")//by anything it means O or X
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }

                //we will check for draw each time a button is clicked if 9 turns are clicked then check draws will proceed true
                if (CheckDraw() == true)
                {
                    MessageBox.Show("tie game!");
                    sd++;
                    NewGame();
                }
                
                //check for a winner each time
                if(CheckWinner()==true)
                {
                    if(button.Text=="X")
                    {
                        MessageBox.Show("X won!!!!");
                        s1++;
                        NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O wonn!!!!");
                        s2++;
                        NewGame();
                    }

                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //here we will set the score labels
            XWINS.Text = "X: " + s1;
            OWINS.Text = "O: " + s2;
            DRAWS.Text = "draws: " + sd;
        }

        private void EButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        void NewGame()
        {
            //we will call this method each time we click "new game"
            player = 2;
            turns = 0;
            //every new game we need to initialize the variable with its initial value
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text="";
            //updating labels
            XWINS.Text = "X: " + s1;
            OWINS.Text = "O: " + s2;
            DRAWS.Text = "draws: " + sd;
        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            //call the new game method
            NewGame();
        }

        //method to check if a tie game happened
        bool CheckDraw()
        {
            if ((turns == 9)&&CheckWinner()==false)
                return true;
            else
                return false;
        }

        bool CheckWinner()
        {
            //horizontal checks
            if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && (A00.Text != ""))
                return true;
            else if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && (A10.Text != ""))
                return true;
            else if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && (A20.Text != ""))
                return true;
            //vertical checks
            if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && (A00.Text != ""))
                return true;
            else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && (A01.Text != ""))
                return true;
            else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && (A02.Text != ""))
                return true;
            //diagonal checks
            if ((A00.Text == A11.Text) && (A11.Text == A22.Text) && (A00.Text != ""))
                return true;
            else if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && (A02.Text != ""))
                return true;
            else
                return false;
        }

        //reset butto functionality
        private void RButton_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            NewGame();
        }
    }
}
