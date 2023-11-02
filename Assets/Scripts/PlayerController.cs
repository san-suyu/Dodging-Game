using System.Collections;
using System.Collections.Generic;
using UnityEngine; // allows special unity methods

// type monobehavior
public class PlayerController : MonoBehaviour
{
    [Tooltip("reference to the player's Rigidbody component")]
    [SerializeField] Rigidbody rb;

    [Tooltip("Force strength of the jump")]
    [SerializeField] float jumpHeight;

    [Tooltip("speed that player moves")]
    [SerializeField] float moveSpeed;

    bool canJump;

    // Update is called once per frame
    // only use for inputs
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    //FixedUpdate is called every fixed frame ; every system runs a frame at different moments 
    // > sync wth time, not frames ; used when smth like physics needs to be consistently applied
    private void FixedUpdate()
    {
        //add horizontal forces to the player gameobject based on the axis inputs

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forceDirection = new Vector3(horizontalInput, 0f, verticalInput);

        rb.AddForce(forceDirection * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the gameobject of the collision has the "ground" tag, set canJump to true

        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
