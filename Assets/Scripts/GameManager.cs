 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool pause;

    private void Start()
    {
        pause = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause)
            {
                Debug.Log("PAUSE GAME");
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
}
