using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController Instance;
    public int highscore;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //ResetData();
        Load();
    }

    /// <summary>
    /// Save persistant data
    /// </summary>
    public void Save()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    /// <summary>
    /// Load in persistant data
    /// </summary>
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
        }
    }

    /// <summary>
    /// Fore testing purposes. Removes any saved data
    /// </summary>
    public void ResetData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log("There is no file to delete");
        }
    }


    [System.Serializable]
    class SaveData
    {
        public int highscore;
    }
}
