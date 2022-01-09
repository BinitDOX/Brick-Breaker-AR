using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public Animator settingAni;
    string btnName;
    public Settingtemp st;
    public Settingbtn0 sb0;
    public Settingbtn1 sb1;
    public Settingbtn2 sb2;
    public Settingbtn3 sb3;
    public GameObject ring;
    public GameObject paddl;
    public NavMeshAgent agent;
    public GameObject navCtrl;
    public bool show = false;
    public bool locky = false;
    public bool nav = false, touch = false;
    //public bool togg0 = false, togg1 = true, togg2 = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        settingAni = GetComponent<Animator>();
        agent = paddl.GetComponent<NavMeshAgent>();
        
        //GetComponent<Animator>().Play("setting_animation");
        //settingAni.Play("sa");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
            {
            Ray ray = Camera.main.ScreenPointToRay(/*Input.GetTouch(0).position*/Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                btnName = hit.transform.name;
                switch (btnName)
                {
                    case "settingsbtn":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                        if(show == false)
                        {
                            st.playAnime();
                            sb0.StartCoroutine(sb0.playAnime());
                            sb1.StartCoroutine(sb1.playAnime());
                            sb2.StartCoroutine(sb2.playAnime());
                            sb3.StartCoroutine(sb3.playAnime());
                            show = true;
                        }
                        else if(show == true)
                        {
                            st.playAnimeRev();
                            sb0.StartCoroutine(sb0.playAnimeRev());
                            sb1.StartCoroutine(sb1.playAnimeRev());
                            sb2.StartCoroutine(sb2.playAnimeRev());
                            sb3.StartCoroutine(sb3.playAnimeRev());
                            show = false;
                        }
                        break;

                    case "lockyaxisbtn":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                        if(locky == false)
                        {
                            locky = true;
                            sb3.colorActi();
                        }
                        else if(locky == true)
                        {
                            locky = false;
                            sb3.colorDeacti();
                        }
                        break;

                    case "raycastbtn":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                        //  if (togg2 == false)
                        //  {
                        //      togg2 = true;
                            sb2.colorActi();
                            sb1.colorDeacti();
                            sb0.colorDeacti();
                            touch = true;
                            agent.enabled = false;
                            navCtrl.SetActive(false);
                        //  }
                        break;

                    case "qrtargetbtn":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                     //   if (togg1 == false)
                     //   {
                     //       togg1 = true;
                            sb1.colorActi();
                            sb2.colorDeacti();
                            sb0.colorDeacti();
                            agent.enabled = true;
                            navCtrl.SetActive(false);
                            nav = false;
                            touch = false;
                        //   }
                        break;

                    case "navctrlbtn":
                        audioSource.clip = audioClip;
                        audioSource.Play();
                    //    if (togg0 == false)
                    //    {
                    //        togg0 = true;
                            sb0.colorActi();
                            sb1.colorDeacti();
                            sb2.colorDeacti();
                            agent.enabled = false;
                            navCtrl.SetActive(true);
                            nav = true;
                            touch = false;
                     //   }
                        break;


                    default:
                        break;
                }

            }
        }
        if (locky == true)
        {
            float y;
            y = ring.transform.eulerAngles.y;
            paddl.transform.eulerAngles = new Vector3(
                paddl.transform.eulerAngles.x,
                y,
                paddl.transform.eulerAngles.z
            );
        }
    }
}
