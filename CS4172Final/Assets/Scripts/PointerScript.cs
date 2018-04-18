using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour {

	private HelperScript helper;
	private GameObject pointer;
	public Color BeakerColor, DyeColor;
	public Material BeakerMat;
	public GameObject Beaker, Bucket, Lab, Faucet;
	private bool FaucetActive=false;
	private float BeakerContains=0.0f;

	// Use this for initialization
	void Start () {
		Faucet.SetActive (FaucetActive);
		helper = GameObject.Find("ARCamera").GetComponent<HelperScript>();
		pointer = GameObject.Find ("Pointer");
		BeakerMat = Beaker.GetComponent<Renderer> ().material;
		Bucket.GetComponent<Renderer>().material.color = DyeColor;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag.Contains ("lab")) {
			GameObject prevObj = helper.getCurrentObject ();
			GameObject curObj = other.transform.gameObject;

			helper.setCurrentObject (curObj);

			Debug.Log (helper.getCurrentObject ().tag);

			//Paint Bucket or Salt selected
			if (other.tag.Contains ("paint") || other.tag.Contains ("salt")) {
				if (helper.getAttachedObject ()) {
					helper.getAttachedObject ().transform.parent = (Lab.transform);
				}
				helper.setAttachedObject (curObj);
				switchObjectParent (curObj);
			}

			//Beaker selected
			if (other.tag.Contains ("beaker"))
			{
				//Show 2D UI and allow the user to create a dye/mordant combo

//				Set current object if exists into beaker
				if (helper.getAttachedObject() != null) {
					GameObject ThisObj = Instantiate(helper.getAttachedObject(),Lab.transform);
					Destroy (helper.getAttachedObject ());
					helper.setAttachedObject (null);
					ThisObj.transform.position = Beaker.transform.position;
					if(ThisObj.tag.Contains("salt")){
						ThisObj.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);

						if (BeakerContains == 1.0f) {
							BeakerContains = 1.1f;
						} else {
							BeakerContains = 0.1f;
						}
					}else{
						ThisObj.transform.localScale = new Vector3 (0.005f, 0.005f, 0.005f);

						if (BeakerContains == 0.1f) {
							BeakerContains = 1.1f;
						} else {
							BeakerContains = 1.0f;
						}
					}
				}
			}

			//Hot Button Selected
			if (other.tag.Contains ("heat"))
			{
				//Show fire animation and change beaker color to color of dye inside
				if (1.0 <= BeakerContains) {
					BeakerMat.color = DyeColor;
				}
			}

			//Cool Button Selected
			if (other.tag.Contains ("cool"))
			{
				//Show water animation from above beaker
				FaucetActive = !FaucetActive;
				Faucet.SetActive (FaucetActive);
			}

		}
	}

	//Switches object parent to translate the object
	void switchObjectParent(GameObject curObj)
	{
		curObj.GetComponentInParent<Transform> ().parent = pointer.transform;

		//Freeze object rotation
		curObj.GetComponent<Rigidbody>().freezeRotation = true;
	}



	void OnTriggerStay(Collider other)
	{

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Trigger exited");
	}
}
