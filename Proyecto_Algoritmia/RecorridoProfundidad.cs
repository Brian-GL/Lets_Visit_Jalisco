/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 26/07/2019
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Algoritmia
{
	/// <summary>
	/// Description of RecorridoProfundidad.
	/// </summary>
	public partial class RecorridoProfundidad : Form
	{
		public string seleccionOrigen;
		public string seleccionDestino;
		public bool selectDestination;
		public RecorridoProfundidad(List<Button> List,bool destino)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			selectDestination = destino;
			if(!destino){
				lblDestino.Enabled = false;
				cbDestinos.Enabled = false;
				seleccionDestino = "";
				for(int i = 0; i < List.Size();i++){
					cbOrigenes.Items.Add(List[i].Name);
				}
				
			}else{
				for(int i = 0; i < List.Size();i++){
					cbOrigenes.Items.Add(List[i].Name);
					cbDestinos.Items.Add(List[i].Name);
				}
			}
			
			
		}
		void BtnAceptarMouseEnter(object sender, EventArgs e)
		{
			btnAceptar.BackColor = Color.Blue;
		}
		void BtnAceptarMouseLeave(object sender, EventArgs e)
		{
			btnAceptar.BackColor = Color.LightGray;
		}
		void BtnAceptarClick(object sender, EventArgs e)
		{
			if(selectDestination){
				if(cbDestinos.SelectedIndex < 0 || cbOrigenes.SelectedIndex < 0 ){
					MessageBox.Show("Seleccione Cada Valor","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}else{
					seleccionOrigen = cbOrigenes.SelectedItem.ToString();
					seleccionDestino = cbDestinos.SelectedItem.ToString();
					this.Close();
				}
				
			}
			else{
				if(cbOrigenes.SelectedIndex < 0 ){
					MessageBox.Show("Seleccione Un Valor Para Origen","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
				else{
					seleccionOrigen = cbOrigenes.SelectedItem.ToString();
					seleccionDestino = "";
					this.Close();
				}
			}
			
			
		}


	}
}
