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
}
