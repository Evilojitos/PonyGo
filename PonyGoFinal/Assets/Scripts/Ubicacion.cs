using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ubicacion : MonoBehaviour {

	public RawImage img;
	string url;

	//public static Ubicacion Instance { set; get;}
	public Text latitudee;
	public Text longitudee;
	public float latitude;
	public float longitude;


	public enum mapType {roadmap,satellite,hybrid,terrain}
	public mapType mapSelected;
	public int scale;


	// Use this for initialization
	void Start () {
		//Instance = this;
		//DontDestroyOnLoad(gameObjetc);
		

		StartCoroutine(InicioLocalizacion());
	}
	
	IEnumerator InicioLocalizacion()
	{
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
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
		//coordinate.text = "Lat: "+ Ubicacion.Instance.latitude.ToString() + "	Lon: "+Ubicacion.Instance.longitude.ToString();
		latitudee.text ="Lat: "+latitude.ToString();
		longitudee.text ="Log: "+longitude.ToString();
		url="https://maps.googleapis.com/maps/api/staticmap?center="
		+latitude.ToString()  +",%20"+longitude.ToString()
		+"&zoom=19&size=600x1000&maptype=roadmap&markers=color:blue|label:S|"+latitude.ToString()  +",%20"+longitude.ToString();
		WWW www = new WWW (url);
		yield return www;
		img.texture = www.texture;
		img.SetNativeSize ();

		yield break;
		

		
	}

	public void Reiniciar(){
		StartCoroutine(InicioLocalizacion());
		
	}
}
