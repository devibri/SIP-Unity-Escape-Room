using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
	Rigidbody cubeRB;
    public Timer timerScript;
	
    // Start is called before the first frame update
    void Start()
    {
		cubeRB = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.W)) 
	   {
			Move("Up"); 
	   }
	   
	   if(Input.GetKeyDown(KeyCode.S)) 
	   {
		   Move("Down");
	   }
	   
	   //if(Input.GetKeyDown(KeyCode.D)) 
	   //{
	//   Move("Right");
  
	 //  }  
	   
	  // if(Input.GetKeyDown(KeyCode.A)) 
	  // {
	//	   Move("Left");
	 //  }
    }
	
	public void Move(string direction)
	{
		Vector3 step = new Vector3();
		
		if(direction == "Up")
		{
			step = new Vector3(0,0.18f,0);
		}
		
		if(direction == "Down")
		{
			step = new Vector3(0,-0.18f,0);
			Debug.Log("Moving down");
		}
		
		if(direction == "Right")
		{
			step = new Vector3(-0.18f,0,0);
			
		}
		
		if(direction == "Left")
		{
			step = new Vector3(0.18f,0,0);
			 
		}
		
		Vector3 start = transform.position;
		Vector3 end = start + step;
		bool hit = Physics.Linecast(start,end);
        if (hit==true){
            timerScript.penalty();
}
		else if(hit == false)
		{
			cubeRB.MovePosition(end);
		}   
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("MazeEnd"))
		{
			cubeRB.useGravity = true;
			cubeRB.freezeRotation = false;
			//cubeRB.freezePosition = false;
			gameObject.tag = "Untagged";
		}
	}
}
