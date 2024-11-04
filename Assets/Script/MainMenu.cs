using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject home;
    public GameObject level;
    public GameObject setting;
    public GameObject btnNext;
    public GameObject btnBack;
    public Animator anim;
    public Animator tran;
    int x=0;
    public void BackToMainMenu()
    {
        Debug.Log("Hi");
        FindObjectOfType<AudioManager>().ButtonClck();
        StartCoroutine(WaitForTransitionClose());
        
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void NextBtn()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        StartCoroutine(NextBtnA());
    }
    IEnumerator NextBtnA()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        btnNext.GetComponent<Button>().enabled = false;
        btnBack.GetComponent<Button>().enabled = false;
        tran.SetInteger("ShowHide", 1);
        if (x<3)
        {
            x++;
            anim.SetInteger("Index", x);
            yield return new WaitForSeconds(2f);
            tran.SetInteger("ShowHide", 0);
        }
        else
        {
            anim.SetInteger("Index", 10);
            yield return new WaitForSeconds(2f);
            setting.SetActive(false);
            home.SetActive(true);
        }
        btnNext.GetComponent<Button>().enabled = true;
        btnBack.GetComponent<Button>().enabled = true;
    }
    IEnumerator WaitForTransitionClose()
    {
        btnNext.GetComponent<Button>().enabled = false;
        btnBack.GetComponent<Button>().enabled = false;
        tran.SetInteger("ShowHide", 1);
       
        anim.SetInteger("Index", 10);
        yield return new WaitForSeconds(2f);
        
        setting.SetActive(false);
        home.SetActive(true);

    }
    public void MoveToLevelMenu()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        home.SetActive(false);
        level.SetActive(true);
    }

    public void MoveToHomeMenu()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        level.SetActive(false);
        setting.SetActive(false);
        home.SetActive(true);
    }

    public void MoveToSettingMenu()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        x = 0;
        home.SetActive(false);
        setting.SetActive(true);
        btnNext.GetComponent<Button>().enabled = true;
        btnBack.GetComponent<Button>().enabled = true;
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        Debug.Log("Exited");
        Application.Quit();
    }
}
