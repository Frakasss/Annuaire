namespace Annuaire
{
    partial class FormulaireParametres
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
            this.gbxCreer = new System.Windows.Forms.GroupBox();
            this.txtCreer = new System.Windows.Forms.TextBox();
            this.btnCreer = new System.Windows.Forms.Button();
            this.gbxModifier = new System.Windows.Forms.GroupBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.cbxModifier = new System.Windows.Forms.ComboBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.gbxSupprimer = new System.Windows.Forms.GroupBox();
            this.cbxSupprimer = new System.Windows.Forms.ComboBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.gbxCreer.SuspendLayout();
            this.gbxModifier.SuspendLayout();
            this.gbxSupprimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCreer
            // 
            this.gbxCreer.Controls.Add(this.txtCreer);
            this.gbxCreer.Controls.Add(this.btnCreer);
            this.gbxCreer.Location = new System.Drawing.Point(13, 13);
            this.gbxCreer.Name = "gbxCreer";
            this.gbxCreer.Size = new System.Drawing.Size(354, 110);
            this.gbxCreer.TabIndex = 0;
            this.gbxCreer.TabStop = false;
            this.gbxCreer.Text = "Création";
            // 
            // txtCreer
            // 
            this.txtCreer.Location = new System.Drawing.Point(19, 45);
            this.txtCreer.Name = "txtCreer";
            this.txtCreer.Size = new System.Drawing.Size(222, 20);
            this.txtCreer.TabIndex = 1;
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(273, 43);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(75, 23);
            this.btnCreer.TabIndex = 0;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // gbxModifier
            // 
            this.gbxModifier.Controls.Add(this.txtModifier);
            this.gbxModifier.Controls.Add(this.cbxModifier);
            this.gbxModifier.Controls.Add(this.btnModifier);
            this.gbxModifier.Location = new System.Drawing.Point(13, 130);
            this.gbxModifier.Name = "gbxModifier";
            this.gbxModifier.Size = new System.Drawing.Size(354, 124);
            this.gbxModifier.TabIndex = 1;
            this.gbxModifier.TabStop = false;
            this.gbxModifier.Text = "Modification";
            // 
            // txtModifier
            // 
            this.txtModifier.Location = new System.Drawing.Point(19, 77);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(222, 20);
            this.txtModifier.TabIndex = 2;
            // 
            // cbxModifier
            // 
            this.cbxModifier.FormattingEnabled = true;
            this.cbxModifier.Location = new System.Drawing.Point(19, 35);
            this.cbxModifier.Name = "cbxModifier";
            this.cbxModifier.Size = new System.Drawing.Size(222, 21);
            this.cbxModifier.TabIndex = 1;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(273, 54);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 0;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // gbxSupprimer
            // 
            this.gbxSupprimer.Controls.Add(this.cbxSupprimer);
            this.gbxSupprimer.Controls.Add(this.btnSupprimer);
            this.gbxSupprimer.Location = new System.Drawing.Point(13, 261);
            this.gbxSupprimer.Name = "gbxSupprimer";
            this.gbxSupprimer.Size = new System.Drawing.Size(354, 123);
            this.gbxSupprimer.TabIndex = 2;
            this.gbxSupprimer.TabStop = false;
            this.gbxSupprimer.Text = "Suppression";
            // 
            // cbxSupprimer
            // 
            this.cbxSupprimer.FormattingEnabled = true;
            this.cbxSupprimer.Location = new System.Drawing.Point(19, 56);
            this.cbxSupprimer.Name = "cbxSupprimer";
            this.cbxSupprimer.Size = new System.Drawing.Size(222, 21);
            this.cbxSupprimer.TabIndex = 1;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(273, 54);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(75, 23);
            this.btnSupprimer.TabIndex = 0;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // FormulaireParametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 393);
            this.Controls.Add(this.gbxSupprimer);
            this.Controls.Add(this.gbxModifier);
            this.Controls.Add(this.gbxCreer);
            this.Name = "FormulaireParametres";
            this.Text = "Gestion Activités";
            this.gbxCreer.ResumeLayout(false);
            this.gbxCreer.PerformLayout();
            this.gbxModifier.ResumeLayout(false);
            this.gbxModifier.PerformLayout();
            this.gbxSupprimer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCreer;
        private System.Windows.Forms.TextBox txtCreer;
        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.GroupBox gbxModifier;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.ComboBox cbxModifier;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.GroupBox gbxSupprimer;
        private System.Windows.Forms.ComboBox cbxSupprimer;
        private System.Windows.Forms.Button btnSupprimer;
    }
}