using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
	 // put the first material here.
	 public Material material1;
	 // put the second material here.
	 public Material material2;
	 bool FirstMaterial = true;
	 bool SecondMaterial = false;
	 GameObject gameManager;
	 public bool isCorrect;
	 
	 void Start () 
	 {
		 gameManager = GameObject.Find("GameManager");
		 GetComponent<Renderer>().material = material1;
	 }
	 
	 public void Press()
	 {
		 if (FirstMaterial)
		 {
			 GetComponent<Renderer>().material = material2;
			 SecondMaterial = true;
			 FirstMaterial = false;
		 }
		 else if (SecondMaterial)
		 {
			 GetComponent<Renderer>().material = material1;
			 FirstMaterial = true;
			 SecondMaterial = false;
		 }
		 
		 if (isCorrect) {
			 isCorrect = false;
		 } else {
			 isCorrect = true;
		 }
		 
		gameManager.GetComponent<GameManager>().QuadChecker();
	 }
}
