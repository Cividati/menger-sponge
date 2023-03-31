using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    /* Variables */
    Camera camera;
    Vector3 moveToPosition; // This is where the camera will move after the start
    float speed = 0.1f; // this is the speed at which the camera moves
    
    /* functions */
    void Start () {
    camera = Camera.main;
    
    }
    
    void Update () {
        // so we only want the movement to start when we decide
        camera.transform.position = Vector3.Lerp(camera.transform.position, moveToPosition, speed * Time.deltaTime);
        
   }
 
 }

