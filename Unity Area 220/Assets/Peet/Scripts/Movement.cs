using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;
    public float jumpspeed = 10f;
    public float hoverspeed = -1f;
    public Rigidbody rb;
    public bool ballIsOnTheGround = true;
    public GameObject deathParticles;
    public GameObject slowdown;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal") * speed;

        var vector = new Vector3(horizontal, rb.velocity.y ,0);


        if (Input.GetButtonDown("Jump") && ballIsOnTheGround)
        {
            vector.y = jumpspeed;
            ballIsOnTheGround = false;
        }
        if (Input.GetButton("Jump"))
        {
            vector.y = Mathf.Max(vector.y, hoverspeed);

        }
        rb.velocity = vector;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            ballIsOnTheGround = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }

}
