using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Padel : MonoBehaviour
{
    private Vector3 pdlPos = new Vector3();
    private Rigidbody rby;
    Vector3 movemt;
    public AudioClip audioClip;
    public Setting st;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rby = GetComponent<Rigidbody>();
        movemt = new Vector3(0f, 0.0f, 0f);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pdlPos = transform.position;
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        pdlPos.x = Mathf.Clamp(xPos, -0.27f, 0.27f);
        pdlPos.z = Mathf.Clamp(zPos, 0f, 0.13f);
        transform.position = pdlPos;

        //float x = CrossPlatformInputManager.GetAxis("Horizontal");
        //float y = CrossPlatformInputManager.GetAxis("Vertical");
        //Vector3 movemt = new Vector3(x, 0.0f, y);
        //rby.velocity = movemt * 0.05f;

    }

    void FixedUpdate()
    {
        if (st.nav == true)
        {
            float x = CrossPlatformInputManager.GetAxis("Horizontal");
            float y = CrossPlatformInputManager.GetAxis("Vertical");
            //Vector3 movemt = new Vector3(x, 0.0f, y);
            movemt.Set(-x, 0.0f, -y);
            movemt = movemt.normalized * 0.5f * Time.deltaTime;
            rby.MovePosition(rby.position + movemt);
        }

        if (st.touch == true)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(/*Input.GetTouch(0).position*/Input.mousePosition);
                //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2f, Camera.main.pixelHeight / 2f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                    if(hit.transform.name == "paddle")
                        rby.MovePosition(hit.point);    
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Ball.rb.AddForce(Ball.rb.velocity.normalized * Time.deltaTime * 30f);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
