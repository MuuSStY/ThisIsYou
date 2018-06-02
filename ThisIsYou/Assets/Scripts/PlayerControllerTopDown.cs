using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerModelTopDown))]
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

        if (Input.GetKey(KeyCode.Space))
        {
           //por si acaso
        }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        _playerModelTopDown.setPos(x, y);
    }
}
