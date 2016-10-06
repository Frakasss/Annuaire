namespace Annuaire
{
    partial class FormulaireNouvelAnnuaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtNomAnnuaire = new System.Windows.Forms.TextBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.chkImporterActivite = new System.Windows.Forms.CheckBox();
            this.chkImporterRelation = new System.Windows.Forms.CheckBox();
            this.chkImporterAnnuaire = new System.Windows.Forms.CheckBox();
            this.lblAlerte = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(374, 231);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(75, 23);
            this.btnCreer.TabIndex = 0;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(293, 231);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 1;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtNomAnnuaire
            // 
            this.txtNomAnnuaire.Location = new System.Drawing.Point(139, 33);
            this.txtNomAnnuaire.Name = "txtNomAnnuaire";
            this.txtNomAnnuaire.Size = new System.Drawing.Size(274, 20);
            this.txtNomAnnuaire.TabIndex = 2;
            this.txtNomAnnuaire.TextChanged += new System.EventHandler(this.txtNomAnnuaire_TextChanged);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(53, 36);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(80, 13);
            this.lblTitre.TabIndex = 3;
            this.lblTitre.Text = "Nom Annuaire :";
            // 
            // chkImporterActivite
            // 
            this.chkImporterActivite.AutoSize = true;
            this.chkImporterActivite.Location = new System.Drawing.Point(184, 59);
            this.chkImporterActivite.Name = "chkImporterActivite";
            this.chkImporterActivite.Size = new System.Drawing.Size(107, 17);
            this.chkImporterActivite.TabIndex = 4;
            this.chkImporterActivite.Text = "Importer Activités";
            this.chkImporterActivite.UseVisualStyleBackColor = true;
            // 
            // chkImporterRelation
            // 
            this.chkImporterRelation.AutoSize = true;
            this.chkImporterRelation.Location = new System.Drawing.Point(184, 83);
            this.chkImporterRelation.Name = "chkImporterRelation";
            this.chkImporterRelation.Size = new System.Drawing.Size(111, 17);
            this.chkImporterRelation.TabIndex = 5;
            this.chkImporterRelation.Text = "Importer Relations";
            this.chkImporterRelation.UseVisualStyleBackColor = true;
            // 
            // chkImporterAnnuaire
            // 
            this.chkImporterAnnuaire.AutoSize = true;
            this.chkImporterAnnuaire.Location = new System.Drawing.Point(184, 107);
            this.chkImporterAnnuaire.Name = "chkImporterAnnuaire";
            this.chkImporterAnnuaire.Size = new System.Drawing.Size(109, 17);
            this.chkImporterAnnuaire.TabIndex = 6;
            this.chkImporterAnnuaire.Text = "Importer Annuaire";
            this.chkImporterAnnuaire.UseVisualStyleBackColor = true;
            // 
            // lblAlerte
            // 
            this.lblAlerte.AutoSize = true;
            this.lblAlerte.ForeColor = System.Drawing.Color.Red;
            this.lblAlerte.Location = new System.Drawing.Point(158, 157);
            this.lblAlerte.Name = "lblAlerte";
            this.lblAlerte.Size = new System.Drawing.Size(151, 13);
            this.lblAlerte.TabIndex = 7;
            this.lblAlerte.Text = "Ce nom d\'annuaire existe déjà!";
            // 
            // FormulaireNouvelAnnuaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 266);
            this.Controls.Add(this.lblAlerte);
            this.Controls.Add(this.chkImporterAnnuaire);
            this.Controls.Add(this.chkImporterRelation);
            this.Controls.Add(this.chkImporterActivite);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.txtNomAnnuaire);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnCreer);
            this.Name = "FormulaireNouvelAnnuaire";
            this.Text = "Nouvel Annuaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtNomAnnuaire;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.CheckBox chkImporterActivite;
        private System.Windows.Forms.CheckBox chkImporterRelation;
        private System.Windows.Forms.CheckBox chkImporterAnnuaire;
        private System.Windows.Forms.Label lblAlerte;
    }
}