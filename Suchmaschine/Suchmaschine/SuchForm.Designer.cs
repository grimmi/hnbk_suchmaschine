namespace Suchmaschine
{
    partial class SuchForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadFiles = new System.Windows.Forms.Button();
            this.txtBoxSuche = new System.Windows.Forms.TextBox();
            this.btnSuche = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBoxResult = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.radiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.bgw_reader = new System.ComponentModel.BackgroundWorker();
            this.bgw_Suche = new System.ComponentModel.BackgroundWorker();
            this.distanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblDistance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxCase = new System.Windows.Forms.CheckBox();
            this.cBoxEqual = new System.Windows.Forms.CheckBox();
            this.cBoxDistance = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReadFiles
            // 
            this.btnReadFiles.Location = new System.Drawing.Point(12, 12);
            this.btnReadFiles.Name = "btnReadFiles";
            this.btnReadFiles.Size = new System.Drawing.Size(727, 23);
            this.btnReadFiles.TabIndex = 0;
            this.btnReadFiles.Text = "Texte einlesen";
            this.btnReadFiles.UseVisualStyleBackColor = true;
            this.btnReadFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxSuche
            // 
            this.txtBoxSuche.Location = new System.Drawing.Point(126, 45);
            this.txtBoxSuche.Name = "txtBoxSuche";
            this.txtBoxSuche.Size = new System.Drawing.Size(183, 20);
            this.txtBoxSuche.TabIndex = 1;
            this.txtBoxSuche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSuche_KeyDown);
            // 
            // btnSuche
            // 
            this.btnSuche.Location = new System.Drawing.Point(15, 71);
            this.btnSuche.Name = "btnSuche";
            this.btnSuche.Size = new System.Drawing.Size(294, 38);
            this.btnSuche.TabIndex = 2;
            this.btnSuche.Text = "suchen";
            this.btnSuche.UseVisualStyleBackColor = true;
            this.btnSuche.Click += new System.EventHandler(this.btnSuche_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Suchbegriff eingeben:";
            // 
            // treeViewResult
            // 
            this.treeViewResult.Location = new System.Drawing.Point(12, 128);
            this.treeViewResult.Name = "treeViewResult";
            this.treeViewResult.Size = new System.Drawing.Size(297, 262);
            this.treeViewResult.TabIndex = 4;
            this.treeViewResult.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewResult_NodeMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(318, 128);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(421, 262);
            this.tabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBoxResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(413, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Umgebung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxResult
            // 
            this.txtBoxResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxResult.Enabled = false;
            this.txtBoxResult.Location = new System.Drawing.Point(3, 3);
            this.txtBoxResult.Multiline = true;
            this.txtBoxResult.Name = "txtBoxResult";
            this.txtBoxResult.ReadOnly = true;
            this.txtBoxResult.Size = new System.Drawing.Size(407, 230);
            this.txtBoxResult.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(413, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistik";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(234, 396);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 6;
            this.btnOpenFile.Text = "öffne Datei";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ergebnisse";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(664, 396);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Beenden";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radiusUpDown
            // 
            this.radiusUpDown.Location = new System.Drawing.Point(613, 399);
            this.radiusUpDown.Name = "radiusUpDown";
            this.radiusUpDown.Size = new System.Drawing.Size(45, 20);
            this.radiusUpDown.TabIndex = 10;
            this.radiusUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.radiusUpDown.ValueChanged += new System.EventHandler(this.radiusUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Wieviele Wörter rechts und links vom Suchbegriff anzeigen?";
            // 
            // bgw_reader
            // 
            this.bgw_reader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw_reader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgw_reader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // bgw_Suche
            // 
            this.bgw_Suche.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Suche_DoWork);
            this.bgw_Suche.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_Suche_ProgressChanged);
            this.bgw_Suche.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Suche_RunWorkerCompleted);
            // 
            // distanceUpDown
            // 
            this.distanceUpDown.Location = new System.Drawing.Point(353, 28);
            this.distanceUpDown.Name = "distanceUpDown";
            this.distanceUpDown.Size = new System.Drawing.Size(45, 20);
            this.distanceUpDown.TabIndex = 12;
            this.distanceUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(194, 30);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(153, 13);
            this.lblDistance.TabIndex = 13;
            this.lblDistance.Text = "Maximale Levenshtein-Distanz:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cBoxDistance);
            this.panel1.Controls.Add(this.cBoxEqual);
            this.panel1.Controls.Add(this.cBoxCase);
            this.panel1.Controls.Add(this.lblDistance);
            this.panel1.Controls.Add(this.distanceUpDown);
            this.panel1.Location = new System.Drawing.Point(318, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 63);
            this.panel1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Suchoptionen";
            // 
            // cBoxCase
            // 
            this.cBoxCase.AutoSize = true;
            this.cBoxCase.Location = new System.Drawing.Point(4, 10);
            this.cBoxCase.Name = "cBoxCase";
            this.cBoxCase.Size = new System.Drawing.Size(186, 17);
            this.cBoxCase.TabIndex = 14;
            this.cBoxCase.Text = "Groß- / Kleinschreibung beachten";
            this.cBoxCase.UseVisualStyleBackColor = true;
            // 
            // cBoxEqual
            // 
            this.cBoxEqual.AutoSize = true;
            this.cBoxEqual.Location = new System.Drawing.Point(4, 29);
            this.cBoxEqual.Name = "cBoxEqual";
            this.cBoxEqual.Size = new System.Drawing.Size(159, 17);
            this.cBoxEqual.TabIndex = 15;
            this.cBoxEqual.Text = "Nur das ganze Wort suchen";
            this.cBoxEqual.UseVisualStyleBackColor = true;
            // 
            // cBoxDistance
            // 
            this.cBoxDistance.AutoSize = true;
            this.cBoxDistance.Location = new System.Drawing.Point(197, 8);
            this.cBoxDistance.Name = "cBoxDistance";
            this.cBoxDistance.Size = new System.Drawing.Size(180, 17);
            this.cBoxDistance.TabIndex = 16;
            this.cBoxDistance.Text = "Ähnliche Wörter berücksichtigen";
            this.cBoxDistance.UseVisualStyleBackColor = true;
            this.cBoxDistance.CheckedChanged += new System.EventHandler(this.cBoxDistance_CheckedChanged);
            // 
            // SuchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 448);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radiusUpDown);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.treeViewResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSuche);
            this.Controls.Add(this.txtBoxSuche);
            this.Controls.Add(this.btnReadFiles);
            this.Name = "SuchForm";
            this.Text = "SuchForm";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiusUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadFiles;
        private System.Windows.Forms.TextBox txtBoxSuche;
        private System.Windows.Forms.Button btnSuche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBoxResult;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown radiusUpDown;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bgw_reader;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker bgw_Suche;
        private System.Windows.Forms.NumericUpDown distanceUpDown;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cBoxDistance;
        private System.Windows.Forms.CheckBox cBoxEqual;
        private System.Windows.Forms.CheckBox cBoxCase;
    }
}