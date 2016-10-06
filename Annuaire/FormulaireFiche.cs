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
    public partial class FormulaireFiche : Form
    {
        #region Region Global
        GlobalFunctions gfctn = new GlobalFunctions();
        ReadAccess read = new ReadAccess();
        WriteAccess write = new WriteAccess();
        public delegate void ChildEvent3(string createdId);
        public event ChildEvent3 returnCreatedValue;
        
        
        int idToUpdate = 0;
        public ModeFiche modeFiche;
        public enum ModeFiche
        {
            CREER = 1,
            MODIFIER = 2,
            AFFICHER = 3
        }
        #endregion

        #region Constructeurs
        public FormulaireFiche()
        {
            InitializeComponent();
            InitializeThemeComboBox();
        }

        public FormulaireFiche(int nodeToLoad)
        {
            InitializeComponent();
            InitializeThemeComboBox();

            idToUpdate = nodeToLoad;

            Fiche myfiche = new Fiche();
            myfiche = read.fnSelectionFiche(nodeToLoad);

            this.txtNom.Text = myfiche.Nom;
            this.txtPrenom.Text = myfiche.Prenom;
            this.txtAlias.Text = myfiche.Alias;
            this.txtAnniversaire.Text = myfiche.DateAnniversaire;
            this.txtTel1.Text = myfiche.Tel1;
            this.txtTel2.Text = myfiche.Tel2;
            this.txtAdresse.Text = myfiche.Adresse;
            this.cbxRelation.Text = myfiche.Relation;
            this.cbxActivite.Text = myfiche.Activite;
            this.txtDetails.Text = myfiche.Detail;            

        }

        public FormulaireFiche(int nodeToLoad, string visu)
        {
            InitializeComponent();
            InitializeThemeComboBox();

            idToUpdate = nodeToLoad;

            Fiche myfiche = new Fiche();
            myfiche = read.fnSelectionFiche(nodeToLoad);

            this.txtNom.Text = myfiche.Nom;
            this.txtPrenom.Text = myfiche.Prenom;
            this.txtAlias.Text = myfiche.Alias;
            this.txtAnniversaire.Text = myfiche.DateAnniversaire;
            this.txtTel1.Text = myfiche.Tel1;
            this.txtTel2.Text = myfiche.Tel2;
            this.txtAdresse.Text = myfiche.Adresse;
            this.cbxRelation.Text = myfiche.Relation;
            this.cbxActivite.Text = myfiche.Activite;
            this.txtDetails.Text = myfiche.Detail;

            this.txtNom.Enabled = false;
            this.txtPrenom.Enabled = false;
            this.txtAlias.Enabled = false;
            this.txtTel1.Enabled = false;
            this.txtTel2.Enabled = false;
            this.txtAdresse.Enabled = false;
            this.cbxRelation.Enabled = false;
            this.cbxActivite.Enabled = false;
            this.txtDetails.Enabled = false;
        }

        #endregion

        #region Fonctions
        public void InitializeThemeComboBox()
        {
            this.cbxActivite.Items.Add("");
            foreach (string act in read.fnSelectActivites())
            {
                this.cbxActivite.Items.Add(act);
            }

            this.cbxRelation.Items.Add("");
            foreach (string rel in read.fnSelectRelations())
            {
                this.cbxRelation.Items.Add(rel);
            }
        }
        #endregion

        #region Gestion Evenements
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            DateTime dateValue;
            String annif = "";
            if (DateTime.TryParse(txtAnniversaire.Text, out dateValue)) { annif = txtAnniversaire.Text; } else { annif = "01-01-9999"; }
            
            if (this.modeFiche == FormulaireFiche.ModeFiche.CREER)
            {
                string createdId = write.fnCreationFiche(this.txtNom.Text, this.txtPrenom.Text, this.txtAlias.Text, this.txtTel1.Text, this.txtTel2.Text, this.txtAdresse.Text, this.cbxActivite.Text, this.cbxRelation.Text, "lienPhoto", this.txtDetails.Text, annif);
                this.returnCreatedValue(createdId);
                this.Close();
            }

            if (this.modeFiche == FormulaireFiche.ModeFiche.MODIFIER)
            {
                write.fnModificationFiche(idToUpdate, this.txtNom.Text, this.txtPrenom.Text, this.txtAlias.Text, this.txtTel1.Text, this.txtTel2.Text, this.txtAdresse.Text, this.cbxActivite.Text, this.cbxRelation.Text, "lienPhoto", this.txtDetails.Text, annif);
                this.Close();
            }

            if (this.modeFiche == FormulaireFiche.ModeFiche.AFFICHER)
            {

            }
        }
        #endregion


    }
}
