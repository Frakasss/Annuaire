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

        private void InitializeDgv()
        {
            foreach (Fiche myFiche in fctn.fnSelection(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text))
            {
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormulaireFiche formulaireFiche = new FormulaireFiche();
            formulaireFiche.modeFiche = FormulaireFiche.ModeFiche.CREER;
            formulaireFiche.ShowDialog();
            this.btnRechercher.PerformClick();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in fctn.fnSelection(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text))
            {
               this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
            }
        }

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
                this.btnRechercher.PerformClick();
            }
        }


    }
}
