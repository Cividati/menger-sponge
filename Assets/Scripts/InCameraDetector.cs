using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if(GeometryUtility.TestPlanesAABB(cameraFrustum, bounds)){
            
            //renderer.gameObject.GetComponent<MeshRenderer>().enabled = true;
        } else {
            
            Destroy(renderer.gameObject);
            //renderer.gameObject.GetComponent<MengerSponge>().RemoveObject(renderer.gameObject);
            
            
        }
    }
}
