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
        string[] tags = new[] { "Spider", "Butterfly", "Serpent" };
        Transform tobj = obj.transform;
        int n= tobj.childCount;
        int current = dr.value;
        for(int i=0;i<n;i++)
        {
            GameObject temp = tobj.GetChild(i).gameObject;
            if (temp.tag == tags[current])
            {
                temp.SetActive(true);
            }
            else
                temp.SetActive(false);
        }
	}
}
