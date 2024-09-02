namespace GameCenterForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void tBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }




        //Login method
        private void Login()
        {
            string username = tBoxUsername.Text;
            string password = tBoxPassword.Text;
            // The default username and password for now
            if (username == "admin" && password == "password")
            {
                MainForm form = new MainForm();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Entered the wrong username or password");
            }
        }
    }
}