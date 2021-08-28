using UnityEngine;
using UnityEngine.SceneManagement;


public class levelManger : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSenceByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void BackToMenu()
    {
        LoadSenceByIndex(0);
    }
    
    public void loadLevel2()
    {
        LoadSenceByIndex(2);
    }

    public void loadLevel3()
    {
        LoadSenceByIndex(3);
    }

    public void loadLevel4()
    {
        LoadSenceByIndex(4);
    }


}
