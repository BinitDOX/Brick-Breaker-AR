using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Rigidbody rb;
    public float ballInitVelo = 600f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider)
        {
            rb.AddForce(new Vector3(-ballInitVelo, 0, -ballInitVelo));
        }
        else if (other is SphereCollider)
        {
            rb.AddForce(new Vector3(-ballInitVelo, 0, -ballInitVelo));
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
