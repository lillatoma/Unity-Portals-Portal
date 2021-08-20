using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGate : MonoBehaviour
{
    public bool isActive = true;
    public GameObject endPortal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
            return;
        if(other.tag == "Player")
        {
            //We shift our player with an offset, so the teleport process is smooth
            other.gameObject.transform.position += endPortal.transform.position - transform.position;
            //We set the other portal inactive to ensure only one teleportation process happens
            endPortal.GetComponent<PortalGate>().isActive = false;
            endPortal.GetComponent<MeshRenderer>().enabled = false;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        //AFter the player leaves the portal area, we set our portal active again
        if (other.tag == "Player")
        {
            isActive = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
