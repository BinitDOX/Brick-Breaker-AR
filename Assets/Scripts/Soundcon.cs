using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soundcon : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    string btnName;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                btnName = hit.transform.name;
                switch (btnName)
                {
                    case "button":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                        SceneManager.LoadScene("Brick Breaker");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
