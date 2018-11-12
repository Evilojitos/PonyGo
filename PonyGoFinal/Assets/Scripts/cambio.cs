using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cambio : MonoBehaviour {
    public Image UIImagen;

	// Use this for initialization
	void Start () {
		UIImagen = GameObject.Find("ImagenCambiante").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void cambiarimagen(){
        Debug.Log("Se toco el boton");
        UIImagen.sprite = Resources.Load<Sprite>("Sprites/173");
    }
}
