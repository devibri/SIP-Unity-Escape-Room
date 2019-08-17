using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public GameManager gameManager;
    public int currentBalance;
    private string moneyCount;
    public TextMesh moneyText;

    // Start is called before the first frame update
    void Start()
    {
        //don't render if no money
        if(gameManager.moneyVariant == false)
        {
            gameObject.GetComponentsInParent<MeshRenderer>()[0].enabled = false;
            gameObject.GetComponentsInParent<MeshRenderer>()[1].enabled = false;
        }
        currentBalance = 1000;
        moneyText = gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.moneyVariant)
        {
            moneyCount = currentBalance.ToString();
            if (currentBalance > 0)
            {
                moneyText.text = "Current Balance: $" + moneyCount;
            }
            else
            {
                moneyText.text = "Current Balance: -$" + Mathf.Abs(currentBalance);
            }
        }
    }

    public void Reward(int amount)
    {
        if (gameManager.moneyVariant)
        {
            currentBalance = currentBalance + amount;
            moneyCount = currentBalance.ToString();
            if (currentBalance > 0)
            {
                moneyText.text = "Current Balance: $" + moneyCount;
            }
            else
            {
                moneyText.text = "Current Balance: -$" + Mathf.Abs(currentBalance);
            }
        }
    }

    public void Subtract(int yay)
    {
        if (gameManager.moneyVariant)
        {
            currentBalance -= yay;
            moneyCount = currentBalance.ToString();
            if (currentBalance > 0)
            {
                moneyText.text = "Current Balance: $" + moneyCount;
            }
            else
            {
                moneyText.text = "Current Balance: -$" + Mathf.Abs(currentBalance);
            }
        }
    }
}
