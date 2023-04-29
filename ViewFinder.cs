//Libraries imported 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libraries for AR Foundation
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ViewFinder : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    // Start is called before the first update
    void Start()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        // hide the placement indicator visual
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // shoot a raycast with reticle from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit a viable flat surface, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
        
        // enable the visual if it's disabled
        if (!visual.activeInHierarchy)
            visual.SetActive(true);
    }
}
