using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickParticle;
    public int Hitpoints;
    private bool Destroyed;

    void OnCollisionEnter(Collision other)
    {
        ReduceHitpoints();



    }

    private void ReduceHitpoints()
    {
        Hitpoints--;
        if (Hitpoints <= 0)
        {

            DestroyBrick();
        }
    }

    public void DestroyBrick()
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);

        if (!Destroyed)
        {
            GM.instance.OnDestroyBrick();
            Destroy(gameObject);
            Destroyed = true;

        }
    }
}
