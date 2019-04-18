namespace GAFE
{
    partial class frmCatUMedidas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveUMedida = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmEditar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.CodEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 58);
            this.panel1.TabIndex = 9;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdBuscar.Location = new System.Drawing.Point(419, 3);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(69, 48);
            this.cmdBuscar.TabIndex = 2;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(59, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(354, 26);
            this.txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboEstatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.cmdAceptar);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtClaveUMedida);
            this.panel2.Controls.Add(this.lblCodEmpleado);
            this.panel2.Location = new System.Drawing.Point(2, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 146);
            this.panel2.TabIndex = 20;
            // 
            // cboEstatus
            // 
            this.cboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstatus.Location = new System.Drawing.Point(95, 74);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(147, 28);
            this.cboEstatus.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Estatus";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(407, 116);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 11;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(326, 116);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(95, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(392, 26);
            this.txtDescripcion.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion";
            // 
            // txtClaveUMedida
            // 
            this.txtClaveUMedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveUMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveUMedida.Location = new System.Drawing.Point(95, 10);
            this.txtClaveUMedida.MaxLength = 10;
            this.txtClaveUMedida.Name = "txtClaveUMedida";
            this.txtClaveUMedida.Size = new System.Drawing.Size(147, 26);
            this.txtClaveUMedida.TabIndex = 7;
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodEmpleado.Location = new System.Drawing.Point(5, 13);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(59, 20);
            this.lblCodEmpleado.TabIndex = 1;
            this.lblCodEmpleado.Text = "Codigo";
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.Location = new System.Drawing.Point(14, 221);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(75, 23);
            this.cmdConsultar.TabIndex = 15;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.UseVisualStyleBackColor = true;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.Location = new System.Drawing.Point(404, 221);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(75, 23);
            this.cmdEliminar.TabIndex = 18;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = true;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmEditar
            // 
            this.cmEditar.Location = new System.Drawing.Point(323, 221);
            this.cmEditar.Name = "cmEditar";
            this.cmEditar.Size = new System.Drawing.Size(75, 23);
            this.cmEditar.TabIndex = 17;
            this.cmEditar.Text = "Editar";
            this.cmEditar.UseVisualStyleBackColor = true;
            this.cmEditar.Click += new System.EventHandler(this.cmEditar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Location = new System.Drawing.Point(242, 221);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(75, 23);
            this.cmdAgregar.TabIndex = 16;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodEmpleado,
            this.Nombre});
            this.grdView.Location = new System.Drawing.Point(13, 65);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(474, 150);
            this.grdView.TabIndex = 19;
            // 
            // CodEmpleado
            // 
            this.CodEmpleado.HeaderText = "Codigo";
            this.CodEmpleado.Name = "CodEmpleado";
            this.CodEmpleado.ReadOnly = true;
            this.CodEmpleado.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 350;
            // 
            // frmCatUMedidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 420);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmEditar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 459);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 286);
            this.Name = "frmCatUMedidas";
            this.Text = "Catálogo de Medidas";
            this.Load += new System.EventHandler(this.frmCatUMedidas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveUMedida;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmEditar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}