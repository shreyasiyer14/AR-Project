using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Switch : MonoBehaviour {
    [SerializeField] private Button switchButton;
    public bool isOn = false;
	
    public void switchTrigger ()
    {
        if (!isOn)
        {
            isOn = true;
            switchButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "OFF";
        }
        else if (isOn)
        {
            isOn = false;
            switchButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = "ON";
        }
        gameObject.SetActive(isOn);
    }
}
