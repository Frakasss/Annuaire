using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annuaire
{
    public partial class FormulaireNouvelAnnuaire : Form
    {
        #region Global
        ConfigFunctions config = new ConfigFunctions();
        ReadAccess read = new ReadAccess();
        WriteAccess write = new WriteAccess();
        public delegate void ChildEvent();
        public event ChildEvent activateRefresh;
        String gNom; 
        String gPrenom; 
        String gAlias; 
        String gTel; 
        String gActivite; 
        String gRelation; 
        String gDetails;
        #endregion

        #region Constructeurs
        public FormulaireNouvelAnnuaire()
        {
            InitializeComponent();
        }

        public FormulaireNouvelAnnuaire(String Nom, String Prenom, String Alias, String Tel, String Activite, String Relation, String Details)
        {
            InitializeComponent();
            gNom = Nom;
            gPrenom = Prenom;
            gAlias = Alias;
            gTel = Tel;
            gActivite = Activite;
            gRelation = Relation;
            gDetails = Details;
        }
        #endregion

        #region Gestion Events
        private void txtNomAnnuaire_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNomAnnuaire.Text == "")
            {
                this.btnCreer.Enabled = false;
            }
            else
            {
                string myXmlDb = config.getDBPath(this.txtNomAnnuaire.Text + ".xml");
                if (System.IO.File.Exists(myXmlDb))
                {
                    this.btnCreer.Enabled = false;
                    lblAlerte.Visible = true;
                }
                else
                {
                    this.btnCreer.Enabled = true;
                    lblAlerte.Visible = false;
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            fnSetUpFile();
            this.activateRefresh();
            this.Close();
        }
        #endregion

        #region fonctions
        //créer fichier
        private void fnCreateFile()
        {
            string myXmlDb = config.getDBPath(this.txtNomAnnuaire.Text + ".xml");
            System.IO.FileStream fs = System.IO.File.Create(myXmlDb);
            fs.Close();
        }

        //Initialise la nouvelle DB
        private void fnSetUpFile()
        {
            string myXmlDb = config.getDBPath(this.txtNomAnnuaire.Text + ".xml");
            string[] lines = { "<root>", "<activites>", "</activites>", "<relations>", "</relations>", "<annuaire>", "</annuaire>", "</root>" };
            System.IO.File.WriteAllLines(myXmlDb, lines);
            if (chkImporterActivite.Checked == true) { write.importActivites(this.txtNomAnnuaire.Text + ".xml"); }
            if (chkImporterRelation.Checked == true) { write.importRelations(this.txtNomAnnuaire.Text + ".xml"); }
            if (chkImporterAnnuaire.Checked == true) { write.importCurrentAnnuaire(this.txtNomAnnuaire.Text + ".xml", gNom, gPrenom, gAlias, gTel, gActivite, gRelation, gDetails); }
            config.saveAnnuaire(this.txtNomAnnuaire.Text + ".xml");
        }
        #endregion
    }
}
