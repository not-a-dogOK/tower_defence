using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class levelManger : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject gameUI;
    public Slider loadbar;


    void start()
    {
        loadingScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        LoadAsyncScene(index + 1);
        
        //SceneManager.LoadScene(
    }
   


    public void BackToMenu()
    {
        Debug.Log("menu pressed");
        StartCoroutine(LoadAsyncScene(0));
    }

    public void loadLevel2()
    {
        Debug.Log("2 pressed");
        StartCoroutine(LoadAsyncScene(2));
        
    }

    public void loadLevel3()
    {
        Debug.Log("3 pressed");
        LoadAsyncScene(3);
    }

    public void loadLevel4()
    {
        Debug.Log("4 pressed");
        LoadAsyncScene(4);
    }


    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public IEnumerator LoadAsyncScene(int buildindex)
    {
        gameUI.SetActive(false);
        loadingScreen.SetActive(true);
        Debug.Log("started LoadAsyncScene()");


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildindex);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            loadbar.value = progress;
            yield return null; //wait untill the next frame
            
            Debug.Log("Press a key to start");
            if (Input.anyKey)
            {
                asyncLoad.allowSceneActivation = true;
            }
            
        }
        yield return null;
    }

}

