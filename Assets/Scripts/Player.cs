using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject body;
    public GameObject playerCamera;
    [Header("Attributes")]
    public float moveSpeed;
    public float mouseSensitivity;

    private Vector3 camOffset;

    void Move()
    {
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        //When no movement key is pressed;
        if (vert == 0 && hori == 0)
            return;


        //Based on our input, we calculate the direction vector
        //Then rotate it with the rotation of our body

        Vector2 relativeDirectionVector = new Vector2(vert, hori);
        float angle = Mathf.Rad2Deg * UseTools.RealVector2Angle(relativeDirectionVector); 
        body.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis( angle, Vector3.up) * body.transform.forward * moveSpeed;
    }

    void ClampCameraAngles()
    {
        //if (playerCamera.transform.rotation.eulerAngles.x < -90)
        //    playerCamera.transform.rotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles - new Vector3(90f + playerCamera.transform.rotation.eulerAngles.x, 0, 0));
        //else if (playerCamera.transform.rotation.eulerAngles.x < 270 && playerCamera.transform.rotation.eulerAngles.x > 180)
        //    playerCamera.transform.rotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles - new Vector3(-90f + playerCamera.transform.rotation.eulerAngles.x, 0, 0));
        playerCamera.transform.rotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles.x, playerCamera.transform.rotation.eulerAngles.y, 0);
    }

    void Rotate()
    {
        ClampCameraAngles();

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX == 0 && mouseY == 0)
            return;



        Quaternion curRotofCamera = playerCamera.transform.rotation;

        if (-mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x < -90f 
            || (-mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x > 180f
            && -mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x < 270f))
            mouseY = 0;

        playerCamera.transform.rotation = Quaternion.Euler(curRotofCamera.eulerAngles + new Vector3(-mouseY,mouseX,0)*mouseSensitivity);
        Quaternion curRotofBody = body.transform.rotation;
        body.transform.rotation = Quaternion.Euler(curRotofBody.eulerAngles + new Vector3(0, mouseX, 0) * mouseSensitivity);

    }

    void UpdateCamera()
    {
        playerCamera.transform.position = body.transform.position + camOffset;
    }


    // Start is called before the first frame update
    void Start()
    {
        camOffset =  playerCamera.transform.position - body.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        UpdateCamera();
    }
}
