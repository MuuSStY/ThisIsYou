using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerEvent : MonoBehaviour
{
    public enum TriggerType
    {
        BOYTOYS,
        GIRLTOYS
    }
    public TriggerType triggerType;

    PlayerModel playerModel;

    void Awake()
    {
        playerModel = FindObjectOfType<PlayerModel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Slider slider = GameObject.Find("Slider2").GetComponent<Slider>();
            switch (triggerType)
            {
                case TriggerType.BOYTOYS:
                    slider.value -= 0.2f;
                    Debug.Log(slider.value);
                    break;
                case TriggerType.GIRLTOYS:
                    slider.value += 0.2f;
                    Debug.Log(slider.value);
                    break;
            }
        }
    }
}
