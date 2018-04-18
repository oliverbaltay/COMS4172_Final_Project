using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperScript : MonoBehaviour {

	public GameObject curObject, AttachedObject;
	private string curMode;

	public void setCurrentObject(GameObject newObj)
	{
		curObject = newObj;
	}

	public GameObject getCurrentObject()
	{
		return curObject;
	}

	public void setAttachedObject(GameObject newObj)
	{
		AttachedObject = newObj;
	}
	public GameObject getAttachedObject()
	{
		return AttachedObject;
	}
	public void setCurrentMode(string newMode)
	{
		curMode = newMode;
	}

	public string getCurrentMode()
	{
		return curMode;
	}

	// Use this for initialization
	void Start () {
		setAttachedObject (null);
		setCurrentObject (null);
		setCurrentMode (null);
	}

	// Update is called once per frame
	void Update () {

	}
}
