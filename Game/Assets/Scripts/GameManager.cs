using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Portal;
    public Text InteractionText;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public float PortalThreshold = 0.2f;

    public GameState GameState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        GameState = GameState.Playing;
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Win:
                HandleWin();
                break;
        }
    }

    private void HandlePlaying()
    {
        if (InRangeOfPortal())
        {
            InteractionText.enabled = true;

            if (Input.GetButtonDown("Jump"))
            {
                Win();
            }
        }
        else
        {
            InteractionText.enabled = false;
        }
    }

    private void HandleGameOver()
    {
        if (Input.GetButtonDown("Jump"))
        {
            NextLevel();
        }
    }

    private void HandleWin()
    {
        if (Input.GetButtonDown("Jump"))
        {
            NextLevel();
        }
    }

    /// <summary>
    /// Loads the next scene. Will loop back to scene 0 if this is the last scene.
    /// </summary>
    private void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        GameState = GameState.GameOver;

        GameOverPanel.SetActive(true);
    }

    public void Win()
    {
        GameOverPanel.SetActive(true);

        WinPanel.SetActive(true);
    }

    private bool InRangeOfPortal()
    {
        float distanceToPortal = Vector3.Distance(Player.transform.position, Portal.transform.position);

        return distanceToPortal <= PortalThreshold;
    }
}

public enum GameState
{
    GameOver, Win, Playing
}
