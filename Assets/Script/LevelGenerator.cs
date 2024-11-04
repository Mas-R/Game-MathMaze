using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public Transform parent;

    private int numScene;
    void Start()
    {
        numScene = SceneManager.sceneCountInBuildSettings;

        for (int i = 1; i < numScene; i++)
        {
            GameObject clone = Instantiate(prefab, parent);

            clone.name = "LevelButton" + i;
            clone.GetComponent<LevelButtonOnClickListener>().index = i;
            clone.GetComponentInChildren<Text>().text = ""+i;
            if(i <= PlayerManager.level)
            {
                clone.GetComponent<Button>().interactable = true;
            }
        }
        prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
