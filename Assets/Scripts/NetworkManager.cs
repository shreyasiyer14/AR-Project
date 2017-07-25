using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
	[SerializeField] private GameObject VuforiaComponent;
	//[SerializeField] private GameObject Controls;
	[SerializeField] private GameObject mainCam;
	private bool isHost;

	void Start () {
		isHost = false;
		Connect ();
	}

	void Connect () {
		PhotonNetwork.ConnectUsingSettings ("ARPhobia v1.0.0");
	}

	void OnJoinedLobby () {
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom (null);
		//Controls.SetActive (true);
		isHost = true;
	}

	void OnJoinedRoom () {
		if (!isHost) {
			mainCam.SetActive (false);
			VuforiaComponent.SetActive (true);
		}
	}
}
