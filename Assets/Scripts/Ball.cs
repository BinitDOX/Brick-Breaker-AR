using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballInitVelo = 600f;
    public string btnName;

    public static Rigidbody rb;
    public static bool ballInPlay;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) && ballInPlay == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                btnName = hit.transform.name;
                switch (btnName)
                {
                    case "ball":
                        transform.parent = null;
                        ballInPlay = true;
                        rb.isKinematic = false;
                        rb.AddForce(new Vector3(-ballInitVelo, 0, -ballInitVelo));
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
