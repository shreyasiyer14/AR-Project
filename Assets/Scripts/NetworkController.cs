using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour {

	[SerializeField] private GameObject serverObj;
	[SerializeField] private GameObject clientObj;
	[SerializeField] private GameObject commonObj;
	[SerializeField] private GameObject sceneCam;

	void Update () {
		if (NetworkServer.active) {
			serverObj.SetActive (true);
		} else if (NetworkClient.active) {
			clientObj.SetActive (true);
			commonObj.SetActive (true);
			sceneCam.SetActive (false);
		}
	}
}
