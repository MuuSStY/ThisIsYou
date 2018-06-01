using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerModel))]
public class PlayerControllerTopDown : MonoBehaviour
{

    Slider BoyVsGirl;
    private PlayerModelTopDown _playerModelTopDown;

    void Awake()
    {

        _playerModelTopDown = GetComponent<PlayerModelTopDown>();
        BoyVsGirl = GameObject.Find("Slider").GetComponent<Slider>();
    }


    void Update()
    {

        float x = 0, y = 0;//float por si hubiera mando o para normalizar

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.C))
        {
            BoyVsGirl.value -= 0.1f;
        }

            _playerModelTopDown.setPos(x, y);
    }
}
