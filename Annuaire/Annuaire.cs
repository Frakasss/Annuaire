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
    public partial class Annuaire : Form
    {

        FunctionFiches fctn = new FunctionFiches();
        string idToSelect;

        public Annuaire()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDgv();
        }

        private void InitializeComboBox()
        {
            this.cbxRechActivite.Items.Add("");
            this.cbxRechActivite.Items.Add("Autre");
            this.cbxRechActivite.Items.Add("Informatique");
            this.cbxRechActivite.Items.Add("Musique");
            this.cbxRechActivite.Items.Add("Moto");
            this.cbxRechActivite.Items.Add("Retraite");
            this.cbxRechActivite.Items.Add("Décédé");

            this.cbxRechRelation.Items.Add("");
            this.cbxRechRelation.Items.Add("Autre");
            this.cbxRechRelation.Items.Add("Famille");
            this.cbxRechRelation.Items.Add("Ami");
            this.cbxRechRelation.Items.Add("Collegue");
            this.cbxRechRelation.Items.Add("Connaissance");
            this.cbxRechRelation.Items.Add("Technique");
            this.cbxRechRelation.Items.Add("Boulet");

        }

        private void FillDatagridview(string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in fctn.fnSelection(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
            }
        }

        private void FillDatagridview(string idToBeSelected, string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            int cpt = 0;
            int indexToBeSelected = 0;
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in fctn.fnSelection(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
                if (myFiche.Id == idToBeSelected) { indexToBeSelected = cpt; }
                cpt = cpt + 1;
            }
            if (indexToBeSelected>1)
            {
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = indexToBeSelected - 2;
            }else{
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = 0;
            }
            this.dgvAnnuaire.Rows[indexToBeSelected].Selected = true;
            this.dgvAnnuaire.CurrentCell = this.dgvAnnuaire[1, indexToBeSelected];
        }
        private void FillDatagridview(int idToBeSelected, string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in fctn.fnSelection(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
            }

            if (idToBeSelected>1)
            {
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = idToBeSelected - 2;
            }else{
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = idToBeSelected;
            }
            this.dgvAnnuaire.Rows[idToBeSelected].Selected = true;
            this.dgvAnnuaire.CurrentCell = this.dgvAnnuaire[idToBeSelected, 0];
        }


        private void setIdToSelect(string s) { idToSelect = s; }


        private void InitializeDgv()
        {
            FillDatagridview(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
        }


        //##### Gestion des Events #####
        //##### Bouton Rechercher #####
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            FillDatagridview(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
        }



        //##### Bouton Nouveau #####
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormulaireFiche formulaireFiche = new FormulaireFiche();
            formulaireFiche.modeFiche = FormulaireFiche.ModeFiche.CREER;
            formulaireFiche.returnCreatedValue += new FormulaireFiche.ChildEvent(this.setIdToSelect);
            formulaireFiche.ShowDialog();
            FillDatagridview(idToSelect, txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            idToSelect = "";
        }

        //##### Bouton Modifier #####
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvAnnuaire.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une ligne!");
            }
            else
            {
                FormulaireFiche formulaireFiche = new FormulaireFiche(Convert.ToInt32(this.dgvAnnuaire.CurrentRow.Cells["colId"].Value.ToString()));
                formulaireFiche.modeFiche = FormulaireFiche.ModeFiche.MODIFIER;
                formulaireFiche.ShowDialog();
                FillDatagridview(this.dgvAnnuaire.CurrentRow.Cells["colId"].Value.ToString(), txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvAnnuaire.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une ligne!");
            }
            else
            {
                int idToSelectInt = this.dgvAnnuaire.CurrentRow.Index;
                fctn.fnSuppressionFiche(Convert.ToInt32(this.dgvAnnuaire.CurrentRow.Cells["colId"].Value.ToString()));
                FillDatagridview(idToSelectInt, txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            }
        }


    }
}
