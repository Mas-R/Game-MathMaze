using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonOnClickListener : MonoBehaviour
{
    // Start is called before the first frame update

    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startLevel()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        PlayerManager.index = 0;
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
}
