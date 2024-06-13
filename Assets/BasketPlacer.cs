using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARAnchorManager))]
public class BasketPlacer : MonoBehaviour
{
    public GameObject basketPrefab;
    public ARAnchorManager anchorManager;
    public ARRaycastManager raycastManager;

    public bool basketPlaced = false;

    void Update()
    {
        if (!basketPlaced && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceBasket();
        }
    }

    void PlaceBasket()
    {
        Vector2 touchPos = Input.GetTouch(0).position;

        var hits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            ARAnchor anchor = anchorManager.AddAnchor(hitPose);

            Instantiate(basketPrefab, hitPose.position, basketPrefab.transform.rotation, anchor.transform);

            basketPlaced = true;
        }
    }
}
