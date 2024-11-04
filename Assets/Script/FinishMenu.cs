using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishMenu : MonoBehaviour
{
    public GameObject FinishUI;
    public GameObject nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            nextLevel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.finish == true)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("SaveManager");
            gameObject.GetComponent<SaveData>().btnSave();
            FinishUI.SetActive(true);
            StartCoroutine(StartAnim());
        }
    }
    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    public void NextLevel()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        PlayerManager.index = 0;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1), LoadSceneMode.Single);
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

