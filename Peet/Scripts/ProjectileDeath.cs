using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour 
{

    public GameObject ProjectileDeathParticle;
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Instantiate(ProjectileDeathParticle, transform.position, Quaternion.identity);
           
        }


    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

