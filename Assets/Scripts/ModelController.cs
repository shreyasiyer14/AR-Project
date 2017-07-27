using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelController : MonoBehaviour {
	[SerializeField] private string idleAnim;
	[SerializeField] private string walkAnim;
	[SerializeField] private float speed;
	[SerializeField] private int directionOfWalk;
	[SerializeField] private Slider scaleSlider;
    [SerializeField] private Dropdown insectDropdown;
    [SerializeField] private Slider countSlider;
    private float scale;
	private Quaternion targetRotation;

	private bool isRotChanged = false;
	public bool isWalking = false;
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;	
		StartCoroutine ("startRotation");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWalking && idleAnim != "") {
			GetComponent<Animation> ().wrapMode = WrapMode.Loop;
			GetComponent<Animation> ().CrossFade (idleAnim);
		} else if (isWalking) {
			GetComponent<Animation> ().CrossFade (walkAnim);
			transform.Translate (directionOfWalk * Vector3.forward * speed * Time.fixedDeltaTime);
		}
	}

	public void modifyScale () {
		GameObject[] models = GameObject.FindGameObjectsWithTag (gameObject.tag);
		foreach (GameObject model in models) {
			model.transform.localScale = new Vector3 (scaleSlider.value, scaleSlider.value, scaleSlider.value);
		}
	}

	public void walkAnimStart () {
		GameObject[] models = GameObject.FindGameObjectsWithTag (gameObject.tag);
		foreach (GameObject model in models) {
			model.GetComponent<ModelController> ().isWalking = true;
		}
		isRotChanged = true;
	}

	IEnumerator startRotation () {
		while (true) {
			isRotChanged = false;
			yield return new WaitForSeconds (3f);
			isRotChanged = true;
			yield return new WaitForSeconds (1f);
			if (isRotChanged) {
				targetRotation *= Quaternion.AngleAxis (60, Vector3.up);
				transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10f * Time.deltaTime); 
			}
		}
	}
    public void modifyState()
    {
        GameObject[] models = GameObject.FindGameObjectsWithTag(gameObject.tag);
        bool state = false;
        int menuIndex = insectDropdown.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = insectDropdown.GetComponent<Dropdown>().options;
        string value = menuOptions[menuIndex].text;
        //Debug.Log(gameObject.tag +" "+ value);
        if (value == gameObject.tag)
        {
            state = true;
            gameObject.SetActive(true);
        }
        foreach (GameObject model in models)
        {
            Debug.Log(gameObject.tag + " " + value);
            model.SetActive(state);
        }
        modifyCount();
    }
    public void modifyCount()
    {
        if (gameObject.activeSelf == false)
            return;
        GameObject[] models = GameObject.FindGameObjectsWithTag(gameObject.tag);
        int count = (int)countSlider.value;
        if (count == models.Length)
        {
            return;
        }
        else if(count > models.Length)
        {
            bool state = gameObject.activeSelf;
            int added = 0;
            while (count > models.Length + added)
            {
                float radius = Random.Range(1, 5) / 12f;
                int angle = Random.Range(0, 360);
                Vector3 pos = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
                GameObject newObj = Object.Instantiate(gameObject, gameObject.transform.position + pos, gameObject.transform.rotation, gameObject.transform.parent.transform);
                newObj.SetActive(state);
                added++;
            }
        }
        else
        {
            int deleted = 0;
            for(int i=0; count < models.Length - deleted && i <models.Length;i++)
            {
                if(models[i]==gameObject)
                {
                    continue;
                }
                else
                {
                    Object.Destroy(models[i]);
                    deleted++;
                }
            }
        }
    }
}
