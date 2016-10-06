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
    public partial class FormulaireParametres : Form
    {
        #region Global
            public enum typeParametre{
            ACTIVITE = 1,
            RELATION = 2
        }
            ReadAccess read = new ReadAccess();
            WriteAccess write = new WriteAccess();
            public delegate void ChildEvent();
            public event ChildEvent activateRefresh;

            private typeParametre typeP;
        #endregion

        #region constructeurs
            public FormulaireParametres()
            {
                InitializeComponent();
            }

            public FormulaireParametres(typeParametre typeParam)
            {
                InitializeComponent();
                typeP = typeParam;
                InitializeFormTitle();
                InitializeComboBox();
            }
        #endregion

        #region fonctions
            private void InitializeFormTitle()
            {
                if (typeP == typeParametre.ACTIVITE) { this.Text = "Gestion Activités"; }
                else if (typeP == typeParametre.RELATION) { this.Text = "Gestion Relations"; }
            }

            private void InitializeComboBox()
            {   
                if (typeP == typeParametre.ACTIVITE)
                {
                    foreach (string item in read.fnSelectActivites()) {
                        cbxModifier.Items.Add(item);
                        if (read.fnCountActivite(item) == 0) { cbxSupprimer.Items.Add(item); }
                    }
                }
                else if (typeP == typeParametre.RELATION)
                {
                    foreach (string item in read.fnSelectRelations())
                    {
                        cbxModifier.Items.Add(item);
                        if (read.fnCountRelation(item) == 0) { cbxSupprimer.Items.Add(item); }
                    }
                }
            }
        #endregion

        #region gestion events
            private void btnCreer_Click(object sender, EventArgs e)
            {
                bool alreadyExists = false;
                if (txtCreer.Text == "") { MessageBox.Show("Vous ne pouvez pas créer de paramètre sans nom!", "Attention!"); }
                else{
                    if (typeP == typeParametre.ACTIVITE)
                    {
                        foreach (string item in read.fnSelectActivites()) { if (item == txtCreer.Text) { alreadyExists = true; } }
                        if (alreadyExists) { MessageBox.Show("Cette Activité existe déjà!", "Attention!"); }
                        else { 
                            write.fnCreationActivite(txtCreer.Text);
                            this.activateRefresh(); 
                            this.Close();
                        }
                    }
                    else if (typeP == typeParametre.RELATION)
                    {
                        foreach (string item in read.fnSelectRelations()) { if (item == txtCreer.Text) { alreadyExists = true; } }
                        if (alreadyExists) { MessageBox.Show("Cette Relation existe déjà!", "Attention!"); }
                        else { 
                            write.fnCreationRelation(txtCreer.Text);
                            this.activateRefresh(); 
                            this.Close();
                        }
                    }
                }
            }

            private void btnSupprimer_Click(object sender, EventArgs e)
            {
                if (typeP == typeParametre.ACTIVITE)
                {
                    write.fnSuppressionActivite(cbxSupprimer.Text);
                    this.Close();
                }
                else if (typeP == typeParametre.RELATION)
                {
                    write.fnSuppressionRelation(cbxSupprimer.Text);
                    this.Close();
                }
            }
        #endregion

            private void btnModifier_Click(object sender, EventArgs e)
            {
                if (cbxModifier.Text == "") { MessageBox.Show("Veuillez sélectionner un item à modifier.","Attention!"); }
                else if (txtModifier.Text == "" || txtModifier.Text == cbxModifier.Text) { MessageBox.Show("Veuillez indiquer une modification à effectuer.", "Attention!"); }
                else {
                    if (typeP == typeParametre.ACTIVITE)
                    {
                        write.fnCreationActivite(txtModifier.Text);
                        write.fnSuppressionActivite(cbxModifier.Text);
                        write.fnModificationActivite(cbxModifier.Text, txtModifier.Text);
                        this.activateRefresh();
                        this.Close();
                    }
                    else if (typeP == typeParametre.RELATION)
                    {
                        write.fnCreationActivite(txtModifier.Text);
                        write.fnSuppressionRelation(cbxModifier.Text);
                        write.fnModificationRelation(cbxModifier.Text, txtModifier.Text);
                        this.activateRefresh();
                        this.Close();
                    }
                    


                }
            }

            


    }
}
