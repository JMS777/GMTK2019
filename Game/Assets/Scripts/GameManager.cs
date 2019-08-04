using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject LevelCollider;
    public GameObject Portal;
    public Text InteractionText;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public float PortalThreshold = 0.2f;

    public GameState GameState { get; private set; }

    private ColliderMovement colliderMovement;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        colliderMovement = LevelCollider.GetComponent<ColliderMovement>();
        playerAnimator = Player.GetComponentInChildren<Animator>();
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
            case GameState.Win:
                HandleEndGame();
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

    private void HandleEndGame()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (GameState == GameState.Win)
            {
                NextLevel();

            }
            else if (GameState == GameState.GameOver)
            {
                RestartLevel();
            }
        }

        else if (Input.GetButtonDown("Cancel"))
        {
            LoadMenu();
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

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        GameState = GameState.GameOver;

        colliderMovement.EnableIsKinematic();
        GameOverPanel.SetActive(true);
    }

    public void Win()
    {
        Debug.Log("Winning");
        GameState = GameState.Win;
        colliderMovement.EnableIsKinematic();

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
