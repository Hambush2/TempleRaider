using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10;
    public float jump = 10;
    Rigidbody rbody;
    CapsuleCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        //locks the mouse to the centre of the screen and hides it so it doesn't show for the player
        Cursor.lockState = CursorLockMode.Locked;
        rbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the inputs and makes them into floats that represent the velocity in the given direction
        float fwdBck = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        fwdBck *= Time.deltaTime;
        straffe *= Time.deltaTime;

        //moves the player model based on the inputs
        transform.Translate(straffe, 0, fwdBck);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //allows the player to jump when on the ground
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rbody.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
    }

    //uses a raycast to check if the player is on the ground
    bool IsGrounded()
    {
        float distToGround = collider.bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}