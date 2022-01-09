using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingbtn3 : MonoBehaviour
{
    public Animator settingAnim;
    public GameObject btn3;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        settingAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator playAnime()
    {
        yield return new WaitForSeconds(0.75f);
        settingAnim.Play("alls_anime");
        //btn3.SetActive(true);
    }

    public IEnumerator playAnimeRev()
    {
        yield return new WaitForSeconds(0.2f);
        settingAnim.Play("allsrev_anime");
        //btn3.SetActive(false);
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
