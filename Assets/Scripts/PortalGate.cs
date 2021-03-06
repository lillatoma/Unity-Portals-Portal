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

            //MidDifference is the difference between the player and this portal
            //We teleport the player to the other portal's midPoint, and the push the player by MidDifference rotated by the angular difference of the two portals.
            Vector3 midDifference = other.transform.position - transform.position;
            Vector3 pushedCenter = endPortal.transform.position + Quaternion.Euler(endPortal.transform.rotation.eulerAngles - transform.rotation.eulerAngles) * midDifference;
            other.gameObject.transform.position = pushedCenter;


            //We rotate the player's camera and body by the angular difference 
            other.gameObject.transform.rotation = Quaternion.Euler(other.gameObject.transform.rotation.eulerAngles + endPortal.transform.rotation.eulerAngles - transform.rotation.eulerAngles);
            other.transform.parent.GetComponent<Player>().playerCamera.transform.rotation =
                Quaternion.Euler(other.transform.parent.GetComponent<Player>().playerCamera.transform.rotation.eulerAngles + endPortal.transform.rotation.eulerAngles - transform.rotation.eulerAngles);

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
