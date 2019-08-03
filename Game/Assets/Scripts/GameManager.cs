using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool waitingOnUserInput;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        waitingOnUserInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingOnUserInput)
        {
            if (Input.GetKeyDown("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    } 

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        waitingOnUserInput = true;
        gameState = GameState.GameOver;
    }
}

public enum GameState
{
    Start, Playing, GameOver, Finished
}
