using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamera : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject localPortal;
    public GameObject otherPortal;


    // Update is called once per frame
    void Update()
    {
        Vector3 diffVector = otherPortal.transform.position - playerCamera.transform.position;
        transform.position = localPortal.transform.position - diffVector;
        transform.rotation = playerCamera.transform.rotation;
    }
}
