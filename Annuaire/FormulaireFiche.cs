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
        public ModeFiche modeFiche;

        int idToUpdate = 0;

        FunctionFiches fctn = new FunctionFiches();
        GlobalFunctions gfctn = new GlobalFunctions();

        public enum ModeFiche
        {
            CREER = 1,
            MODIFIER = 2,
            AFFICHER = 3
        }

        public delegate void ChildEvent(string text);
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
            myfiche = fctn.fnSelection(nodeToLoad);

            this.txtNom.Text = myfiche.Nom;
            this.txtPrenom.Text = myfiche.Prenom;
            this.txtAlias.Text = myfiche.Alias;
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
            myfiche = fctn.fnSelection(nodeToLoad);

            this.txtNom.Text = myfiche.Nom;
            this.txtPrenom.Text = myfiche.Prenom;
            this.txtAlias.Text = myfiche.Alias;
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

        public void InitializeThemeComboBox()
        {
            this.cbxActivite.Items.Add("");
            this.cbxActivite.Items.Add("Autre");
            this.cbxActivite.Items.Add("Informatique");
            this.cbxActivite.Items.Add("Musique");
            this.cbxActivite.Items.Add("Moto");
            this.cbxActivite.Items.Add("Retraite");
            this.cbxActivite.Items.Add("Décédé");

            this.cbxRelation.Items.Add("");
            this.cbxRelation.Items.Add("Autre");
            this.cbxRelation.Items.Add("Famille");
            this.cbxRelation.Items.Add("Ami");
            this.cbxRelation.Items.Add("Collegue");
            this.cbxRelation.Items.Add("Connaissance");
            this.cbxRelation.Items.Add("Technique");
            this.cbxRelation.Items.Add("Boulet");
        }

        public event ChildEvent returnCreatedValue;

        #endregion

        #region Gestion Evenements
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (this.modeFiche == FormulaireFiche.ModeFiche.CREER)
            {
                string createdId = fctn.fnCreationFiche(this.txtNom.Text, this.txtPrenom.Text, this.txtAlias.Text, this.txtTel1.Text, this.txtTel2.Text, this.txtAdresse.Text, this.cbxActivite.Text, this.cbxRelation.Text, "lienPhoto", this.txtDetails.Text);
                this.returnCreatedValue(createdId);
                this.Close();
            }

            if (this.modeFiche == FormulaireFiche.ModeFiche.MODIFIER)
            {
                fctn.fnModificationFiche(idToUpdate, this.txtNom.Text, this.txtPrenom.Text, this.txtAlias.Text, this.txtTel1.Text, this.txtTel2.Text, this.txtAdresse.Text, this.cbxActivite.Text, this.cbxRelation.Text, "lienPhoto", this.txtDetails.Text);
                this.Close();
            }

            if (this.modeFiche == FormulaireFiche.ModeFiche.AFFICHER)
            {

            }
        }
        #endregion


    }
}
