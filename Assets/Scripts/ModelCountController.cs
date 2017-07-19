using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModelCountController : MonoBehaviour
{

    public Slider sl;
    public GameObject obj;
    public Dropdown dr;
    // Use this for initialization
    void Start()
    {
        //int current = dr.value;
        ;
    }

    // Update is called once per frame
    void Update()
    {
        string[] tags = new[] { "Spider", "Butterfly", "Serpent" };
        int current =dr.value;
        Transform tobj = obj.transform;
        int n = tobj.childCount;
        int count = 0;
        int value = (int)sl.value;
        for (int i = 0; i < n; i++)
        {
            GameObject temp = tobj.GetChild(i).gameObject;
            if (tags[current]==temp.tag && temp.activeSelf==true)
            {
                count++;
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
                float radius = 0.1f;
                int angle = Random.Range(0, 360);
                Vector3 pos = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
                GameObject newObj = Object.Instantiate(tem, tobj.position + pos, tobj.rotation, tobj);
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
}