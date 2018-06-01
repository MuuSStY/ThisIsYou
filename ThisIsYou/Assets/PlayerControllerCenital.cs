using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerControllerCenital : MonoBehaviour
{


    private PlayerModelCenital _playerModelCenital;

    void Awake()
    {

        _playerModelCenital = GetComponent<PlayerModelCenital>();
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

        _playerModelCenital.setPos(x, y);
    }
}
