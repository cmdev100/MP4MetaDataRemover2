using System.Drawing.Text;
using System.IO;
using System.Reflection.Metadata;
using System.IO.MemoryMappedFiles;
using System.Text.Json;
using System;
using static System.Net.WebRequestMethods;
using System.Windows.Forms;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MP4MetaDataRemover
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const string TMP_FOLDER = "tmp";

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                btnStart.Text = "Aborting...";
                btnStart.Enabled = false;
                backgroundWorker1.CancelAsync();
            }
            else
            {
                if (!conversionSettings.useDestinationFolder)
                {
                    var filePath = Path.GetDirectoryName(conversionSettings.files[0]);
                    if (filePath != null)
                        conversionSettings.destinationPath = Path.Combine(filePath, TMP_FOLDER);
                }

                if (!FolderCheck())
                {
                    MessageBox.Show("It''s not allowed to use the same folder as output folder.");
                    return;
                };

                btnStart.Text = "Stop";
                btnSelectFolder.Enabled = false;
                cbSetFileDate.Enabled = false;
                dtpFileDate.Enabled = false;
                if (cbSetFileDate.Checked)
                    conversionSettings.fileDate = new DateTime(dtpFileDate.Value.Year, dtpFileDate.Value.Month, dtpFileDate.Value.Day, dtpFileDate.Value.Hour, dtpFileDate.Value.Minute, 0, 0);
                else
                    conversionSettings.fileDate = new DateTime(0);

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private bool FolderCheck()
        {
            if (conversionSettings.useDestinationFolder)
            {
                string? lFilePath = Path.GetDirectoryName(conversionSettings.files[0]);
                if (!System.String.IsNullOrEmpty(lFilePath))
                    lFilePath = PathAddDirectorySeparator(lFilePath);
                else
                    return false;
                string lDestPath = PathAddDirectorySeparator(conversionSettings.destinationPath);
                return lFilePath != lDestPath;
            }
            else
                return true;
        }

        string PathAddDirectorySeparator(string path)
        {
            ArgumentNullException.ThrowIfNull(path);

            path = path.TrimEnd();

            if (Path.EndsInDirectorySeparator(path))
                return path;

            return path + GetDirectorySeparatorUsedInPath();

            char GetDirectorySeparatorUsedInPath()
            {
                if (path.Contains(Path.AltDirectorySeparatorChar))
                    return Path.AltDirectorySeparatorChar;

                return Path.DirectorySeparatorChar;
            }
        }

        public class SystemSettings
        {
            public DateTime FileDate { get; set; }
            public bool SetFileDate { get; set; }
            public bool SetOutputFolder { get; set; }
            public string OutputFolder { get; set; } = string.Empty;
        }

        struct ConversionSettings(DateTime aFileDate, string aSelectedFolderPath, string aDestinationFolder, bool aUseDestinationFolder)
        {
            public DateTime fileDate = aFileDate;
            public List<string> files = [];
            public string selectedFolderPath = aSelectedFolderPath;
            public string destinationPath = aDestinationFolder;
            public bool useDestinationFolder = aUseDestinationFolder;
        }

        private ConversionSettings conversionSettings;

        private void EnableFiles()
        {
            pbProgress.Value = 0;
            lblCount.Text = conversionSettings.files.Count.ToString();
            SetButtons();

            if (conversionSettings.files.Count == 0)
            {
                MessageBox.Show("There is no MP4 file selected.");
                return;
            }

            ProgressUpdate(0, conversionSettings.files.Count);

            if (conversionSettings.files.Count > 1)
                lblFile.Text = "Multiple files";
            else
                lblFile.Text = conversionSettings.files[0];

            lblFile.Font = new Font(lblFile.Font, FontStyle.Regular);
            lblFile.ForeColor = System.Drawing.Color.Green;

            DisableFolders();
        }

        private void EnableFolder()
        {
            pbProgress.Value = 0;
            GetFilesFromFolder();
            SetButtons();

            if (conversionSettings.files.Count == 0)
            {
                MessageBox.Show("There is no mp4 files in this folder.");
                return;
            }

            ProgressUpdate(0, conversionSettings.files.Count);

            lblFolder.Text = conversionSettings.selectedFolderPath;
            lblFolder.Font = new Font(lblFile.Font, FontStyle.Regular);
            lblFolder.ForeColor = System.Drawing.Color.Green;

            DisableFiles();
        }

        private void ProgressUpdate(int aProgress, int aTotal)
        {
            pbProgress.Value = aProgress;
            pbProgress.Maximum = aTotal;
            lblProgress.Text = System.String.Format("Progress: {0}/{1}", aProgress, aTotal);
        }

        private void GetFilesFromFolder()
        {
            var files = Directory.GetFiles(conversionSettings.selectedFolderPath, "*.mp4");

            foreach (var file in files)
                conversionSettings.files.Add(file);
            lblCount.Text = conversionSettings.files.Count.ToString();
        }

        private void DisableFolders()
        {
            lblFolder.Text = "Select a folder";
            lblFolder.Font = new Font(lblFolder.Font, FontStyle.Italic);
            lblFolder.ForeColor = new System.Drawing.Color();
        }

        private void DisableFiles()
        {
            lblFile.Text = "Select file(s)";
            lblFile.Font = new Font(lblFile.Font, FontStyle.Italic);
            lblFile.ForeColor = new System.Drawing.Color();
        }

        private void SetButtons()
        {
            btnStart.Enabled = (conversionSettings.files.Count > 0) &&
            (conversionSettings.useDestinationFolder && Directory.Exists(conversionSettings.destinationPath) || !conversionSettings.useDestinationFolder);
        }

        private void LoadSettings()
        {
            SystemSettings? systemSettings = null;

            if (System.IO.File.Exists("settings.json"))
            {
                string jsonString = System.IO.File.ReadAllText("settings.json");
                systemSettings = JsonSerializer.Deserialize<SystemSettings>(jsonString);
            }

            if (systemSettings != null)
            {
                cbSetFileDate.Checked = systemSettings.SetFileDate;
                dtpFileDate.Value = systemSettings.FileDate;
                cbSetOutputFolder.Checked = systemSettings.SetOutputFolder;
                SetDestinationPath(systemSettings.OutputFolder);
            }
            else
            {
                cbSetFileDate.Checked = false;
                dtpFileDate.Value = DateTime.Now;
                cbSetOutputFolder.Checked = false;
                SetDestinationPath(System.String.Empty);
            }
            cbSetOutputFolder_Click(cbSetOutputFolder, EventArgs.Empty);
        }

        private void SaveSettings()
        {
            var settings = new SystemSettings
            {
                SetFileDate = cbSetFileDate.Checked,
                FileDate = dtpFileDate.Value,
                SetOutputFolder = cbSetOutputFolder.Checked,
                OutputFolder = conversionSettings.destinationPath
            };

            var jsonString = JsonSerializer.Serialize<SystemSettings>(settings);

            if (jsonString != null)
                System.IO.File.WriteAllText("settings.json", jsonString);
        }

        private void SetDestinationPath(string aPath)
        {
            if (System.String.IsNullOrEmpty(aPath) || !Directory.Exists(aPath))
            {
                conversionSettings.destinationPath = "";
                lblOutputFolder.Text = "Select a folder";
                lblOutputFolder.Font = new Font(lblOutputFolder.Font, FontStyle.Italic);
                lblOutputFolder.ForeColor = new System.Drawing.Color();
                conversionSettings.useDestinationFolder = false;
            }
            else
            {
                conversionSettings.destinationPath = aPath;
                lblOutputFolder.Text = aPath;
                lblOutputFolder.Font = new Font(lblOutputFolder.Font, FontStyle.Regular);
                lblOutputFolder.ForeColor = System.Drawing.Color.Green;
                conversionSettings.useDestinationFolder = true;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            conversionSettings = new ConversionSettings(DateTime.Now, "", "", false);

            btnStart.Enabled = false;
            DisableFiles();
            DisableFolders();
            dtpFileDate.Enabled = false;
            lblCount.Text = "-";
            lblProgress.Text = "";
            LoadSettings();
        }

        private void cbSetOutputFolder_Click(object sender, EventArgs e)
        {
            conversionSettings.useDestinationFolder = cbSetOutputFolder.Checked;
            lblOutputFolder.Enabled = cbSetOutputFolder.Checked;
            btnSelectOutputFolder.Enabled = cbSetOutputFolder.Checked;
            SetButtons();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void cbSetFileDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFileDate.Enabled = cbSetFileDate.Checked;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();

            fileDlg.Multiselect = true;
            fileDlg.Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            fileDlg.FilterIndex = 0;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                foreach (System.String file in fileDlg.FileNames)
                    conversionSettings.files.Add(file);
                EnableFiles();
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                conversionSettings.selectedFolderPath = fbd.SelectedPath;
                EnableFolder();
            }
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < conversionSettings.files.Count; i++)
            {
                if (sender is BackgroundWorker worker && worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i + 1);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressUpdate(e.ProgressPercentage, conversionSettings.files.Count);
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation was canceled");
                ProgressUpdate(0, conversionSettings.files.Count);
            }                
            else if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else if (e.Result != null)
                MessageBox.Show(e.Result.ToString());
            else
                MessageBox.Show("Conversion done.");

            btnStart.Enabled = true;
            btnStart.Text = "Start";
            btnSelectFolder.Enabled = true;
            cbSetFileDate.Enabled = true;
            dtpFileDate.Enabled = true;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e == null || e.Data == null)
                return;

            List<string> files;

            if (e.Data.GetData(DataFormats.FileDrop) is string[] dropped)
                files = dropped.ToList();
            else
                return;

            bool lFolderMode = false;

            foreach (var file in files)
            {
                if (Path.GetExtension(file).ToUpper() == ".MP4")
                    conversionSettings.files.Add(file);
                else if (files.Count == 1 && Directory.Exists(file))
                {
                    conversionSettings.selectedFolderPath = file;
                    lFolderMode = true;
                }            
            }

            if (lFolderMode)
            {
                EnableFolder();
                conversionSettings.files.Clear();
            }
            else if (conversionSettings.files.Count > 0)
                EnableFiles();                
        }
    }
}
