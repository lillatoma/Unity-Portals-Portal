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
            Debug.Log("Collision Enter");
            other.gameObject.transform.position += endPortal.transform.position - transform.position;
            endPortal.GetComponent<PortalGate>().isActive = false;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isActive = true;
    }
}
