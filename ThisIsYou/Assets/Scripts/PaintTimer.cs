using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTimer : MonoBehaviour
{

    GameManager manager;
    public float timeToResults = 5f;
    public float timeToLoadNextScene = 2f;

    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(CountTimeForResults(timeToResults));
        Debug.Log("start time");
    }

    void Update()
    {
    }

    IEnumerator CountTimeForResults(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("time's up");
        StartCoroutine(CountTimeForSceneChange(timeToLoadNextScene));
    }

    public IEnumerator CountTimeForSceneChange(float time)
    {
        yield return new WaitForSeconds(time);
        manager.LoadScene(GameManager.ScenesToLoad.INTRO);
    }

}
