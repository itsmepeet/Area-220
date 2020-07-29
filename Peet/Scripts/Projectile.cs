using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody ProjectileFire;
    public Transform barrelEnd;
    public float FireRate = 3f;
    public float speed = 10f;

    private void Start()
    {
        StartCoroutine(FireEveryXSeconds(FireRate));
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FireEveryXSeconds(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(ProjectileFire, barrelEnd.position, barrelEnd.rotation);
        projectileInstance.AddForce(barrelEnd.up * speed);
        StartCoroutine(FireEveryXSeconds(fireRate));
    }
}
