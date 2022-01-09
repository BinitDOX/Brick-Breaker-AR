using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingbtn1 : MonoBehaviour
{
    public Animator settingAnim;
    public GameObject btn1;
    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        settingAnim = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator playAnime()
    {
        yield return new WaitForSeconds(0.4f);
        settingAnim.Play("alls_anime");
        //btn1.SetActive(true);
    }

    public IEnumerator playAnimeRev()
    {
        yield return new WaitForSeconds(0.6f);
        settingAnim.Play("allsrev_anime");
        //btn1.SetActive(false);
    }

    public void colorActi()
    {
        //rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.red);
    }

    public void colorDeacti()
    {
        //rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", new Color(0.1683873f, 0.8301887f, 0.2878793f));
    }
}
