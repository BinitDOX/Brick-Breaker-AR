using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickParti;
    public AudioClip audioClip;
    public AudioSource audioSource;


    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParti, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject, 0.2f);
        Ball.rb.AddForce(Ball.rb.velocity.normalized * Time.deltaTime * 30f);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
