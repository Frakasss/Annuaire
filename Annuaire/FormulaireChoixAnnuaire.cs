using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Annuaire
{
    public partial class FormulaireChoixAnnuaire : Form
    {
        #region global
        GlobalFunctions globalfn = new GlobalFunctions();
        ConfigFunctions config = new ConfigFunctions();
        public delegate void ChildEvent2();
        public event ChildEvent2 activateRefresh;
        #endregion

        public FormulaireChoixAnnuaire()
        {
            InitializeComponent();
            InitializeCombobox();
        }

        public void InitializeCombobox(){
            String myXmlDb = globalfn.AppRootPath() + "Annuaires/BasesDeDonnees/";
            DirectoryInfo dir = new DirectoryInfo(myXmlDb);
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                string myExtension = fichier.Name.Substring(fichier.Name.Length - 4);
                if (myExtension.ToLower() == ".xml") { cbxListeAnnuaires.Items.Add(fichier.Name); }
            }
            cbxListeAnnuaires.SelectedIndex = cbxListeAnnuaires.FindStringExact(config.currentAnnuaire());
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            config.saveAnnuaire(cbxListeAnnuaires.Text);
            this.activateRefresh();
            this.Close();

        }
    }
}
