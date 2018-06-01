using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextIntroController : MonoBehaviour {
    public Camera _camera;
    private float _sizeToAppear;
    // Use this for initialization
    void Awake () {
        //At first the opacity of the text is 0.0f.
        Color color = GetComponent<Text>().color;
        color.a = 0.0f;
        GetComponent<Text>().color = color;
	}
	
	// Update is called once per frame
	void Update () {
        int j = 0;
	}
}
