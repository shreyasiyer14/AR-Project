using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModelCountController : MonoBehaviour
{

    public Slider sl;
    public GameObject obj;
    public Dropdown dr;
    private string[] tags;
    // Use this for initialization
    void Start()
    {
        //int current = dr.value;
        Transform tobj = obj.transform;
        tobj.GetChild(0).gameObject.SetActive(true);
        int n= tobj.childCount;
        tags = new string[n];
        for(int i=0;i<n;i++)
        {
            tags[i] = tobj.GetChild(i).gameObject.tag;
        }
    }

    public void CountUpdate()
    {
        int current =dr.value;
        Transform tobj = obj.transform;
        int n = tobj.childCount;
        int count = 0;
        int value = (int)sl.value;
        for (int i = 0; i < n; i++)
        {
            GameObject temp = tobj.GetChild(i).gameObject;
            if (tags[current]==temp.tag)
            {
                count++;
                temp.SetActive(true);
            }
            else
                temp.SetActive(false);
        }
        GameObject tem = tobj.GetChild(current).gameObject;
        Random r = new Random();
        if (count == value)
            return;
        else if (count < value)
        {
            while (count < value)
            {
				float radius = Random.Range(1,5)/12f;
                int angle = Random.Range(0, 360);
                Vector3 pos = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
				GameObject newObj = Object.Instantiate(tem, tem.transform.position + pos, tem.transform.rotation, tobj);
                newObj.SetActive(true);
                count++;
            }
        }
        else
        {
            for(int i=tags.Length; count > value && i < n;i++)
            {
                GameObject temp = tobj.GetChild(i).gameObject;
                if(temp.tag==tags[current])
                {
                    Object.Destroy(temp);
                    i--;
                    n--;
                    count--;
                }
            }
        }
    }
    public void ModelUpdate()
    {
        Transform tobj = obj.transform;
        int n = tobj.childCount;
        int current = dr.value;
        for (int i = 0; i < n; i++)
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