using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamera : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject localPortal;
    public GameObject otherPortal;

    void Update()
    {

        //The vector difference between the player's camera and local portal
        Vector3 diffVector = (playerCamera.transform.position - localPortal.transform.position);

        //The angular difference between the two portals
        Vector3 diffAngVector = otherPortal.transform.rotation.eulerAngles - localPortal.transform.rotation.eulerAngles;

        //The (local) camera must be exactly diffVector's length distance from the otherPortal and rotated by the angular difference
        //This produces accurate camera positioning
        transform.position = otherPortal.transform.position + Quaternion.Euler(diffAngVector)*diffVector;

        //Last, the (local) camera must be rotated to the player's camera's angle + the angular difference
        //This produces accurate camera rotation
        transform.rotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles + diffAngVector);
    }
}
