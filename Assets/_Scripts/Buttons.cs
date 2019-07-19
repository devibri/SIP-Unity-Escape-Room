
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
	CubeMovement cubeMove;
	public string direction;
    // Start is called before the first frame update
    void Start()
    {
        cubeMove = GameObject.Find("MazeCube").GetComponent <CubeMovement> ();
    }

	public void Press()
	{
		cubeMove.Move(direction);
		Debug.Log ("Pressing matter");
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
