using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingbtn0 : MonoBehaviour
{
    public Animator settingAnim;
    public GameObject btn0;
    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        settingAnim = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator playAnime()
    {
       // gameObject.SetActive(true);
        //btn0.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        settingAnim.Play("alls_anime");
        //btn0.SetActive(true);
        
    }

    public IEnumerator playAnimeRev()
    {
        yield return new WaitForSeconds(0.7f);
        settingAnim.Play("allsrev_anime");
        //btn0.SetActive(false);
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
