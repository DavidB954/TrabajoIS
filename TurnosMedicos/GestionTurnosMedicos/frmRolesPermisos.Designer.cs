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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolesPermisos));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.btnEditarRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRolSeleccionado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.btnDevolverPermiso = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.listBxRoles = new System.Windows.Forms.ListBox();
            this.listBxPermisosDisponibles = new System.Windows.Forms.ListBox();
            this.listBxPermisosAsignados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roles";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarRol.Image")));
            this.btnAgregarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarRol.Location = new System.Drawing.Point(30, 58);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(96, 35);
            this.btnAgregarRol.TabIndex = 1;
            this.btnAgregarRol.Text = "Nuevo Rol";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            // 
            // btnEditarRol
            // 
            this.btnEditarRol.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarRol.Image")));
            this.btnEditarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarRol.Location = new System.Drawing.Point(132, 58);
            this.btnEditarRol.Name = "btnEditarRol";
            this.btnEditarRol.Size = new System.Drawing.Size(96, 35);
            this.btnEditarRol.TabIndex = 2;
            this.btnEditarRol.Text = "Editar";
            this.btnEditarRol.UseVisualStyleBackColor = true;
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarRol.Image")));
            this.btnEliminarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarRol.Location = new System.Drawing.Point(234, 58);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(96, 35);
            this.btnEliminarRol.TabIndex = 3;
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(389, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Asignar Permisos al Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rol Seleccionado:";
            // 
            // txtRolSeleccionado
            // 
            this.txtRolSeleccionado.Location = new System.Drawing.Point(393, 88);
            this.txtRolSeleccionado.Name = "txtRolSeleccionado";
            this.txtRolSeleccionado.ReadOnly = true;
            this.txtRolSeleccionado.Size = new System.Drawing.Size(195, 20);
            this.txtRolSeleccionado.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Permisos Disponibles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(800, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Permisos asignados al Rol";
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPermiso.Location = new System.Drawing.Point(670, 310);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(65, 40);
            this.btnAgregarPermiso.TabIndex = 12;
            this.btnAgregarPermiso.Text = ">";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            // 
            // btnDevolverPermiso
            // 
            this.btnDevolverPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolverPermiso.Location = new System.Drawing.Point(670, 379);
            this.btnDevolverPermiso.Name = "btnDevolverPermiso";
            this.btnDevolverPermiso.Size = new System.Drawing.Size(65, 40);
            this.btnDevolverPermiso.TabIndex = 13;
            this.btnDevolverPermiso.Text = "<";
            this.btnDevolverPermiso.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCambios.Image")));
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.Location = new System.Drawing.Point(894, 623);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(127, 40);
            this.btnGuardarCambios.TabIndex = 14;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // listBxRoles
            // 
            this.listBxRoles.FormattingEnabled = true;
            this.listBxRoles.Location = new System.Drawing.Point(30, 129);
            this.listBxRoles.Name = "listBxRoles";
            this.listBxRoles.Size = new System.Drawing.Size(300, 472);
            this.listBxRoles.TabIndex = 15;
            // 
            // listBxPermisosDisponibles
            // 
            this.listBxPermisosDisponibles.FormattingEnabled = true;
            this.listBxPermisosDisponibles.Location = new System.Drawing.Point(393, 167);
            this.listBxPermisosDisponibles.Name = "listBxPermisosDisponibles";
            this.listBxPermisosDisponibles.Size = new System.Drawing.Size(255, 433);
            this.listBxPermisosDisponibles.TabIndex = 16;
            // 
            // listBxPermisosAsignados
            // 
            this.listBxPermisosAsignados.FormattingEnabled = true;
            this.listBxPermisosAsignados.Location = new System.Drawing.Point(783, 167);
            this.listBxPermisosAsignados.Name = "listBxPermisosAsignados";
            this.listBxPermisosAsignados.Size = new System.Drawing.Size(238, 433);
            this.listBxPermisosAsignados.TabIndex = 17;
            // 
            // frmRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 741);
            this.Controls.Add(this.listBxPermisosAsignados);
            this.Controls.Add(this.listBxPermisosDisponibles);
            this.Controls.Add(this.listBxRoles);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnDevolverPermiso);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRolSeleccionado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.btnEditarRol);
            this.Controls.Add(this.btnAgregarRol);
            this.Controls.Add(this.label1);
            this.Name = "frmRolesPermisos";
            this.Text = "frmRolesPermisos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.Button btnEditarRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRolSeleccionado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnDevolverPermiso;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.ListBox listBxRoles;
        private System.Windows.Forms.ListBox listBxPermisosDisponibles;
        private System.Windows.Forms.ListBox listBxPermisosAsignados;
    }
}