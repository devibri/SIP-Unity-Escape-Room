using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //toggles for variants
    public bool moneyVariant;
    public bool penaltyVariant;
   
    public Light alarmLight;
    public AudioSource audioSource;
    public AudioClip alarmNoise1;
    public AudioClip alarmNoise2;
    public AudioClip alarmNoise3;
    public AudioClip alarmNoise4;
    public AudioClip alarmNoise5;
    public List<GameObject> quadList = new List<GameObject>();
    public Camera tvCamera;

    //number of seconds for each light
    public float lightSeconds;

    //colors for light puzzle
    public Color color1; 
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    public Timer timey;
    public WorldSpaceTimer worldy;

    public Money balance;
    public bool showSequence = true;
    int sequenceCount = 0;
    int correctNumber;
    float time = 0;
	
	public SettingsManager settingsManager;
	
	public float destroyedTime=0f;


    // Start is called before the first frame update
    void Start()
    {
		settingsManager= GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
		moneyVariant=settingsManager.moneyVariant;
		penaltyVariant=settingsManager.penaltyVariant;
		destroyedTime=Time.time;
		Destroy(settingsManager.gameObject);
		
		if (moneyVariant==false){
			GameObject.Find("MoneyCountDisplay").SetActive(false);
		}
			
		tvCamera.gameObject.SetActive	(true);
        audioSource = GetComponent<AudioSource>();
		correctNumber = 0;
        //activate camera on TV
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showSequence)
        {
            StartCoroutine(lightSequence());
        }
    }
	
	public void QuadChecker()
	{
		foreach(GameObject cubeType in quadList)
		{
			foreach(Transform quad in cubeType.transform)
			{
				if(quad.gameObject.GetComponent<ColorChange>().isCorrect)
				{
					correctNumber = correctNumber + 1;
				}
				else
				{
					if(penaltyVariant == true)
					{
						timey.penalty(1);
						worldy.penalty(1);
					}

					if(moneyVariant == true)
					{
						balance.Subtract(10);
					}
				}
			}
		}
		if(correctNumber == 54)
		{
            sequenceCount = 0;
            showSequence = true;
            GameObject.Find("BigCube").SetActive(false);
            alarmLight.gameObject.SetActive(true);
            if (moneyVariant == true)
            {
                balance.Reward(500);
            }
		}
		else
		{
			correctNumber = 0;
		}
	}

    IEnumerator lightSequence()
    {
        
        time += Time.deltaTime;
        if (time < lightSeconds * 1 && sequenceCount == 0)
        {
            tvCamera.backgroundColor = color1; //change color on TV
            alarmLight.color = Color.black; //black
            audioSource.PlayOneShot(alarmNoise3);
            sequenceCount++;
            yield return null;
        }
        if (time <= lightSeconds * 2 && time >= lightSeconds * 1 && sequenceCount == 1)
        {
            tvCamera.backgroundColor = Color.black; //black
            alarmLight.color = color2; //change light color
            audioSource.PlayOneShot(alarmNoise2);
            sequenceCount++;
            yield return null;
        }
        if (time <= lightSeconds * 3 && time >= lightSeconds * 2 && sequenceCount == 2)
        {
            tvCamera.backgroundColor = color3; //change color on TV
            alarmLight.color = Color.black; //black
            audioSource.PlayOneShot(alarmNoise4);
            sequenceCount++;
            yield return null;
        }
        if (time <= lightSeconds * 4 && time >= lightSeconds * 3 && sequenceCount == 3)
        {
            tvCamera.backgroundColor = Color.black; //black
            alarmLight.color = color4; //change light color
            audioSource.PlayOneShot(alarmNoise1); 
            sequenceCount++;
            yield return null;
        }
        if (time <= lightSeconds * 5 && time >= lightSeconds * 4 && sequenceCount == 4)
        {
            tvCamera.backgroundColor = color5; //change color on TV
            alarmLight.color = Color.black; //black
            audioSource.PlayOneShot(alarmNoise5);
            sequenceCount++;
            yield return null;
        }
        if (time > lightSeconds * 5)
        {
            sequenceCount = 0;
            time = 0;
            yield return null;
        }
    }
}


