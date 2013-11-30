using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Suchmaschine
{
    public partial class SuchForm : Form
    {
        private List<Lemma> Woerter;
        private TreeNode activeNode;
        private IEnumerable<Lemma> suchergebnis;
        private delegate void AddNodeToTree(TreeNode node);
        private AddNodeToTree AddNode;
        private AddNodeToTree ClearNodes;
        private delegate void ClearBox();
        private ClearBox clearResultBox;
        private int lemmaNodes;
        private int sourceNodes;
        private bool searchCase { get { return cBoxCase.Checked; } }
        private bool searchEqual { get { return cBoxEqual.Checked; } }
        private bool searchDistance { get { return cBoxDistance.Checked; } }
        private int maxDistance { get { return (int)distanceUpDown.Value; } }

        public SuchForm()
        {
            Woerter = new List<Lemma>();
            InitializeComponent();
            AddNode = x => treeViewResult.Nodes.Add(x);
            ClearNodes = x => treeViewResult.Nodes.Clear();
            clearResultBox = () => txtBoxResult.Text = String.Empty;
            btnOpenFile.Enabled = false;
            btnSuche.Enabled = false;
            txtBoxSuche.Enabled = false;
            radiusUpDown.Enabled = false;
            toolStripProgressBar1.Visible = false;
            cBoxCase.Enabled = false;
            cBoxDistance.Enabled = false;
            cBoxEqual.Enabled = false;
            distanceUpDown.Enabled = false;
            lblDistance.Enabled = false;
            lemmaNodes = 0;
            sourceNodes = 0;
        }

        private void SwitchEnabled()
        {
            btnReadFiles.Enabled = !btnReadFiles.Enabled;
            btnSuche.Enabled = !btnSuche.Enabled;
            txtBoxSuche.Enabled = !txtBoxSuche.Enabled;
            radiusUpDown.Enabled = !radiusUpDown.Enabled;
            cBoxCase.Enabled = !cBoxCase.Enabled;
            cBoxDistance.Enabled = !cBoxDistance.Enabled;
            cBoxEqual.Enabled = !cBoxEqual.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bgw_reader.IsBusy)
            {
                toolStripProgressBar1.Visible = true;
                bgw_reader.WorkerReportsProgress = true;
                bgw_reader.RunWorkerAsync();
            }
        }

        private void ReadFiles()
        {
            string[] files = Directory.GetFiles(@"F:\Git Repos\hnbk suchmaschine\Suchmaschine\Suchmaschine\Korpus").Take(2).ToArray<string>();
            int count = 0;
            foreach (string f in files)
            {
                ReadWordsFromFile(f);
                count++;
                double progress = ((double)count / (double)files.Length) * 100.0;
                string currentFile = Path.GetFileName(f);
                bgw_reader.ReportProgress((int)progress, currentFile);
            }
        }

        private List<string> SplittedText(string text)
        {
            char[] splitChars = new char[] { '\r', '\n', ' ', '\t' };
            List<string> splittedText = text.Split(splitChars).ToList<string>();
            return splittedText;
        }

        private void ReadWordsFromFile(string file)
        {
            using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
            {
                string text = sr.ReadToEnd();
                List<string> splittedText = SplittedText(text);
                for (int i = 0; i < splittedText.Count(); i++)
                {
                    string tmpWort = splittedText[i];
                    string bereinigt = RemoveSpecialChars(tmpWort);
                    if (IsWord(bereinigt))
                    {
                        Lemma lemma;
                        if (LemmaExists(bereinigt, out lemma))
                        {
                            lemma.AddQuelle(file, i);
                        }
                        else
                        {
                            lemma = new Lemma(bereinigt, file, i);
                            Woerter.Add(lemma);
                        }
                    }
                }
            }
        }

        static readonly List<string> blackList = new List<string>() { "in", "am", "um", "zu", "im", "der", 
                                    "die", "das", "er", "sie", "es", "bei", "mit", "weil", "ob", "an", "und" };
        private bool IsWord(string wort)
        {
            string bereinigt = RemoveSpecialChars(wort).Trim();
            if (String.IsNullOrEmpty(bereinigt))
            {
                return false;
            }
            if (blackList.Contains(bereinigt.ToLowerInvariant()))
            {
                return false;
            }
            return true;
        }

        private bool LemmaExists(string wort, out Lemma lemma)
        {
            foreach (Lemma l in Woerter)
            {
                if (l.Wort.ToUpper() == wort.ToUpper())
                {
                    lemma = l;
                    return true;
                }
            }
            lemma = null;
            return false;
        }

        private string RemoveSpecialChars(string wort)
        {
            // A-Z: 65-90
            // a-z: 97-122
            // Sonderzeichen: 192-255
            //List<char> specialChars = new List<char>{ ',', '.', '"', '\'', '!', '?', '(', ')', ':' };
            string neuWort = String.Empty;
            foreach (char c in wort)
            {
                int code = (int)c;
                if ((code >= 65 && code <= 90) || (code >= 97 && code <= 122) || (code >= 192 && code <= 255))
                {
                    neuWort += c;
                }
            }
            return neuWort;
        }

        private void btnSuche_Click(object sender, EventArgs e)
        {
            lemmaNodes = 0;
            sourceNodes = 0;
            SuspendLayout();
            bgw_Suche.WorkerReportsProgress = true;
            bgw_Suche.RunWorkerAsync();
            ResumeLayout();
        }

        private bool IsResult(Lemma lemma, string suchbegriff)
        {
            StringComparison comp = StringComparison.InvariantCultureIgnoreCase;
            if (searchCase)
            {
                comp = StringComparison.InvariantCulture;
            }
            Func<Lemma, string, bool> isEqual = (x, s) => x.Wort.Equals(s, comp);
            Func<Lemma, string, bool> isContained = (x, s) => x.Wort.Contains(s, comp);
            Func<Lemma, string, bool> isClose = (x, s) => x.Wort.Distance(s) < distanceUpDown.Value;
            bool isResult = false;
            if (searchEqual)
            {
                isResult = isResult || isEqual(lemma, suchbegriff);
            }
            else
            {
                isResult = isResult || isContained(lemma, suchbegriff);
            }
            if (searchDistance)
            {
                isResult = isResult || isClose(lemma, suchbegriff);
            }
            return isResult;
        }

        private void Suche()
        {
            string such = txtBoxSuche.Text;
            Invoke(clearResultBox);
            suchergebnis = Woerter.Where(x => IsResult(x, such));
            Invoke(ClearNodes, new TreeNode(""));
            foreach (var lemma in suchergebnis.OrderBy(x => x.Wort))
            {
                TreeNode lemmaNode = new TreeNode(lemma.Wort + "(" + lemma.AnzahlFundstellen + ")");
                lemmaNode.Tag = lemma;
                foreach (var q in lemma.Quellen)
                {
                    string fName = Path.GetFileName(q.Datei);
                    int index = q.WortIndex;
                    TreeNode qNode = new TreeNode(String.Format("{0} ({1})", fName, index));
                    qNode.Tag = q;
                    lemmaNode.Nodes.Add(qNode);
                    sourceNodes++;
                }
                Invoke(AddNode, lemmaNode);
                lemmaNodes++;
                bgw_Suche.ReportProgress(10);
            }
        }

        private void treeViewResult_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtBoxResult.Text = String.Empty;
            TreeNode clickedNode = e.Node;
            activeNode = e.Node;
            object tag = clickedNode.Tag;
            btnOpenFile.Enabled = false;
            if (tag is Lemma)
            {
                Lemma l = tag as Lemma;
            }
            else if (tag is Quelle)
            {
                Quelle q = tag as Quelle;
                txtBoxResult.Text = ReadWordsAroundIndex(q.Datei, q.WortIndex);
                btnOpenFile.Enabled = true;
            }
        }

        private string ReadWordsAroundIndex(string file, int index, int radius = 5)
        {
            using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
            {
                if (radiusUpDown.Value >= 0)
                {
                    radius = (int)radiusUpDown.Value;
                }
                string text = sr.ReadToEnd();
                List<string> splittedText = SplittedText(text);
                string toShow = String.Empty;
                int start = (index - radius >= 0) ? index - radius : 0;
                int ende = (index + radius < splittedText.Count() - 2) ? index + radius + 1 : splittedText.Count() - 1;
                for (int i = start; i < ende; i++)
                {
                    toShow += (String.IsNullOrEmpty(splittedText[i])) ? "" : splittedText[i] + " ";
                }
                return toShow;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (activeNode != null && activeNode.Tag is Quelle)
            {
                Quelle q = activeNode.Tag as Quelle;
                Process.Start(q.Datei);
            }
        }

        private void txtBoxSuche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSuche_Click(null, null);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (activeNode.Tag is Quelle)
            {
                Quelle q = activeNode.Tag as Quelle;
                txtBoxResult.Text = ReadWordsAroundIndex(q.Datei, q.WortIndex);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadFiles();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SwitchEnabled();
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Text = "Texte eingelesen!";
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = e.UserState.ToString() + "...";
        }

        private void bgw_Suche_DoWork(object sender, DoWorkEventArgs e)
        {
            Suche();
        }

        private void bgw_Suche_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Suche nach '{0}' beendet! {1} Lemmata, {2} Textstellen."
                    , txtBoxSuche.Text, suchergebnis.Count(), suchergebnis.Sum(x => x.AnzahlFundstellen));
        }

        private void bgw_Suche_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Suche nach '{0}' ...! {1} Lemmata, {2} Fundstellen..."
                    , txtBoxSuche.Text, lemmaNodes, sourceNodes);
        }

        private void cBoxDistance_CheckedChanged(object sender, EventArgs e)
        {
            lblDistance.Enabled = cBoxDistance.Checked;
            distanceUpDown.Enabled = cBoxDistance.Checked;
        }

    }
}
