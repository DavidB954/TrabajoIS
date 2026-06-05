namespace Presentacion
{
    partial class frmPermisos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.comboTipoPermiso = new System.Windows.Forms.ComboBox();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.btnBorrarPermiso = new System.Windows.Forms.Button();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // txtNombrePermiso
            // 
            this.txtNombrePermiso.Location = new System.Drawing.Point(161, 197);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(217, 26);
            this.txtNombrePermiso.TabIndex = 2;
            this.txtNombrePermiso.Tag = "PERMISO_Nombre";
            // 
            // comboTipoPermiso
            // 
            this.comboTipoPermiso.FormattingEnabled = true;
            this.comboTipoPermiso.Location = new System.Drawing.Point(161, 267);
            this.comboTipoPermiso.Name = "comboTipoPermiso";
            this.comboTipoPermiso.Size = new System.Drawing.Size(217, 28);
            this.comboTipoPermiso.TabIndex = 3;
            this.comboTipoPermiso.Tag = "PERMISO_Tipo";
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.Location = new System.Drawing.Point(50, 331);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(118, 47);
            this.btnCrearPermiso.TabIndex = 4;
            this.btnCrearPermiso.Tag = "PERMISO_Crear";
            this.btnCrearPermiso.Text = "Crear Permiso";
            this.btnCrearPermiso.UseVisualStyleBackColor = true;
            // 
            // btnBorrarPermiso
            // 
            this.btnBorrarPermiso.Location = new System.Drawing.Point(221, 331);
            this.btnBorrarPermiso.Name = "btnBorrarPermiso";
            this.btnBorrarPermiso.Size = new System.Drawing.Size(131, 47);
            this.btnBorrarPermiso.TabIndex = 5;
            this.btnBorrarPermiso.Tag = "PERMISO_Borrar";
            this.btnBorrarPermiso.Text = "Borrar";
            this.btnBorrarPermiso.UseVisualStyleBackColor = true;
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(458, 21);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.RowHeadersWidth = 62;
            this.dgvPermisos.RowTemplate.Height = 28;
            this.dgvPermisos.Size = new System.Drawing.Size(442, 553);
            this.dgvPermisos.TabIndex = 6;
            this.dgvPermisos.Tag = "PERMISO_Visualizar";
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 586);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.btnBorrarPermiso);
            this.Controls.Add(this.btnCrearPermiso);
            this.Controls.Add(this.comboTipoPermiso);
            this.Controls.Add(this.txtNombrePermiso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPermisos";
            this.Text = "frmPermisos";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private System.Windows.Forms.ComboBox comboTipoPermiso;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.Button btnBorrarPermiso;
        private System.Windows.Forms.DataGridView dgvPermisos;
    }
}