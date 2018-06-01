﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onTriggerEvent2 : MonoBehaviour {

    GameManager manager;

    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Slider slider = GameObject.Find("Slider2").GetComponent<Slider>();
            slider.value = 0.3f;
            Debug.Log(slider.value);
            manager.LoadScene(GameManager.ScenesToLoad.INTRO);

        }
    }
}
