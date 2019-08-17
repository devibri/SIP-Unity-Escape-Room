using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float gameTime;
    public Text timerText;
    private float startTime;
	private string minutes;
	private string seconds;
    public Text timeOut;
	private float addOnTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = gameTime;
        timeOut.enabled = false;
		addOnTime=GameObject.Find("GameManager").GetComponent<GameManager>().destroyedTime;
	}

    // Update is called once per frame
    void Update()
    {
        float t = startTime-Time.time+addOnTime;

        minutes = (((int)t)/60).ToString();
        seconds = (t % 60).ToString("f0");
		if (int.Parse(seconds)<0){
			seconds=Mathf.Abs(int.Parse(seconds)).ToString();
		}
        if (seconds.Equals("60")) {
            seconds = "59";
        }
		if (int.Parse(seconds)<10){
			timerText.text=minutes+":0"+seconds;
		}
		else{
        timerText.text = minutes + ":" + seconds;
		}

        if(t < 0)
        {
            timeOut.text = "Awww...you are out of time!";
            timeOut.enabled = true;
            timerText.enabled = false;
        }
       
    }

    public void penalty(int numb)
	{
		int red = int.Parse(minutes) - numb;
		minutes = red.ToString();
		startTime = startTime - (float)(numb * 60.00);
		timerText.text = minutes+":" + seconds;
    }

}
