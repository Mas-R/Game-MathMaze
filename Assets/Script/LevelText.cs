using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelText : MonoBehaviour
{
    TextMeshProUGUI text;
    string texts;
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        texts = SceneManager.GetActiveScene().name;
        text.text = texts.Replace("_", " ");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
