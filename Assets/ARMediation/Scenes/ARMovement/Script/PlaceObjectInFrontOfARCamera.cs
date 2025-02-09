using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlaceObjectInFrontOfARCamera : MonoBehaviour {

    public int msDelayBeforePlacing = 2000;
    
    async void Start() {
        await Task.Delay (msDelayBeforePlacing);
        Camera cam = Camera.main;
        
        Vector3 newPosition = cam.transform.position + 1f * cam.transform.forward;
        //Place Object on the ground
        newPosition.y = 0;
        transform.position = newPosition;
        
        //Look at the camera but only for Y axis (object will only turn around the Up axis to face the camera)
        transform.LookAt (cam.transform.position, Vector3.up);
        transform.rotation = Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0));
    }
}
