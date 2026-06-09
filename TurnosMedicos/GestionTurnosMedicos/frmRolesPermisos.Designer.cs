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
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOpciones = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardarRP = new System.Windows.Forms.Button();
            this.btnAgregarPR = new System.Windows.Forms.Button();
            this.btnModificarPR = new System.Windows.Forms.Button();
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
            this.groupBoxRolesPermisos.Location = new System.Drawing.Point(33, 21);
            this.groupBoxRolesPermisos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRolesPermisos.Name = "groupBoxRolesPermisos";
            this.groupBoxRolesPermisos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRolesPermisos.Size = new System.Drawing.Size(331, 408);
            this.groupBoxRolesPermisos.TabIndex = 0;
            this.groupBoxRolesPermisos.TabStop = false;
            this.groupBoxRolesPermisos.Text = "Roles y Permisos";
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(17, 23);
            this.treeViewRoles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(291, 331);
            this.treeViewRoles.TabIndex = 4;
            this.treeViewRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterSelect);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(227, 371);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 33);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(121, 371);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 33);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(17, 371);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 33);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBoxDetalles
            // 
            this.groupBoxDetalles.Controls.Add(this.btnModificarPR);
            this.groupBoxDetalles.Controls.Add(this.btnAgregarPR);
            this.groupBoxDetalles.Controls.Add(this.cboTipo);
            this.groupBoxDetalles.Controls.Add(this.txtNombre);
            this.groupBoxDetalles.Controls.Add(this.label2);
            this.groupBoxDetalles.Controls.Add(this.label1);
            this.groupBoxDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalles.Location = new System.Drawing.Point(436, 32);
            this.groupBoxDetalles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDetalles.Name = "groupBoxDetalles";
            this.groupBoxDetalles.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDetalles.Size = new System.Drawing.Size(449, 256);
            this.groupBoxDetalles.TabIndex = 1;
            this.groupBoxDetalles.TabStop = false;
            this.groupBoxDetalles.Text = "Detalles";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(129, 110);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(197, 28);
            this.cboTipo.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(129, 51);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(197, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // groupBoxOpciones
            // 
            this.groupBoxOpciones.Controls.Add(this.btnCancelar);
            this.groupBoxOpciones.Controls.Add(this.btnGuardarRP);
            this.groupBoxOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOpciones.Location = new System.Drawing.Point(436, 292);
            this.groupBoxOpciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOpciones.Name = "groupBoxOpciones";
            this.groupBoxOpciones.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOpciones.Size = new System.Drawing.Size(449, 137);
            this.groupBoxOpciones.TabIndex = 2;
            this.groupBoxOpciones.TabStop = false;
            this.groupBoxOpciones.Text = "Opciones";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(245, 64);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 33);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardarRP
            // 
            this.btnGuardarRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRP.Location = new System.Drawing.Point(93, 64);
            this.btnGuardarRP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardarRP.Name = "btnGuardarRP";
            this.btnGuardarRP.Size = new System.Drawing.Size(80, 33);
            this.btnGuardarRP.TabIndex = 4;
            this.btnGuardarRP.Text = "Guardar";
            this.btnGuardarRP.UseVisualStyleBackColor = true;
            this.btnGuardarRP.Click += new System.EventHandler(this.btnGuardarRP_Click);
            // 
            // btnAgregarPR
            // 
            this.btnAgregarPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPR.Location = new System.Drawing.Point(129, 190);
            this.btnAgregarPR.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPR.Name = "btnAgregarPR";
            this.btnAgregarPR.Size = new System.Drawing.Size(80, 33);
            this.btnAgregarPR.TabIndex = 5;
            this.btnAgregarPR.Text = "Agregar";
            this.btnAgregarPR.UseVisualStyleBackColor = true;
            this.btnAgregarPR.Click += new System.EventHandler(this.btnAgregarPR_Click);
            // 
            // btnModificarPR
            // 
            this.btnModificarPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPR.Location = new System.Drawing.Point(246, 190);
            this.btnModificarPR.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarPR.Name = "btnModificarPR";
            this.btnModificarPR.Size = new System.Drawing.Size(80, 33);
            this.btnModificarPR.TabIndex = 6;
            this.btnModificarPR.Text = "Modificar";
            this.btnModificarPR.UseVisualStyleBackColor = true;
            // 
            // frmRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 487);
            this.Controls.Add(this.groupBoxOpciones);
            this.Controls.Add(this.groupBoxDetalles);
            this.Controls.Add(this.groupBoxRolesPermisos);
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
        private System.Windows.Forms.Button btnModificarPR;
        private System.Windows.Forms.Button btnAgregarPR;
    }
}