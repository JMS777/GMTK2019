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
    public float PortalThreshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InRangeOfPortal())
        {
            InteractionText.enabled = true;

            if (Input.GetButtonDown("Jump"))
            {
                NextLevel();
            }
        }
        else
        {
            InteractionText.enabled = false;
        }
    }

    public void LevelComplete()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        NextLevel();
    }

    private bool InRangeOfPortal()
    {
        float distanceToPortal = Vector3.Distance(Player.transform.position, Portal.transform.position);

        return distanceToPortal <= PortalThreshold;
    }
}
