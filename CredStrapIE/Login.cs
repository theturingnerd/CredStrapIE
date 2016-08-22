using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CredStrapIE
{
    public partial class Login : Form
    {
        public string Username { get; set; }
        public System.Security.SecureString Password { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Username = textBox1.Text;
            Password = new System.Security.SecureString();
            Password = ConvertToSecureString(textBox2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public static SecureString ConvertToSecureString( string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            unsafe
            {
                fixed (char* passwordChars = password)
                {
                    var securePassword = new SecureString(passwordChars, password.Length);
                    securePassword.MakeReadOnly();
                    return securePassword;
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
