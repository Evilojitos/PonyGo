using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leyendodatos : MonoBehaviour {
VariablesGlabales puntos;
	public GameObject Global1;
	public GameObject Canvas;
	public Text texto;

	// Use this for initialization
	void Start () {
		Global1 = GameObject.Find("Global");

		puntos = Global1.GetComponent<VariablesGlabales>();
		//texto = Canvas.GetComponent<Text>();
		texto.text=""+puntos.puntos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Contenido(){
		puntos.puntos++;
		Debug.Log("contenido es: "+puntos.puntos);
		texto.text =""+puntos.puntos;
	}
}
