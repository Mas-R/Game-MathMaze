using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Hint : MonoBehaviour
{
    
    [SerializeField] string[] indexText;
    public TextMeshProUGUI textMesh;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animator anim;
    // Start is called before the first frame update
    public void BtnHint()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();

        }
    }

    public void Resume()
    {
       
        FindObjectOfType<AudioManager>().ButtonClck();
        StartCoroutine(EndAnim());
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        PlayerManager.moveplayer = false;
        Debug.Log(PlayerManager.moveplayer);
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
        PlayerManager.moveplayer = true;
    }
    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1.25f);
        GameIsPaused = true;
    }

    public void BtnOk()
    {
        textMesh.text = "";
        for(int x = 0; x <= PlayerManager.index; x++)
        {
            if(x < indexText.Length)
            {
                textMesh.text += " "+indexText[x];
            }
            else
            {
                Debug.Log("Out of Length");
            }
            
        }
        if (PlayerManager.index + 1 < indexText.Length)
        {
            textMesh.text += " ...";
        }

        PlayerManager.index++;
    }
}
