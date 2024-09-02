using GameCenterForm.Forms;

namespace GameCenterForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            BookingsForm form = new BookingsForm();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            GamesForm form = new GamesForm();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }

        private void btnInstalledGames_Click(object sender, EventArgs e)
        {
            InstalledGamesForm form = new();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentsForm form = new PaymentsForm();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }

        private void btnConsoles_Click(object sender, EventArgs e)
        {
            GamingConsolesForm form = new();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();
        }
    }
}
