 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool pause;

    public GameObject pausePnl;
    public GameObject JokePnl;
    public GameObject Joke1Pnl;
    private void Start()
    {
        pause = false;
        pausePnl.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
          
            if(!pausePnl.activeInHierarchy)
            {
                Debug.Log("CLICK X");
                PauseGame();
            }
            else if (pausePnl.activeInHierarchy)
            {
                Debug.Log("CLICK y");
                Continue();
            }
        }
    }



    public void RestartLevel()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePnl.SetActive(true);
       
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausePnl.SetActive(false);

    }

    public void JokePnlActive()
    {
        Joke1Pnl.SetActive(false);
        JokePnl.SetActive(true);
    }

}
