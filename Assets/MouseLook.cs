using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform playerHead;
    public Transform playerShootingArm;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -65f, 65f);
        yRotation += mouseX;

        playerHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        playerShootingArm.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);



    }
}
