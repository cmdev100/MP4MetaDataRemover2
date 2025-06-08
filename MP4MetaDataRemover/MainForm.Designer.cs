namespace MP4MetaDataRemover
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pbProgress = new ProgressBar();
            btnStart = new Button();
            lblFilesTxt = new Label();
            lblFile = new Label();
            btnSelectFile = new Button();
            lblFolderTxt = new Label();
            lblFolder = new Label();
            btnSelectFolder = new Button();
            lblFileCountTxt = new Label();
            lblCount = new Label();
            lblProgress = new Label();
            dtpFileDate = new DateTimePicker();
            cbSetFileDate = new CheckBox();
            cbSetOutputFolder = new CheckBox();
            lblOutputFolder = new Label();
            btnSelectOutputFolder = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // pbProgress
            // 
            pbProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbProgress.Location = new Point(12, 129);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new Size(440, 14);
            pbProgress.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.Location = new Point(377, 186);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblFilesTxt
            // 
            lblFilesTxt.AutoSize = true;
            lblFilesTxt.Location = new Point(12, 19);
            lblFilesTxt.Name = "lblFilesTxt";
            lblFilesTxt.Size = new Size(41, 15);
            lblFilesTxt.TabIndex = 2;
            lblFilesTxt.Text = "File(s):";
            // 
            // lblFile
            // 
            lblFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFile.AutoEllipsis = true;
            lblFile.Location = new Point(59, 19);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(359, 15);
            lblFile.TabIndex = 3;
            lblFile.Text = "lblFile";
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFile.Location = new Point(424, 15);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(28, 22);
            btnSelectFile.TabIndex = 4;
            btnSelectFile.Text = "...";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // lblFolderTxt
            // 
            lblFolderTxt.AutoSize = true;
            lblFolderTxt.Location = new Point(12, 48);
            lblFolderTxt.Name = "lblFolderTxt";
            lblFolderTxt.Size = new Size(43, 15);
            lblFolderTxt.TabIndex = 5;
            lblFolderTxt.Text = "Folder:";
            // 
            // lblFolder
            // 
            lblFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFolder.AutoEllipsis = true;
            lblFolder.Location = new Point(59, 48);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(359, 15);
            lblFolder.TabIndex = 6;
            lblFolder.Text = "lblFolder";
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder.Location = new Point(424, 44);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(28, 22);
            btnSelectFolder.TabIndex = 7;
            btnSelectFolder.Text = "...";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // lblFileCountTxt
            // 
            lblFileCountTxt.AutoSize = true;
            lblFileCountTxt.Location = new Point(12, 76);
            lblFileCountTxt.Name = "lblFileCountTxt";
            lblFileCountTxt.Size = new Size(62, 15);
            lblFileCountTxt.TabIndex = 8;
            lblFileCountTxt.Text = "File count:";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(80, 76);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(53, 15);
            lblCount.TabIndex = 9;
            lblCount.Text = "lblCount";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(12, 111);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(65, 15);
            lblProgress.TabIndex = 10;
            lblProgress.Text = "lblProgress";
            // 
            // dtpFileDate
            // 
            dtpFileDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFileDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpFileDate.Format = DateTimePickerFormat.Custom;
            dtpFileDate.Location = new Point(12, 186);
            dtpFileDate.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtpFileDate.Name = "dtpFileDate";
            dtpFileDate.Size = new Size(132, 23);
            dtpFileDate.TabIndex = 11;
            dtpFileDate.Value = new DateTime(2024, 11, 18, 20, 11, 22, 0);
            // 
            // cbSetFileDate
            // 
            cbSetFileDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSetFileDate.AutoSize = true;
            cbSetFileDate.Location = new Point(12, 161);
            cbSetFileDate.Name = "cbSetFileDate";
            cbSetFileDate.Size = new Size(87, 19);
            cbSetFileDate.TabIndex = 12;
            cbSetFileDate.Text = "Set file date";
            cbSetFileDate.UseVisualStyleBackColor = true;
            cbSetFileDate.CheckedChanged += cbSetFileDate_CheckedChanged;
            // 
            // cbSetOutputFolder
            // 
            cbSetOutputFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSetOutputFolder.AutoSize = true;
            cbSetOutputFolder.Location = new Point(179, 161);
            cbSetOutputFolder.Name = "cbSetOutputFolder";
            cbSetOutputFolder.Size = new Size(98, 19);
            cbSetOutputFolder.TabIndex = 13;
            cbSetOutputFolder.Text = "Output folder";
            cbSetOutputFolder.UseVisualStyleBackColor = true;
            cbSetOutputFolder.Click += cbSetOutputFolder_Click;
            // 
            // lblOutputFolder
            // 
            lblOutputFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOutputFolder.AutoEllipsis = true;
            lblOutputFolder.Location = new Point(179, 191);
            lblOutputFolder.Name = "lblOutputFolder";
            lblOutputFolder.Size = new Size(152, 17);
            lblOutputFolder.TabIndex = 14;
            lblOutputFolder.Text = "lblOutputFolder";
            // 
            // btnSelectOutputFolder
            // 
            btnSelectOutputFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectOutputFolder.Location = new Point(338, 187);
            btnSelectOutputFolder.Name = "btnSelectOutputFolder";
            btnSelectOutputFolder.Size = new Size(28, 22);
            btnSelectOutputFolder.TabIndex = 15;
            btnSelectOutputFolder.Text = "...";
            btnSelectOutputFolder.UseVisualStyleBackColor = true;
            btnSelectOutputFolder.Click += btnSelectOutputFolder_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork_1;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted_1;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 221);
            Controls.Add(btnSelectOutputFolder);
            Controls.Add(lblOutputFolder);
            Controls.Add(cbSetOutputFolder);
            Controls.Add(cbSetFileDate);
            Controls.Add(dtpFileDate);
            Controls.Add(lblProgress);
            Controls.Add(lblCount);
            Controls.Add(lblFileCountTxt);
            Controls.Add(btnSelectFolder);
            Controls.Add(lblFolder);
            Controls.Add(lblFolderTxt);
            Controls.Add(btnSelectFile);
            Controls.Add(lblFile);
            Controls.Add(lblFilesTxt);
            Controls.Add(btnStart);
            Controls.Add(pbProgress);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(480, 260);
            Name = "MainForm";
            Text = "MP4 Meta Data Remover (.NET edition)";
            FormClosing += MainForm_FormClosing;
            Shown += MainForm_Shown;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pbProgress;
        private Button btnStart;
        private Label lblFilesTxt;
        private Label lblFile;
        private Button btnSelectFile;
        private Label lblFolderTxt;
        private Label lblFolder;
        private Button btnSelectFolder;
        private Label lblFileCountTxt;
        private Label lblCount;
        private Label lblProgress;
        private DateTimePicker dtpFileDate;
        private CheckBox cbSetFileDate;
        private CheckBox cbSetOutputFolder;
        private Label lblOutputFolder;
        private Button btnSelectOutputFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
