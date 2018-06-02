using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SexualitySlider : MonoBehaviour {
    public static SexualitySlider instance;

    Slider slider;

	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

        slider = GetComponent<Slider>();
	}

    void Start()
    {
        slider.value = 0.5f;
    }

    void Update () {
		
	}

    public void AddToBar(float fraction)
    {
        slider.value += fraction;
    }

    public float GetValue()
    {
        return slider.value;
    }
}
