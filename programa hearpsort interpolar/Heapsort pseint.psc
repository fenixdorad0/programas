Algoritmo sin_titulo
	Leer longi	
	dimension arreglo[longi]
	imprimirDatos(longi,arreglo)	
	//ordenar(longi,arreglo)	
	PerformHeapSort(arreglo,longi)
	imprimirDatos(longi,arreglo)	
	izquierda=0
	derecha=longi-1	
	//res=busqueda(arreglo,izquierda,derecha,(longi-1)*10)
	
FinAlgoritmo

SubAlgoritmo ordenar(longi,arreglo)
	cont=0
	cont2=0
	cambio=0
	Mientras cont2<(longi-1) Hacer
		cont2=0
		cont=0
		mientras (cont+1)<longi Hacer
			si arreglo[cont+1] < arreglo[cont]
				cambio = arreglo[cont + 1]
				arreglo[cont + 1] = arreglo[cont]
				arreglo[cont] = cambio
			SiNo
				cont2=cont2+1
			FinSi
			cont=cont+1	
			
		FinMientras
	FinMientras
FinSubAlgoritmo

SubAlgoritmo ingresarDatos(longi,arreglo)
	i=0
	mientras i<longi Hacer
		arreglo[i]=azar(longi);
		i=i+1;
	FinMientras
	
FinSubAlgoritmo

SubAlgoritmo imprimirDatos(longi,arreglo)
	i=0
	z=""
	mientras i<longi Hacer
		z=z+" "+ ConvertirATexto(arreglo[i])
		i=i+1;
	FinMientras
	Escribir z
FinSubAlgoritmo




subAlgoritmo buildheap(arreglo,longi,heapsize)
	heapsize = longi-1
	i = trunc(heapsize / 2)
	
	mientras i >= 0 hacer  
	
		heapify(arreglo, i,heapsize);
		i=i-1
	fin mientras
FinSubAlgoritmo

SubAlgoritmo  heapify(arreglo, index,heapsize)
	left = 2*index
	right =2*index+1
	largest=index
	
	si (left <= heapsize && arreglo[left] > arreglo[index]) entonces
	
	largest = left;
	
	fin si
	
	si (right <= heapsize && arreglo[right] > arreglo[largest]) entonces	
		largest = right;
	fin si
	
	si (largest != index) entonces
	
		Swap(arreglo, index, largest);
		heapify(arreglo, largest,heapsize);
	fin si
FinSubAlgoritmo


SubAlgoritmo swap(arreglo, xx, yy)//function to swap elements
	
	temp = arreglo[xx];
	arreglo[xx] = arreglo[yy];
	arreglo[yy] = temp;		
FinSubAlgoritmo

subalgoritmo PerformHeapSort(arreglo,longi)
	heapsize = longi-1
	BuildHeap(arreglo,longi,heapsize)
	i = longi - 1
	mientras ( i >= 0) hacer
		Swap(arreglo, 0, i);
		heapsize=heapsize-1;
		heapify(arreglo, 0,heapsize);
		i=i-1
	finMientras
FinSubAlgoritmo





	