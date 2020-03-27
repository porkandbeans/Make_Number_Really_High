using System;
using System.Drawing;
using System.Windows.Forms;

namespace lolhurr
{
    public partial class MAKE_NUMBER_GO_HIGHER_GAME : Form
    {
        public MAKE_NUMBER_GO_HIGHER_GAME()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e){}

        Random rnd = new Random();
        decimal button2tax = 20;
        decimal press = 0;
        decimal clickcounter = 0;
        decimal autoclickcount = 120;
        decimal multvalue = 1;
        decimal multtax = 300;
        decimal escrow;
        decimal gambleloop;
        int textclick = 0;
        bool autoclick = false;
        bool greencheck = false;
        bool bluecheck = false;
        bool redcheck = false;
        
        int randnum;
        
        //when "make number go up" button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            press += multvalue;
            escrow += multvalue;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            press -= button2tax;
            button2tax = (button2tax * 3);
            autoclickcount = (autoclickcount / 2);
            if (!autoclick)
            {
                autoclick = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            press -= multtax;
            multvalue = (multvalue * 2);
            multtax = (multtax * 3);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //devbutton.Visible = true;
            button1.Text = ("MAKE NUMBER GO UP BY " + multvalue);
            counter.Text = press.ToString();
            taxlabel.Text = button2tax.ToString();
            multlabel.Text = multtax.ToString();
            ultimatelabel.Text = ("100,000,000");
            escrowlabel.Text = ("Total number gathered: " + escrow.ToString());
            gambleloop++;
            gambleLabelCount.Text = ("Gambleloop: " + gambleloop.ToString());

            if (autoclick)
            {
                clickcounter++;
                if (clickcounter >= autoclickcount)
                {
                    button1.PerformClick();
                    clickcounter = 0;
                }
            }

            if (gambleloop < 2000)
            {
                gambleLabelCount.ForeColor = Color.Red;
            }
            else
            {
                gambleLabelCount.ForeColor = Color.Green;
            }
            if (press >= multtax){
                button3.Enabled = true;
            }else{
                button3.Enabled = false;
            }
            if (press >= button2tax){
                button2.Enabled = true;
            }else{
                button2.Enabled = false;
            }
            if (press >= 100000000){
                button4.Enabled = true;
            }else{
                button4.Enabled = false;
            }
            
            if (press >= 100000 && !greencheck)
            {
                cosmetic.Enabled = true;
            }
            else { cosmetic.Enabled = false; }

            if (press >= 1000000 && !bluecheck)
            {
                cosmetic1.Enabled = true;
            }
            else
            {
                cosmetic1.Enabled = false;
            }
            if (press >= 10000000 && !redcheck)
            {
                cosmetic2.Enabled = true;
            }
            else
            {
                cosmetic2.Enabled = false;
            }
            if (press >= 1000)
            {
                randlabel.ForeColor = Color.Green;
            }
            else { randlabel.ForeColor = Color.Red; }

        }

        private void randbutton_Click(object sender, EventArgs e)
        {
            
            if ((press >= 1000) && (gambleloop >= 2000))
            {
                
                gambleloop = 0;
                randnum = rnd.Next(1, 100);
                if (randnum >= 50)
                {
                    press += press;
                    escrow += press;
                    MessageBox.Show("Success! Number has doubled.");
                    gambleloop = 0;

                }
                else
                {
                    press = 0;
                    MessageBox.Show("Failure. Number goes slower now.");
                    multvalue = (multvalue / 2);
                    multtax = (multtax / 3);
                }
            }
            else
            {
                MessageBox.Show("You must have 1000 number and gambleloop must be at 2000");
            }

        }

        private void cosmetic_Click(object sender, EventArgs e)
        {
            if (!greencheck)
            {
                counter.ForeColor = Color.Lime;
                press -= 100000;
                greencheck = true;
            }
        }

        private void cosmetic2_Click(object sender, EventArgs e)
        {
            counter.ForeColor = Color.Red;
            press -= 10000000;
            redcheck = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=UBhggQiYt0E");
            Application.Exit();
            
        }

        private void title_Click(object sender, EventArgs e)
        {
            textclick += 1;

            if (textclick == 1)
            {
                title.Text = "don't click me";
            }
            else if (textclick > 1)
            {
                title.Text = "stop";
            }

        }

        private void devbutton_Click(object sender, EventArgs e)
        {
            press += 9999999999;
        }

        private void cosmetic1_Click_1(object sender, EventArgs e)
        {
            if (!bluecheck)
            {
                counter.ForeColor = Color.Blue;
                press -= 1000000;
                bluecheck = true;
            }
        }

        private void cosmetic2_Click_1(object sender, EventArgs e)
        {
            if (!redcheck)
            {
                counter.ForeColor = Color.Red;
                press -= 10000000;
                redcheck = true;
            }
        }
		
		private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                //top secret cheat button for people looking at the code
                press += 100000000;
            }
        }
    }
}
