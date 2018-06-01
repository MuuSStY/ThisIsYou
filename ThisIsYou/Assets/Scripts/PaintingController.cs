using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Awake () {
        player = GameObject.Find("PlayerTopDown").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerModelTopDown model_down = player.GetComponent<PlayerModelTopDown>();
            
        if (model_down.IsMoving())
        {
            //Every frame we spawn a prefab of the pink floor.
            GameObject newObject = GameObject.Instantiate(Resources.Load("Prefabs/PinkFloor")) as GameObject;
            newObject.transform.position = transform.position;
        }
    }
}
