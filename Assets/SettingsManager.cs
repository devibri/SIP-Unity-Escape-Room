using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
	Toggle moneyToggle;
	Toggle penaltyToggle;
    public bool moneyVariant;
    public bool penaltyVariant;
	private float time;

    // Start is called before the first frame update
    void Awake()
    {
		moneyVariant = false;
		penaltyVariant = false;
		Object.DontDestroyOnLoad(this);
    }

	public void FindToggle()
	{
		penaltyToggle = GameObject.Find ("Penalty").GetComponent<Toggle> ();
		moneyToggle = GameObject.Find ("Money").GetComponent<Toggle> ();

		moneyToggle.isOn = false;
		penaltyToggle.isOn = false;

	}


	// Update is called once per frame
	void Update()
    {
        time=Time.time;//nothing needs to be here
    }


	public void ChangeButton()
	{
		if (moneyToggle.isOn == true) 
		{
			moneyVariant = true;
		}
		else if (moneyToggle.isOn == false) 
		{
			moneyVariant = false;
		}


		if (penaltyToggle.isOn == true) 
		{
			penaltyVariant = true;
		}
		else if (penaltyToggle.isOn == false) 
		{
			penaltyVariant = false;
		}

	}
}
