using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InsectOptions : MonoBehaviour {
    public GameObject obj;
    public Dropdown dr;
	// Use this for initialization
	void Start () {
        Transform tobj = obj.transform;
        int n = tobj.childCount;
        for(int i=0;i<n;i++)
        {
            dr.options.Add(new Dropdown.OptionData(tobj.GetChild(i).gameObject.tag));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
