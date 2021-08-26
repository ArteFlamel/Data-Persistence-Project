using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string highScorePlayer;
    public int score;
    public int highScore;    


    public void Awake()
    {
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            //LoadGame();

        }
    }


    private void Update()
    {
        ChangeHSData();

    }


    [System.Serializable]
    class SavedHighScore
    {
        public string highScorePlayer;
        public int HighScore;

    }

    public void ChangeHSData()
    {
        if (score > highScore)
        {
            highScore = score;
            highScorePlayer = playerName;
            SaveGame();
        }
    }

    public void SaveGame()
    {
        SavedHighScore data = new SavedHighScore();
        data.highScorePlayer = playerName;
        data.HighScore = highScore;

        Debug.Log("Saved a Game File");
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedHighScore data = JsonUtility.FromJson<SavedHighScore>(json);
            Debug.Log("Loaded Game File");
            highScorePlayer = data.highScorePlayer;            
            highScore = data.HighScore;
        }

    }

}
