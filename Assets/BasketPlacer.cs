using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BasketPlacer : MonoBehaviour
{
    public GameObject basketPrefab;

    public ARRaycastManager raycastManager;

    void Start()
    {
        PlaceBasket();
    }

    void PlaceBasket()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = s_Hits[0].pose;
            Instantiate(basketPrefab, hitPose.position, Quaternion.identity);
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
}
