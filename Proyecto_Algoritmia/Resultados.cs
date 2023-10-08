/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 27/07/2019
 * Time: 16:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Algoritmia
{
	/// <summary>
	/// Description of Resultados_Recorridos.
	/// </summary>
	public partial class Resultados_Recorridos : Form
	{
		public Resultados_Recorridos(List<string> lista,string origen, string destino)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			if(destino == ""){
				tbxDestino.Enabled = false;
				lblDestino.Enabled = false;
			}
			else{
				tbxDestino.Text = destino;
			}
			
			txbOrigenSeleccionado.Text = origen;
			
			var j = 0;
			for(int i = 0; i < lista.Size();i++){
				var cadena = "";
				
				switch(j){
					case 1:
						cadena = "Siga Con: "+  lista[i];
						j++;
						break;
					case 2:
						cadena = "Despues Siga Con: "+  lista[i];
						j++;
						break;
					case 3:
						cadena = "Pase Por: "+  lista[i];
						j = 1;
						break;
				}
				
				if(i == 0){
					cadena = "Empieze Con: " + lista[i];
					j++;
				}

				
				lbLista.Items.Add( cadena + "\r\n");
			
			}
			
			lista.Clear();
		}
		void BtnAcceptClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void BtnAcceptMouseEnter(object sender, EventArgs e)
		{
			btnAccept.BackColor = Color.Green;
		}
		void BtnAcceptMouseLeave(object sender, EventArgs e)
		{
			btnAccept.BackColor = Color.White;
		}
	}
}
