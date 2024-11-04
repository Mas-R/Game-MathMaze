using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animator anim;
    // Start is called before the first frame update
    public void BtnPause()
    {
        if(GameIsPaused)
        {
            Resume();
        }else
        {
            Pause();
               
        }
    }

    public void Resume()
    {
        PlayerManager.moveplayer = true;
        FindObjectOfType<AudioManager>().ButtonClck();
        StartCoroutine(EndAnim());
    }

    public void Pause()
    {
        PlayerManager.moveplayer = false;
        FindObjectOfType<AudioManager>().ButtonClck();
        pauseMenuUI.SetActive(true);
        StartCoroutine(StartAnim());
    }

    IEnumerator EndAnim()
    {
        anim.SetBool("ShowHide", true);
        yield return new WaitForSeconds(0.75f);
        anim.SetBool("ShowHide", false);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1.25f);
        
        GameIsPaused = true;
    }
    public void Restart()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        PlayerManager.index = 0;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
