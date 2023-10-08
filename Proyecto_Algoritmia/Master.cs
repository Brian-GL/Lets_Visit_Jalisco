/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 24/07/2019
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Proyecto_Algoritmia
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	/// 
	
	
	public class Graph<T>
	{
		//Edge
		public class GraphEdge<M>
		{
			public GraphEdge<M> nextEdge;
			public GraphNode<M> adyacentNode;
			public double weight;
			
			public GraphEdge(double peso, GraphNode<M> nodoAdyacente, GraphEdge<M> siguiente)
			{
				this.weight = peso;
				this.adyacentNode = nodoAdyacente;
				this.nextEdge = siguiente;
				
			}
			
			public override string ToString()
			{
				return string.Format("{0}", weight);
			}

		}
		//Node
		public class GraphNode<N>
		{
	
			public GraphNode<N> nextNode;
			public N data;
			public GraphEdge<N> adyacentEdge;
			
			public GraphNode(N dato, GraphNode<N> siguiente, GraphEdge<N> aristaAdyacente)
			{
				this.data = dato;
				this.nextNode = siguiente;
				this.adyacentEdge = aristaAdyacente;
				
			}
			
			public override string ToString()
			{
				return string.Format("{0}", data);
			}
			
			
			public int Number_Edges(){
				var auxiliar = this.adyacentEdge;
				if(auxiliar == null) return 0;
				else{
					var counter = 0;
					while(auxiliar != null){
						counter++;
						auxiliar = auxiliar.nextEdge;
					}
					return counter;
				}
				
			}
	
		}

		public class KruskalNode<O>{
			public GraphNode<O> origin;
			public double weight;
			public GraphNode<O> destination;
			public KruskalNode(GraphNode<O> origen, double peso, GraphNode<O> destino){
				this.origin = origen;
				this.weight = peso;
				this.destination = destino;
				
			}
		}
		
		private GraphNode<T> startNode;
		private int numberNodes;
		private int NumberEdges;
		
		public Graph()
		{
			startNode = null;
			numberNodes = 0;
			NumberEdges = 0;
		}
		~Graph(){
			Clear();
		}
		
		public bool Empty(){
			return startNode == null;
		}
		public int Size_Nodes(){
			return numberNodes;
		}
		
		public int Get_Position(GraphNode<T> node){
			int k = 0;
			var auxiliar = startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(node.data)) break;
				auxiliar = auxiliar.nextNode;
				k++;
			}
		 	return k;
		}
		
		public int Get_Position(T value){
			int k = 0;
			var auxiliar = startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(value)) break;
				auxiliar = auxiliar.nextNode;
				k++;
			}
		 	return k;
		}
		
		public int Size_Edges(){
			return NumberEdges;
		}
		
		public void Insert_Node(T element){
			if(!Exist(element)){
				if(Empty()){
					var newNode = new GraphNode<T>(element,null,null);
					startNode = newNode;
				}
				else{
					var auxiliar = startNode;
					while(auxiliar.nextNode != null){
						auxiliar = auxiliar.nextNode;
					}
					var newNode = new GraphNode<T>(element,null,null);
					auxiliar.nextNode = newNode;
				}
				
				numberNodes++;
			}

		}
		
		public bool Exist(T element){
			var auxiliar = startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(element)) return true;
				auxiliar = auxiliar.nextNode;
			}
			return false;
		}
		
		public GraphNode<T> Get_Node(T element){
			if(Exist(element)){
				var auxiliar = startNode;
				while(auxiliar != null){
					if(element.Equals(auxiliar.data)) break;
					auxiliar = auxiliar.nextNode;
				}
				
				return auxiliar;
			
			}
			else throw new Exception("THE NODE WITH SUCH A NAME DOES NOT EXIST");

		}
		
		public GraphNode<T> Get_Node(int pos){
			if(!Empty()){
				pos = pos % Size_Nodes();
				if(pos == 0) {
					return startNode;
				}
				else{
					var auxiliar = startNode;
					int cont = 0;
					while(cont < pos){
						auxiliar = auxiliar.nextNode;
						cont++;
					}
					
					return auxiliar;
				}
			}
			else{
				throw new Exception("EMPTY GRAPH");
			}
		}
		
		public void Insert_Edge(double value, T origen, T destino){
			if(!Exist_Edge(origen,destino)){
				var Origin = Get_Node(origen);
				var Destination = Get_Node(destino);
				
				var newEdge = new GraphEdge<T>(value,Destination,null);
				
				var auxiliar = Origin.adyacentEdge;
				
				if(auxiliar == null){
					
					Origin.adyacentEdge = newEdge;
				}
				else{
					while(auxiliar.nextEdge != null){
						auxiliar = auxiliar.nextEdge;
					}
					
					auxiliar.nextEdge = newEdge;
				}
				
				NumberEdges++;
			}
			
		}
		
		public bool Exist_Edge(T origen, T destino){
			var Origin = Get_Node(origen);
			var Destination = Get_Node(destino);
			var auxiliar = Origin.adyacentEdge;
			if(auxiliar == null){
				return false;
			}
			else{
				while(auxiliar != null){
					if(auxiliar.adyacentNode.data.Equals(Destination.data)) return true;
					auxiliar = auxiliar.nextEdge;
				}
				
				return false;
			}
		}

		public void Clear(){
			var counter = 0;
			var numNodes = Size_Nodes();
			
			while(counter < numNodes){
				Delete_Node(startNode.data);
				counter++;
			}
			
			NumberEdges = 0;
			numberNodes = 0;
			startNode = null;
		}
		
		public void Delete_Edge(T origin, T destination){
			var origen = Get_Node(origin);
			var destino = Get_Node(destination);
			
			int bandera = 0;
		    var ayudante_arista = origen.adyacentEdge;
		   	
		    if(ayudante_arista == null){
		    	MessageBox.Show("¡The Origin Node Has No Edges!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
		    }
		    else if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
		    	origen.adyacentEdge = ayudante_arista.nextEdge;
		    	ayudante_arista = null;
		    	NumberEdges--;
		    }
		    else{
				GraphEdge<T> auxiliar_arista = null;
		        while(ayudante_arista != null){
		
					if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
		                bandera = 1;
		                
		                auxiliar_arista.nextEdge = ayudante_arista.nextEdge;
		                ayudante_arista = null;
		                break;
		            }
		    		
		            auxiliar_arista = ayudante_arista;
		            ayudante_arista = ayudante_arista.nextEdge;
		            NumberEdges--;
		        }
		
		        if(bandera == 0) MessageBox.Show("¡Unbound Nodes!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
		    }
		}
		
		public void Delete_Node(T element){
			var Node = Get_Node(element);
			var auxiliar = startNode;
		    
		    GraphEdge<T> helper;
		
			//delete edges
		    while(auxiliar != null){
		
		        helper = auxiliar.adyacentEdge;
		        while(helper != null){
		
		        	if(helper.adyacentNode.data.Equals(Node.data)){
		        		Delete_Edge(auxiliar.data,helper.adyacentNode.data);
		        		Delete_Edge(helper.adyacentNode.data,auxiliar.data);
		                break;
		            }
		            helper = helper.nextEdge;
		        }
		
		        auxiliar = auxiliar.nextNode;
		    }
		
		    auxiliar = startNode;
		
		    if(startNode.data.Equals(Node.data)){
		        startNode = startNode.nextNode;
		        auxiliar = null;
		        numberNodes--;
		    }
		
		    else{
		    	GraphNode<T> auxiliar1 = null;
		    	
		    	while(auxiliar.data.Equals(Node.data)){
		            auxiliar1 = auxiliar;
		            auxiliar = auxiliar.nextNode;
		        }
		
		        auxiliar1.nextNode = auxiliar.nextNode;
		
		        auxiliar = null;
		        numberNodes--;
		    }

		}
		
		public int[,] Matrix(){
			int tam = Size_Nodes();
			var matriz = new int[tam,tam];
			int i = 0;
			
			for(int m = 0; m < tam; m++){
				for(int n = 0; n < tam;n++){
					matriz[m,n] = 0;
				}
			}
						
			var ayudante_vertice = startNode;
		
		    while(ayudante_vertice != null){
		        
		        var ayudante_arista = ayudante_vertice.adyacentEdge;
		        
		        if(ayudante_arista != null){
		        	

		        	 while(ayudante_arista != null){
		        		int valu = Get_Position(ayudante_arista.adyacentNode);
		        		
		        		if(valu != -1){
			        		matriz[i,valu] = 1;
			        		matriz[valu,i] = 1;
			        	}
		        		
			            ayudante_arista = ayudante_arista.nextEdge;
		        	}
		        }

		        ayudante_vertice = ayudante_vertice.nextNode;
		        i++;
		        
		    }
		    
		    return matriz;
		}
		
		public void Modify_Node(T value, T mod)
		{
			var Node = Get_Node(mod);
			var ayudante = startNode;
		
		    while(ayudante != null){
				if(ayudante.data.Equals(Node.data)) {
					ayudante.data = value;
		            break;
		        }
		        ayudante = ayudante.nextNode;
		    }
		
		}
		
		public void Modify_Edge(T origin, T destination, float weight)
		{
			 var origen = Get_Node(origin);
			 var destino = Get_Node(destination);
			 
		     var ayudante_arista = origen.adyacentEdge;
		     var auxiliar_arista = destino.adyacentEdge;
		
		     int banderauno = 0, banderados = 0;
		
		     if(ayudante_arista.adyacentNode.data.Equals(destino.data) 
		        && auxiliar_arista.adyacentNode.data.Equals(origen.data)){
		     	origen.adyacentEdge.weight = weight;
		         destino.adyacentEdge.weight = weight;
		     }
		     else{
		
		         while(ayudante_arista != null){
		
		     		if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
		                 ayudante_arista.weight = weight;
		                 banderauno = 1;
		                 break;
		     		}
		
		             ayudante_arista = ayudante_arista.nextEdge;
		
		         }
		
		         while(auxiliar_arista != null){
		     		if(auxiliar_arista.adyacentNode.data.Equals(origen.data)){
		                 auxiliar_arista.weight = weight;
		                 banderados = 1;
		                 break;
		     		}
		             auxiliar_arista = auxiliar_arista.nextEdge;
		         }
		
		
		     	if(banderauno == 0 || banderados == 0) MessageBox.Show("¡Nodes Not Connected To Each Other!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
		
		     }
		
		}
		
		public GraphNode<T> this[int index]{
			get {return this.Get_Node(index);}
		}
		
		public GraphEdge<T> this[int row, int column]{
			get {
				var auxiliar = Get_Node(row);
				var helper = auxiliar.adyacentEdge;
				var counter = 0;
				while(helper != null){
					if(counter == column) return helper;
					counter++;
					helper = helper.nextEdge;
				}
				
				throw new Exception("Invalid Position");
			}
		}
		
		//ALGORITHMS:
		
		//Recorrido en profundidad:
		public List<T> Depth_Travel(T value){
			var returnList = new List<T>();
			var Node_Stack = new Stack<GraphNode<T>>();
		    var visitedList = new List<T>();
		
		    Node_Stack.Push(Get_Node(value));
	
		    while(!Node_Stack.Empty()){
		        var actual = Node_Stack.Peek(); 
		        Node_Stack.Pop();
		
		        if(!visitedList.Contains(actual.data)){
		        	returnList.Push_Back(actual.data);
		        	visitedList.Push_Back(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){
		              
		            	if(!visitedList.Contains(auxiliar.adyacentNode.data)){
		            		Node_Stack.Push(auxiliar.adyacentNode);
		            	}
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO Visited
		
		    }//END Stack EMPTY

      		visitedList.Clear();
			
			return returnList;
		}
		
		//Recorrido De Anchura:
		public List<T> Width_Travel(T value){
			
			var returnList = new List<T>();
			var Node_Queue = new Queue<GraphNode<T>>();
		    var visitedList = new List<T>();
		
		    Node_Queue.Enqueue(Get_Node(value));
	
		    while(!Node_Queue.Empty()){
		         
		         var actual = Node_Queue.Peek(); Node_Queue.Dequeue();

		         if(!visitedList.Contains(actual.data)){
		         	
		         	returnList.Push_Back(actual.data);
		         	visitedList.Push_Back(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){
		               
		            	if(!visitedList.Contains(auxiliar.adyacentNode.data)){
		            		Node_Queue.Enqueue(auxiliar.adyacentNode);
		            	}
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    
		    return returnList;
		}
		
		//Ruta De Anchura:
		
		public List<T> Width_Path(T value1, T value2){
			var Node_Queue = new Queue<GraphNode<T>>();
			var returnList = new List<T>();
			var Node_Double_Stack = new Double_Stack<GraphNode<T>,GraphNode<T>>();
		    var visitedList = new List<T>();
		    var Destination = Get_Node(value2);
		
		    Node_Queue.Enqueue(Get_Node(value1));
		
		    while(!Node_Queue.Empty()){
		         var actual = Node_Queue.Peek();
		         Node_Queue.Dequeue();
		
		         if(!visitedList.Contains(actual.data)){
		
		         	if(actual.data.Equals(Destination.data)){
		
		               var  actual_Destination = Destination;
		
		                while(!Node_Double_Stack.Empty()){
		                	returnList.Push_Back(actual_Destination.data);
		                	while(!Node_Double_Stack.Empty() 
		                	      && !Node_Double_Stack.Peek().secondData.data.Equals(actual_Destination.data)){
		                        
		                		Node_Double_Stack.Pop();
		                    }
		                	if(!Node_Double_Stack.Empty()){
		                		actual_Destination = Node_Double_Stack.Peek().firstData;
		                    }
		                }
		
		                break;
		            }
		
		         	visitedList.Push_Back(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){

		                if(!visitedList.Contains(auxiliar.adyacentNode.data)) {
		                    Node_Queue.Enqueue(auxiliar.adyacentNode);
		                    Node_Double_Stack.Push(actual,auxiliar.adyacentNode);
		                }
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    
		    returnList.Reverse();
		    
		    return returnList;
		}
		
		//Ruta Profundidad
		public List<T> Depth_Path(T value1, T value2)
		{
			var returnList = new List<T>();
			var Node_Stack = new Stack<GraphNode<T>>();
			var Node_DoubleStack = new Double_Stack<GraphNode<T>,GraphNode<T>>();
		    var visitedList = new List<T>();
		    var Destination = Get_Node(value2);
		
		    Node_Stack.Push(Get_Node(value1));
		
		    while(!Node_Stack.Empty()){
		         var actual = Node_Stack.Peek(); 
		         Node_Stack.Pop();
		
		         if(!visitedList.Contains(actual.data)){
		
		         	if(actual.data.Equals(Destination.data)){
		         		var actual_Destination = Destination;
		
		         		while(!Node_DoubleStack.Empty()){
		         			returnList.Push_Back(actual_Destination.data);
		                    
		         			while(!Node_DoubleStack.Empty() 
		         			      && !Node_DoubleStack.Peek().secondData.data.Equals(actual_Destination.data)){
		                		
		         				Node_DoubleStack.Pop();
		                    }
		         			if(!Node_DoubleStack.Empty()){
		         				actual_Destination = Node_DoubleStack.Peek().firstData;
		                    }
		                }
		
		                break;
		            }
		
		         	visitedList.Push_Back(actual.data);
		            var ayudante = actual.adyacentEdge;
		
		            while(ayudante != null){
		            
		            	if(!visitedList.Contains(ayudante.adyacentNode.data)) {
		                    Node_Stack.Push(ayudante.adyacentNode);
		                    Node_DoubleStack.Push(actual,ayudante.adyacentNode);
		                }
		
		                ayudante = ayudante.nextEdge;
		
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    returnList.Reverse();
		    return returnList;
		}
		
		//Obtiene un arbol dependiendo de un valor del grafo
		public Tree<T> Get_Tree(T value){
			
			if(Empty()) throw new Exception("EMPTY GRAPH");
			else{
				var auxiliar = Get_Node(value).data; 

				var auxQueue_Tree_Nodes = new Queue<Tree_Node<T>>();
	
				var newTree = new Tree<T>(new Tree_Node<T>(null,value));
				auxQueue_Tree_Nodes.Enqueue(newTree.Root);
				
				while(!auxQueue_Tree_Nodes.Empty()){
						
					auxiliar = auxQueue_Tree_Nodes.Peek().data;
					var auxEdge = Get_Node(auxiliar).adyacentEdge;
					
					while(auxEdge != null){
						
						if(!auxQueue_Tree_Nodes.Peek().Get_Value_Fathers().Contains(auxEdge.adyacentNode.data)){
							var newTree_Node = new Tree_Node<T>(auxQueue_Tree_Nodes.Peek(),auxEdge.adyacentNode.data);
							auxQueue_Tree_Nodes.Peek().Add_Son(newTree_Node);
							auxQueue_Tree_Nodes.Enqueue(newTree_Node);
						}
						
						auxEdge = auxEdge.nextEdge;
					}
					
					auxQueue_Tree_Nodes.Dequeue();
					
				}
	
				return newTree;
			}
			
		}
		
		//Ruta de dijsktra
		public Pair<List<T>,double> Dijsktra_Route(T value1, T value2){
			
			var returnList = new List<T>();
			double actualCost = 0;
			var actualNode = Get_Node(value1);
			var Destination = Get_Node(value2);
			
			var costList = new List<Pair<GraphNode<T>,double>>();
			var sortedList = new List<Pair<GraphNode<T>,double>>();
			var Node_DoubleStack = new Double_Stack<GraphNode<T>,GraphNode<T>>();

			costList.Push_Back(new Pair<GraphNode<T>,double>(actualNode,0));
			sortedList.Push_Back(new Pair<GraphNode<T>,double>(actualNode,0));
			
			while(!sortedList.Empty()){//Mientras la lista ordenada no este vacia:
				actualNode = sortedList[0].firstData;
				actualCost = sortedList[0].secondData;
				
				sortedList.Erase_At(0);
				
				if(actualNode.data.Equals(Destination.data)){//si el vertice actual es igual al vertice destino:
					//desplegar ruta:
					var actualDestination = Destination;
					while(!Node_DoubleStack.Empty()){
						returnList.Push_Back(actualDestination.data);
						while(!Node_DoubleStack.Empty() && !Node_DoubleStack.Peek().secondData.data.Equals(actualDestination.data)){
							Node_DoubleStack.Pop();
						}
						if(!Node_DoubleStack.Empty()){
							actualDestination = Node_DoubleStack.Peek().firstData;
						}
					}
					
					break;
				}

				var auxiliarEdge = actualNode.adyacentEdge;
				
				while(auxiliarEdge != null){
					var existing = false;
					actualCost+=auxiliarEdge.weight;
					for(int i = 0; i < costList.Size();i++){
						if(auxiliarEdge.adyacentNode.data.Equals(costList[i].firstData.data)){
							existing = true;
							if(actualCost < costList[i].secondData){
								costList[i].secondData = actualCost;
								for(int k = 0; k < sortedList.Size();k++){
									if(sortedList[k].firstData.data.Equals(costList[i].firstData.data)){
										sortedList[k].secondData = actualCost;
										break;
									}
								}
								
								sortedList = Sort(sortedList);
								Node_DoubleStack.Push(actualNode,auxiliarEdge.adyacentNode);
								actualCost-=auxiliarEdge.weight;
							}
							
							break;
						}
					}
					if(!existing){
						costList.Push_Back(new Pair<GraphNode<T>,double>(auxiliarEdge.adyacentNode,actualCost));
						sortedList.Push_Back(new Pair<GraphNode<T>,double>(auxiliarEdge.adyacentNode,actualCost));
						sortedList = Sort(sortedList);
						Node_DoubleStack.Push(actualNode,auxiliarEdge.adyacentNode);
						actualCost-=auxiliarEdge.weight;
					}
					
					auxiliarEdge = auxiliarEdge.nextEdge;
				}
				
			}
			
			costList.Clear();
			
			returnList.Reverse();
			
			return new Pair<List<T>,double>(returnList,actualCost);
			
		}
		
		public static List<Pair<GraphNode<T>,double>> Sort(List<Pair<GraphNode<T>,double>> list){
			
			for(int i = 0; i < list.Size();i++){
				var min = i;
				for(int j = i+1;j < list.Size();j++){
					if(list[j].secondData < list[min].secondData){
						min = j;
					}
				}
				
				//intercambio
				
				var intercambio = list[i];
       			list[i] = list[min];
        		list[min] = intercambio;
				
			}
			
			return list;

		}
		
//		public List<T> Dijsktra(T value1, T value2){
//			var newList = new List<T>();
//			var newTree = Get_Tree(value1);
//			var leafsList = newTree.Get_Node_Leafs();
//			var list = new List<double>();
//			var Destination = Get_Node(value2);
//			
//			for(int i = 0; i < leafsList.Size();i++){
//				var cost = 0.0;
//				var getList = newTree.Get_SubList(leafsList[i],Destination.data);
//				for(int j = 0; j < getList.Size();j++){
//					cost+= Get_Node(getList[i].data).adyacentEdge.weight;
//				}
//				list.Push_Back(cost);
//			
//			}
//			
//			
//			var lista = newTree.Get_SubList(leafsList[Minumum(list)],Destination.data);
//			for(int i = 0; i < lista.Size();i++){
//				newList.Push_Back(lista[i].data);
//			}
//			
//			return newList;
//		}
		
//		public static int Minumum(List<double> lista){
//			var num = 0;
//			for(int i = 0;i < lista.Size();i++){
//				for(int j = 0;j < lista.Size();j++){
//					if(lista[j] < lista[i]){
//						num = j;
//					}
//				}	
//			}
//			return num;
//		}
		
		public List<Pair<T,T>> Kruskal(){
			
			var returnList = new List<Pair<T,T>>(); //la lista de las conexiones a retornar
			
			var listaDeVisitados = new List<KruskalNode<T>>(); //lista que nos ayudara a guardar las conexiones que no generan ciclos
			var listaDeAristas = new List<KruskalNode<T>>(); //lista de todas las conexiones
			var listaAuxiliar = new List<KruskalNode<T>>();
			
			var ayudante_vertice = startNode;
			while(ayudante_vertice != null){
				var ayudante_arista = ayudante_vertice.adyacentEdge;
				while(ayudante_arista != null){
					
					//Verificacion:
					
					if(!ayudante_vertice.data.Equals(ayudante_arista.adyacentNode.data)){
						
						bool se_agrega = true;
						for(int i = 0; i < listaDeAristas.Size();i++){
							if(listaDeAristas[i].origin.data.Equals(ayudante_arista.adyacentNode.data)
							   && listaDeAristas[i].destination.data.Equals(ayudante_vertice.data)){
								se_agrega = false; break;
							}
						}
					
						if(se_agrega){
							listaDeAristas.Push_Back(new KruskalNode<T>(ayudante_vertice,ayudante_arista.weight,ayudante_arista.adyacentNode));
						}
						
					}
					
					
					ayudante_arista = ayudante_arista.nextEdge;
				}
				ayudante_vertice = ayudante_vertice.nextNode;
			}
		
			//ordenamos la lista del menor a mayor
			for (int i = 0; i < listaDeAristas.Size(); ++i) {
		        var min = i;
		        for (int j = i+1; j < listaDeAristas.Size(); ++j) {
		            if(listaDeAristas[j].weight < listaDeAristas[min].weight){
		                min = j;
		            }
		
		        }
		
		        var intercambio = listaDeAristas[i];
		        listaDeAristas[i] = listaDeAristas[min];
		        listaDeAristas[min] = intercambio;
		
		    }
			
			
			for(int i = 0; i < listaDeAristas.Size();i++){
				listaAuxiliar.Push_Back(listaDeAristas[i]);
				listaAuxiliar.Push_Back(new KruskalNode<T>(listaDeAristas[i].destination,listaDeAristas[i].weight,listaDeAristas[i].origin));
			}
			
			listaDeAristas.Clear();

			
			if(listaAuxiliar.Size() <= 4){ //Solo hay una o dos conexion (A -> B v B -> C) Por ejemplo, lo cual no genera conexiones ciclicas
				
				for(int i = 0; i < listaAuxiliar.Size();i+=2){
					listaDeVisitados.Push_Back(listaAuxiliar[i]);
				}
				
			}
			else{ //Ya hay mas de dos conexiones, lo que implica que pueden existir ciclos
				
				
				//agregamos los primeros valores iniciales:
				
				listaDeAristas.Push_Back(listaAuxiliar[0]);
				listaDeAristas.Push_Back(listaAuxiliar[1]);
				listaDeAristas.Push_Back(listaAuxiliar[2]);
				listaDeAristas.Push_Back(listaAuxiliar[3]);
				
				for(int i = 0; i < 4;i+=2){
					listaDeVisitados.Push_Back(listaAuxiliar[i]);	
				}

				int posicion = 4;
				
				while(listaDeVisitados.Size() < (Size_Edges()-1)){ //Mientras el tamaño de la lista de visitados sea menor al numero de nodos - 1, podemos añadir a la lista de visitados.
					
					//Revision: 
					
					bool genera_poligono = false;
					
					//contamos cuantas veces existe listaAuxiliar[posicion] en su campo destino:
					int numApariciones = 0;
					
					for(int i = 0; i < listaDeAristas.Size();i++){
						if(listaAuxiliar[posicion].destination.data.Equals(listaDeAristas[i].origin.data)){
							numApariciones++;
						}
					}
					
					int indice_aparicion = 0;
					for(int k = 0; k < numApariciones;k++){
						
						var comparador = listaAuxiliar[posicion]; //generamos un valor comparador que nos comparará las aristas, para que no existan ciclos
						
						int contador = 0;
						
						
						if(k == 0){ //aqui no importa el indice de aparicion
							
							while(contador < listaDeAristas.Size()){
							
								for(int i = 0; i < listaDeAristas.Size();i++){
									if(comparador.destination.data.Equals(listaDeAristas[i].origin.data) //si el comparador en su campo destino existe en alguno de los origenes, y que este en su campo destino sea desigual al comparador en su campo origen ( F -> E != E -> F) Por Ejemplo
									   && (!listaDeAristas[i].destination.data.Equals(comparador.origin.data))){
										indice_aparicion = i;
										comparador = listaDeAristas[i];
										if(comparador.destination.data.Equals(listaAuxiliar[posicion].origin.data)){ //si el nuevo valor del comparador es igual a la listaDeAristas[posicion].origen, entonces ahi es donde genera un ciclo.
											genera_poligono = true;
											break;
										}//end comparador if
										
										break;
										
									}//end if
									
								}//end for
								
								if(genera_poligono) break;
								
								contador++;
								
							}//end while
								
						}//end if primera iteracion
						
						else{//aqui si importa
							
							while(contador < listaDeAristas.Size()){
								
								for(int i = 0; i < listaDeAristas.Size();i++){
									if(comparador.destination.data.Equals(listaDeAristas[i].origin.data) //si el comparador en su campo destino existe en alguno de los origenes, y que este en su campo destino sea desigual al comparador en su campo origen ( F -> E != E -> F) Por Ejemplo
									   && (!listaAuxiliar[i].destination.data.Equals(comparador.origin.data)) && i != indice_aparicion){
										//revisar que ya no exista en algun indice de aparicion:
										indice_aparicion = i;
										comparador = listaDeAristas[i];
										if(comparador.destination.data.Equals(listaAuxiliar[posicion].origin.data)){ //si el nuevo valor del comparador es igual a la listaDeAristas[posicion].origen, entonces ahi es donde genera un ciclo.
											genera_poligono = true;
											break;
										}
										break;
									}//end if
								}//end for
								
								if(genera_poligono) break;
								
								contador++;
								
							}//end while contador
							
						}//end else pimera en adelante iteracion
						
						
					}//end for
					
					//Agregamos a la lista si no genera poligono
					
					if(!genera_poligono){
						listaDeVisitados.Push_Back(listaAuxiliar[posicion]);
						
						listaDeAristas.Push_Back(listaAuxiliar[posicion]);
						int posi = posicion+1;
						listaDeAristas.Push_Back(listaAuxiliar[posi]);
						
					}
					
					posicion+=2;
					
					if(posicion == listaAuxiliar.Size()) break;
					
				}
				
			}//end else hay mas de dos conexiones
			
			for(int i = 0; i < listaDeVisitados.Size();i++){ //Aqui llenamos la lista a retornar
				returnList.Push_Back(new Pair<T,T>(listaDeVisitados[i].origin.data,listaDeVisitados[i].destination.data));

			}
			
			listaDeAristas.Clear();
			listaDeVisitados.Clear();
			
			
			return returnList;
			
		}
		
		public List<Pair<T,T>> Prim(){
			
			var lista_a_retornar = new List<Pair<T,T>>(); //la lista de las conexiones a retornar
			
			var listaDeVisitados = new List<KruskalNode<T>>(); //lista que nos ayudara a guardar las conexiones que no generan ciclos
			var listaDeAristas = new List<KruskalNode<T>>(); //lista de todas las conexiones
			var listaAuxiliar = new List<KruskalNode<T>>();
			
			var listaDeVistos = new List<KruskalNode<T>>();
			
			var ayudante_vertice = startNode;
			while(ayudante_vertice != null){
				var ayudante_arista = ayudante_vertice.adyacentEdge;
				while(ayudante_arista != null){
					
					//Verificacion:
					
					if(!ayudante_vertice.data.Equals(ayudante_arista.adyacentNode.data)){
						
						bool se_agrega = true;
						for(int i = 0; i < listaDeAristas.Size();i++){
							if(listaDeAristas[i].origin.data.Equals(ayudante_arista.adyacentNode.data)
							   && listaDeAristas[i].destination.data.Equals(ayudante_vertice.data)){
								se_agrega = false; break;
							}
						}
					
						if(se_agrega){
							listaDeAristas.Push_Back(new KruskalNode<T>(ayudante_vertice,ayudante_arista.weight,ayudante_arista.adyacentNode));
						}
						
					}
					
					ayudante_arista = ayudante_arista.nextEdge;
				}
				ayudante_vertice = ayudante_vertice.nextNode;
			}
		
			//ordenamos la lista del menor a mayor
			for (int i = 0; i < listaDeAristas.Size(); ++i) {
		        var min = i;
		        for (int j = i+1; j < listaDeAristas.Size(); ++j) {
		            if(listaDeAristas[j].weight < listaDeAristas[min].weight){
		                min = j;
		            }
		
		        }
		
		        var intercambio = listaDeAristas[i];
		        listaDeAristas[i] = listaDeAristas[min];
		        listaDeAristas[min] = intercambio;
		
		    }
					
			for(int i = 0; i < listaDeAristas.Size();i++){
				listaAuxiliar.Push_Back(listaDeAristas[i]);
				listaAuxiliar.Push_Back(new KruskalNode<T>(listaDeAristas[i].destination,listaDeAristas[i].weight,listaDeAristas[i].origin));
			}
			
			listaDeAristas.Clear();
		

			
			if(listaAuxiliar.Size() <= 2){ //Solo hay una conexion
				
				listaDeVisitados.Push_Back(listaAuxiliar.First());
			
			}
			else if(listaAuxiliar.Size() > 2 && listaAuxiliar.Size() <= 4 ){
				listaDeVisitados.Push_Back(listaAuxiliar.First());
				for(int i = 1; i < listaAuxiliar.Size();i++){

					if(listaAuxiliar[i].origin.data.Equals(listaAuxiliar.First().origin.data) ||
					   listaAuxiliar[i].destination.data.Equals(listaAuxiliar.First().destination.data)){
						listaDeVisitados.Push_Back(listaAuxiliar[i]);
						break;
					}

				}//end for i
			}
			else{ //Ya hay mas de dos conexiones, lo que implica que pueden existir ciclos
				
				//agregamos los primeros valores iniciales:
				
				
				listaDeVistos.Push_Back(listaAuxiliar[0]);
				listaDeVistos.Push_Back(listaAuxiliar[1]);
								
				listaDeVisitados.Push_Back(listaAuxiliar.First());
				
				
				while(listaDeVisitados.Size() < (Size_Edges()-1)){ //Mientras el tamaño de la lista de visitados sea menor al numero de nodos - 1, podemos añadir a la lista de visitados.
					
					var minimo = listaDeVisitados.Last();
					
					//tomar el menor asociado tanto al nodo origen como el del destino:
					
					var listaDeAsociaciones = new List<KruskalNode<T>>();
					
					for(int i = 0; i < listaAuxiliar.Size();i++){ //for para origen
						if(listaAuxiliar[i].origin.data.Equals(minimo.origin.data) 
						   && !listaAuxiliar[i].destination.data.Equals(minimo.destination.data)){
							bool se_agrega_a_la_lista = true;
							for(int j = 0; j < listaDeVistos.Size();j++){
								if(listaDeVistos[j].origin.data.Equals(listaAuxiliar[i].origin.data) 
								   && listaDeVistos[j].destination.data.Equals(listaAuxiliar[i].destination.data)){
									se_agrega_a_la_lista = false; break;
								}
							}
							if(se_agrega_a_la_lista) listaDeAsociaciones.Push_Back(listaAuxiliar[i]);
						}
						
					}//end llenar lista de asociaciones para minimo.origen
					
					for(int i = 0; i < listaAuxiliar.Size();i++){ //for para origen
						if(listaAuxiliar[i].origin.data.Equals(minimo.destination.data) 
						   && !listaAuxiliar[i].destination.data.Equals(minimo.origin.data)){
							
							bool se_agrega_a_la_lista = true;
							for(int j = 0; j < listaDeVistos.Size();j++){
								if(listaDeVistos[j].origin.data.Equals(listaAuxiliar[i].origin.data) 
								   && listaDeVistos[j].destination.data.Equals(listaAuxiliar[i].destination.data)){
									se_agrega_a_la_lista = false; break;
								}
							}
							
							if(se_agrega_a_la_lista) listaDeAsociaciones.Push_Back(listaAuxiliar[i]);
						}
						
					}//end llenar lista de asociaciones minimo .destino
					
									
					//si la lista de asociaciones esta vacia, esto quiere decir que ya no existen conexiones
					//por lo que se acaba el llenado
					if(listaDeAsociaciones.Size() == 0) break;
					
//					for(int i = 0; i < listaDeAsociaciones.Count;i++){
//						MessageBox.Show(listaDeAsociaciones[i].origen.dato+" | "+listaDeAsociaciones[i].destino.dato,"listaDeAsociaciones");
//					}
					
					//esa lista de asociaciones se ordena de menor a mayor peso:
					
					for (int i = 0; i < listaDeAsociaciones.Size(); ++i) {
				        var min = i;
				        for (int j = i+1; j < listaDeAsociaciones.Size(); ++j) {
				            if(listaDeAsociaciones[j].weight < listaDeAsociaciones[min].weight){
				                min = j;
				            }
				
				        }
				
				        var intercambio = listaDeAsociaciones[i];
				        listaDeAsociaciones[i] = listaDeAsociaciones[min];
				        listaDeAsociaciones[min] = intercambio;
				
				    }
					

					for(int m = 0; m < listaDeAsociaciones.Size();m++){ //vamos tomando de menor a mayor para ver si esa conexion es valida
						//Revision: 
					
						//contamos cuantas veces existe listaAuxiliar[posicion] en su campo destino:
						int numApariciones = 0;
						
						for(int i = 0; i < listaDeVistos.Size();i++){
							if(listaDeAsociaciones[m].destination.data.Equals(listaDeVistos[i].origin.data)){
								numApariciones++;
							}
						}
						
						bool genera_poligono = false;
						
						var lista_indices_apariciones = new List<int>();
						
						for(int k = 0; k < numApariciones;k++){
							
							var comparador = listaDeAsociaciones[m]; //generamos un valor comparador que nos comparará las aristas, para que no existan ciclos
							
							int contador = 0;
							
							if(k == 0){ //aqui no importa el indice de aparicion
								
								while(contador < listaDeVistos.Size()){
								
									for(int i = 0; i < listaDeVistos.Size();i++){
										if(comparador.destination.data.Equals(listaDeVistos[i].origin.data) //si el comparador en su campo destino existe en alguno de los origenes, y que este en su campo destino sea desigual al comparador en su campo origen ( F -> E != E -> F) Por Ejemplo
										   && (!listaDeVistos[i].destination.data.Equals(comparador.origin.data))){
											lista_indices_apariciones.Push_Back(i);
											comparador = listaDeVistos[i];
											if(comparador.destination.data.Equals(listaDeAsociaciones[m].origin.data)){ //si el nuevo valor del comparador es igual a la listaDeAristas[posicion].origen, entonces ahi es donde genera un ciclo.
												
												genera_poligono = true;
												
												break;
											}//end if comparador
											
										}//end if
									}//end for
									
									if(genera_poligono) break;
									
									contador++;
									
								}//end while
									
							}//end if primera iteracion
							
							else{//aqui si importa
								
								while(contador < listaDeVistos.Size()){
									
									for(int i = 0; i < listaDeVistos.Size();i++){
										if(comparador.destination.data.Equals(listaDeVistos[i].origin.data) //si el comparador en su campo destino existe en alguno de los origenes, y que este en su campo destino sea desigual al comparador en su campo origen ( F -> E != E -> F) Por Ejemplo
										   && (!listaDeVistos[i].destination.data.Equals(comparador.origin.data))){
											
											//revisar que ya no exista en algun indice de aparicion:
											bool se_continua = true;
											for(int n = 0; n < lista_indices_apariciones.Size();n++){
												if(lista_indices_apariciones[n] == i){
													se_continua = false; break;
												}
											}
											
											if(se_continua){
												lista_indices_apariciones.Push_Back(i);
												comparador = listaDeVistos[i];
												if(comparador.destination.data.Equals(listaDeAsociaciones[m].origin.data)){ //si el nuevo valor del comparador es igual a la listaDeAristas[posicion].origen, entonces ahi es donde genera un ciclo.
													
													genera_poligono = true;
													break;
												}
											}//end se continua

										}//end if 
									}//end for
									
									if(genera_poligono) break;
									
									contador++;
									
								}//end while contador
								
							}//end else pimera en adelante iteracion
							
							if(genera_poligono) break;
							
							
						}//end for numero de aparciones
						
						lista_indices_apariciones.Clear();
						
						
						//Agregamos a la lista si no genera poligono
						
						if(!genera_poligono){
							
							listaDeVisitados.Push_Back(listaDeAsociaciones[m]);
							listaDeVistos.Push_Back(listaDeAsociaciones[m]);
							listaDeVistos.Push_Back(new KruskalNode<T>(listaDeAsociaciones[m].destination,listaDeAsociaciones[m].weight,listaDeAsociaciones[m].origin));
							break;
							
						}//end si no genera poligono lo metemos

							
					}//end for listaDeAsociaciones
					
					listaDeAsociaciones.Clear();

					
				}//end while listaVisitados.coutn == numverticos con aristas -1
				
			}//end else hay mas de dos conexiones
			
			for(int i = 0; i < listaDeVisitados.Size();i++){ //Aqui llenamos la lista a retornar
				lista_a_retornar.Push_Back(new Pair<T,T>(listaDeVisitados[i].origin.data,listaDeVisitados[i].destination.data));

			}
			
			listaDeAristas.Clear();
			listaDeVisitados.Clear();
			listaAuxiliar.Clear();
			listaDeVistos.Clear();
			
			return lista_a_retornar;
			
			
		}

	}

	public class Tree_Node<N>
	{
		public Tree_Node<N> Father;
		public List<Tree_Node<N>> Sons;
		public N data;
		
		public Tree_Node(Tree_Node<N> Padre, N Valor)
		{
			this.Father = Padre;
			this.data = Valor;
			this.Sons = new List<Tree_Node<N>>();
		}
		
		public Tree_Node(N Valor)
		{
			this.Father = null;
			this.data = Valor;
			this.Sons = new List<Tree_Node<N>>();
		}
		
		 public void Add_Son(Tree_Node<N> hijo) {
        	Sons.Push_Back(hijo);
    	}
		
		public bool Is_Father() {
			return !Sons.Empty();
    	}
		
		public bool Is_Leaf(){
			return Sons.Empty();
		}
		
		public List<Tree_Node<N>> Get_Fathers(){
			var returnList = new List<Tree_Node<N>>();
			var auxiliar = this;
			while(auxiliar != null){
				returnList.Push_Back(auxiliar);
				auxiliar = auxiliar.Father;
			}
			
			return returnList;
		}
		
		public List<N> Get_Value_Fathers(){
			var returnList = new List<N>();
			var auxiliar = this;
			while(auxiliar != null){
				returnList.Push_Back(auxiliar.data);
				auxiliar = auxiliar.Father;
			}
			
			return returnList;
		}
		
	}
	
	public class Tree<T>
	{

		public Tree_Node<T> Root;
		
		public Tree(Tree_Node<T> element){
			this.Root = element;
		}
		
		public bool Empty(){
			return Root == null;
		}
		
		public List<Tree_Node<T>> Get_Node_Leafs(){
			if(Empty()){
				throw new Exception("EMPTY TREE");
			}
			else{
				var aux_Queue = new Queue<Tree_Node<T>>();
				var leafs = new List<Tree_Node<T>>();
				aux_Queue.Enqueue(Root);
				
				while(!aux_Queue.Empty()){
					var auxiliar = aux_Queue.Peek();
					if(auxiliar.Is_Leaf()){
						leafs.Push_Back(auxiliar);
					}
					else{
						for(int i = 0; i < auxiliar.Sons.Size();i++){
							aux_Queue.Enqueue(auxiliar.Sons[i]);
						}
					}
					aux_Queue.Dequeue();
				}
				
				return leafs;
			}
			
		}
		
		public List<T> Get_Value_Leafs(){
			if(Empty()){
				throw new Exception("EMPTY TREE");
			}
			else{
				var aux_Queue = new Queue<Tree_Node<T>>();
				var leafs = new List<T>();
				aux_Queue.Enqueue(Root);
				
				while(!aux_Queue.Empty()){
					var auxiliar = aux_Queue.Peek();
					if(auxiliar.Is_Leaf()){
						leafs.Push_Back(auxiliar.data);
					}
					else{
						
						for(int i = 0; i < auxiliar.Sons.Size();i++){
							aux_Queue.Enqueue(auxiliar.Sons[i]);
						}
					}
					
					aux_Queue.Dequeue();
					
				}
				
				return leafs;
			}
			
		}
		
		public List<T> Get_All_Values(){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			var returnList = new List<T>();
			var auxQueue = new Queue<Tree_Node<T>>();
			auxQueue.Enqueue(Root);
			while(!auxQueue.Empty()){
				var auxiliar = auxQueue.Peek();
				returnList.Push_Back(auxiliar.data);
				if(!auxiliar.Is_Leaf()){
					for(int i = 0; i < auxiliar.Sons.Size();i++){
						auxQueue.Enqueue(auxiliar.Sons[i]);
					}
				}
				
				auxQueue.Dequeue();
			}
			
			return returnList;
		}

		public List<Tree_Node<T>> Get_All_Nodes(){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			var returnList = new List<Tree_Node<T>>();
			var auxQueue = new Queue<Tree_Node<T>>();
			auxQueue.Enqueue(Root);
			while(!auxQueue.Empty()){
				var auxiliar = auxQueue.Peek();
				returnList.Push_Back(auxiliar);
				if(!auxiliar.Is_Leaf()){
					for(int i = 0; i < auxiliar.Sons.Size();i++){
						auxQueue.Enqueue(auxiliar.Sons[i]);
					}
				}
				
				auxQueue.Dequeue();
			}
			
			return returnList;
		}
		
		public Tree_Node<T> Get_Node(T value){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			for(int i = 0; i < Get_All_Nodes().Size();i++){
				if(Get_All_Nodes()[i].data.Equals(value)) return Get_All_Nodes()[i];
			}
			
			throw new Exception("NODE DOES NOT EXIST");
		}
		
		public bool Contains(T Value){
			return Get_All_Values().Contains(Value);
		}
		
		public List<Tree_Node<T>> Get_SubList(Tree_Node<T> Leaf){
			var returnList = new List<Tree_Node<T>>();
			var auxiliar = Leaf;
			while(auxiliar != null){
				returnList.Push_Back(auxiliar);
				if(auxiliar.data.Equals(Root.data)) break;
				auxiliar = auxiliar.Father;
			}
			
			returnList.Reverse();
			return returnList;
			
		}
		
		public List<Tree_Node<T>> Get_SubList(Tree_Node<T> Leaf, T start){
			var returnList = new List<Tree_Node<T>>();
			var flag = false;
			var auxiliar = Leaf;
			while(auxiliar != null){
				if(auxiliar.data.Equals(start) && !flag) flag = true;

				if(flag) returnList.Push_Back(auxiliar);
				
				if(auxiliar.data.Equals(Root.data)) break;
				
				auxiliar = auxiliar.Father;
			}
			
			returnList.Reverse();
			return returnList;
			
		}
		
		public int Size_Leafs(){
			return Get_Node_Leafs().Size();
		}
		
		public int Size_Nodes(){
			return Get_All_Nodes().Size();
		}
		
	}

	public class Stack<T>
	{
		private List<T> list;
		public Stack()
		{
			list = new List<T>();
		}
		~Stack(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		
		public T Peek(){
			return list.First();
		}
		
		public void Push(T element){
			list.Push_Front(element);
		}
		
		public void Pop(){
			list.Pop_Front();
		}
		
		public int Size(){
			return list.Size();
		}
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains(T elem){
			return list.Contains(elem);
		}
		
		
		public static Stack<T> operator +(Stack<T> first, Stack<T> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Pop();
			}
			return first;
		}
		
		public static Stack<T> operator +(Stack<T> first, Queue<T> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Dequeue();
			}
			return first;
		}
		
		
	}

	public class Queue<T>
	{
		private List<T> list;
		
		public Queue()
		{
			list = new List<T>();
		}
		~Queue(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		public int Size(){
			return list.Size();
		}
		public void Dequeue(){
			list.Pop_Front();
		}
		public T Peek(){
			return list.First();
		}
		public void Enqueue(T elem){
			list.Push_Back(elem);
		}
		
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains(T elem){
			return list.Contains(elem);
		}
		
		public static Queue<T> operator +(Queue<T> first, Queue<T> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Dequeue();
			}
			return first;
		}
		
		public static Queue<T> operator +(Queue<T> first, Stack<T> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Pop();
			}
			return first;
		}
		

	}

	public class List<T>
	{
		//Node:
		public class List_Node<N>
		{
			public List_Node<N> next;
			public List_Node<N> previous;
			public N data;
			
			public List_Node()
			{
			}
			
			public List_Node(N dato, List_Node<N> anterior, List_Node<N> siguiente){
				this.data = dato;
				this.previous = anterior;
				this.next = siguiente;
			}
			
			
		}
		
		private List_Node<T> listFront;
		private List_Node<T> listBack;
		private int index;
		
		public List()
		{
			listFront = null;
			listBack = null;
			index = 0;
		}
		
		~List(){
			Clear();
		}
		
		public bool Empty(){
			return index == 0;
		}
		public int Size(){
			return index;
		}
		
		public T First(){
			if(!Empty()) return listFront.data;
			else throw new Exception("EMPTY LIST");
		}
		
		public T Last(){
			if(!Empty()) return listBack.data;
			else throw new Exception("EMPTY LIST");
		}
		
		public void Push_Back(T element){
			if(Empty()){
				var newNode = new List_Node<T>(element,null,null);
				listFront = newNode;
				listBack = listFront;
			}else{
				var newNode = new List_Node<T>(element,listBack,null);
				listBack.next = newNode;
				listBack = newNode;
			}
			index++;
		}
		
		public void Push_Front(T element){
			
			if(Empty()){
				var newNode = new List_Node<T>(element,null,null);
				listFront = newNode;
				listBack = listFront;
			}else{
				var newNode = new List_Node<T>(element,null,listFront);
				listFront.previous = newNode;
				listFront = newNode;
			}
			index++;
			
			
		}
		
		public T Get_Element(int position){
			if(!Empty()){
				if(position == 0){
					return First();
				}
				else if(position == Size()-1){
					return Last();
				}
				else{
					position = position % Size();
					var auxiliar = listFront;
					for(int i = 0; i < position;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data;
				}

			}else{
				throw new Exception("EMPTY LIST");
			}
		}
		
		public List_Node<T> Get_Node(int position){
			if(!Empty()){
				if(position == 0){
					return listFront;
				}
				else if(position == Size()-1){
					return listBack;;
				}
				else{
					position = position % Size();
				
					var auxiliar = listFront;
					for(int i = 0; i < position;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar;
				}

			}else{
				throw new Exception("EMPTY LIST");
			}
		}
	
		public List<T> Get_Reverse_List(){
			var newList = new List<T>();
			var auxiliar = listBack;
			while(auxiliar != null){
				newList.Push_Back(auxiliar.data);
				auxiliar = auxiliar.previous;
			}
			
			return newList;
		}

		public void Pop_Back(){
			if(!Empty()){
				var deleteNode = listBack;
				listBack = listBack.previous;
				if(listBack != null){
					listBack.next = null;
				}
				
				deleteNode = null;
				index--;
				
			}
			else{
				throw new Exception("EMPTY LIST");
			}
			
		}
		
		public void Pop_Front(){
			if(!Empty()){
				
				var deleteNode = listFront;
				
				listFront = listFront.next;
				
				if(listFront != null){
					listFront.previous = null;
				}
				
				deleteNode = null;
				
				index--;
				
			}else{
				throw new Exception("EMPTY LIST");
			}

		}
		
		public void Clear(){
			if(!Empty()){
				int i = 0;
				int size = Size();
				
				while(i < size){
					Pop_Front();
					i++;
				}
				index = 0;
				
				listFront  = listBack = null;
			}
		}
		
		public void Insert_At(int pos, T element){
			if(Empty()){
				Push_Back(element);
			}
			else{
				pos = pos % Size();
				if(pos == 0) Push_Front(element);
				else if(pos == Size()) Push_Back(element);
				else{
					var auxiliar = listFront;
					for(int i = 0; i < pos-1;i++){
						auxiliar = auxiliar.next;
					}
					var newNode = new List_Node<T>(element,auxiliar.previous,auxiliar.next);
					auxiliar.next = newNode;
					newNode.previous = auxiliar;
					index++;
				}
			}
		}
		
		public void Erase_At(int pos){
			if(!Empty()){
				pos = pos % Size();
				if(pos == 0) Pop_Front();
				else if(pos == Size()) Pop_Back();
				else{
					var temp = listFront;
			        for (int i = 0; i < pos -1; ++i) {
			            temp = temp.next;
			        }
			
			        var delete = temp.next;
			
			        temp.next = delete.next;
			
			        delete.next = delete.previous.next;

			        delete = null;
			
			        --index;
				}
				
			}
		}
		
		public void Remove(T value){
			if(!Empty()){
				T dato;
			    var temp = listFront;
			    var i = 0;
			    while(temp != null){
			        dato = temp.data;
			        temp = temp.next;
			        if(dato.Equals(value)){
			            Erase_At(i);
			            i--;
			        }
			        i++;
			    }
			}
		}
		
		public bool Contains(T value){
			if(Empty()){
				return false;
			}
			else{
				var auxiliar = listFront;
				for(int i = 0; i < Size();i++){
					if(auxiliar.data.Equals(value)){
						return true;
					}
					auxiliar = auxiliar.next;
				}
				
				return false;
			}
		}
		
		public void Replace(T elementToReplace,T replacement){
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.Equals(elementToReplace)) {
					auxiliar.data = replacement;
					break;
				}
				auxiliar = auxiliar.next;
			}
		}
		
		public void Replace(int pos,T replacement){
			pos = pos % Size();
			var auxiliar = listFront;
			for(int i = 0; i < pos;i++){
				auxiliar = auxiliar.next;
			}
			
			auxiliar.data = replacement;
			
		}
		
		public int Get_Position(T element){
			var cont = 0;
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.Equals(element)) return cont;
				cont++;
				auxiliar = auxiliar.next;
			}
			
			return -1;
		}
		
		public  bool Is_Equal(List<T> second){
			if(this.Size() != second.Size()) return false;
			else{
				var auxiliar = listFront;
				for(int i = 0; i < Size();i++){
					if(!auxiliar.data.Equals(second[i])) return false;
					auxiliar = auxiliar.next;
				}
				return true;
			}
		}
		
		public static List<T> operator +(List<T> original, List<T> sumante){
			for(int i = 0; i < sumante.Size();i++){
				if(!original.Contains(sumante.Get_Element(i))) original.Push_Back(sumante.Get_Element(i));
			}
			return original;
		}
		
		public static List<T> operator -(List<T> original, List<T> restante){
			for(int i = 0; i < restante.Size();i++){
				if(original.Contains(restante.Get_Element(i))){
					original.Remove(restante.Get_Element(i));
				}
			}
			return original;
		}
		
		public void Reverse(){
			if(!Empty()){
				var newList = new List<T>();
				var auxiliar = listBack;
				for(int i = 0; i < Size();i++){
					newList.Push_Back(auxiliar.data);
					auxiliar = auxiliar.previous;
				}
				
				Clear();
				for(int i = 0; i < newList.Size();i++){
					Push_Back(newList.Get_Element(i));
				}
				newList.Clear();
			}
			
		}
		
		public T this[int indice]{
			get {return Get_Element(indice); }
			set { this.Get_Node(indice).data = value; }
		}
		
	}

	public class Matrix<T>
	{
		public class Row<N>{
			public int index;
			public Row<N> next;
			public Row<N> previous;
			public Column<N> adyacentColumn;
			
			public Row(int indice, Row<N> anterior,Row<N> siguiente,Column<N> columna){
				this.index = indice;
				this.next = siguiente;
				this.previous = anterior;
				this.adyacentColumn = columna;
			}
			
			public Row(int indice){
				this.index = indice;
				this.next = null;
				this.previous = null;
				this.adyacentColumn = null;
			}
			
			public int Size_Columns(){
				var auxiliar = this.adyacentColumn;
				if(adyacentColumn == null) return 0;
				else{
					var counter = 0;
					while(auxiliar != null){
						counter++;
						auxiliar = auxiliar.next;
					}
					return counter;
				}
			}
			
			public bool Empty_Columns(){
				return Size_Columns() == 0;
			}
		}
		
		public class Column<M>{
			public M data;
			public Column<M> next;
			public Column(M dato, Column<M> siguiente){
				this.data = dato;
				this.next = siguiente;
			}
			public Column(M dato){
				this.data = dato;
				this.next = null;
			}

		}
		
		private Row<T> start;
		private Row<T> end;
		private int numRows;
		
		public Matrix()
		{
			start = null;
			end = null;
			numRows = 0;
		}
		
		public bool Empty(){
			return start == null;
		}
		
		public int Size_Rows(){
			return numRows;
		}
		
		public void Add_Row(){
			if(Empty()){
				var newRow = new Row<T>(numRows);
				start = end = newRow;
			}
			else{
				var newRow = new Row<T>(numRows,end,null,null);
				end.next = newRow;
				end = newRow;
			}
			numRows++;
		}

		
		public Row<T> First_Row_Node(){
			if(!Empty()) return start;
			else throw new Exception("EMPTY MATRIX");
		}
		
		public Row<T> Last_Row_Node(){
			if(!Empty()) return end;
			else throw new Exception("EMPTY MATRIX");
		}
		
		public Row<T> Get_Row(int indice){
			indice = indice % Size_Rows();
			if(indice == 0) return First_Row_Node();
			else if (indice == Size_Rows() -1) return Last_Row_Node();
			else{
				var auxiliar = start;
				for(int i = 0; i < indice;i++){
					auxiliar = auxiliar.next;
				}
				return auxiliar;
			}
			
		}
		
		public T Get_Value(int Row_Index, int Column_Index){
			var row = Get_Row(Row_Index);
			if(row.adyacentColumn == null) throw new Exception("INVALID POSITION");
			else{
				var auxiliar = row.adyacentColumn;
				var num_Column = 0;
				while(auxiliar != null){
					if(num_Column == Column_Index) return auxiliar.data;
					num_Column++;
					auxiliar = auxiliar.next;
				}
				throw new Exception("INVALID POSITION");
			}
		}
		
		public Column<T> Get_Column(int Row_Index, int Column_Index){
			var row = Get_Row(Row_Index);
			if(row.adyacentColumn == null) throw new Exception("INVALID POSITION");
			else{
				var auxiliar = row.adyacentColumn;
				var num_Column = 0;
				while(auxiliar != null){
					if(num_Column == Column_Index) return auxiliar;
					num_Column++;
					auxiliar = auxiliar.next;
				}
				throw new Exception("INVALID POSITION");
			}
		}
		
		public void Add_Column(int nRow, T element){
			if(!Exist_Column(nRow,element)){
				var newColumn = new Column<T>(element);
				nRow = nRow % Size_Rows();
				var column = Get_Row(nRow).adyacentColumn;
				if(column == null){
					Get_Row(nRow).adyacentColumn = newColumn;
				}
				else{
					while(column.next != null){
						column = column.next;
					}
					column.next = newColumn;
				}
				
			}
		}
		
		public bool Exist_Column(int nRow,T element){
			nRow = nRow % Size_Rows();
			var column = Get_Row(nRow).adyacentColumn;
			while(column != null){
				if(column.data.Equals(element)) return true;
				column = column.next;
			}
			return false;
		}
		
		public bool Exist_Column(int nRow,int nColumn){
			nRow = nRow % Size_Rows();
			var column = Get_Row(nRow).adyacentColumn;
			for(int i = 0; i < Get_Row(nRow).Size_Columns();i++){
				if(nColumn == i) return true;
				column = column.next;
			}
			return false;
		}
		
		public T this[int fila,int columna]{
			get {return Get_Value(fila,columna);}
			set { Get_Column(fila,columna).data = value;}
		}
		
		public void Delete_Column(int fila, T element){
			if(!Empty()){
				fila = fila % Size_Rows();
				var auxiliar = Get_Row(fila).adyacentColumn;
				var previousColumn = Get_Row(fila).adyacentColumn;;
				if(auxiliar != null){
					for(int i = 0; i < Get_Row(fila).Size_Columns();i++){
						if(auxiliar.data.Equals(element)){
							if(i == 0){//The first One
								Get_Row(fila).adyacentColumn = auxiliar.next;
								auxiliar = null;
							}
							else if(i == Get_Row(fila).Size_Columns()-1){//The last one
								auxiliar = null;
								previousColumn.next = null;
								
							}
							else{//In the middle
								
								previousColumn.next = auxiliar.next;
								auxiliar = null;
							}
							
							break;
						}
						previousColumn = auxiliar;
						auxiliar = auxiliar.next;
					}
	
				}
			}

			
		}
		
		public void Delete_Column(int fila, int columna){
			
			if(!Empty()){
				fila = fila % Size_Rows();
				columna = columna % Get_Row(fila).Size_Columns();
				var auxiliar = Get_Row(fila).adyacentColumn;
				var previousColumn = Get_Row(fila).adyacentColumn;;
				if(auxiliar != null){
					if(columna == 0){//The first One
						Get_Row(fila).adyacentColumn = auxiliar.next;
						auxiliar = null;
					}else{
						for(int i = 0; i < columna;i++){
							previousColumn = auxiliar;
							auxiliar = auxiliar.next;
						}
						
						if(columna == Get_Row(fila).Size_Columns()-1){//The last one
								
							auxiliar = null;
								previousColumn.next =null;
								
						}
						else{//In the middle
							previousColumn.next = auxiliar.next;
							auxiliar = null;
						}
					}
					
	
				}
			}
			
			
		}
	
		public void Delete_Row(int indice){
			if(!Empty()){
				indice = indice % Size_Rows();
				var auxiliar = Get_Row(indice);
				var previousAuxiliar = Get_Row(indice);
				for(int i = 0; i < auxiliar.Size_Columns();i++){//delete its columns
					Delete_Column(indice,i);
				}
				
				//Delete ROw:
				
				if(indice == 0){
					start = auxiliar.next;
					auxiliar = null;
				}
				else{
					for(int i = 0; i < indice;i++){
						previousAuxiliar = auxiliar;
						auxiliar = auxiliar.next;
					}
					
					if(indice == Size_Rows()-1){//The last one
						auxiliar = null;
						previousAuxiliar.next = null;
					}
					else{//In the middle
						previousAuxiliar.next = auxiliar.next;
						auxiliar = null;
					}
					
				}
			}
			
			
		}
	
		public void Modify_Column(int fila, int columna, T newValue){
			Get_Column(fila,columna).data = newValue;
		}
		
	
	}

	public class Pair<A,B>
		{
			public A firstData;
			public B secondData;
			
			public Pair(A dato1,B dato2)
			{
				this.firstData = dato1;
				this.secondData = dato2;
			}
			
			public bool Same_Type(){
				return firstData.GetType().Equals(secondData.GetType());
			}
			
			public bool Is_Equal(Pair<A,B> other){
				return this.firstData.Equals(other.firstData) && 
					this.secondData.Equals(other.secondData);
			}
		}
	
	public class Double_List<T,N>
	{
		
		//Node
		public class Double_Node<M,P>
		{
			
			public Pair<M,P> data;
			public Double_Node<M,P> previous;
			public Double_Node<M,P> next;
			
			public Double_Node(M dato1, P dato2, Double_Node<M,P> anterior, Double_Node<M,P> siguiente){
				this.data = new Pair<M,P>(dato1,dato2);
				this.previous = anterior;
				this.next = siguiente;
			}
	
			public Double_Node(M dato1, P dato2){
				this.data = new Pair<M,P>(dato1,dato2);
				this.previous = null;
				this.next = null;
			}
			
			public Double_Node(Pair<M,P> par, Double_Node<M,P> anterior, Double_Node<M,P> siguiente){
				this.data = par;
				this.previous = anterior;
				this.next = siguiente;
			}
	
			public Double_Node(Pair<M,P> par){
				this.data = par;
				this.previous = null;
				this.next = null;
			}
			
		}
		
		private Double_Node<T,N> listFront;
		private Double_Node<T,N> listBack;
		private int index;
		
		public Double_List()
		{
			listBack = listFront = null;
			index = 0;
			
		}
		 
		~Double_List(){
			this.Clear();
		}
		
		
		public bool Empty(){
			return index == 0;
		}
		public int Size(){
			return index;
		}
		
		public T First_Data_Front(){
			if(!Empty()) return listFront.data.firstData;
			else throw new Exception("Empty Double List");
		}
		public T First_Data_Back(){
			if(!Empty()) return listBack.data.firstData;
			else throw new Exception("Empty Double List");
		}
		public N Second_Data_Front(){
			if(!Empty()) return listFront.data.secondData;
			else throw new Exception("Empty Double List");
		}
		public N Second_Data_Back(){
			if(!Empty()) return listBack.data.secondData;
			else throw new Exception("Empty Double List");
		}
		public Pair<T,N> First(){
			if(!Empty()) return listFront.data;
			else throw new Exception("Empty Double List");
		}
		public Pair<T,N> Back(){
			if(!Empty()) return listBack.data;
			else throw new Exception("Empty Double List");
		}
		
		public void Push_Back(T data1,N data2){
			if(Empty()){
				var newNode = new Double_Node<T,N>(data1,data2);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(data1,data2,listBack,null);
				listBack.next = newNode;
				listBack = newNode;
				index++;
			}
		}
		
		public void Push_Front(T data1,N data2){
			if(Empty()){
				var newNode = new Double_Node<T,N>(data1,data2);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(data1,data2,null,listFront);
				listFront.previous = newNode;
				listFront = newNode;
				index++;
			}
		}
		
		public void Push_Back(Pair<T,N> couple){
			if(Empty()){
				var newNode = new Double_Node<T,N>(couple);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(couple,listBack,null);
				listBack.next = newNode;
				listBack = newNode;
				index++;
			}
		}
		
		public void Push_Front(Pair<T,N> couple){
			if(Empty()){
				var newNode = new Double_Node<T,N>(couple);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(couple,null,listFront);
				listFront.previous = newNode;
				listFront = newNode;
				index++;
			}
		}
		
		public void Pop_Front(){
			if(!Empty()){
				
				var deleteNode = listFront;
				
				listFront = listFront.next;
				
				if(listFront != null){
					listFront.previous = null;
				}
				
				deleteNode = null;
				
				index--;
			}
		}

		public void Pop_Back(){
			if(!Empty()){
				
				var deleteNode = listBack;
				
				listBack = listBack.previous;
				
				if(listBack != null){
					listBack.next = null;
				}
				
				deleteNode = null;
				
				index--;
			}
		}
		
		public void Clear(){
			if(!Empty()){
				int i = 0;
				int size = Size();
				
				while(i < size){
					Pop_Front();
					i++;
				}
				index = 0;
				
				listFront  = listBack = null;
			}
		}
		
		public void Erase_At(int pos){
			if(!Empty()){
				pos = pos % Size();
				if(pos == 0) Pop_Front();
				else if(pos == Size()) Pop_Back();
				else{
					var temp = listFront;
			        for (int i = 0; i < pos -1; ++i) {
			            temp = temp.next;
			        }
			
			        var delete = temp.next;
			
			        temp.next = delete.next;
			
			        delete.next = delete.previous.next;

			        delete = null;
			
			        --index;
				}
				
			}
		}
		
		public bool Exist_First(T value){
			if(Empty()){
				return false;
			}
			else{
				var auxiliar = listFront;
				
				for(int i = 0; i < Size();i++){
					if(auxiliar.data.firstData.Equals(value)){
						return true;
					}
					auxiliar = auxiliar.next;
				}
				
				return false;
			}
		}
		
		public bool Exist_Second(N value){
			if(Empty()){
				return false;
			}
			else{
				var auxiliar = listFront;
				
				for(int i = 0; i < Size();i++){
					if(auxiliar.data.secondData.Equals(value)){
						return true;
					}
					auxiliar = auxiliar.next;
				}
				
				return false;
			}
		}
		
		public bool Exist(Pair<T,N> pair){
			return Exist_First(pair.firstData) && Exist_Second(pair.secondData);
		}
		
		public T Get_First_Element(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return First_Data_Front();
				else if(indice == Size()-1) return First_Data_Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data.firstData;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		public N Get_Second_Element(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return Second_Data_Front();
				else if(indice == Size()-1) return Second_Data_Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data.secondData;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		
		public Pair<T,N> Get_Pair(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return First();
				else if(indice == Size()-1) return Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		
		public void Reverse(){
			
			if(!Empty()){
				var newList = new Double_List<T,N>();
				var auxiliar = listBack;
				for(int i = 0; i < Size();i++){
					newList.Push_Back(auxiliar.data);
					
					auxiliar = auxiliar.previous;
				}
				
				Clear();
				for(int i = 0; i < newList.Size();i++){
					Push_Back(newList.Get_Pair(i));
				}
				newList.Clear();
			}
			
		}
		
		public Pair<T,N> this[int indice]{
			get { return Get_Pair(indice); }
			set { Get_Pair(indice).firstData = value.firstData;
				  Get_Pair(indice).secondData = value.secondData;}
		}
		
		public  bool Is_Equal(Double_List<T,N> second){
			if(this.Size() != second.Size()) return false;
			else{
				var auxiliar = listFront;
				for(int i = 0; i < Size();i++){
					if(!auxiliar.data.firstData.Equals(second[i].firstData) && 
					   !auxiliar.data.secondData.Equals(second[i].secondData)) return false;
					auxiliar = auxiliar.next;
				}
				return true;
			}
		}
		
		public static Double_List<T,N> operator +(Double_List<T,N> original, Double_List<T,N> sumante){
			for(int i = 0; i < sumante.Size();i++){
				if(!original.Exist(sumante[i])) original.Push_Back(sumante[i]);
			}
			return original;
		}
		
		public static Double_List<T,N> operator -(Double_List<T,N> original, Double_List<T,N> restante){
			for(int i = 0; i < restante.Size();i++){
				if(original.Exist(restante[i])){
					original.Remove(restante[i]);
				}
			}
			return original;
		}
		
		public void Remove(Pair<T,N> value){
			if(!Empty()){
				Pair<T,N> dato;
			    var temp = listFront;
			    var i = 0;
			    while(temp != null){
			        dato = temp.data;
			        temp = temp.next;
			        if(dato.Is_Equal(value)){
			            Erase_At(i);
			            i--;
			        }
			        i++;
			    }
			}
		}
		
		public void Insert_At(int pos, Pair<T,N> element){
			if(Empty()){
				Push_Back(element);
			}
			else{
				pos = pos % Size();
				if(pos == 0) Push_Front(element);
				else if(pos == Size()) Push_Back(element);
				else{
					var auxiliar = listFront;
					for(int i = 0; i < pos-1;i++){
						auxiliar = auxiliar.next;
					}
					var newNode = new Double_Node<T,N>(element,auxiliar.previous,auxiliar.next);
					auxiliar.next = newNode;
					newNode.previous = auxiliar;
					index++;
				}
			}
		}
		
		public void Replace_First_Element(T elementToReplace,T replacement){
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.firstData.Equals(elementToReplace)) {
					auxiliar.data.firstData = replacement;
					break;
				}
				auxiliar = auxiliar.next;
			}
		}
		
		public void Replace_Second_Element(N elementToReplace,N replacement){
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.secondData.Equals(elementToReplace)) {
					auxiliar.data.secondData = replacement;
					break;
				}
				auxiliar = auxiliar.next;
			}
		}
		
		public void Replace_First_Element(int pos,T replacement){
			pos = pos % Size();
			var auxiliar = listFront;
			for(int i = 0; i < pos;i++){
				auxiliar = auxiliar.next;
			}
			
			auxiliar.data.firstData = replacement;
			
		}
		
		public void Replace_Second_Element(int pos,N replacement){
			pos = pos % Size();
			var auxiliar = listFront;
			for(int i = 0; i < pos;i++){
				auxiliar = auxiliar.next;
			}
			
			auxiliar.data.secondData = replacement;
			
		}
		
		
	}

	public class Double_Stack<T,N>
	{
		private Double_List<T,N> list;
		public Double_Stack()
		{
			list = new Double_List<T, N>();
		}
		
		~Double_Stack(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		
		public Pair<T,N> Peek(){
			return list.First();
		}
		
		public void Push(Pair<T,N> element){
			list.Push_Front(element);
		}
		public void Push(T element1, N element2){
			list.Push_Front(element1,element2);
		}
		
		public void Pop(){
			list.Pop_Front();
		}
		
		public int Size(){
			return list.Size();
		}
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains_First_Element(T elem){
			return list.Exist_First(elem);
		}
		
		public bool Contains_Second_Element(N elem){
			return list.Exist_Second(elem);
		}
		
		public bool Contains(Pair<T,N> par){
			return list.Exist(par);
		}
		
		public bool Contains(T element1, N element2){
			return list.Exist(new Pair<T, N>(element1,element2));
		}
		
		
		public static Double_Stack<T,N> operator +(Double_Stack<T,N> first, Double_Stack<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Pop();
			}
			return first;
		}
		
		public static Double_Stack<T,N> operator +(Double_Stack<T,N> first, Double_Queue<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Dequeue();
			}
			return first;
		}
	}

	public class Double_Queue<T,N>
	{
		private Double_List<T,N> list;
		public Double_Queue()
		{
			list = new Double_List<T, N>();
		}
		
		~Double_Queue(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		
		public int Size(){
			return list.Size();
		}
		public void Dequeue(){
			list.Pop_Front();
		}
		public Pair<T,N> Peek(){
			return list.First();
		}
		public void Enqueue(Pair<T,N> elem){
			list.Push_Back(elem);
		}
		
		public void Enqueue(T element1, N element2){
			list.Push_Back(element1,element2);
		}
		
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains_First_Element(T elem){
			return list.Exist_First(elem);
		}
		
		public bool Contains_Second_Element(N elem){
			return list.Exist_Second(elem);
		}
		
		public bool Contains(Pair<T,N> par){
			return list.Exist(par);
		}
		
		public bool Contains(T element1,N element2){
			return list.Exist(new Pair<T, N>(element1,element2));
		}
		
		public static Double_Queue<T,N> operator +(Double_Queue<T,N> first, Double_Queue<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Dequeue();
			}
			return first;
		}
		
		public static Double_Queue<T,N> operator +(Double_Queue<T,N> first, Double_Stack<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Pop();
			}
			return first;
		}
		
	}
	
}
