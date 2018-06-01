using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinchitosController : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Body");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(ResetLevel());
        }
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
