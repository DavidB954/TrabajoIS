namespace GestionTurnosMedicos
{
    partial class frmRolesPermisos
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
            this.groupBoxRolesPermisos = new System.Windows.Forms.GroupBox();
            this.groupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.groupBoxOpciones = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnGuardarRP = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.groupBoxRolesPermisos.SuspendLayout();
            this.groupBoxDetalles.SuspendLayout();
            this.groupBoxOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRolesPermisos
            // 
            this.groupBoxRolesPermisos.Controls.Add(this.treeViewRoles);
            this.groupBoxRolesPermisos.Controls.Add(this.btnEliminar);
            this.groupBoxRolesPermisos.Controls.Add(this.btnModificar);
            this.groupBoxRolesPermisos.Controls.Add(this.btnAgregar);
            this.groupBoxRolesPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRolesPermisos.Location = new System.Drawing.Point(49, 32);
            this.groupBoxRolesPermisos.Name = "groupBoxRolesPermisos";
            this.groupBoxRolesPermisos.Size = new System.Drawing.Size(496, 628);
            this.groupBoxRolesPermisos.TabIndex = 0;
            this.groupBoxRolesPermisos.TabStop = false;
            this.groupBoxRolesPermisos.Text = "Roles y Permisos";
            // 
            // groupBoxDetalles
            // 
            this.groupBoxDetalles.Controls.Add(this.cboTipo);
            this.groupBoxDetalles.Controls.Add(this.txtNombre);
            this.groupBoxDetalles.Controls.Add(this.label2);
            this.groupBoxDetalles.Controls.Add(this.label1);
            this.groupBoxDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalles.Location = new System.Drawing.Point(654, 49);
            this.groupBoxDetalles.Name = "groupBoxDetalles";
            this.groupBoxDetalles.Size = new System.Drawing.Size(673, 291);
            this.groupBoxDetalles.TabIndex = 1;
            this.groupBoxDetalles.TabStop = false;
            this.groupBoxDetalles.Text = "Detalles";
            // 
            // groupBoxOpciones
            // 
            this.groupBoxOpciones.Controls.Add(this.btnCancelar);
            this.groupBoxOpciones.Controls.Add(this.btnGuardarRP);
            this.groupBoxOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOpciones.Location = new System.Drawing.Point(654, 378);
            this.groupBoxOpciones.Name = "groupBoxOpciones";
            this.groupBoxOpciones.Size = new System.Drawing.Size(673, 282);
            this.groupBoxOpciones.TabIndex = 2;
            this.groupBoxOpciones.TabStop = false;
            this.groupBoxOpciones.Text = "Opciones";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(25, 571);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 51);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(182, 571);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(131, 51);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(340, 571);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 51);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(193, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(294, 35);
            this.txtNombre.TabIndex = 2;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(193, 169);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(294, 37);
            this.cboTipo.TabIndex = 3;
            // 
            // btnGuardarRP
            // 
            this.btnGuardarRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRP.Location = new System.Drawing.Point(140, 99);
            this.btnGuardarRP.Name = "btnGuardarRP";
            this.btnGuardarRP.Size = new System.Drawing.Size(120, 51);
            this.btnGuardarRP.TabIndex = 4;
            this.btnGuardarRP.Text = "Guardar";
            this.btnGuardarRP.UseVisualStyleBackColor = true;
            this.btnGuardarRP.Click += new System.EventHandler(this.btnGuardarRP_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(367, 99);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 51);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(25, 35);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(435, 507);
            this.treeViewRoles.TabIndex = 4;
            this.treeViewRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterSelect);
            // 
            // frmRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 750);
            this.Controls.Add(this.groupBoxOpciones);
            this.Controls.Add(this.groupBoxDetalles);
            this.Controls.Add(this.groupBoxRolesPermisos);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRolesPermisos";
            this.Text = "frmRolesPermisos";
            this.Load += new System.EventHandler(this.frmRolesPermisos_Load);
            this.groupBoxRolesPermisos.ResumeLayout(false);
            this.groupBoxDetalles.ResumeLayout(false);
            this.groupBoxDetalles.PerformLayout();
            this.groupBoxOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRolesPermisos;
        private System.Windows.Forms.GroupBox groupBoxDetalles;
        private System.Windows.Forms.GroupBox groupBoxOpciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardarRP;
        private System.Windows.Forms.TreeView treeViewRoles;
    }
}