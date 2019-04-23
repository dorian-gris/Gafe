namespace GAFE
{
    partial class frmMenuCatalogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuCatalogos));
            this.PanCabeza = new System.Windows.Forms.Panel();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.lblCabeza = new System.Windows.Forms.Label();
            this.PanMenu = new System.Windows.Forms.Panel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenAlmacen = new System.Windows.Forms.Button();
            this.BarraSidePanel = new System.Windows.Forms.Panel();
            this.btnMenMarcas = new System.Windows.Forms.Button();
            this.btnMenUMedida = new System.Windows.Forms.Button();
            this.btnMenLineas = new System.Windows.Forms.Button();
            this.btnMenClases = new System.Windows.Forms.Button();
            this.btnMenArticulo = new System.Windows.Forms.Button();
            this.PanContenido = new System.Windows.Forms.Panel();
            this.PanPíe = new System.Windows.Forms.Panel();
            this.txtError = new System.Windows.Forms.TextBox();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.PanCabeza.SuspendLayout();
            this.PanMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanPíe.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanCabeza
            // 
            this.PanCabeza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.PanCabeza.Controls.Add(this.cmdCerrar);
            this.PanCabeza.Controls.Add(this.lblCabeza);
            this.PanCabeza.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanCabeza.Location = new System.Drawing.Point(0, 0);
            this.PanCabeza.Name = "PanCabeza";
            this.PanCabeza.Size = new System.Drawing.Size(990, 33);
            this.PanCabeza.TabIndex = 3;
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.FlatAppearance.BorderSize = 0;
            this.cmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCerrar.ForeColor = System.Drawing.Color.White;
            this.cmdCerrar.Location = new System.Drawing.Point(691, 2);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(30, 31);
            this.cmdCerrar.TabIndex = 4;
            this.cmdCerrar.Text = "X";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // lblCabeza
            // 
            this.lblCabeza.AutoSize = true;
            this.lblCabeza.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabeza.ForeColor = System.Drawing.Color.White;
            this.lblCabeza.Location = new System.Drawing.Point(6, 7);
            this.lblCabeza.Name = "lblCabeza";
            this.lblCabeza.Size = new System.Drawing.Size(0, 16);
            this.lblCabeza.TabIndex = 0;
            // 
            // PanMenu
            // 
            this.PanMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanMenu.Controls.Add(this.ribbon1);
            this.PanMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanMenu.Location = new System.Drawing.Point(0, 33);
            this.PanMenu.Name = "PanMenu";
            this.PanMenu.Size = new System.Drawing.Size(990, 118);
            this.PanMenu.TabIndex = 6;
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(990, 117);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btnMenAlmacen);
            this.panel1.Controls.Add(this.BarraSidePanel);
            this.panel1.Controls.Add(this.btnMenMarcas);
            this.panel1.Controls.Add(this.btnMenUMedida);
            this.panel1.Controls.Add(this.btnMenLineas);
            this.panel1.Controls.Add(this.btnMenClases);
            this.panel1.Controls.Add(this.btnMenArticulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 417);
            this.panel1.TabIndex = 7;
            // 
            // btnMenAlmacen
            // 
            this.btnMenAlmacen.FlatAppearance.BorderSize = 0;
            this.btnMenAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenAlmacen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenAlmacen.ForeColor = System.Drawing.Color.White;
            this.btnMenAlmacen.Image = ((System.Drawing.Image)(resources.GetObject("btnMenAlmacen.Image")));
            this.btnMenAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenAlmacen.Location = new System.Drawing.Point(9, 280);
            this.btnMenAlmacen.Name = "btnMenAlmacen";
            this.btnMenAlmacen.Size = new System.Drawing.Size(214, 46);
            this.btnMenAlmacen.TabIndex = 5;
            this.btnMenAlmacen.Text = "     Almacenes";
            this.btnMenAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenAlmacen.UseVisualStyleBackColor = true;
            // 
            // BarraSidePanel
            // 
            this.BarraSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.BarraSidePanel.Location = new System.Drawing.Point(2, 47);
            this.BarraSidePanel.Name = "BarraSidePanel";
            this.BarraSidePanel.Size = new System.Drawing.Size(8, 46);
            this.BarraSidePanel.TabIndex = 0;
            // 
            // btnMenMarcas
            // 
            this.btnMenMarcas.FlatAppearance.BorderSize = 0;
            this.btnMenMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenMarcas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenMarcas.ForeColor = System.Drawing.Color.White;
            this.btnMenMarcas.Image = ((System.Drawing.Image)(resources.GetObject("btnMenMarcas.Image")));
            this.btnMenMarcas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenMarcas.Location = new System.Drawing.Point(12, 228);
            this.btnMenMarcas.Name = "btnMenMarcas";
            this.btnMenMarcas.Size = new System.Drawing.Size(214, 46);
            this.btnMenMarcas.TabIndex = 4;
            this.btnMenMarcas.Text = "     Marcas";
            this.btnMenMarcas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenMarcas.UseVisualStyleBackColor = true;
            // 
            // btnMenUMedida
            // 
            this.btnMenUMedida.FlatAppearance.BorderSize = 0;
            this.btnMenUMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenUMedida.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenUMedida.ForeColor = System.Drawing.Color.White;
            this.btnMenUMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnMenUMedida.Image")));
            this.btnMenUMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenUMedida.Location = new System.Drawing.Point(12, 183);
            this.btnMenUMedida.Name = "btnMenUMedida";
            this.btnMenUMedida.Size = new System.Drawing.Size(214, 46);
            this.btnMenUMedida.TabIndex = 3;
            this.btnMenUMedida.Text = "  Unidad de Medida";
            this.btnMenUMedida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenUMedida.UseVisualStyleBackColor = true;
            this.btnMenUMedida.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMenLineas
            // 
            this.btnMenLineas.FlatAppearance.BorderSize = 0;
            this.btnMenLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenLineas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenLineas.ForeColor = System.Drawing.Color.White;
            this.btnMenLineas.Image = ((System.Drawing.Image)(resources.GetObject("btnMenLineas.Image")));
            this.btnMenLineas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenLineas.Location = new System.Drawing.Point(12, 138);
            this.btnMenLineas.Name = "btnMenLineas";
            this.btnMenLineas.Size = new System.Drawing.Size(214, 46);
            this.btnMenLineas.TabIndex = 2;
            this.btnMenLineas.Text = "   Lineas";
            this.btnMenLineas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenLineas.UseVisualStyleBackColor = true;
            this.btnMenLineas.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnMenClases
            // 
            this.btnMenClases.FlatAppearance.BorderSize = 0;
            this.btnMenClases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenClases.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenClases.ForeColor = System.Drawing.Color.White;
            this.btnMenClases.Image = ((System.Drawing.Image)(resources.GetObject("btnMenClases.Image")));
            this.btnMenClases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenClases.Location = new System.Drawing.Point(12, 93);
            this.btnMenClases.Name = "btnMenClases";
            this.btnMenClases.Size = new System.Drawing.Size(214, 46);
            this.btnMenClases.TabIndex = 1;
            this.btnMenClases.Text = "   Clases";
            this.btnMenClases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenClases.UseVisualStyleBackColor = true;
            this.btnMenClases.Click += new System.EventHandler(this.cmdClases_Click);
            // 
            // btnMenArticulo
            // 
            this.btnMenArticulo.FlatAppearance.BorderSize = 0;
            this.btnMenArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenArticulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenArticulo.ForeColor = System.Drawing.Color.White;
            this.btnMenArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnMenArticulo.Image")));
            this.btnMenArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenArticulo.Location = new System.Drawing.Point(12, 48);
            this.btnMenArticulo.Name = "btnMenArticulo";
            this.btnMenArticulo.Size = new System.Drawing.Size(214, 46);
            this.btnMenArticulo.TabIndex = 0;
            this.btnMenArticulo.Text = "   Articulo";
            this.btnMenArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenArticulo.UseVisualStyleBackColor = true;
            this.btnMenArticulo.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanContenido
            // 
            this.PanContenido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanContenido.Location = new System.Drawing.Point(246, 151);
            this.PanContenido.Name = "PanContenido";
            this.PanContenido.Size = new System.Drawing.Size(744, 417);
            this.PanContenido.TabIndex = 8;
            // 
            // PanPíe
            // 
            this.PanPíe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PanPíe.Controls.Add(this.txtError);
            this.PanPíe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanPíe.Location = new System.Drawing.Point(246, 494);
            this.PanPíe.Name = "PanPíe";
            this.PanPíe.Size = new System.Drawing.Size(744, 74);
            this.PanPíe.TabIndex = 9;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(9, 6);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(723, 56);
            this.txtError.TabIndex = 2;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = null;
            // 
            // frmMenuCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(990, 568);
            this.Controls.Add(this.PanPíe);
            this.Controls.Add(this.PanContenido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanMenu);
            this.Controls.Add(this.PanCabeza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmMenuCatalogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenuCatalogos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanCabeza.ResumeLayout(false);
            this.PanCabeza.PerformLayout();
            this.PanMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanPíe.ResumeLayout(false);
            this.PanPíe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanCabeza;
        private System.Windows.Forms.Label lblCabeza;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Panel PanMenu;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel BarraSidePanel;
        private System.Windows.Forms.Button btnMenMarcas;
        private System.Windows.Forms.Button btnMenUMedida;
        private System.Windows.Forms.Button btnMenLineas;
        private System.Windows.Forms.Button btnMenClases;
        private System.Windows.Forms.Button btnMenArticulo;
        private System.Windows.Forms.Panel PanContenido;
        private System.Windows.Forms.Button btnMenAlmacen;
        private System.Windows.Forms.Panel PanPíe;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.RibbonTab ribbonTab1;
    }
}