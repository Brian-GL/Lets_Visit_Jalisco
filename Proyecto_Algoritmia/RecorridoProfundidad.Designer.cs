/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 26/07/2019
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Proyecto_Algoritmia
{
	partial class RecorridoProfundidad
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblIndicacion;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.ComboBox cbOrigenes;
		private System.Windows.Forms.ComboBox cbDestinos;
		private System.Windows.Forms.Label lblDestino;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblIndicacion = new System.Windows.Forms.Label();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.cbOrigenes = new System.Windows.Forms.ComboBox();
			this.cbDestinos = new System.Windows.Forms.ComboBox();
			this.lblDestino = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblIndicacion
			// 
			this.lblIndicacion.BackColor = System.Drawing.Color.LightGray;
			this.lblIndicacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIndicacion.Font = new System.Drawing.Font("Tw Cen MT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIndicacion.Location = new System.Drawing.Point(12, 19);
			this.lblIndicacion.Name = "lblIndicacion";
			this.lblIndicacion.Size = new System.Drawing.Size(476, 51);
			this.lblIndicacion.TabIndex = 0;
			this.lblIndicacion.Text = "Seleccione El Origen";
			this.lblIndicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.Color.LightGray;
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAceptar.Location = new System.Drawing.Point(169, 281);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(123, 45);
			this.btnAceptar.TabIndex = 1;
			this.btnAceptar.Text = "ACEPTAR";
			this.btnAceptar.UseVisualStyleBackColor = false;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptarClick);
			this.btnAceptar.MouseEnter += new System.EventHandler(this.BtnAceptarMouseEnter);
			this.btnAceptar.MouseLeave += new System.EventHandler(this.BtnAceptarMouseLeave);
			// 
			// cbOrigenes
			// 
			this.cbOrigenes.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbOrigenes.FormattingEnabled = true;
			this.cbOrigenes.Location = new System.Drawing.Point(12, 92);
			this.cbOrigenes.Name = "cbOrigenes";
			this.cbOrigenes.Size = new System.Drawing.Size(476, 32);
			this.cbOrigenes.Sorted = true;
			this.cbOrigenes.TabIndex = 2;
			// 
			// cbDestinos
			// 
			this.cbDestinos.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbDestinos.FormattingEnabled = true;
			this.cbDestinos.Location = new System.Drawing.Point(12, 210);
			this.cbDestinos.Name = "cbDestinos";
			this.cbDestinos.Size = new System.Drawing.Size(476, 32);
			this.cbDestinos.Sorted = true;
			this.cbDestinos.TabIndex = 4;
			// 
			// lblDestino
			// 
			this.lblDestino.BackColor = System.Drawing.Color.LightGray;
			this.lblDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDestino.Font = new System.Drawing.Font("Tw Cen MT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDestino.Location = new System.Drawing.Point(12, 141);
			this.lblDestino.Name = "lblDestino";
			this.lblDestino.Size = new System.Drawing.Size(476, 51);
			this.lblDestino.TabIndex = 3;
			this.lblDestino.Text = "Seleccione El Destino";
			this.lblDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RecorridoProfundidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(504, 344);
			this.Controls.Add(this.cbDestinos);
			this.Controls.Add(this.lblDestino);
			this.Controls.Add(this.cbOrigenes);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.lblIndicacion);
			this.Name = "RecorridoProfundidad";
			this.Text = "DFB";
			
			this.ResumeLayout(false);

		}
	}
}
