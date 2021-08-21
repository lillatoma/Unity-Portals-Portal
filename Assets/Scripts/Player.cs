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
    /// <summary>
    /// This function takes care of WASD input and the movement of the player's body
    /// </summary>
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
        playerCamera.transform.rotation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles.x, playerCamera.transform.rotation.eulerAngles.y, 0);
    }
    /// <summary>
    /// This function takes care of mouse movement, and the rotation of the player's camera and body
    /// </summary>
    void Rotate()
    {
        ClampCameraAngles();

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //When the mouse hasn't been moved
        if (mouseX == 0 && mouseY == 0)
            return;



        Quaternion curRotofCamera = playerCamera.transform.rotation;

        //If the mouse goes too high, or too low, this is suppsoed to block it
        if (-mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x < -90f 
            || (-mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x > 180f
            && -mouseY / mouseSensitivity + curRotofCamera.eulerAngles.x < 270f))
            mouseY = 0;

        //We rotate the playercamera and body scaled by the mousesensitivity
        playerCamera.transform.rotation = Quaternion.Euler(curRotofCamera.eulerAngles + new Vector3(-mouseY,mouseX,0)*mouseSensitivity);
        Quaternion curRotofBody = body.transform.rotation;
        body.transform.rotation = Quaternion.Euler(curRotofBody.eulerAngles + new Vector3(0, mouseX, 0) * mouseSensitivity);

    }
    /// <summary>
    /// This function sets the camera's position accoring to the bodys position
    /// </summary>
    void UpdateCamera()
    {
        playerCamera.transform.position = body.transform.position + camOffset;
    }


    void Start()
    {
        camOffset =  playerCamera.transform.position - body.transform.position;

        //Calling the Rotate() function but reverting it's effect, because on app-start,
        //The odd positioning of the mouse would rotate the player's camera
        Quaternion originalRotCamera = playerCamera.transform.rotation;
        Quaternion originalRotBody = body.transform.rotation;
        Rotate();
        playerCamera.transform.rotation = originalRotCamera;
        body.transform.rotation = originalRotBody;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        UpdateCamera();
    }
}
