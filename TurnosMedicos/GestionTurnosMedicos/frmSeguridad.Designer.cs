namespace GestionTurnosMedicos
{
    partial class frmSeguridad
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
            this.dgvSeguridad = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnRestaurarBD = new System.Windows.Forms.Button();
            this.btnBloquearUsuYRecalcular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguridad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSeguridad
            // 
            this.dgvSeguridad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeguridad.Location = new System.Drawing.Point(6, 38);
            this.dgvSeguridad.Name = "dgvSeguridad";
            this.dgvSeguridad.Size = new System.Drawing.Size(524, 182);
            this.dgvSeguridad.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSeguridad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filas Corrompidas";
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(28, 336);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(153, 54);
            this.btnBackUp.TabIndex = 2;
            this.btnBackUp.Text = "Generar Back Up";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnRestaurarBD
            // 
            this.btnRestaurarBD.Location = new System.Drawing.Point(211, 336);
            this.btnRestaurarBD.Name = "btnRestaurarBD";
            this.btnRestaurarBD.Size = new System.Drawing.Size(152, 54);
            this.btnRestaurarBD.TabIndex = 3;
            this.btnRestaurarBD.Text = "Restaurar BD";
            this.btnRestaurarBD.UseVisualStyleBackColor = true;
            this.btnRestaurarBD.Click += new System.EventHandler(this.btnRestaurarBD_Click);
            // 
            // btnBloquearUsuYRecalcular
            // 
            this.btnBloquearUsuYRecalcular.Location = new System.Drawing.Point(395, 336);
            this.btnBloquearUsuYRecalcular.Name = "btnBloquearUsuYRecalcular";
            this.btnBloquearUsuYRecalcular.Size = new System.Drawing.Size(134, 54);
            this.btnBloquearUsuYRecalcular.TabIndex = 4;
            this.btnBloquearUsuYRecalcular.Text = "Bloquear Usuario y Recalcular DV";
            this.btnBloquearUsuYRecalcular.UseVisualStyleBackColor = true;
            this.btnBloquearUsuYRecalcular.Click += new System.EventHandler(this.btnBloquearUsuYRecalcular_Click);
            // 
            // frmSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 698);
            this.Controls.Add(this.btnBloquearUsuYRecalcular);
            this.Controls.Add(this.btnRestaurarBD);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSeguridad";
            this.Text = "frmSeguridad";
            this.Load += new System.EventHandler(this.frmSeguridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguridad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeguridad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnRestaurarBD;
        private System.Windows.Forms.Button btnBloquearUsuYRecalcular;
    }
}