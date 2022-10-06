using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class MainDataManager : MonoBehaviour
{
    public static MainDataManager Instance; // For data savings

    public string currentPlayerName;
    public int currentPlayerScore = 0;

    // For data savings
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData // new class for saving data
    {
        public int topScore;
        public string topName;
    }

    public void Save() // new method for saving data
    {
        SaveData data = new SaveData(); // new object
        data.topScore = currentPlayerScore; // write MainManager data in object
        data.topName = currentPlayerName;
        string json = JsonUtility.ToJson(data); // transform data object to JSON

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // save file
    }

    public void Load() // new method for loading data
    {
        string path = Application.persistentDataPath + "/savefile.json"; // variable of path of file
        if (File.Exists(path)) // method Exists to check existence of file
        {
            string json = File.ReadAllText(path); // reading to string
            SaveData data = JsonUtility.FromJson<SaveData>(json);  // converted json to data object

            currentPlayerScore = data.topScore;
            currentPlayerName = data.topName;// MainManager now is from saved data from json
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
        }
    }

}
