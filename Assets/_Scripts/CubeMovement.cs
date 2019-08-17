using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CubeMovement : MonoBehaviour
{
	Rigidbody cubeRB;
    public bool mazeDone;
	bool confettiLoaded;
    public GameManager gameManager;
    public Timer timerScript;
    public WorldSpaceTimer tvTimer;
    public Text warning;
	public TextMesh screenWarning;
	public Money balance;
	public GameObject bigCube;
	//public GameObject ConfettiOne;
	//public GameObject ConfettiTwo;
    // Start is called before the first frame update
    void Start()
    {
        mazeDone = false;
		confettiLoaded = true;
        warning.enabled=false;
		screenWarning.gameObject.SetActive(false);
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
	   
	   if(Input.GetKeyDown(KeyCode.D)) 
	   {
	   Move("Right");
  
	   }  
	   
	   if(Input.GetKeyDown(KeyCode.A)) 
	   {
		   Move("Left");
	   }
    }
	
	public void Move(string direction)
	{
        if (!mazeDone)
        {
            Vector3 step = new Vector3();

            if (direction == "Up")
            {
                step = new Vector3(0, 0.18f, 0);
            }

            if (direction == "Down")
            {
                step = new Vector3(0, -0.18f, 0);
            }

            if (direction == "Left")
            {
                step = new Vector3(0.18f, 0, 0);

            }

            if (direction == "Right")
            {
                step = new Vector3(-0.18f, 0, 0);

            }

            Vector3 start = transform.position;
            Vector3 end = start + step;
            bool hit = Physics.Linecast(start, end);
            if (hit == true)
            {
                if (gameManager.penaltyVariant == true)
                {
                    timerScript.penalty(1);
                    tvTimer.penalty(1);
                    StartCoroutine(ShowMessage("  PENALTY \n-1 MINUTES", 2));
                }
                if (gameManager.moneyVariant == true)
                {
                    balance.Subtract(75);
                    //StartCoroutine(ShowMessage(" PENALTY \n-$75", 2));
                }
            }
            else if (hit == false)
            {
                cubeRB.MovePosition(end);
            }
        }
	}

    IEnumerator ShowMessage(string message, int delay) {
        warning.text=message;
		screenWarning.text=message;
        warning.enabled=true;
		screenWarning.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        warning.enabled=false;
		screenWarning.gameObject.SetActive(false);
}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("MazeEnd"))
		{
			cubeRB.useGravity = true;
			cubeRB.freezeRotation = false;
			//cubeRB.freezePosition = false;
			gameObject.tag = "Untagged";
            mazeDone = true;
			bigCube.SetActive(true);
			if (GameObject.Find("GameManager").GetComponent<GameManager>().penaltyVariant==true){
				balance.Reward(350);
			}
		}
	}
	
	public void OnTriggerExit(Collider other)
	{
		
		if(confettiLoaded && other.gameObject.name=="MazeEnd")
		{
			confettiLoaded = false;
			AudioSource source;
			source = GetComponent<AudioSource>();
			source.Play();
			
			ParticleSystem confettiOne;
			confettiOne = GameObject.Find("ConfettiOne").GetComponent<ParticleSystem>();
			confettiOne.Play();
			
			ParticleSystem confettiTwo;
			confettiTwo = GameObject.Find("ConfettiTwo").GetComponent<ParticleSystem>();
			confettiTwo.Play();
		} 
		
		
	}
}
