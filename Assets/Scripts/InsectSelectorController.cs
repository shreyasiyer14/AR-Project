using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InsectSelectorController : MonoBehaviour {

    public Dropdown dr;
    public GameObject obj;
    // Use this for initialization
    void Start () {
        int current = dr.value;
	}
	
	// Update is called once per frame
	void Update () {
        Transform tobj = obj.transform;
        int n= tobj.childCount;
        int current = dr.value;
        for(int i=0;i<n;i++)
        {
            if (i == current)
            {
                tobj.GetChild(i).gameObject.SetActive(true);
            }
            else
                tobj.GetChild(i).gameObject.SetActive(false);
        }
	}
}
