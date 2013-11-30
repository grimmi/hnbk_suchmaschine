using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Suchmaschine
{
    class Lemma
    {
        // Liste von Quellen, an denen das Wort vorkommt
        public List<Quelle> Quellen { get; set; }
        // "Das Wort"
        public string Wort { get; set; }
        // Länge des Wortes
        public int Laenge { get { return Wort.Length; } }
        // Anzahl der Fundstellen
        public int AnzahlFundstellen { get { return Quellen.Count(); } }

        public Lemma(string wort, string file, int index)
        {
            Wort = wort;
            Quellen = new List<Quelle>();
            AddQuelle(file, index);
        }

        public void AddQuelle(string file, int index)
        {
            Quelle q = new Quelle(file, index);
            if (!Quellen.Contains(q))
            {
                Quellen.Add(q);
            }
            else
            {
                Debug.WriteLine(String.Format("Quelle existiert bereits: {0} :: {1}", file, index));
            }
        }

    }

    internal class Quelle : IEquatable<Quelle>
    {
        public string Datei;
        public int WortIndex;

        public Quelle(string file, int index)
        {
            this.Datei = file;
            this.WortIndex = index;
        }

        public bool Equals(Quelle other)
        {
            bool gleicheDatei = this.Datei.Equals(other.Datei);
            bool gleicherIndex = this.WortIndex.Equals(other.WortIndex);
            return gleicheDatei && gleicherIndex;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Quelle qObj = obj as Quelle;
            if (qObj == null)
            {
                return false;
            }
            else
            {
                return Equals(qObj);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
