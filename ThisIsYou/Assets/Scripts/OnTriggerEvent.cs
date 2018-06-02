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

    bool hasEntered = false;

    SexualitySlider slider;
    PlayerModel playerModel;

    void Awake()
    {
        playerModel = FindObjectOfType<PlayerModel>();
        slider = FindObjectOfType<SexualitySlider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            switch (triggerType)
            {
                case TriggerType.BOYTOYS:
                    slider.AddToBar(0.25f);
                    Debug.Log(slider.GetValue());
                    break;
                case TriggerType.GIRLTOYS:
                    slider.AddToBar(-0.25f);
                    Debug.Log(slider.GetValue());
                    break;
            }
        }
    }
}
