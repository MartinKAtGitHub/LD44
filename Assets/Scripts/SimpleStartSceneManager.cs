using UnityEngine;
using UnityEngine.SceneManagement;


public class SimpleStartSceneManager : MonoBehaviour
{
   // private int sceneBuildIndex;

    /// <summary>
    /// Chanages the scene to the given index, you can check the index of the scene in the buildsettings. If you dont see you scene in the the buildsettings drag and drop the desired scene.
    /// </summary>
    /// <param name="sceneBuildIndex">the build index int</param>
    public void ChanageScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        Debug.Log($"Loading scene{sceneBuildIndex}"); // $ - string interpolation
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
