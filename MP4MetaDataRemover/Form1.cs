namespace MP4MetaDataRemover
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!", "Info", MessageBoxButtons.OK);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            lblCount.Text = "-";
            lblFolder.Text = "-";
            lblProgress.Text = "-";
            lblFile.Text = "Select file(s)";
            lblFolder.Text = "Select folder";
            lblOutputFolder.Text = "Select folder";
            lblFolder.Font = new Font(lblFolder.Font, FontStyle.Italic);
            lblFile.Font = new Font(lblFile.Font, FontStyle.Italic);
            lblOutputFolder.Font = new Font(lblOutputFolder.Font, FontStyle.Italic);
            lblOutputFolder.Enabled = false;
            btnSelectOutputFolder.Enabled = false;
        }
    }
}
