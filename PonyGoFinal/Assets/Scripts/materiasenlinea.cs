using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class materiasenlinea : MonoBehaviour {
	public Button M0001,M0002,M0003,M0004,M0005,M0006,M0007,M0008,M0009,M0010,M0011,M0012,M0013,M0014,M0015,M0016,M0017,M0018,M0019,M0020,M0021,M0022,M0023,M0024,M0025,M0026,M0027,M0028,M0029,M0030;
	public Button M0031,M0032,M0033,M0034,M0035,M0036,M0037,M0038,M0039,M0041,M0042,M0043,M0044,M0045,M0046,M0047,M0048,M0049,M0050,M0051,M0052,M0053,M0054,M0055,M0056,M0057,M0058,M0059,M0060,M0061;

	// Use this for initialization
	void Start () {
		GameObject.Find("M0001").GetComponentInChildren<Text>().text = "boton 1";
		GameObject.Find("M0002").GetComponentInChildren<Text>().text = "boton 2";
		//M0001.interactable=false; 
		//UIImagen = GameObject.Find("ImagenCambiante").GetComponent<Button>();
		//materia1.text ="Numero";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
