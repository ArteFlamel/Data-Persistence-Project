using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    public Text playerName, highScoreData;
    public Button m_StartGameClicked, m_ExitGameClicked;
    private string highScorePlayer;
    private int highScore;
    public bool nameEntered;

    public GameObject MainMenu;
    public GameObject EnterName;

    public void Start()
    {
        ShowCurrentHighScoreData();
    }

    public void ShowCurrentHighScoreData()
    {
        GameManager.Instance.LoadGame();
        highScorePlayer = GameManager.Instance.highScorePlayer;
        highScore = GameManager.Instance.highScore;
        highScoreData.text = "Current High Score: " + highScore + " held by: " + highScorePlayer;
    }


    public void StartButton()
    {
        GameManager.Instance.playerName = playerName.text;
        if (GameManager.Instance.playerName == "") // Useless Code, I tried to get a menu to appear to tell the player to Write a Name in.
        {//The condition just doesn't seem to come up despite my best effort, on debug it shows null but the condition fails...
            MainMenu.SetActive(false);
            EnterName.SetActive(true);
            
        }
        else if (GameManager.Instance.playerName != "")
        {           
            SceneManager.LoadScene(1); // Works as intended.
        }
        
    }



    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void ExitGameButton()
    {     
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}



