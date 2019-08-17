using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceTimer : MonoBehaviour
{
	public float gameTime;
    private TextMesh timerText;
    private float startTime;
    private string minutes;
    private string seconds;
    // Start is called before the first frame update
    void Start()
    {
		timerText = gameObject.GetComponent<TextMesh>();
		startTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.time;

        minutes = (((int)t) / 60).ToString();
        seconds = (t % 60).ToString("f0");
		if (int.Parse(seconds)<0){
			seconds=Mathf.Abs(int.Parse(seconds)).ToString();
		}
		if (seconds.Equals("60"))
		{
			seconds = "59";
		}
		if (int.Parse(seconds) < 10){
			timerText.text = minutes + ":0" + seconds;
		}
		else
		{
			timerText.text = minutes + ":" + seconds;
		}
	}
    public void penalty(int val)
	{
		startTime -= (float)(val * 60.00);
		int red = int.Parse(minutes) - val;
		minutes = red.ToString();
		timerText.text = minutes + ":" + seconds;
	}
}

