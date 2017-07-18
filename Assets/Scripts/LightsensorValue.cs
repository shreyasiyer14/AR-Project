using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightsensorValue : MonoBehaviour
{

    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = Sensor.light + "";   
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = Sensor.light + "";
    }
}