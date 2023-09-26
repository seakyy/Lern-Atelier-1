using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int turn1;
        bool turn = true; //Wenn True dann ist X an der Reihe, false ist O an der Reihe
        int turn_counter = 0;

        public Color Button { get; private set; }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e) { }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By David", "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            { b.Text = "X"; }
            else { b.Text = "O"; }
            turn = !turn;
            b.Enabled = false;

            turn_counter++;
            checkforwinner1();
        }

        private void checkforwinner1()
        {
            bool there_is_a_winner = false;

            //Horizontal überprüfen
            if (((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.Red; A2.BackColor = Color.Red; A3.BackColor = Color.Red;
            }
            if (((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)))
            {
                there_is_a_winner = true;
                C1.BackColor = Color.Red;
                C2.BackColor = Color.Red;
                C3.BackColor = Color.Red;
            }

            if (((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)))
            {
                there_is_a_winner = true;
                B1.BackColor = Color.Red;
                B2.BackColor = Color.Red;
                B3.BackColor = Color.Red;
            }

            //Vertical überprüfen
            else if (((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.Red;
                B1.BackColor = Color.Red;
                C1.BackColor = Color.Red;
            }
            else if (((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)))
            {
                there_is_a_winner = true;
                A2.BackColor = Color.Red;
                B2.BackColor = Color.Red;
                C2.BackColor = Color.Red;
            }
            else if (((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)))
            {
                there_is_a_winner = true;
                A3.BackColor = Color.Red;
                B3.BackColor = Color.Red;
                C3.BackColor = Color.Red;
            }


            //Diagonal überprüfen
            else if (((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)))
            {
                there_is_a_winner = true;
                A1.BackColor = Color.Red;
                B2.BackColor = Color.Red;
                C3.BackColor = Color.Red;
            }
            else if (((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled)))
            {
                there_is_a_winner = true;
                A3.BackColor = Color.Red;
                B2.BackColor = Color.Red;
                C1.BackColor = Color.Red;
            }





            if (there_is_a_winner == true)
            {

                string winner = "";
                if (turn) { winner = "O"; }
                else { winner = "X"; }
                MessageBox.Show(winner + " Gewonnen!", "Yay!");
                disableButtons();
                newGameToolStripMenuItem.Enabled = true;


            }



            else
            {
                if (turn_counter == 9)
                    MessageBox.Show("Unentschieden!", "Das war schlecht...");
                newGameToolStripMenuItem.Enabled = true;
            }


        }
        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Enabled = false;
                }
            }
            newGameToolStripMenuItem.Enabled = true;
        }
        private void buttonsdefault()
        {
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_counter = 0;
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Enabled = true;
                    c.Text = "";
                }
                newGameToolStripMenuItem.Enabled = false;
                BackColor = Color.SteelBlue;
                buttonsdefault();
            }
        }

        private void frageStellenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Size = new System.Drawing.Size(this.Size.Width + 100, this.Size.Height + 50);
        }
    }
}
