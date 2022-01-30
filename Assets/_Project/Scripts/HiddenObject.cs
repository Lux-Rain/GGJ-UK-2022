using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HiddenObject : MonoBehaviour
{
    public static List<HiddenObject> hiddenObjects = new List<HiddenObject>();
    private Collider collider;
    
    public UnityEvent OnDetected;
    [SerializeField] private float distance;
    public void Awake(){
        hiddenObjects.Add(this);
        collider = GetComponentInChildren<Collider>();
    }

    public static bool ChecksAllObject(Camera cam)
    {
        bool currentBool = false;
        bool lastBool = false;
        foreach (HiddenObject hiddenObject in hiddenObjects)
        {
            lastBool =hiddenObject.CheckObject(cam);
            if (lastBool)
            {
                currentBool = true;
            }
        }

        return currentBool;
    }

    public bool CheckObject(Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
        {
            if (Vector3.Distance(transform.position, cam.transform.position) <= distance)
            {
                OnDetected?.Invoke();
                return true;
            }
        }

        return false;
    }
}
