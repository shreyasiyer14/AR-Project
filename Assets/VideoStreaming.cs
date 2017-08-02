using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoStreaming : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("SendVideo", 5.0f, 0.5f);
	}

    public void SendVideo()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            PhotonView photonView = PhotonView.Get(this);
            Texture2D tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            
            /*if (tex == null)
                Debug.Log("NULL");
            else
                Debug.Log("Correct");*/

            photonView.RPC("SyncVideoBackgroundRPC", PhotonTargets.All, tex.GetRawTextureData(),tex.width,tex.height,tex.format,tex.mipmapCount);
        }
    }
    [PunRPC]
    void SyncVideoBackgroundRPC(byte[] tex,int width, int height, TextureFormat format,int mipmapCount)
    {
        Texture2D background = new Texture2D(width, height, format, mipmapCount>1);
        background.LoadRawTextureData(tex);
        GetComponent<MeshRenderer>().material.mainTexture = background;
    }
}
