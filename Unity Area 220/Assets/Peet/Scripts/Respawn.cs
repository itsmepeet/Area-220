using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    public float ResetDelay = 5f;

    private GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        var rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        player.SetActive(false);
        rb.velocity = Vector3.zero;
        Invoke("Reset", ResetDelay);
    }

    private void Reset()
    {
        player.SetActive(true);
        player.transform.position = respawnPoint.transform.position;
        var rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.useGravity = true;
        player = null;
        
    }   

}
