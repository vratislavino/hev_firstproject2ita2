using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IDamagable
{
    private Vector3 rotation;
    private Vector3 cameraRotation;

    [SerializeField]
    private Transform cameraHolder;

    private Rigidbody rb;
    public Rigidbody Rb => rb;

    public int HP { get; set; }

    [SerializeField]
    private float speed;

    private float envSpeedMultiplier = 1f;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float sensitivity;

    [SerializeField]
    private Transform groundChecker;

    bool isHit = false;
    [SerializeField]
    private GameObject hitGraphics;
    [SerializeField]
    private float healInterval = 1;
    private float healCooldown = 1;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        UpdateGrounded();
        DoMovement();
        DoRotation();

        if(isHit)
        {
            healCooldown -= Time.deltaTime;
            if(healCooldown <= 0)
            {
                isHit = false;
                hitGraphics.SetActive(false);
                healCooldown = healInterval;
            }
        }
    }

    private void UpdateGrounded()
    {
        if(Physics.Raycast(groundChecker.position, Vector3.down, 0.06f))
        {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
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
        float currentSpeed = speed;
        float yMovement = rb.velocity.y;

        bool jump = Input.GetButtonDown("Jump");
        if(isGrounded && jump)
        {
            yMovement = jumpForce;
        }

        if(Input.GetButton("Sprint"))
        {
            currentSpeed *= 1.5f;
        }
        currentSpeed *= envSpeedMultiplier;

        Vector3 dir = (vert * transform.forward) + (hor * transform.right);

        rb.velocity = new Vector3(dir.x * currentSpeed, yMovement, dir.z * currentSpeed);
    }

    public void ChangeEnvSpeedMultiplier(float mult)
    {
        envSpeedMultiplier = mult;
    }

    public void ApplyDamage(float dmg)
    {
        if(!isHit)
        {
            isHit = true;
            hitGraphics.SetActive(true);
        } else
        {
            Time.timeScale = 0;
        }
    }
}
