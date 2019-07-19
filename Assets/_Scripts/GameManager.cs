using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> quadList = new List<GameObject>();
	int correctNumber;
	// Start is called before the first frame update
	
    void Start()
    {        
		correctNumber = 0;
		//Display.displays[1].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void QuadChecker()
	{
		foreach(GameObject cubeType in quadList)
		{
			foreach(Transform quad in cubeType.transform)
			{
				if(quad.gameObject.GetComponent<ColorChange>().isCorrect)
				{
					//Debug.Log("Checking cubes...");
					correctNumber = correctNumber + 1;
				} else {
					//Debug.Log("Is not correct");
				}
			}
		
		}
		Debug.Log("Correct number: " + correctNumber);
		if(correctNumber == 54)
		{
			Debug.Log("Puzzle solved");
		}
		else
		{
			correctNumber = 0;
		}
	}
}
