using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingtemp : MonoBehaviour
{
    public Animator settingAnim;

    // Start is called before the first frame update
    void Start()
    {
        settingAnim = GetComponent<Animator>();
        //settingAnim.Play("sa");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void playAnime()
    {
        settingAnim.Play("settings_anime");
    }

    public void playAnimeRev()
    {
        settingAnim.Play("settingsrev_anime");
    }
}
