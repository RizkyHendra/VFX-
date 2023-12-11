using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControllerScript : MonoBehaviour
{
    public int FPS = 120;
    public float speed = 6.0f;
    public float jumspeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    float yRotation;
    float xRotation;
    float lookSensitivy = 2;
    float currentXRotation;
    float currentYRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothes = 0.1f;
    void Start()
    {
        // untuk mengatur FPS game
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumspeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        yRotation += Input.GetAxis("Mouse X") * lookSensitivy;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivy;
        xRotation = Mathf.Clamp(xRotation, -80, 100);
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothes);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothes);
        transform.rotation = Quaternion.Euler(xRotation, yRotationV, 0);

    }
}
