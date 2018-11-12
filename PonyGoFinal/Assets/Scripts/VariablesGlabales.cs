using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VariablesGlabales : MonoBehaviour {
	public int puntos = 0;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void cambiar(int num){
		puntos = num;
		//SceneManager.LoadScene("nivel1");
		Debug.Log("El numero oprimido es: "+num.ToString());
		Application.LoadLevel("MostrandoContenido");
	}
}
