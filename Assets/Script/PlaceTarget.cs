using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTarget : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject targetPrefab;
    private GameObject targetInstance;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (targetInstance == null)
                {
                    targetInstance = Instantiate(targetPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    targetInstance.transform.position = hitPose.position;
                    targetInstance.transform.rotation = hitPose.rotation;
                }
            }
        }
    }
}

