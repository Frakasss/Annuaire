﻿namespace Annuaire
{
    partial class Annuaire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gboxRecherche = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRechTelephone = new System.Windows.Forms.TextBox();
            this.lblRechercheDetails = new System.Windows.Forms.Label();
            this.lblRechercheRelation = new System.Windows.Forms.Label();
            this.lblRechercheActivite = new System.Windows.Forms.Label();
            this.lblRechercheAlias = new System.Windows.Forms.Label();
            this.lblRecherchePrenom = new System.Windows.Forms.Label();
            this.lblRechercheNom = new System.Windows.Forms.Label();
            this.txtRechDetails = new System.Windows.Forms.TextBox();
            this.cbxRechRelation = new System.Windows.Forms.ComboBox();
            this.cbxRechActivite = new System.Windows.Forms.ComboBox();
            this.txtRechAlias = new System.Windows.Forms.TextBox();
            this.txtRechPrenom = new System.Windows.Forms.TextBox();
            this.txtRechNom = new System.Windows.Forms.TextBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.dgvAnnuaire = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerAnnuaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirAnnuaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesActivitésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesRelationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPrenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvTelephone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvTelephone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnniversaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnniversaire2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvActivite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gboxRecherche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnuaire)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(1054, 76);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 24);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nouveau";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(1054, 104);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 24);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Modifier";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(1054, 133);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gboxRecherche
            // 
            this.gboxRecherche.Controls.Add(this.label1);
            this.gboxRecherche.Controls.Add(this.txtRechTelephone);
            this.gboxRecherche.Controls.Add(this.lblRechercheDetails);
            this.gboxRecherche.Controls.Add(this.lblRechercheRelation);
            this.gboxRecherche.Controls.Add(this.lblRechercheActivite);
            this.gboxRecherche.Controls.Add(this.lblRechercheAlias);
            this.gboxRecherche.Controls.Add(this.lblRecherchePrenom);
            this.gboxRecherche.Controls.Add(this.lblRechercheNom);
            this.gboxRecherche.Controls.Add(this.txtRechDetails);
            this.gboxRecherche.Controls.Add(this.cbxRechRelation);
            this.gboxRecherche.Controls.Add(this.cbxRechActivite);
            this.gboxRecherche.Controls.Add(this.txtRechAlias);
            this.gboxRecherche.Controls.Add(this.txtRechPrenom);
            this.gboxRecherche.Controls.Add(this.txtRechNom);
            this.gboxRecherche.Controls.Add(this.btnRechercher);
            this.gboxRecherche.Location = new System.Drawing.Point(10, 34);
            this.gboxRecherche.Margin = new System.Windows.Forms.Padding(2);
            this.gboxRecherche.Name = "gboxRecherche";
            this.gboxRecherche.Padding = new System.Windows.Forms.Padding(2);
            this.gboxRecherche.Size = new System.Drawing.Size(437, 124);
            this.gboxRecherche.TabIndex = 3;
            this.gboxRecherche.TabStop = false;
            this.gboxRecherche.Text = "Recherche";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "N° Téléphone :";
            // 
            // txtRechTelephone
            // 
            this.txtRechTelephone.Location = new System.Drawing.Point(88, 89);
            this.txtRechTelephone.Margin = new System.Windows.Forms.Padding(2);
            this.txtRechTelephone.Name = "txtRechTelephone";
            this.txtRechTelephone.Size = new System.Drawing.Size(107, 20);
            this.txtRechTelephone.TabIndex = 13;
            // 
            // lblRechercheDetails
            // 
            this.lblRechercheDetails.AutoSize = true;
            this.lblRechercheDetails.Location = new System.Drawing.Point(272, 66);
            this.lblRechercheDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRechercheDetails.Name = "lblRechercheDetails";
            this.lblRechercheDetails.Size = new System.Drawing.Size(45, 13);
            this.lblRechercheDetails.TabIndex = 12;
            this.lblRechercheDetails.Text = "Details :";
            // 
            // lblRechercheRelation
            // 
            this.lblRechercheRelation.AutoSize = true;
            this.lblRechercheRelation.Location = new System.Drawing.Point(272, 41);
            this.lblRechercheRelation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRechercheRelation.Name = "lblRechercheRelation";
            this.lblRechercheRelation.Size = new System.Drawing.Size(52, 13);
            this.lblRechercheRelation.TabIndex = 11;
            this.lblRechercheRelation.Text = "Relation :";
            // 
            // lblRechercheActivite
            // 
            this.lblRechercheActivite.AutoSize = true;
            this.lblRechercheActivite.Location = new System.Drawing.Point(272, 17);
            this.lblRechercheActivite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRechercheActivite.Name = "lblRechercheActivite";
            this.lblRechercheActivite.Size = new System.Drawing.Size(48, 13);
            this.lblRechercheActivite.TabIndex = 10;
            this.lblRechercheActivite.Text = "Activité :";
            // 
            // lblRechercheAlias
            // 
            this.lblRechercheAlias.AutoSize = true;
            this.lblRechercheAlias.Location = new System.Drawing.Point(8, 67);
            this.lblRechercheAlias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRechercheAlias.Name = "lblRechercheAlias";
            this.lblRechercheAlias.Size = new System.Drawing.Size(35, 13);
            this.lblRechercheAlias.TabIndex = 9;
            this.lblRechercheAlias.Text = "Alias :";
            // 
            // lblRecherchePrenom
            // 
            this.lblRecherchePrenom.AutoSize = true;
            this.lblRecherchePrenom.Location = new System.Drawing.Point(8, 44);
            this.lblRecherchePrenom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecherchePrenom.Name = "lblRecherchePrenom";
            this.lblRecherchePrenom.Size = new System.Drawing.Size(49, 13);
            this.lblRecherchePrenom.TabIndex = 8;
            this.lblRecherchePrenom.Text = "Prénom :";
            // 
            // lblRechercheNom
            // 
            this.lblRechercheNom.AutoSize = true;
            this.lblRechercheNom.Location = new System.Drawing.Point(8, 20);
            this.lblRechercheNom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRechercheNom.Name = "lblRechercheNom";
            this.lblRechercheNom.Size = new System.Drawing.Size(35, 13);
            this.lblRechercheNom.TabIndex = 7;
            this.lblRechercheNom.Text = "Nom :";
            // 
            // txtRechDetails
            // 
            this.txtRechDetails.Location = new System.Drawing.Point(337, 63);
            this.txtRechDetails.Margin = new System.Windows.Forms.Padding(2);
            this.txtRechDetails.Name = "txtRechDetails";
            this.txtRechDetails.Size = new System.Drawing.Size(92, 20);
            this.txtRechDetails.TabIndex = 6;
            // 
            // cbxRechRelation
            // 
            this.cbxRechRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRechRelation.FormattingEnabled = true;
            this.cbxRechRelation.Location = new System.Drawing.Point(337, 38);
            this.cbxRechRelation.Margin = new System.Windows.Forms.Padding(2);
            this.cbxRechRelation.Name = "cbxRechRelation";
            this.cbxRechRelation.Size = new System.Drawing.Size(92, 21);
            this.cbxRechRelation.TabIndex = 5;
            // 
            // cbxRechActivite
            // 
            this.cbxRechActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRechActivite.FormattingEnabled = true;
            this.cbxRechActivite.Location = new System.Drawing.Point(337, 15);
            this.cbxRechActivite.Margin = new System.Windows.Forms.Padding(2);
            this.cbxRechActivite.Name = "cbxRechActivite";
            this.cbxRechActivite.Size = new System.Drawing.Size(92, 21);
            this.cbxRechActivite.TabIndex = 4;
            // 
            // txtRechAlias
            // 
            this.txtRechAlias.Location = new System.Drawing.Point(88, 65);
            this.txtRechAlias.Margin = new System.Windows.Forms.Padding(2);
            this.txtRechAlias.Name = "txtRechAlias";
            this.txtRechAlias.Size = new System.Drawing.Size(107, 20);
            this.txtRechAlias.TabIndex = 3;
            // 
            // txtRechPrenom
            // 
            this.txtRechPrenom.Location = new System.Drawing.Point(88, 41);
            this.txtRechPrenom.Margin = new System.Windows.Forms.Padding(2);
            this.txtRechPrenom.Name = "txtRechPrenom";
            this.txtRechPrenom.Size = new System.Drawing.Size(107, 20);
            this.txtRechPrenom.TabIndex = 2;
            // 
            // txtRechNom
            // 
            this.txtRechNom.Location = new System.Drawing.Point(88, 18);
            this.txtRechNom.Margin = new System.Windows.Forms.Padding(2);
            this.txtRechNom.Name = "txtRechNom";
            this.txtRechNom.Size = new System.Drawing.Size(107, 20);
            this.txtRechNom.TabIndex = 1;
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(358, 91);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(2);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(70, 24);
            this.btnRechercher.TabIndex = 0;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // dgvAnnuaire
            // 
            this.dgvAnnuaire.AllowUserToAddRows = false;
            this.dgvAnnuaire.AllowUserToDeleteRows = false;
            this.dgvAnnuaire.AllowUserToOrderColumns = true;
            this.dgvAnnuaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnnuaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnnuaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnnuaire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.DgvNom,
            this.DgvPrenom,
            this.DgvAlias,
            this.DgvTelephone1,
            this.DgvTelephone2,
            this.colAnniversaire,
            this.colAnniversaire2,
            this.DgvAdresse,
            this.DgvActivite,
            this.DgvRelation});
            this.dgvAnnuaire.Location = new System.Drawing.Point(10, 165);
            this.dgvAnnuaire.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAnnuaire.MinimumSize = new System.Drawing.Size(0, 28);
            this.dgvAnnuaire.MultiSelect = false;
            this.dgvAnnuaire.Name = "dgvAnnuaire";
            this.dgvAnnuaire.ReadOnly = true;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnnuaire.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnnuaire.RowTemplate.Height = 35;
            this.dgvAnnuaire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnnuaire.Size = new System.Drawing.Size(1114, 258);
            this.dgvAnnuaire.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.paramètresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerAnnuaireToolStripMenuItem,
            this.ouvrirAnnuaireToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // créerAnnuaireToolStripMenuItem
            // 
            this.créerAnnuaireToolStripMenuItem.Name = "créerAnnuaireToolStripMenuItem";
            this.créerAnnuaireToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.créerAnnuaireToolStripMenuItem.Text = "Créer Annuaire";
            this.créerAnnuaireToolStripMenuItem.Click += new System.EventHandler(this.créerAnnuaireToolStripMenuItem_Click);
            // 
            // ouvrirAnnuaireToolStripMenuItem
            // 
            this.ouvrirAnnuaireToolStripMenuItem.Name = "ouvrirAnnuaireToolStripMenuItem";
            this.ouvrirAnnuaireToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ouvrirAnnuaireToolStripMenuItem.Text = "Ouvrir Annuaire";
            this.ouvrirAnnuaireToolStripMenuItem.Click += new System.EventHandler(this.ouvrirAnnuaireToolStripMenuItem_Click);
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesActivitésToolStripMenuItem,
            this.gestionDesRelationsToolStripMenuItem});
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // gestionDesActivitésToolStripMenuItem
            // 
            this.gestionDesActivitésToolStripMenuItem.Name = "gestionDesActivitésToolStripMenuItem";
            this.gestionDesActivitésToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gestionDesActivitésToolStripMenuItem.Text = "Gestion des Activités";
            this.gestionDesActivitésToolStripMenuItem.Click += new System.EventHandler(this.gestionDesActivitésToolStripMenuItem_Click);
            // 
            // gestionDesRelationsToolStripMenuItem
            // 
            this.gestionDesRelationsToolStripMenuItem.Name = "gestionDesRelationsToolStripMenuItem";
            this.gestionDesRelationsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gestionDesRelationsToolStripMenuItem.Text = "Gestion des Relations";
            this.gestionDesRelationsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesRelationsToolStripMenuItem_Click);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // DgvNom
            // 
            this.DgvNom.FillWeight = 75F;
            this.DgvNom.HeaderText = "Nom";
            this.DgvNom.Name = "DgvNom";
            this.DgvNom.ReadOnly = true;
            // 
            // DgvPrenom
            // 
            this.DgvPrenom.FillWeight = 75F;
            this.DgvPrenom.HeaderText = "Prénom";
            this.DgvPrenom.Name = "DgvPrenom";
            this.DgvPrenom.ReadOnly = true;
            // 
            // DgvAlias
            // 
            this.DgvAlias.FillWeight = 40F;
            this.DgvAlias.HeaderText = "Alias";
            this.DgvAlias.Name = "DgvAlias";
            this.DgvAlias.ReadOnly = true;
            // 
            // DgvTelephone1
            // 
            this.DgvTelephone1.FillWeight = 55F;
            this.DgvTelephone1.HeaderText = "Téléphone";
            this.DgvTelephone1.Name = "DgvTelephone1";
            this.DgvTelephone1.ReadOnly = true;
            // 
            // DgvTelephone2
            // 
            this.DgvTelephone2.FillWeight = 55F;
            this.DgvTelephone2.HeaderText = "Téléphone";
            this.DgvTelephone2.Name = "DgvTelephone2";
            this.DgvTelephone2.ReadOnly = true;
            // 
            // colAnniversaire
            // 
            this.colAnniversaire.FillWeight = 55F;
            this.colAnniversaire.HeaderText = "Anniversaire";
            this.colAnniversaire.MaxInputLength = 10;
            this.colAnniversaire.Name = "colAnniversaire";
            this.colAnniversaire.ReadOnly = true;
            // 
            // colAnniversaire2
            // 
            this.colAnniversaire2.FillWeight = 75F;
            this.colAnniversaire2.HeaderText = "Anniversaire";
            this.colAnniversaire2.Name = "colAnniversaire2";
            this.colAnniversaire2.ReadOnly = true;
            // 
            // DgvAdresse
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAdresse.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAdresse.FillWeight = 110F;
            this.DgvAdresse.HeaderText = "Adresse";
            this.DgvAdresse.MinimumWidth = 100;
            this.DgvAdresse.Name = "DgvAdresse";
            this.DgvAdresse.ReadOnly = true;
            // 
            // DgvActivite
            // 
            this.DgvActivite.FillWeight = 45F;
            this.DgvActivite.HeaderText = "Activité";
            this.DgvActivite.Name = "DgvActivite";
            this.DgvActivite.ReadOnly = true;
            // 
            // DgvRelation
            // 
            this.DgvRelation.FillWeight = 45F;
            this.DgvRelation.HeaderText = "Relation";
            this.DgvRelation.Name = "DgvRelation";
            this.DgvRelation.ReadOnly = true;
            // 
            // Annuaire
            // 
            this.AcceptButton = this.btnRechercher;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 433);
            this.Controls.Add(this.dgvAnnuaire);
            this.Controls.Add(this.gboxRecherche);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Annuaire";
            this.Text = "Annuaire";
            this.gboxRecherche.ResumeLayout(false);
            this.gboxRecherche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnuaire)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gboxRecherche;
        private System.Windows.Forms.DataGridView dgvAnnuaire;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRechAlias;
        private System.Windows.Forms.TextBox txtRechPrenom;
        private System.Windows.Forms.TextBox txtRechNom;
        private System.Windows.Forms.Label lblRechercheAlias;
        private System.Windows.Forms.Label lblRecherchePrenom;
        private System.Windows.Forms.Label lblRechercheNom;
        private System.Windows.Forms.TextBox txtRechDetails;
        private System.Windows.Forms.ComboBox cbxRechRelation;
        private System.Windows.Forms.ComboBox cbxRechActivite;
        private System.Windows.Forms.Label lblRechercheDetails;
        private System.Windows.Forms.Label lblRechercheRelation;
        private System.Windows.Forms.Label lblRechercheActivite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRechTelephone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créerAnnuaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirAnnuaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesActivitésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesRelationsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvTelephone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvTelephone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnniversaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnniversaire2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvActivite;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvRelation;
    }
}

