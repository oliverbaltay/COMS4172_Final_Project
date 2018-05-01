using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DyeMakerScript : MonoBehaviour {

	public Transform lab;
	GameObject mordant;
	GameObject dye;
	// Use this for initialization
	void Start () {
		mordant = null;
		dye = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMordant(GameObject prefab){
		mordant = prefab;
	}

	public void setDye(GameObject prefab){
		dye = prefab;
	}

	public void createDye(){
		if (mordant != null && dye != null) {
			GameObject m = Instantiate (mordant, lab);
			GameObject d = Instantiate (dye, lab);
			mordant = null;
			dye = null;
		} else
			Debug.Log ("must pick a dye and a mordant");
	}

	public void clear(){
		mordant = null;
		dye = null;
	}

		
}
