using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Assets.Script;
using System;
using TMPro;

public class GameLogic : MonoBehaviour
{
    private int playerScore;
    private int collectedCoin;
    private string playerName;
    private int level;

    private PipeSpawner pipeSpawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinText;
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private GameObject gameOverScreen;


    public int PlayerScore
    {
        get { return playerScore; }
        private set { playerScore = value; }
    }
    public int CollectedCoin
    {
        get { return collectedCoin; }
        private set { collectedCoin = value; }
    }
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public int Level
    {
        get
        {
            return level;
        }
         private set
        {
            level = value;
        }
    }

    // Set the default values 
    void Awake()
    {
        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawner>();

        PlayerName = "LarryBird";
        PlayerScore = 0;
        CollectedCoin = 0;
        Level = 0;

        lvlText.gameObject.SetActive(false);
    }

    // GAME FUNCTIONS

    // set the levels harder and harder
    private void LevelUp()
    {
        Level++;
        float currentSpawnRate = pipeSpawner.SpawnRate;
        pipeSpawner.SpawnRate = currentSpawnRate - 0.1f;
    }
    public void AddScore()
    {
        PlayerScore++;
        scoreText.text = "x" + PlayerScore.ToString();
    }
    public void AddCoin()
    {
        CollectedCoin++;
        coinText.text = "x" + CollectedCoin.ToString();
    }



    // UI CONTROL FUNCTIONS
    public void GameOver()
    {
        HighScoreController.AddHighScoreEntry(PlayerScore, PlayerName, Level);
        Debug.Log("PlayerScore: " + PlayerScore + " PlayerName :" + PlayerName + " Level: " + Level);

        gameOverScreen.SetActive(true);
        AudioController.uiAudioInstance.PlayDeathSFX();
        AudioController.uiAudioInstance.PlayLobbyMusic();
    }
    public void DisplayCurrentLvl()
    {
        if (PlayerScore % 10 == 0)
        {
            LevelUp();
            lvlText.gameObject.SetActive(true);
            lvlText.enabled = true;
            lvlText.text = "Level " + Level.ToString();
            lvlText.CrossFadeAlpha(0, 3f, true);
            
        }
        else
        {
            lvlText.gameObject.SetActive(false);
            lvlText.CrossFadeAlpha(1, 3f, true);
        }
    }

    // Load the GameOverScene with highscore board
    public void LoadGameOverMenu()
    {
        SceneManager.LoadScene("GameOverScene");
    }



}
