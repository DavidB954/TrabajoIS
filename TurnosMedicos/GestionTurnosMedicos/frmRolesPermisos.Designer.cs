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
            this.button1 = new System.Windows.Forms.Button();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.btnAgregarPR = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOpciones = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardarRP = new System.Windows.Forms.Button();
            this.treeViewRolesC = new System.Windows.Forms.TreeView();
            this.groupBoxRE = new System.Windows.Forms.GroupBox();
            this.btnEliminarPermisos = new System.Windows.Forms.Button();
            this.btnAgregarPermisos = new System.Windows.Forms.Button();
            this.btnModificarPermisos = new System.Windows.Forms.Button();
            this.cboPermisos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.btnAgregarRolExistente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRolesExistentes = new System.Windows.Forms.ComboBox();
            this.groupBoxRolesPermisos.SuspendLayout();
            this.groupBoxDetalles.SuspendLayout();
            this.groupBoxOpciones.SuspendLayout();
            this.groupBoxRE.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRolesPermisos
            // 
            this.groupBoxRolesPermisos.Controls.Add(this.button1);
            this.groupBoxRolesPermisos.Controls.Add(this.treeViewRoles);
            this.groupBoxRolesPermisos.Controls.Add(this.btnEliminar);
            this.groupBoxRolesPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRolesPermisos.Location = new System.Drawing.Point(50, 32);
            this.groupBoxRolesPermisos.Name = "groupBoxRolesPermisos";
            this.groupBoxRolesPermisos.Size = new System.Drawing.Size(490, 1048);
            this.groupBoxRolesPermisos.TabIndex = 0;
            this.groupBoxRolesPermisos.TabStop = false;
            this.groupBoxRolesPermisos.Text = "Roles y Permisos";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(26, 865);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "Limpiar Arbol";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(26, 35);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(434, 790);
            this.treeViewRoles.TabIndex = 4;
            this.treeViewRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterSelect);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(342, 865);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 51);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(273, 192);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 51);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // groupBoxDetalles
            // 
            this.groupBoxDetalles.Controls.Add(this.btnAgregarPR);
            this.groupBoxDetalles.Controls.Add(this.cboTipo);
            this.groupBoxDetalles.Controls.Add(this.txtNombre);
            this.groupBoxDetalles.Controls.Add(this.label2);
            this.groupBoxDetalles.Controls.Add(this.label1);
            this.groupBoxDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalles.Location = new System.Drawing.Point(570, 32);
            this.groupBoxDetalles.Name = "groupBoxDetalles";
            this.groupBoxDetalles.Size = new System.Drawing.Size(692, 226);
            this.groupBoxDetalles.TabIndex = 1;
            this.groupBoxDetalles.TabStop = false;
            this.groupBoxDetalles.Text = "Crear Nuevos Roles O Permisos";
            // 
            // btnAgregarPR
            // 
            this.btnAgregarPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPR.Location = new System.Drawing.Point(540, 155);
            this.btnAgregarPR.Name = "btnAgregarPR";
            this.btnAgregarPR.Size = new System.Drawing.Size(120, 51);
            this.btnAgregarPR.TabIndex = 5;
            this.btnAgregarPR.Text = "Agregar";
            this.btnAgregarPR.UseVisualStyleBackColor = true;
            this.btnAgregarPR.Click += new System.EventHandler(this.btnAgregarPR_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(194, 169);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(294, 37);
            this.cboTipo.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(194, 78);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(294, 35);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // groupBoxOpciones
            // 
            this.groupBoxOpciones.Controls.Add(this.txtDescripcion);
            this.groupBoxOpciones.Controls.Add(this.label3);
            this.groupBoxOpciones.Controls.Add(this.btnGuardarRP);
            this.groupBoxOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOpciones.Location = new System.Drawing.Point(570, 725);
            this.groupBoxOpciones.Name = "groupBoxOpciones";
            this.groupBoxOpciones.Size = new System.Drawing.Size(692, 223);
            this.groupBoxOpciones.TabIndex = 2;
            this.groupBoxOpciones.TabStop = false;
            this.groupBoxOpciones.Text = "Guardar Rol";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(41, 96);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(277, 96);
            this.txtDescripcion.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripcion del Rol";
            // 
            // btnGuardarRP
            // 
            this.btnGuardarRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRP.Location = new System.Drawing.Point(420, 96);
            this.btnGuardarRP.Name = "btnGuardarRP";
            this.btnGuardarRP.Size = new System.Drawing.Size(240, 72);
            this.btnGuardarRP.TabIndex = 4;
            this.btnGuardarRP.Text = "Crear Nuevo Rol";
            this.btnGuardarRP.UseVisualStyleBackColor = true;
            this.btnGuardarRP.Click += new System.EventHandler(this.btnGuardarRP_Click);
            // 
            // treeViewRolesC
            // 
            this.treeViewRolesC.Location = new System.Drawing.Point(1323, 52);
            this.treeViewRolesC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewRolesC.Name = "treeViewRolesC";
            this.treeViewRolesC.Size = new System.Drawing.Size(439, 753);
            this.treeViewRolesC.TabIndex = 3;
            // 
            // groupBoxRE
            // 
            this.groupBoxRE.Controls.Add(this.btnEliminarPermisos);
            this.groupBoxRE.Controls.Add(this.btnAgregarPermisos);
            this.groupBoxRE.Controls.Add(this.btnModificarPermisos);
            this.groupBoxRE.Controls.Add(this.cboPermisos);
            this.groupBoxRE.Controls.Add(this.label5);
            this.groupBoxRE.Controls.Add(this.btnEliminarRol);
            this.groupBoxRE.Controls.Add(this.btnAgregarRolExistente);
            this.groupBoxRE.Controls.Add(this.label4);
            this.groupBoxRE.Controls.Add(this.btnModificar);
            this.groupBoxRE.Controls.Add(this.cboRolesExistentes);
            this.groupBoxRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRE.Location = new System.Drawing.Point(570, 266);
            this.groupBoxRE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRE.Name = "groupBoxRE";
            this.groupBoxRE.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRE.Size = new System.Drawing.Size(692, 451);
            this.groupBoxRE.TabIndex = 4;
            this.groupBoxRE.TabStop = false;
            this.groupBoxRE.Text = "Agregar Roles y Permisos Existentes";
            this.groupBoxRE.Enter += new System.EventHandler(this.groupBoxRE_Enter);
            // 
            // btnEliminarPermisos
            // 
            this.btnEliminarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPermisos.Location = new System.Drawing.Point(453, 354);
            this.btnEliminarPermisos.Name = "btnEliminarPermisos";
            this.btnEliminarPermisos.Size = new System.Drawing.Size(130, 51);
            this.btnEliminarPermisos.TabIndex = 12;
            this.btnEliminarPermisos.Text = "Eliminar";
            this.btnEliminarPermisos.UseVisualStyleBackColor = true;
            this.btnEliminarPermisos.Click += new System.EventHandler(this.btnEliminarPermisos_Click);
            // 
            // btnAgregarPermisos
            // 
            this.btnAgregarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPermisos.Location = new System.Drawing.Point(86, 354);
            this.btnAgregarPermisos.Name = "btnAgregarPermisos";
            this.btnAgregarPermisos.Size = new System.Drawing.Size(120, 51);
            this.btnAgregarPermisos.TabIndex = 11;
            this.btnAgregarPermisos.Text = "Agregar";
            this.btnAgregarPermisos.UseVisualStyleBackColor = true;
            this.btnAgregarPermisos.Click += new System.EventHandler(this.btnAgregarPermisos_Click);
            // 
            // btnModificarPermisos
            // 
            this.btnModificarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPermisos.Location = new System.Drawing.Point(273, 354);
            this.btnModificarPermisos.Name = "btnModificarPermisos";
            this.btnModificarPermisos.Size = new System.Drawing.Size(130, 51);
            this.btnModificarPermisos.TabIndex = 10;
            this.btnModificarPermisos.Text = "Modificar";
            this.btnModificarPermisos.UseVisualStyleBackColor = true;
            this.btnModificarPermisos.Click += new System.EventHandler(this.btnModificarPermisos_Click);
            // 
            // cboPermisos
            // 
            this.cboPermisos.FormattingEnabled = true;
            this.cboPermisos.Location = new System.Drawing.Point(194, 285);
            this.cboPermisos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPermisos.Name = "cboPermisos";
            this.cboPermisos.Size = new System.Drawing.Size(301, 37);
            this.cboPermisos.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Permisos";
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRol.Location = new System.Drawing.Point(453, 192);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(130, 51);
            this.btnEliminarRol.TabIndex = 7;
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // btnAgregarRolExistente
            // 
            this.btnAgregarRolExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRolExistente.Location = new System.Drawing.Point(86, 192);
            this.btnAgregarRolExistente.Name = "btnAgregarRolExistente";
            this.btnAgregarRolExistente.Size = new System.Drawing.Size(120, 51);
            this.btnAgregarRolExistente.TabIndex = 6;
            this.btnAgregarRolExistente.Text = "Agregar";
            this.btnAgregarRolExistente.UseVisualStyleBackColor = true;
            this.btnAgregarRolExistente.Click += new System.EventHandler(this.btnAgregarRolExistente_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Roles";
            // 
            // cboRolesExistentes
            // 
            this.cboRolesExistentes.FormattingEnabled = true;
            this.cboRolesExistentes.Location = new System.Drawing.Point(186, 97);
            this.cboRolesExistentes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboRolesExistentes.Name = "cboRolesExistentes";
            this.cboRolesExistentes.Size = new System.Drawing.Size(301, 37);
            this.cboRolesExistentes.TabIndex = 0;
            // 
            // frmRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 1050);
            this.Controls.Add(this.groupBoxRE);
            this.Controls.Add(this.treeViewRolesC);
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
            this.groupBoxOpciones.PerformLayout();
            this.groupBoxRE.ResumeLayout(false);
            this.groupBoxRE.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRolesPermisos;
        private System.Windows.Forms.GroupBox groupBoxDetalles;
        private System.Windows.Forms.GroupBox groupBoxOpciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardarRP;
        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.Button btnAgregarPR;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewRolesC;
        private System.Windows.Forms.GroupBox groupBoxRE;
        private System.Windows.Forms.Button btnAgregarRolExistente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRolesExistentes;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEliminarPermisos;
        private System.Windows.Forms.Button btnAgregarPermisos;
        private System.Windows.Forms.Button btnModificarPermisos;
        private System.Windows.Forms.ComboBox cboPermisos;
        private System.Windows.Forms.Label label5;
    }
}