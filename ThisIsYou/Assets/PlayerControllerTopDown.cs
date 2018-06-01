using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerControllerTopDown : MonoBehaviour
{


    private PlayerModelTopDown _playerModelTopDown;

    void Awake()
    {

        _playerModelTopDown = GetComponent<PlayerModelTopDown>();
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

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        _playerModelTopDown.setPos(x, y);
    }
}
