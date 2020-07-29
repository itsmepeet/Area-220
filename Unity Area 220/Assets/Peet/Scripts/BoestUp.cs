﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoestUp : MonoBehaviour
    {
    public float power;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject block = collision.gameObject;
            Rigidbody rb = block.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
