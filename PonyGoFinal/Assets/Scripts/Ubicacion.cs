using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ubicacion : MonoBehaviour {

	public RawImage img;
	string url;
	public float Tiempo = 0.0f;

	//public static Ubicacion Instance { set; get;}
	public Text latitudee;
	public Text longitudee;
	public Text tiempo;
	public float latitude;
	public float longitude;
     public Image UIImagen;
	int maxmaterias = 5;
	ArrayList coordenadas = new ArrayList();
	bool generacion = false;


	public enum mapType {roadmap,satellite,hybrid,terrain}
	public mapType mapSelected;
	public int scale;


	// Use this for initialization
	void Start () {
        UIImagen = GameObject.Find("ImagenCambiante").GetComponent<Image>();
		StartCoroutine(InicioLocalizacion(false));
	}
	
	IEnumerator InicioLocalizacion(bool crearmateria)
	{
		//Proceso basico para iniciar la geolocalizacion
		/*
		if(!Input.location.isEnabledByUser)
		{
			Debug.Log("No tiene habilitado el GPS");
			yield break;
		}
		Input.location.Start();
		int maxWait=20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if(maxWait <=0)
		{
			Debug.Log("Tiempo terminado");
			yield break;
		}

		if(Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("No se pudo obtener la localizacion");
			yield break;
		}
*/
		//obtenemos las coordenadas del dispositivo
		//latitude = Input.location.lastData.latitude;
		//longitude = Input.location.lastData.longitude;
		
		Debug.Log("se entro a InicioLocalizacion");


		if(crearmateria==true)
		{
            Debug.Log("Se creara una nueva materia en: ");

			//En esta parte se va a generar una nueva materia
			//float auxlat =  Random.Range(latitude,(latitude+0.0004000f));
			//float auxlon =  Random.Range(longitude,(longitude+0.0004000f));

			float auxlat =  Random.Range(0,10);
			float auxlon =  Random.Range(0,10);

			//Se guardara las nuevas coordenadas en el arreglo
			coordenadas.Add(auxlat.ToString());
			coordenadas.Add(auxlon.ToString());
		}
		Debug.Log("El tamaño del ArrayList es: "+ coordenadas.Count.ToString());
		string marcadores="";
		if(coordenadas.Count>0)
		{
		int contadore=0;
		foreach(string i in coordenadas)
        {
        	if(contadore%2==0){
				marcadores+="&markers=color:blue|label:M|"+i.ToString();
        	}else{
        		marcadores+=","+i.ToString();
        	}
            Debug.Log("El marcador es: "+marcadores);
            contadore++;
        }
        contadore=0;
			Debug.Log("marcador final es: "+marcadores);
		}
		url="https://maps.googleapis.com/maps/api/staticmap?center=Brooklyn+Bridge,New+York,NY&zoom=13&size=600x300&maptype=roadmap&markers=color:blue|label:S|40.702147,-74.015794&markers=color:green|label:G|40.711614,-74.012318&markers=color:red|label:C|40.718217,-73.998284";
		WWW www = new WWW (url);
		yield return www;
		img.texture = www.texture;
		img.SetNativeSize ();

		yield break;
        
		
		
	}

	void Update() 
    {

    	Tiempo += Time.deltaTime;
    	
    	tiempo.text ="Log: "+Tiempo.ToString();
    	//Debug.Log("Tiempo es: "+ Tiempo.ToString());
    	if(5.0000000f <= Tiempo)
    	{
    		// reiniciamos el tiempo
    		Tiempo=0.0f;
    		Debug.Log("el Tiempo llego a 30 reiniciando: "+ Tiempo.ToString());
            Debug.Log("Se toco el reinicio");
            //UIImagen.sprite = 
            //img.texture=Resources.Load<Sprite>("Sprites/173");
    		//StartCoroutine(InicioLocalizacion(true));
    	}
    }

	public void Reiniciar(){
        Debug.Log("Se toco el reinicio");
		//StartCoroutine(InicioLocalizacion(false));
		
	}
}
