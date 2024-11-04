using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class SaveData : MonoBehaviour
{
    

    private void Awake()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
        SaveManager.init();
    }
    public void btnSave()
    {
        Save();
    }
    public void btnLoad()
    {
        Load();
    }
    private void Save()
    {
        string saveString = SaveManager.Load();
        if (saveString == null)
        {
            SaveObject saveObject = new SaveObject
            {
                level = SceneManager.GetActiveScene().buildIndex
            };
            string json = JsonUtility.ToJson(saveObject);
            SaveManager.Save(json);
        }
        else
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            PlayerManager.level = SceneManager.GetActiveScene().buildIndex;
            if (PlayerManager.level > saveObject.level)
            {
                SaveObject saveObject1 = new SaveObject
                {
                    level = SceneManager.GetActiveScene().buildIndex
                };
                string json = JsonUtility.ToJson(saveObject1);
                SaveManager.Save(json);
                Debug.Log("Saved");
            }
            
        }
    }

    private void Load()
    {
        string saveString = SaveManager.Load();
        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            PlayerManager.level = saveObject.level+1;
        }
        else
        {
            Debug.Log("No Save Data");
        }
    }
    private class SaveObject
    {
        public int level;
    }
}
