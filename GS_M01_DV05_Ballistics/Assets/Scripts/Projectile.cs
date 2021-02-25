using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float launchForce = 15f;
    Rigidbody rb;
    Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FiringSolution fs = new FiringSolution();
            Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
            if (aimVector.HasValue)
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.isKinematic = true;
            transform.position = startPos;
            rb.isKinematic = false;
            target.transform.position = new Vector3(UnityEngine.Random.Range(-3, 3), target.transform.position.y, UnityEngine.Random.Range(-3, 3));
        }
    }
}
