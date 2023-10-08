/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 27/07/2019
 * Time: 16:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Proyecto_Algoritmia
{
	partial class Resultados_Recorridos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txbOrigenSeleccionado;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.ListBox lbLista;
		private System.Windows.Forms.Label lblDestino;
		private System.Windows.Forms.TextBox tbxDestino;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txbOrigenSeleccionado = new System.Windows.Forms.TextBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.lbLista = new System.Windows.Forms.ListBox();
			this.lblDestino = new System.Windows.Forms.Label();
			this.tbxDestino = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(30, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(369, 85);
			this.label1.TabIndex = 0;
			this.label1.Text = "TU RECORRIDO OBTENIDO:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(30, 113);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(213, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Origen Seleccionado: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txbOrigenSeleccionado
			// 
			this.txbOrigenSeleccionado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txbOrigenSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txbOrigenSeleccionado.Location = new System.Drawing.Point(249, 112);
			this.txbOrigenSeleccionado.Name = "txbOrigenSeleccionado";
			this.txbOrigenSeleccionado.ReadOnly = true;
			this.txbOrigenSeleccionado.Size = new System.Drawing.Size(150, 29);
			this.txbOrigenSeleccionado.TabIndex = 2;
			// 
			// btnAccept
			// 
			this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAccept.Location = new System.Drawing.Point(151, 450);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(119, 43);
			this.btnAccept.TabIndex = 4;
			this.btnAccept.Text = "ACEPTAR";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.BtnAcceptClick);
			this.btnAccept.MouseEnter += new System.EventHandler(this.BtnAcceptMouseEnter);
			this.btnAccept.MouseLeave += new System.EventHandler(this.BtnAcceptMouseLeave);
			// 
			// lbLista
			// 
			this.lbLista.Font = new System.Drawing.Font("Tw Cen MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbLista.FormattingEnabled = true;
			this.lbLista.ItemHeight = 31;
			this.lbLista.Location = new System.Drawing.Point(30, 210);
			this.lbLista.Name = "lbLista";
			this.lbLista.Size = new System.Drawing.Size(369, 221);
			this.lbLista.TabIndex = 5;
			// 
			// lblDestino
			// 
			this.lblDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDestino.Location = new System.Drawing.Point(30, 163);
			this.lblDestino.Name = "lblDestino";
			this.lblDestino.Size = new System.Drawing.Size(213, 29);
			this.lblDestino.TabIndex = 6;
			this.lblDestino.Text = "Destino Seleccionado: ";
			this.lblDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbxDestino
			// 
			this.tbxDestino.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tbxDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxDestino.Location = new System.Drawing.Point(249, 162);
			this.tbxDestino.Name = "tbxDestino";
			this.tbxDestino.ReadOnly = true;
			this.tbxDestino.Size = new System.Drawing.Size(150, 29);
			this.tbxDestino.TabIndex = 7;
			// 
			// Resultados_Recorridos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(422, 510);
			this.Controls.Add(this.tbxDestino);
			this.Controls.Add(this.lblDestino);
			this.Controls.Add(this.lbLista);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.txbOrigenSeleccionado);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Resultados_Recorridos";
			this.Text = "RESULTADOS";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
