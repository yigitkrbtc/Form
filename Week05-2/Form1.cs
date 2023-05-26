using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week05_2
{
    public partial class Form1 : Form
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string message { get; set; }



        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
                    throw new Exception("Please enter your full name");
                if (txtFullName.Text.Trim().Split(' ').Length < 2)
                    throw new Exception("Please enter your name and surname");

                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                    throw new Exception("Please enter your email");
                if (txtEmail.Text.Trim().Split('@').Length < 2)
                    throw new Exception("Please enter a valid email");

                this.fullname = txtFullName.Text.Trim();
                this.email = txtEmail.Text.Trim();

                MessageBox.Show("Sign up successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                    throw new Exception("Please enter your message");
                if(string.IsNullOrEmpty(this.fullname) || string.IsNullOrEmpty(this.email))
                    throw new Exception("Please sign up to send message");

                this.message = txtMessage.Text.Trim();

                timer2.Start();
                MessageBox.Show("Message sent successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLastMessage_Click(object sender, EventArgs e)
        {
            displayLastMessage();
        }

        private void displayLastMessage()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Your Name: " + this.fullname);
            builder.AppendLine("Email    : " + this.email);
            builder.AppendLine("Message  :");
            builder.AppendLine(this.message);

            lblLastMessage.Text = builder.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";

            lblTime.Text = string.Empty;
            lblLastMessage.Text = string.Empty;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayTheTime();
        }

        private void displayTheTime()
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            displayLastMessage();
            timer2.Stop();
        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkGithub.Text);
        }
    }
}
