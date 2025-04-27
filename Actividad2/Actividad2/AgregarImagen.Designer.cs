namespace Actividad2
{
    partial class AgregarImagen
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
            this.Lacaja = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PbxAgregar = new System.Windows.Forms.PictureBox();
            this.Borrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbxAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGREGAR IMAGEN";
            // 
            // Lacaja
            // 
            this.Lacaja.Location = new System.Drawing.Point(98, 43);
            this.Lacaja.Name = "Lacaja";
            this.Lacaja.Size = new System.Drawing.Size(189, 20);
            this.Lacaja.TabIndex = 1;
            this.Lacaja.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PbxAgregar
            // 
            this.PbxAgregar.Location = new System.Drawing.Point(81, 84);
            this.PbxAgregar.Name = "PbxAgregar";
            this.PbxAgregar.Size = new System.Drawing.Size(237, 190);
            this.PbxAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxAgregar.TabIndex = 3;
            this.PbxAgregar.TabStop = false;
            this.PbxAgregar.Click += new System.EventHandler(this.PbxAgregar_Click);
            // 
            // Borrar
            // 
            this.Borrar.Location = new System.Drawing.Point(305, 40);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(75, 23);
            this.Borrar.TabIndex = 4;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseVisualStyleBackColor = true;
            this.Borrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // AgregarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 349);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.PbxAgregar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lacaja);
            this.Controls.Add(this.label1);
            this.Name = "AgregarImagen";
            this.Text = "AgregarImagen";
            this.Load += new System.EventHandler(this.AgregarImagen_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AgregarImagen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PbxAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Lacaja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox PbxAgregar;
        private System.Windows.Forms.Button Borrar;
    }
}