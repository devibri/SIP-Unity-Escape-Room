using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
	private string minutes;
	private string seconds;
    // Start is called before the first frame update
    void Start()
    {
        startTime = 3600.00f;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime-Time.time;

        minutes = (((int)t)/60).ToString();
        seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
       
    }
    public void penalty()
	{
		int red = int.Parse(minutes) - 2;
		minutes = red.ToString();
		startTime = startTime - 120.00f;
		timerText.text = minutes+":" + seconds;
	}
}
