namespace SistemaCitasDental
{
    partial class frmAgendarCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendarCita));
            this.lblID = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.lblDentista = new System.Windows.Forms.Label();
            this.txtDentista = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.cboMotivo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblID.Location = new System.Drawing.Point(182, 226);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(106, 19);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID de la cita:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(357, 226);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(228, 27);
            this.txtId.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaciente.Location = new System.Drawing.Point(88, 306);
            this.lblPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(177, 19);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "Nombre del Paciente:";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(357, 306);
            this.txtPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(228, 27);
            this.txtPaciente.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(235, 380);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(62, 19);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(357, 373);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(228, 27);
            this.dtpFecha.TabIndex = 5;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(249, 437);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(53, 19);
            this.lblHora.TabIndex = 6;
            this.lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(357, 437);
            this.dtpHora.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(228, 27);
            this.dtpHora.TabIndex = 7;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracion.Location = new System.Drawing.Point(652, 430);
            this.lblDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(165, 19);
            this.lblDuracion.TabIndex = 8;
            this.lblDuracion.Text = "Duracion (Minutos):";
            // 
            // nudDuracion
            // 
            this.nudDuracion.Location = new System.Drawing.Point(905, 434);
            this.nudDuracion.Margin = new System.Windows.Forms.Padding(4);
            this.nudDuracion.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudDuracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(229, 27);
            this.nudDuracion.TabIndex = 9;
            this.nudDuracion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDentista
            // 
            this.lblDentista.AutoSize = true;
            this.lblDentista.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDentista.Location = new System.Drawing.Point(641, 313);
            this.lblDentista.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDentista.Name = "lblDentista";
            this.lblDentista.Size = new System.Drawing.Size(173, 19);
            this.lblDentista.TabIndex = 10;
            this.lblDentista.Text = "Nombre del dentista:";
            // 
            // txtDentista
            // 
            this.txtDentista.Location = new System.Drawing.Point(905, 317);
            this.txtDentista.Margin = new System.Windows.Forms.Padding(4);
            this.txtDentista.Name = "txtDentista";
            this.txtDentista.Size = new System.Drawing.Size(228, 27);
            this.txtDentista.TabIndex = 11;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(651, 380);
            this.lblMotivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(163, 19);
            this.lblMotivo.TabIndex = 12;
            this.lblMotivo.Text = "Motivo de consulta:";
            // 
            // cboMotivo
            // 
            this.cboMotivo.FormattingEnabled = true;
            this.cboMotivo.Location = new System.Drawing.Point(905, 376);
            this.cboMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(228, 27);
            this.cboMotivo.TabIndex = 13;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(375, 559);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(235, 63);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(646, 559);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(235, 63);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(252, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 38);
            this.label1.TabIndex = 16;
            this.label1.Text = "Agendar Citas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "__________________________________________";
            // 
            // frmAgendarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1457, 775);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtDentista);
            this.Controls.Add(this.lblDentista);
            this.Controls.Add(this.nudDuracion);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblID);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAgendarCita";
            this.Text = "Agendar Cita";
            this.Load += new System.EventHandler(this.frmAgendarCita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.Label lblDentista;
        private System.Windows.Forms.TextBox txtDentista;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.ComboBox cboMotivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}