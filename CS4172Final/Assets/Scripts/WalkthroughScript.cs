using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkthroughScript : MonoBehaviour {

	public string step1 = "step1";
	public string step1B = "step1B";
	private static bool mordantRetrieved;
	private static bool mordantPoured;
	GameObject Mordant;

	public string step2 = "step2";
	public string step2B = "step2B";

	public string step3 = "step3";
	public string step3B = "step3B";

	public string step4 = "step4";
	public string step4B = "step4B";

	public string step5 = "step5";
	public string step5B = "step5B";

	private string[] step1Items = new string[] {"HeatButton","CoolButton","Beaker","Pan"};
	private string[] step2Items = new string[] {"HeatButton","CoolButton","Beaker","Pan","SaltShaker","PaintBucket"};

	GameObject InfoQuad;
	GameObject ItemQuad;
	GameObject InstructionQuad;

	GameObject Lab;

	// Use this for initialization
	void Start () {
		InfoQuad = GameObject.Find("InfoQuad");
		ItemQuad = GameObject.Find("ItemQuad");
		InstructionQuad = GameObject.Find("InstructionQuad");
		Lab = GameObject.Find ("Lab");
		clearWorkspace (step1);
		mordantRetrieved = false;
		mordantPoured = false;
		Mordant = GameObject.Find ("Mordant");
	}
	
	// Update is called once per frame
	void Update () {
		onMordantRotation ();
	}
		
	public void setStep(string curStep) 
	{
		clearWorkspace (curStep);
		updateWorkspace(curStep);
		updateScreens (curStep);
	}

	private void updateWorkspace(string curStep)
	{
		string[] curItems = new string[] {};
			
		if (curStep == step1B) {
			curItems = step1Items;
			mordantRetrieved = true;
		}

		if (curStep == step2) {
			//Includes mordant in beaker 
			curItems = step2Items;
			Debug.Log ("updating 2");
		}

		foreach(string item in curItems) {
			Lab.transform.Find (item).gameObject.SetActive (true);
		}
	}

	private void updateScreens(string curStep)
	{
		Material infoMaterial = (Material)Resources.Load ("InfoMaterial");
		Material itemMaterial = (Material)Resources.Load ("ItemMaterial");
		Material stepMaterial = (Material)Resources.Load ("StepMaterial");
	
		if (curStep == step1B) {
//			Texture stepText1B = (Texture)Resources.Load ("Step1B.png");
//			Texture info1B = (Texture)Resources.Load ("Info1B.png");
//			Texture image1B = (Texture)Resources.Load ("Item1B.png");
////			InfoQuad.GetComponent<Renderer>().material.SetTexture ("",info1B);
////			ItemQuad.GetComponent<Renderer>().material.SetTexture ("",image1B);
////			InstructionQuad.GetComponent<Renderer>().material.SetTexture ("",step1B);
//
//			infoMaterial.mainTexture = info1B;
//			itemMaterial.mainTexture = image1B;
//			stepMaterial.mainTexture = stepText1B;

//			InfoQuad.GetComponent<Renderer> ().material.mainTexture = info1B;
//			ItemQuad.GetComponent<Renderer> ().material.mainTexture = image1B;
//			InstructionQuad.GetComponent<Renderer> ().material.mainTexture = stepText1B;

			InfoQuad.GetComponent<Renderer>().material = infoMaterial;
			ItemQuad.GetComponent<Renderer>().material = itemMaterial;
			InstructionQuad.GetComponent<Renderer>().material = stepMaterial;
		}

		if (curStep == step2) {

		}
	}

	private void clearWorkspace(string curStep)
	{
		foreach (Transform child in Lab.transform) {
			if (child.tag.Contains("lab")) {
				child.gameObject.SetActive (false);
			}
		}
	}

	public void onMordantRotation()
	{
		if (mordantRetrieved == true && mordantPoured == false) {
			Debug.Log (Mordant.transform.rotation.eulerAngles);
//			mordantPoured = true;

			if (Mordant.transform.rotation.eulerAngles.x < 60) {
				mordantPoured = true;

				Debug.Log ("Mordant poured");

				//Play particle animation 
				Mordant.GetComponent<ParticleSystem>().Play();
				Mordant.GetComponent<ParticleSystem>().enableEmission = true;

				//Deactivate mordant game object 

				//Show 2D Congratualations screen - close on 'OK'. 

				//Initiate step 2 and show Step 2 screen. 
				setStep(step2);

			}
		}
	}

	public void showStepCompleteScreen(string curStep)
	{

	}
}
