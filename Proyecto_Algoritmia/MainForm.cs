/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 24/07/2019
 * Time: 7:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace Proyecto_Algoritmia
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public Graph<string> Grafo = new Graph<string>();
		public List<Button> Buttons = new List<Button>();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			Create_Button_List();
			CreateGraph();
			
			var tlpRecorridoDFB = new ToolTip();
			tlpRecorridoDFB.SetToolTip(btnDFB,"Muestra El Recorrido De Todos Los Lugares\nEmpezando Por Un Lugar Seleccionado Por El Usuario ");
			tlpRecorridoDFB.Active = true;
			
			var tlpMazamitla = new ToolTip();
			tlpMazamitla.SetToolTip(Mazamitla,"MAZAMITLA");
			
//			var g= new Graph<string>();
//			g.Insert_Node("A");
//			g.Insert_Node("B");
//			g.Insert_Node("C");
//			
//			g.Insert_Edge(0.5,"A","B");
//			g.Insert_Edge(0.5,"B","A");
//			g.Insert_Edge(4,"C","A");
//			g.Insert_Edge(4,"A","C");
//			g.Insert_Edge(3,"C","B");
//			g.Insert_Edge(3,"B","C");
//			
//			var lista = g.Dijsktra("A","C");
//			
//			for(int i = 0; i < lista.Size();i++){
//				MessageBox.Show(lista[i]);
//			}
			
		}
		
		Point Get_Point(string nombre){
			var returnPoint = new Point();
			for(int i = 0; i < Buttons.Size();i++){
				if(Buttons[i].Name.Equals(nombre)){
					returnPoint = Buttons[i].Location;
					returnPoint.X = returnPoint.X+7;
					returnPoint.Y = returnPoint.Y+6;
					return returnPoint;
				}
			}
			
			return returnPoint;
		}
		
		Point Get_Real_Point(string nombre){
			var returnPoint = new Point();
			for(int i = 0; i < Buttons.Size();i++){
				if(Buttons[i].Name.Equals(nombre)){
					returnPoint = Buttons[i].Location;
					return returnPoint;
				}
			}
			
			return returnPoint;
		}
		
		Button Get_Button(string name){
			var returnButton = new Button();
			for(int i = 0; i < Buttons.Size();i++){
				if(Buttons[i].Name.Equals(name)){
					return Buttons[i];
				}
			}
			
			return returnButton;
		}
		
		void Create_Button_List(){
			
			Buttons.Push_Back(PuertoVallarta);
			Buttons.Push_Back(Mismaloya);
			Buttons.Push_Back(Yelapa);
			Buttons.Push_Back(ElTuito);
			Buttons.Push_Back(SanPatricio);
			Buttons.Push_Back(BarraDeNavidad);
			Buttons.Push_Back(Cihuatlan);
			Buttons.Push_Back(VillaPurificacion);

			Buttons.Push_Back(Cajititlan);
			Buttons.Push_Back(TlajomulcoDeZuniga);
			Buttons.Push_Back(Guadalajara);
			Buttons.Push_Back(Zapopan);
			Buttons.Push_Back(Tlaquepaque);
			Buttons.Push_Back(Tonala);
			Buttons.Push_Back(AcatlanDeJuarez);

			Buttons.Push_Back(Chapala);
			Buttons.Push_Back(Ajijic);
			Buttons.Push_Back(Jocotepec);
			Buttons.Push_Back(Mezcala);
			Buttons.Push_Back(SanPedroTesistan);
			Buttons.Push_Back(TizapanElAlto);
			Buttons.Push_Back(Jamay);
			Buttons.Push_Back(Ocotlan);
			Buttons.Push_Back(Poncitlan);

			Buttons.Push_Back(SanSebastianDelOeste);
			Buttons.Push_Back(Mascota);
			Buttons.Push_Back(TalpaDeAllende);
			Buttons.Push_Back(Mixtlan);
			Buttons.Push_Back(Ayutla);
			Buttons.Push_Back(UnionDeTula);
			Buttons.Push_Back(AutlanDeNavarro);
			Buttons.Push_Back(ElGrullo);
			Buttons.Push_Back(Tonaya);
			Buttons.Push_Back(SanGabriel);
			Buttons.Push_Back(Juchitlan);

			Buttons.Push_Back(CiudadGuzman);
			Buttons.Push_Back(Sayula);
			Buttons.Push_Back(Pihuamo);
			Buttons.Push_Back(TamazulaDeGordiano);
			Buttons.Push_Back(Mazamitla);
			Buttons.Push_Back(LaManzanillaDeLaPaz);
			Buttons.Push_Back(ConcepcionDeBuenosAires);
			Buttons.Push_Back(ZacoalcoDeTorres);
			Buttons.Push_Back(AtemajacDeBrizuela);
			Buttons.Push_Back(Sayula);
			Buttons.Push_Back(TechalutaDeMontenegro);
			Buttons.Push_Back(Tecolotlan);
			Buttons.Push_Back(Tapalpa);			

			Buttons.Push_Back(Magdalena);
			Buttons.Push_Back(Etzatlan);
			Buttons.Push_Back(Teuchitlan);
			Buttons.Push_Back(Cocula);
			Buttons.Push_Back(Tala);
			Buttons.Push_Back(Tequila);
			Buttons.Push_Back(Amatitlan);
			Buttons.Push_Back(Ameca);
			Buttons.Push_Back(Colotlan);

			Buttons.Push_Back(Zapotlanejo);
			Buttons.Push_Back(Cuquio);
			Buttons.Push_Back(YahualicaDeGonzalezGallo);
			Buttons.Push_Back(IxtlahuacanDelRio);
			Buttons.Push_Back(Acatic);
			Buttons.Push_Back(Mexticacan);
			Buttons.Push_Back(TepatitlanDeMorelos);
			Buttons.Push_Back(Tototlan);
			Buttons.Push_Back(LaBarca);
			Buttons.Push_Back(CanadasDeObregon);
			Buttons.Push_Back(ValleDeGuadalupe);
			Buttons.Push_Back(CapillaDeGuadalupe);
			Buttons.Push_Back(SanIgnacioCerroGordo);
			Buttons.Push_Back(AtotonilcoElAlto);
			Buttons.Push_Back(Ayotlan);
			Buttons.Push_Back(SanMiguelElAlto);
			Buttons.Push_Back(Arandas);
			Buttons.Push_Back(Jalostotitlan);
			Buttons.Push_Back(Teocaltiche);
			Buttons.Push_Back(VillaHidalgo);
			Buttons.Push_Back(SanJuanDeLosLagos);
			Buttons.Push_Back(SanJulian);
			Buttons.Push_Back(Degollado);
			Buttons.Push_Back(SanDiegoDeAlejandria);
			Buttons.Push_Back(UnionDeSanAntonio);
			Buttons.Push_Back(LagosDeMoreno);
			Buttons.Push_Back(Ojuelos);
			Buttons.Push_Back(EncarnacionDeDiaz);
		}

		void CreateGraph(){
			for(int i = 0; i < Buttons.Size();i++){
				Grafo.Insert_Node(Buttons[i].Name);
			}
		}
		
		void AddConnection(double value, string origen, string destino){
			Grafo.Insert_Edge(value,origen,destino);
			Grafo.Insert_Edge(value,destino,origen);
			
			var PointOrigen = Get_Point(origen);
			var PointDestino = Get_Point(destino);
			
			Graphics draw = this.CreateGraphics();
			draw.DrawLine(new Pen(Color.Black,2),PointOrigen,PointDestino);
			draw.Dispose();
			
		}
		
		void Guadalajara_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Guadalajara,"GUADALAJARA");
		}
		void Zapopan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Zapopan,"ZAPOPAN");
			
		}
		void Tlaquepaque_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tlaquepaque,"TLAQUEPAQUE");
			
		}
		void TlajomulcoDeZuniga_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TlajomulcoDeZuniga,"TLAJOMULCO DE ZUNIGA");
		
		}
		void Cajititlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Cajititlan,"CAJITITLAN");
			
		}
		void Chapala_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Chapala,"CHAPALA");
			
		}
		void Ajijic_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ajijic,"AJIJIC");
			 
		}
		void Jocotepec_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Jocotepec,"JOCOTEPEC");
			 
		}
		void Tonala_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tonala,"TONALA");
			 
		}
		void PuertoVallarta_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(PuertoVallarta,"PUERTO VALLARTA");
			 
		}
		void Mismaloya_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Mismaloya,"MISMALOYA");
			 
		}
		void Yelapa_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Yelapa,"YELAPA");
			 
		}
		void ElTuito_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(ElTuito,"EL TUITO");
			 
		}
		void SanSebastianDelOeste_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanSebastianDelOeste,"SAN SEBASTIAN DEL OESTE");
			 
		}
		void Mascota_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Mascota,"MASCOTA");
			 
		}
		void TalpaDeAllende_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TalpaDeAllende,"TALPA DE ALLENDE");
			 
		}
		void Mixtlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Mixtlan,"MIXTLAN");
			 
		}
		void Ayutla_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ayutla,"AYUTLA");
			 
		}
		void UnionDeTula_MouseEnter(object sender, EventArgs e)
		{	
			var mensaje = new ToolTip();
			mensaje.SetToolTip(UnionDeTula,"UNION DE TULA");
			 
		}
		void ElGrullo_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(ElGrullo,"EL GRULLO");
			 
		}
		void AutlanDeNavarro_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(AutlanDeNavarro,"AUTLAN DE NAVARRO");
			 
		}
		void VillaPurificacion_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(VillaPurificacion,"VILLA PURIFICACION");
			 
		}
		void Cihuatlan_MouseEnter(object sender, EventArgs e)
		{	
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Cihuatlan,"CIHUATLAN");
			 
		}
		void BarraDeNavidad_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(BarraDeNavidad,"BARRA DE NAVIDAD");
			 
		}
		void SanPatricio_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanPatricio,"SAN PATRICIO");
			 
		}

		void Tonaya_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tonaya,"TONAYA");
			
		}

		void SanGabriel_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanGabriel,"SAN GABRIEL");
			 
		}
		
		void CiudadGuzan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(CiudadGuzman,"CIUDAD GUZMAN");
			
		}
		
		void ZacoalcoDeTorres_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(ZacoalcoDeTorres,"ZACOALCO DE TORRES");
			 
		}
		void Sayula_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Sayula,"SAYULA");
			 
		}
		void TechalutaDEMontenegro_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TechalutaDeMontenegro,"TECHALUTA DE MONTENEGRO");
			 
		}
		void AtemajacDEBrizuel_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(AtemajacDeBrizuela,"ATEMAJAC DE BRIZUELA");
			 
		}
		void Tapalpa_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tapalpa,"TAPALPA");
			 
		}
		
		void SanPedroTesistan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanPedroTesistan,"SAN PEDRO TESISTAN");
			 
		}

		void TizapanElAlto_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TizapanElAlto,"TIZAPAN EL ALTO");
			 
		}
		void LaManzanillaDeLaPaz_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(LaManzanillaDeLaPaz,"LA MANZANILLA DE LA PAZ");
			 
		}
		void ConcepcionDeBuenosAires_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(ConcepcionDeBuenosAires,"CONCEPCION DE BUENOS AIRES");
			 
		}
		void TamazulaDeGordiano_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TamazulaDeGordiano,"TAMAZULA DE GORDIANO");
			 
		}
		void Pihuamo_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Pihuamo,"PIHUAMO");
			 
		}
		void Cocula_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Cocula,"COCULA");
			 
		}

		void Tecolotlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tecolotlan,"TECOLOTLAN");
			 
		}
		void Juchitlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Juchitlan,"JUCHITLAN");
			 
		}

		void AcatlanDeJuarez_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(AcatlanDeJuarez,"ACATLAN DE JUAREZ");
		}
		void Tala_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tala,"TALA");
		}
		void Ameca_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ameca,"AMECA");
		}
		void Teuchitlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Teuchitlan,"TEUCHITLAN");
		}
		void Etzatlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Etzatlan,"ETZATLAN");
		}
		void Amatitlan_MouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Amatitlan,"AMATITLAN");
		}

		void TequilaMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tequila,"TEQUILA");
		}
		void MagdalenaMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Magdalena,"MAGDALENA");
		}

		void ColotlanMouseEnter(object sender, EventArgs e)
		{
			
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Colotlan,"COLOTLAN");
		}

		void MezcalaMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Mezcala,"MEZCALA");
		}
		void OcotlanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ocotlan,"OCOTLAN");
		}
		void JamayMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Jamay,"JAMAY");
		}

		void ZapotlanejoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Zapotlanejo,"ZAPOTLANEJO");
		}

		void PoncitlanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Poncitlan,"PONCITLAN");
		}

		void LaBarcaMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(LaBarca,"LA BARCA");
		}

		void YahualicaDeGonzalezGalloMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(YahualicaDeGonzalezGallo,"YAHUALICA DE GONZALEZ GALLO");
		}
	
		void CuquioMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Cuquio,"CUQUIO");
		}

		void IxtlahuacanDelRioMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(IxtlahuacanDelRio,"IXTLAHUACAN DEL RIO");
		}

		void TepatitlanDeMorelosMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(TepatitlanDeMorelos,"TEPATITLAN DE MORELOS");
		}

		void AcaticMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Acatic,"ACATIC");
		}

		void TototlanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Tototlan,"TOTOTLAN");
		}

		void AtotonilcoElAltoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(AtotonilcoElAlto,"ATOTONILCO EL ALTO");
		}

		void MexticacanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Mexticacan,"MEXTICACAN");
		}

		void CanadasDeObregonMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(CanadasDeObregon,"CAÑADAS DE OBREGON");
		}

		void JalostotitlanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Jalostotitlan,"JALOSTOTITLAN");
		}

		void LagosDeMorenoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(LagosDeMoreno,"LAGOS DE MORENO");
		}

		void SanJuanDeLosLagosMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanJuanDeLosLagos,"SAN JUAN DE LOS LAGOS");
		}

		void EncarnacionDeDiazMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(EncarnacionDeDiaz,"ENCARNACION DE DIAZ");
		}

		void VillaHidalgoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(VillaHidalgo,"VILLA HIDALGO");
		}

		void TeocalticheMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Teocaltiche,"TEOCALTICHE");
		}

		void ValleDeGuadalupeMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(ValleDeGuadalupe,"VALLE DE GUADALUPE");
		}

		void SanMiguelElAltoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanMiguelElAlto,"SAN MIGUEL EL ALTO");
		}

		void UnionDeSanAntonioMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(UnionDeSanAntonio,"UNION DE SAN ANTONIO");
		}
	
		void SanDiegoDeAlejandriaMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanDiegoDeAlejandria,"SAN DIEGO DE ALEJANDRIA");
		}

		void SanJulianMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanJulian,"SAN JULIAN");
		}

		void ArandasMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Arandas,"ARANDAS");
		}

		void SanIgnacioCerroGordoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(SanIgnacioCerroGordo,"SAN IGNACIO CERRO GORDO");
		}

		void CapillaDeGuadalupeMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(CapillaDeGuadalupe,"CAPILLA DE GUADALUPE");
		}

		void DegolladoMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Degollado,"DEGOLLADO");
		}
		void AyotlanMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ayotlan,"AYOTLAN");
		}

		void OjuelosMouseEnter(object sender, EventArgs e)
		{
			var mensaje = new ToolTip();
			mensaje.SetToolTip(Ojuelos,"OJUELOS");
		}
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			//Dibujar Y Agregar Conexiones:
			
			AddConnection(18.1,PuertoVallarta.Name,Mismaloya.Name);
			AddConnection(67.9,PuertoVallarta.Name,SanSebastianDelOeste.Name);
			AddConnection(97.1,PuertoVallarta.Name,Mascota.Name);
			AddConnection(97,PuertoVallarta.Name,TalpaDeAllende.Name);
			
			AddConnection(32,Mismaloya.Name,ElTuito.Name);
			
			AddConnection(38.2,Yelapa.Name,ElTuito.Name);
			AddConnection(129,TalpaDeAllende.Name,ElTuito.Name);
			AddConnection(29.3,TalpaDeAllende.Name,Mascota.Name);
			AddConnection(48,Mascota.Name,SanSebastianDelOeste.Name);
			AddConnection(67.9,Mascota.Name,Mixtlan.Name);
			AddConnection(181,SanSebastianDelOeste.Name,Etzatlan.Name);
			AddConnection(54.1,Mixtlan.Name,Ayutla.Name);
			AddConnection(84.6,Ayutla.Name,TalpaDeAllende.Name);
			AddConnection(87.3,Ayutla.Name,Mascota.Name);
			AddConnection(42.5,Ayutla.Name,Tecolotlan.Name);
			AddConnection(29.1,Ayutla.Name,UnionDeTula.Name);
			AddConnection(30.3,Ayutla.Name,Juchitlan.Name);
			AddConnection(36.2,UnionDeTula.Name,AutlanDeNavarro.Name);
			AddConnection(29.7,UnionDeTula.Name,ElGrullo.Name);
			AddConnection(18.1,AutlanDeNavarro.Name,ElGrullo.Name);
			AddConnection(30.7,Tonaya.Name,ElGrullo.Name);
			AddConnection(32.4,Tonaya.Name,SanGabriel.Name);
			AddConnection(36.5,Tapalpa.Name,SanGabriel.Name);
			AddConnection(41.5,Sayula.Name,SanGabriel.Name);
			AddConnection(31.3,Tapalpa.Name,AtemajacDeBrizuela.Name);
			AddConnection(61.9,AutlanDeNavarro.Name,VillaPurificacion.Name);
			AddConnection(167,VillaPurificacion.Name,ElTuito.Name);
			AddConnection(173,ElTuito.Name,SanPatricio.Name);
			AddConnection(106,SanPatricio.Name,AutlanDeNavarro.Name);
			AddConnection(4.6,SanPatricio.Name,BarraDeNavidad.Name);
			AddConnection(16,SanPatricio.Name,Cihuatlan.Name);
			AddConnection(16.3,Cihuatlan.Name,BarraDeNavidad.Name);
			AddConnection(106,SanPatricio.Name,AutlanDeNavarro.Name);
			AddConnection(120,Cihuatlan.Name,AutlanDeNavarro.Name);
			AddConnection(16.4,Juchitlan.Name,Tecolotlan.Name);
			AddConnection(41.6,Tecolotlan.Name,Cocula.Name);
			AddConnection(57.2,Tecolotlan.Name,AtemajacDeBrizuela.Name);
			AddConnection(63.5,Tecolotlan.Name,Tapalpa.Name);
			AddConnection(97.5,Tapalpa.Name,ElGrullo.Name);
			AddConnection(46.4,Tapalpa.Name,Sayula.Name);
			AddConnection(105,Ameca.Name,Ayutla.Name);
			AddConnection(66.9,ZacoalcoDeTorres.Name,CiudadGuzman.Name);
			AddConnection(36.2,Sayula.Name,CiudadGuzman.Name);
			AddConnection(62,CiudadGuzman.Name,SanGabriel.Name);
			AddConnection(64.7,CiudadGuzman.Name,Pihuamo.Name);
			AddConnection(73.1,TamazulaDeGordiano.Name,Pihuamo.Name);
			AddConnection(37,TamazulaDeGordiano.Name,CiudadGuzman.Name);
			AddConnection(47.7,TamazulaDeGordiano.Name,Mazamitla.Name);
			AddConnection(76.3,CiudadGuzman.Name,Tonaya.Name);
			AddConnection(55.1,Ameca.Name,Mixtlan.Name);
			AddConnection(93.1,Ameca.Name,Jocotepec.Name);
			AddConnection(35.5,Ameca.Name,Cocula.Name);
			AddConnection(65.9,Ameca.Name,Tecolotlan.Name);
			AddConnection(115,Ameca.Name,AtemajacDeBrizuela.Name);
			AddConnection(92.3,Ameca.Name,ZacoalcoDeTorres.Name);
			AddConnection(41.1,Ameca.Name,Tala.Name);
			AddConnection(45.2,Ameca.Name,Teuchitlan.Name);
			AddConnection(44.8,Ameca.Name,Etzatlan.Name);
			AddConnection(29.8,Teuchitlan.Name,Etzatlan.Name);
			AddConnection(17.7,Teuchitlan.Name,Tala.Name);
			AddConnection(26.2,Etzatlan.Name,Magdalena.Name);
			AddConnection(44.6,Etzatlan.Name,Tequila.Name);
			AddConnection(18.3,Magdalena.Name,Tequila.Name);
			AddConnection(12.2,Tequila.Name,Amatitlan.Name);
			AddConnection(59.8,Tequila.Name,Zapopan.Name);
			AddConnection(62,Tequila.Name,Tala.Name);
			AddConnection(36.1,Tala.Name,Amatitlan.Name);
			AddConnection(40.4,Tala.Name,Zapopan.Name);
			AddConnection(10,Guadalajara.Name,Zapopan.Name);
			AddConnection(5.4,Guadalajara.Name,Tlaquepaque.Name);
			AddConnection(16.3,Guadalajara.Name,Tonala.Name);
			AddConnection(29.9,Guadalajara.Name,Cajititlan.Name);
			AddConnection(24.9,Guadalajara.Name,TlajomulcoDeZuniga.Name);
			AddConnection(78.4,Guadalajara.Name,Cuquio.Name);
			AddConnection(46.8,Guadalajara.Name,IxtlahuacanDelRio.Name);
			AddConnection(83.1,Cuquio.Name,Zapopan.Name);
			AddConnection(207,Colotlan.Name,Zapopan.Name);
			AddConnection(28,Tlaquepaque.Name,Cajititlan.Name);
			AddConnection(10.9,Tlaquepaque.Name,Tonala.Name);
			AddConnection(43.7,Tlaquepaque.Name,Chapala.Name);
			AddConnection(30,Chapala.Name,Cajititlan.Name);
			AddConnection(67.3,TlajomulcoDeZuniga.Name,Chapala.Name);
			AddConnection(11,Ajijic.Name,Chapala.Name);
			AddConnection(20.3,Mezcala.Name,Chapala.Name);
			AddConnection(57.6,Ocotlan.Name,Chapala.Name);
			AddConnection(18.3,Ajijic.Name,Jocotepec.Name);
			
			
		}
		
		void BtnDFBClick(object sender, EventArgs e)
		{
			var recorrido = new RecorridoProfundidad(Buttons,false);
			recorrido.ShowDialog();
			var nodo = recorrido.seleccionOrigen;
			recorrido.Dispose();
			
			var List = Grafo.Depth_Travel(nodo);
			
			for(int i = 0; i < List.Size();i++){
				if(i == List.Size() - 1){
					Draw(Get_Real_Point(List[i])); //Draw Point
					Color_Button(List[i]);
					Draw_Line(Get_Point(List[i]),Get_Point(List[i]));
				}
				else{
					Draw(Get_Real_Point(List[i])); //Draw Point
					Color_Button(List[i]);
					Draw_Line(Get_Point(List[i]),Get_Point(List[i+1]));
					
				}
				
				Thread.Sleep(250);
				
				
			}

			MessageBox.Show("Recorrido Realizado","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
			
			var Results = new Resultados_Recorridos(List,nodo,"");
			Results.ShowDialog();
			
			for(int i = 0; i < Buttons.Size();i++){
					Buttons[i].BackColor = Color.DarkBlue;
			}
			
			this.Refresh();
			List.Clear();
		}
		
		void Draw_Line(Point p, Point q){
			Graphics graphic = this.CreateGraphics();
			graphic.DrawLine(new Pen(Color.Green,2),p.X,p.Y,q.X,q.Y);
			graphic.Dispose();
		}

		void Draw(Point p){
			
			Graphics graphic = this.CreateGraphics();
			graphic.DrawEllipse(new Pen(Color.Green,5),new Rectangle(p.X,p.Y,20,20));
			graphic.FillEllipse(new SolidBrush(Color.Green),new Rectangle(p.X,p.Y,20,20));
			
			graphic.Dispose();
			
		}

		public void Color_Button(string nombre){
			for(int i = 0; i < Buttons.Size();i++){
				if(Buttons[i].Name == nombre){
					Buttons[i].BackColor = Color.Green;
				}
			}
		}
		
		void BtnRuta_AnchuraClick(object sender, EventArgs e)
		{
			var recorrido = new RecorridoProfundidad(Buttons,true);
			recorrido.ShowDialog();
			var nodoOrigen = recorrido.seleccionOrigen;
			var nodoDestino = recorrido.seleccionDestino;
			recorrido.Dispose();
			
			if(nodoOrigen.Length != 0 || nodoDestino.Length != 0){
				var lista = new List<string>();
				double peso = 0;
				var peso1 = Grafo.Dijsktra_Route(nodoOrigen,nodoDestino).secondData;
				var peso2 = Grafo.Dijsktra_Route(nodoDestino,nodoOrigen).secondData;
				
				if(peso2 < peso1){
					lista = Grafo.Dijsktra_Route(nodoDestino,nodoOrigen).firstData;
					peso = peso2;
					lista.Reverse();
				}else{
					lista = Grafo.Dijsktra_Route(nodoOrigen,nodoDestino).firstData;
					peso = peso1;
				}
			
				for(int i = 0; i < lista.Size();i++){
					if(i == lista.Size() - 1){
						Draw(Get_Real_Point(lista[i])); //Draw Point
						Color_Button(lista[i]);
						Draw_Line(Get_Point(lista[i]),Get_Point(lista[i]));
					}
					else{
						Draw(Get_Real_Point(lista[i])); //Draw Point
						Color_Button(lista[i]);
						Draw_Line(Get_Point(lista[i]),Get_Point(lista[i+1]));
						
					}
					
					Thread.Sleep(250);
					
				}
	
				MessageBox.Show("Ruta Realizada Correctamente\n\nCon Peso Total De "+peso+" km.","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
				var Results = new Resultados_Recorridos(lista,nodoOrigen,nodoDestino);
				Results.ShowDialog();
				
				for(int i = 0; i < Buttons.Size();i++){
					Buttons[i].BackColor = Color.DarkBlue;
				}
				
				this.Refresh();
				lista.Clear();
				
			}
				
		}
			
		
		void BtnAEMClick(object sender, EventArgs e)
		{
			var List = Grafo.Prim();
			
			for(int i = 0; i < List.Size();i++){
				
				Draw(Get_Real_Point(List[i].firstData)); //Draw Point
				Draw(Get_Real_Point(List[i].secondData)); //Draw Point
				Draw_Line(Get_Point(List[i].firstData),Get_Point(List[i].secondData));
				Thread.Sleep(250);
				
			}

			MessageBox.Show("Recorrido Realizado Correctamente","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);

			for(int i = 0; i < Buttons.Size();i++){
				Buttons[i].BackColor = Color.DarkBlue;
			}
			
			this.Refresh();
			List.Clear();
		}
		
		
		

	}
}
