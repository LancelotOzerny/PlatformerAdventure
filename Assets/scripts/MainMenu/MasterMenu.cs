using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;  
    }

    public void OpenScene(int sceneCount)
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel", 1));
    }
}
