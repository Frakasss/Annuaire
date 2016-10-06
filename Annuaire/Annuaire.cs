using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Annuaire
{
    public partial class Annuaire : Form
    {
        #region Global
        ReadAccess read = new ReadAccess();
        WriteAccess write = new WriteAccess();
        string idToSelect;
        #endregion

        #region Constructeurs
        public Annuaire()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDgv();
            MessageBox.Show("Reste à faire: \n- Vérification fichier chargé (et traitement en cas de corruption)\n-Gestion Anniversaire (Visualisation anniversaires aujourd'hui / suivants)\n- Gestion de la date d'anniversaire par defaut");
        }
        #endregion

        #region fonctions
        private void activateRefresh() { InitializeDgv(); }
        private void returnCreatedValue(string id) { InitializeDgv(); }

        private void InitializeComboBox()
        {
            this.cbxRechActivite.Items.Add("");
            foreach (string act in read.fnSelectActivites()) {
                this.cbxRechActivite.Items.Add(act);
            }

            this.cbxRechRelation.Items.Add("");
            foreach (string rel in read.fnSelectRelations())
            {
                this.cbxRechRelation.Items.Add(rel);
            }
        }
        private void InitializeDgv()
        {
            FillDatagridview(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
        }

        private string CalcAnniversaire(string dateNaissance)
        {
            string retour = "Non Défini";
            if(dateNaissance!="01-01-9999"){
                DateTime anniversaire = Convert.ToDateTime(dateNaissance.Substring(0, 6) + DateTime.Now.Year);
                DateTime aujourdhui = Convert.ToDateTime(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
                if (DateTime.Compare(anniversaire, aujourdhui) == 0) { retour = "Aujourd'hui !!"; }
                else if (DateTime.Compare(anniversaire, aujourdhui) > 0) { retour = "Dans " + ("   " + (anniversaire - aujourdhui).Days.ToString()).Substring(("   " + (anniversaire - aujourdhui).Days.ToString()).Length - 3, 3) + " jours"; }
                else {
                    anniversaire = Convert.ToDateTime(dateNaissance.Substring(0, 6) + DateTime.Now.AddYears(1).Year);
                    retour = "Dans " + (anniversaire - aujourdhui).Days.ToString() + " jours";
                }
            }
            return retour;
        }
        private string CalcAnniversaire2(string dateNaissance) {
            string retour = "999";
            if (dateNaissance != "01-01-9999")
            {
                DateTime naissance = Convert.ToDateTime(dateNaissance);
                DateTime cetteAnnee = Convert.ToDateTime(dateNaissance.Substring(0, 6) + DateTime.Now.Year);
                DateTime aujourdhui = Convert.ToDateTime(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());

                if (DateTime.Compare(cetteAnnee, aujourdhui) >= 0)
                {
                    string age = "   " + (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(dateNaissance.Substring(6, 4))).ToString();
                    age = age.Substring(age.Length - 3, 3);
                    retour = age + " ans le " + naissance.Day.ToString() + " " + naissance.ToString("MMMM", CultureInfo.CreateSpecificCulture("fr"));
                }
                else
                {
                    string age = "   " + (Convert.ToInt32(DateTime.Now.AddYears(1).Year) - Convert.ToInt32(dateNaissance.Substring(6, 4))).ToString();
                    age = age.Substring(age.Length - 3, 3);
                    retour = age + " ans le " + naissance.Day.ToString() + " " + naissance.ToString("MMMM", CultureInfo.CreateSpecificCulture("fr"));
                }
            }
            return retour;
        }

        private void FillDatagridview(string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            int cpt = 0;
            this.dgvAnnuaire.Rows.Clear();

            foreach (Fiche myFiche in read.fnSelectionFiche(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                string annif = annif = CalcAnniversaire(myFiche.DateAnniversaire);
                string annif2 = annif2 = CalcAnniversaire2(myFiche.DateAnniversaire);
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, annif, annif2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);


                //this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, Convert.ToDateTime(myFiche.DateAnniversaire.Substring(0,6) + DateTime.Now.Year), myFiche.Tel1, myFiche.Tel2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
                if (annif == "Non Défini") 
                {
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                }
                
                cpt = cpt + 1;
            }
            dgvAnnuaire.Columns["colAnniversaire"].DefaultCellStyle.Format = "dd-MM-yyyy";            
        }
        private void FillDatagridview(string idToBeSelected, string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            int cpt = 0;
            int indexToBeSelected = 0;
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in read.fnSelectionFiche(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                string annif = annif = CalcAnniversaire(myFiche.DateAnniversaire);
                string annif2 = annif2 = CalcAnniversaire2(myFiche.DateAnniversaire);
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, annif, annif2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
                if (myFiche.Id == idToBeSelected) { indexToBeSelected = cpt; }
                
                if (annif == "Non Défini")
                {
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                }

                cpt = cpt + 1;
            }
            dgvAnnuaire.Columns["colAnniversaire"].DefaultCellStyle.Format = "dd-MM-yyyy";
            if (indexToBeSelected>1)
            {
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = indexToBeSelected - 2;
            }else{
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = 0;
            }
            this.dgvAnnuaire.Rows[indexToBeSelected].Selected = true;
            this.dgvAnnuaire.CurrentCell = this.dgvAnnuaire[1, indexToBeSelected];
        }
        private void FillDatagridview(int indexToBeSelected, string txtRechNom, string txtRechPrenom, string txtRechAlias, string txtRechTelephone, string cbxRechActivite, string cbxRechRelation, string txtRechDetails)
        {
            int cpt = 0;
            this.dgvAnnuaire.Rows.Clear();
            foreach (Fiche myFiche in read.fnSelectionFiche(txtRechNom, txtRechPrenom, txtRechAlias, txtRechTelephone, cbxRechActivite, cbxRechRelation, txtRechDetails))
            {
                string annif = annif = CalcAnniversaire(myFiche.DateAnniversaire);
                string annif2 = annif2 = CalcAnniversaire2(myFiche.DateAnniversaire);
                this.dgvAnnuaire.Rows.Add(myFiche.Id, myFiche.Nom, myFiche.Prenom, myFiche.Alias, myFiche.Tel1, myFiche.Tel2, annif, annif2, myFiche.Adresse, myFiche.Activite, myFiche.Relation);
                if (annif == "Non Défini")
                {
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.ForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[6].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                    dgvAnnuaire.Rows[cpt].Cells[7].Style.SelectionForeColor = System.Drawing.Color.Transparent;
                }

                cpt = cpt + 1;
            }
            dgvAnnuaire.Columns["colAnniversaire"].DefaultCellStyle.Format = "dd-MM-yyyy";

            if (indexToBeSelected > 1)
            {
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = indexToBeSelected - 2;
            }else{
                this.dgvAnnuaire.FirstDisplayedScrollingRowIndex = indexToBeSelected;
            }
            this.dgvAnnuaire.Rows[indexToBeSelected].Selected = true;
            this.dgvAnnuaire.CurrentCell = this.dgvAnnuaire[1, indexToBeSelected];
        }
        #endregion

        #region gestion events
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            FillDatagridview(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormulaireFiche formulaireFiche = new FormulaireFiche();
            formulaireFiche.modeFiche = FormulaireFiche.ModeFiche.CREER;
            formulaireFiche.returnCreatedValue += new FormulaireFiche.ChildEvent3(this.returnCreatedValue);
            formulaireFiche.ShowDialog();
            FillDatagridview(idToSelect, txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            idToSelect = "";
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
                write.fnSuppressionFiche(Convert.ToInt32(this.dgvAnnuaire.CurrentRow.Cells["colId"].Value.ToString()));
                FillDatagridview(idToSelectInt, txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            }
        }

        private void créerAnnuaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulaireNouvelAnnuaire formNouvelAnnuaire = new FormulaireNouvelAnnuaire(txtRechNom.Text, txtRechPrenom.Text, txtRechAlias.Text, txtRechTelephone.Text, cbxRechActivite.Text, cbxRechRelation.Text, txtRechDetails.Text);
            formNouvelAnnuaire.activateRefresh += new FormulaireNouvelAnnuaire.ChildEvent(activateRefresh);
            formNouvelAnnuaire.ShowDialog();
        }

        private void ouvrirAnnuaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulaireChoixAnnuaire formChoixAnnuaire = new FormulaireChoixAnnuaire();
            formChoixAnnuaire.activateRefresh += new FormulaireChoixAnnuaire.ChildEvent2(activateRefresh);
            formChoixAnnuaire.ShowDialog();
        }

        private void gestionDesActivitésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulaireParametres formAct = new FormulaireParametres(FormulaireParametres.typeParametre.ACTIVITE);
            formAct.activateRefresh += new FormulaireParametres.ChildEvent(this.activateRefresh);
            formAct.ShowDialog();

        }

        private void gestionDesRelationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulaireParametres formAct = new FormulaireParametres(FormulaireParametres.typeParametre.RELATION);
            formAct.activateRefresh += new FormulaireParametres.ChildEvent(this.activateRefresh);
            formAct.ShowDialog();
        }

        #endregion
    }
}
