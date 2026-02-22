using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGod : MonoBehaviour
{
    [SerializeField] private string deathScene = "DeathScene";
    [SerializeField] private string gameScene = "Gameplay";
    [SerializeField] private string mainMenuScene = "MainMenuScene";
    [SerializeField] private string winMenuScene = "WinScene";
    public static SceneGod SInstance { get; private set; }

    public enum GameState
    {
        None,
        Death,
        Game,
        Win,
        MainMenu,
        Quit
    }

    // services

    [SerializeField] public AudioScript audioSystem;

    //state
    public GameState _currentState { get; private set; }

    //player variables
    public GameObject player;
    public int PlayerScore { get; private set; }
    public int PlayerDeaths { get; private set; }

    /// <summary>
    /// Initializes the SceneGod instance and ensures it persists across scenes.
    /// </summary>
    /// <remarks>
    /// This method is responsible for setting up the singleton instance of the SceneGod
    /// and ensuring it is not destroyed when loading new scenes. It also destroys duplicate
    /// instances that already exist in other scenes.
    /// </remarks>
    private void Awake()
    {
        // kill itself if there is another
        if (SInstance != null && SInstance != this)
        {
            if (SInstance.gameObject.scene.buildIndex != gameObject.scene.buildIndex) Destroy(gameObject);
        }
        else
        {
            SInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //ensures we go thru menu
        EnterMainMenuState();
        
    }

    /// <summary>
    /// Increases the player's score by the specified value.
    /// </summary>
    /// <param name="score">The amount to increment the player's score by.</param>
    public void IncrementScore(int score)
    {
        PlayerScore += score;
    }

    /// <summary>
    /// Increases death count by 1
    /// </summary>
    public void IncrementDeaths()
    {
        PlayerDeaths += 1;
        ResetPlayer();
        EnterDeathState();
    }

    /// <summary>
    /// Resets the player's score to zero. & resets deathcounter
    /// </summary>
    private void ResetPlayer()
    {
        PlayerScore = 0;
    }


    public void EnterGameState()
    {
        audioSystem.PlayBackgroundMusic();

        if (_currentState != GameState.Game)
        {
            _currentState = GameState.Game;
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.LogWarning("Already in Game Scene!");
        }

        
    }

    private void EnterDeathState()
    {
        if (_currentState != GameState.Death)
        {
            _currentState = GameState.Death;
            SceneManager.LoadScene(deathScene);
        }
        else
        {
            Debug.LogWarning("Already in Death Scene!");
        }
    }
    
    public void EnterWinState()
    {
        if (_currentState != GameState.Win)
        {
            _currentState = GameState.Win;
            SceneManager.LoadScene(winMenuScene);
        }
        else
        {
            Debug.LogWarning("Already in Win Scene!");
        }
    }

    public void EnterMainMenuState()
    {
        if (_currentState != GameState.MainMenu)
        {
            _currentState = GameState.MainMenu;
            SceneManager.LoadScene(mainMenuScene);
        }
        else
        {
            Debug.LogWarning("Already in Main Menu Scene!");
        }

        audioSystem?.PlayIntroMusic();
    }
    
    public void EnterQuitState()
    {
        Application.Quit();
    }
}