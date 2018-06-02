using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static AudioSource audio;

    public enum ScenesToLoad
    {
        INTRO = 0,
        SCHOOL,
        PAINT,
        CLOTHES,
        END
    }

    private int currentLevel = 0;
    private bool isReloading = false;

    void Awake()
    {
        audio.Play();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void OnLevelWasLoaded(int level)
    {
        if (this != instance) return; //To avoid duplicate GameManager to run this before being destroyed
        if (!isReloading)
        {
            currentLevel = level;
        }
        else
        {
            isReloading = false;
        }
    }

    public void ReloadCurrentScene()
    {
        isReloading = true;
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadScene(ScenesToLoad nextScene)
    {
        currentLevel = (int)nextScene;
        SceneManager.LoadScene((int)nextScene);
        if (audio.isPlaying)
        {
            audio.Stop();

        }
    }
}
