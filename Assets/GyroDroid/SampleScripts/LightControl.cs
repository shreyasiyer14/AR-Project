// prefrontal cortex -- http://prefrontalcortex.de
// Full Android Sensor Access for Unity3D
// Contact:
// 		contact@prefrontalcortex.de

using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
	
	public Color dayBackgroundColor;
	public Color nightBackgroundColor;
	public Color darkAmbient = new Color(0.1f,0.1f,0.1f);
	public Color lightAmbient = new Color(1.5f,1.5f,1.5f);
	
	// Use this for initialization
	void Start () {
		// activate Light sensor
		Sensor.Activate(Sensor.Type.Light);
	}
	
	// Update is called once per frame
	void Update () {
		// fetch light sensor
		float lightValue = Sensor.light;
        float maxWhite = 1.0f;
        int maxLightValue = 150;
        float divideFactor = maxLightValue / maxWhite;
        if(lightValue!=0)
		    RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, new Color(lightValue/divideFactor, lightValue/divideFactor, lightValue/divideFactor), Time.deltaTime);
        else
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, new Color(0.001f,0.001f,0.001f), Time.deltaTime);
        //RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, new Color(lightValue/15f, lightValue / 15f, lightValue / 15f), Time.deltaTime);
        //Debug.Log(lightValue + "\n");
        //		// compare to predefined LightValue constants
        //		if(lightValue < Sensor.LightValue.Cloudy)
        //			ItIsNight(true);
        //		else
        //			ItIsNight(false);
    }
    //	
    	//void ItIsNight(bool on) {
    		// slowly fade colors and ambientLight settings
    		//if(on) {
    		//	RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, darkAmbient, Time.deltaTime);
    		//}
    		//else {
    		//	RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, lightAmbient, Time.deltaTime);
    		//}		
    	//}
}