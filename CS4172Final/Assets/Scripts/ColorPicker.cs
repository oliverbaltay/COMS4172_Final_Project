using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour {

	public Dropdown recipiePicker;
	public Image panelBackground;

	// Use this for initialization
	void Start () {
		panelBackground.color = Color.white;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeBGColor(){
		switch (recipiePicker.value) {
		case 0:
			panelBackground.color = Color.red;
			break;
		case 1:
			panelBackground.color = Color.blue;
			break;
		case 2:
			panelBackground.color = Color.green;
			break;
		case 3:
			panelBackground.color = Color.yellow;
			break;
		default:
			panelBackground.color = Color.white;
			break;
		}
	}
}
