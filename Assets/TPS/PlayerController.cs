using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 rotation;
    private Vector3 cameraRotation;

    [SerializeField]
    private Transform cameraHolder;

    private Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float sensitivity;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        DoMovement();
        DoRotation();
    }

    private void DoRotation()
    {
        float xRot = Input.GetAxis("Mouse Y");
        float yRot = Input.GetAxis("Mouse X");

        cameraRotation.x -= xRot * sensitivity;
        rotation.y += yRot * sensitivity;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -80, 50);

        transform.rotation = Quaternion.Euler(rotation);
        cameraHolder.localRotation = Quaternion.Euler(cameraRotation);
    }

    private void DoMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float yMovement = rb.velocity.y;

        bool jump = Input.GetButtonDown("Jump");
        if(isGrounded && jump)
        {
            yMovement = jumpForce;
        }

        rb.velocity = new Vector3(hor * speed, yMovement, vert * speed);
    }
}
