namespace AVIAssembler
{
  partial class AVIAsm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AVIAsm));
      this.mChooseOutputFile = new System.Windows.Forms.SaveFileDialog();
      this.mBrowseForPath = new System.Windows.Forms.FolderBrowserDialog();
      this.label1 = new System.Windows.Forms.Label();
      this.mSearchPath = new System.Windows.Forms.ComboBox();
      this.mSearchExpr = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.mBrowse = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.mValidate = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.mIterateUntilError = new System.Windows.Forms.RadioButton();
      this.mIterateNumerical = new System.Windows.Forms.RadioButton();
      this.mIndexEnd = new System.Windows.Forms.NumericUpDown();
      this.mIndexStart = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.mFPS = new System.Windows.Forms.NumericUpDown();
      this.mAssemble = new System.Windows.Forms.Button();
      this.mProgress = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mIndexEnd)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.mIndexStart)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mFPS)).BeginInit();
      this.SuspendLayout();
      // 
      // mChooseOutputFile
      // 
      this.mChooseOutputFile.DefaultExt = "avi";
      this.mChooseOutputFile.Filter = "AVI Movies (*.avi)|*.avi|All Files|*.*";
      // 
      // mBrowseForPath
      // 
      this.mBrowseForPath.Description = "Where are your images?";
      this.mBrowseForPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
      this.mBrowseForPath.ShowNewFolderButton = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Image Search Path :";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // mSearchPath
      // 
      this.mSearchPath.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mSearchPath.FormattingEnabled = true;
      this.mSearchPath.Location = new System.Drawing.Point(9, 46);
      this.mSearchPath.MaxDropDownItems = 16;
      this.mSearchPath.Name = "mSearchPath";
      this.mSearchPath.Size = new System.Drawing.Size(407, 24);
      this.mSearchPath.TabIndex = 2;
      this.mSearchPath.SelectedIndexChanged += new System.EventHandler(this.mSearchPath_TextUpdate);
      this.mSearchPath.TextUpdate += new System.EventHandler(this.mSearchPath_TextUpdate);
      // 
      // mSearchExpr
      // 
      this.mSearchExpr.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mSearchExpr.FormattingEnabled = true;
      this.mSearchExpr.Location = new System.Drawing.Point(9, 95);
      this.mSearchExpr.MaxDropDownItems = 16;
      this.mSearchExpr.Name = "mSearchExpr";
      this.mSearchExpr.Size = new System.Drawing.Size(438, 24);
      this.mSearchExpr.TabIndex = 4;
      this.mSearchExpr.SelectedIndexChanged += new System.EventHandler(this.mSearchExpr_TextUpdate);
      this.mSearchExpr.TextUpdate += new System.EventHandler(this.mSearchExpr_TextUpdate);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 79);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(120, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "File Search Expression :";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // mBrowse
      // 
      this.mBrowse.Location = new System.Drawing.Point(420, 46);
      this.mBrowse.Name = "mBrowse";
      this.mBrowse.Size = new System.Drawing.Size(27, 24);
      this.mBrowse.TabIndex = 5;
      this.mBrowse.Text = "...";
      this.mBrowse.UseVisualStyleBackColor = true;
      this.mBrowse.Click += new System.EventHandler(this.mBrowse_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::AVIAssembler.Properties.Resources.Media_video_avi_icon;
      this.pictureBox1.Location = new System.Drawing.Point(478, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(128, 128);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 6;
      this.pictureBox1.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.mValidate);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.mIterateUntilError);
      this.groupBox1.Controls.Add(this.mIterateNumerical);
      this.groupBox1.Controls.Add(this.mIndexEnd);
      this.groupBox1.Controls.Add(this.mIndexStart);
      this.groupBox1.Controls.Add(this.mSearchExpr);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.mBrowse);
      this.groupBox1.Controls.Add(this.mSearchPath);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(460, 251);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Configure Input";
      // 
      // mValidate
      // 
      this.mValidate.Enabled = false;
      this.mValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mValidate.Location = new System.Drawing.Point(344, 208);
      this.mValidate.Name = "mValidate";
      this.mValidate.Size = new System.Drawing.Size(110, 37);
      this.mValidate.TabIndex = 11;
      this.mValidate.Text = "Validate";
      this.mValidate.UseVisualStyleBackColor = true;
      this.mValidate.Click += new System.EventHandler(this.mValidate_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 136);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Initial index :";
      // 
      // mIterateUntilError
      // 
      this.mIterateUntilError.AutoSize = true;
      this.mIterateUntilError.Location = new System.Drawing.Point(109, 176);
      this.mIterateUntilError.Name = "mIterateUntilError";
      this.mIterateUntilError.Size = new System.Drawing.Size(186, 17);
      this.mIterateUntilError.TabIndex = 9;
      this.mIterateUntilError.Text = "Increment until no more files found";
      this.mIterateUntilError.UseVisualStyleBackColor = true;
      // 
      // mIterateNumerical
      // 
      this.mIterateNumerical.Checked = true;
      this.mIterateNumerical.Location = new System.Drawing.Point(109, 152);
      this.mIterateNumerical.Name = "mIterateNumerical";
      this.mIterateNumerical.Size = new System.Drawing.Size(157, 20);
      this.mIterateNumerical.TabIndex = 8;
      this.mIterateNumerical.TabStop = true;
      this.mIterateNumerical.Text = "Increment to specific index :";
      this.mIterateNumerical.UseVisualStyleBackColor = true;
      this.mIterateNumerical.CheckedChanged += new System.EventHandler(this.incrementChanged);
      // 
      // mIndexEnd
      // 
      this.mIndexEnd.Location = new System.Drawing.Point(272, 152);
      this.mIndexEnd.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.mIndexEnd.Name = "mIndexEnd";
      this.mIndexEnd.Size = new System.Drawing.Size(90, 20);
      this.mIndexEnd.TabIndex = 7;
      this.mIndexEnd.ValueChanged += new System.EventHandler(this.checkIndexRange);
      // 
      // mIndexStart
      // 
      this.mIndexStart.Location = new System.Drawing.Point(9, 152);
      this.mIndexStart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.mIndexStart.Name = "mIndexStart";
      this.mIndexStart.Size = new System.Drawing.Size(90, 20);
      this.mIndexStart.TabIndex = 6;
      this.mIndexStart.ValueChanged += new System.EventHandler(this.checkIndexRange);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(495, 134);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(93, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "AVI Assembler 1.0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(478, 148);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(131, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Harry Denholm - ishani.org";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.mFPS);
      this.groupBox2.Controls.Add(this.mAssemble);
      this.groupBox2.Location = new System.Drawing.Point(12, 269);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(460, 79);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Output Options";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 25);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "FPS :";
      // 
      // mFPS
      // 
      this.mFPS.Location = new System.Drawing.Point(9, 41);
      this.mFPS.Name = "mFPS";
      this.mFPS.Size = new System.Drawing.Size(90, 20);
      this.mFPS.TabIndex = 13;
      this.mFPS.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // mAssemble
      // 
      this.mAssemble.Enabled = false;
      this.mAssemble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mAssemble.Location = new System.Drawing.Point(344, 36);
      this.mAssemble.Name = "mAssemble";
      this.mAssemble.Size = new System.Drawing.Size(110, 37);
      this.mAssemble.TabIndex = 12;
      this.mAssemble.Text = "Assemble...";
      this.mAssemble.UseVisualStyleBackColor = true;
      this.mAssemble.Click += new System.EventHandler(this.mAssemble_Click);
      // 
      // mProgress
      // 
      this.mProgress.Location = new System.Drawing.Point(11, 354);
      this.mProgress.Name = "mProgress";
      this.mProgress.Size = new System.Drawing.Size(461, 23);
      this.mProgress.Step = 1;
      this.mProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.mProgress.TabIndex = 11;
      // 
      // AVIAsm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(614, 387);
      this.Controls.Add(this.mProgress);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AVIAsm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "AVI Assembler";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AVIAsm_Closing);
      this.Load += new System.EventHandler(this.AVIAsm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mIndexEnd)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.mIndexStart)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mFPS)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SaveFileDialog mChooseOutputFile;
    private System.Windows.Forms.FolderBrowserDialog mBrowseForPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox mSearchPath;
    private System.Windows.Forms.ComboBox mSearchExpr;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button mBrowse;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button mValidate;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.RadioButton mIterateUntilError;
    private System.Windows.Forms.RadioButton mIterateNumerical;
    private System.Windows.Forms.NumericUpDown mIndexEnd;
    private System.Windows.Forms.NumericUpDown mIndexStart;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown mFPS;
    private System.Windows.Forms.Button mAssemble;
    private System.Windows.Forms.ProgressBar mProgress;
  }
}

