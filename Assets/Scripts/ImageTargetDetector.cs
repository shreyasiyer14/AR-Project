using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetDetector : MonoBehaviour,
                                            ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Transform emptyTrans;
    public GameObject currentsModels;
    private GameObject target;
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        target = gameObject;
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            currentsModels.transform.SetParent(target.transform);
            currentsModels.transform.localPosition = Vector3.zero;
        }
    }
}