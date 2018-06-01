using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasIntroController : MonoBehaviour {
    public Camera _camera;
    public Text _text;
    public Image _image;
    private float _size_to_reach;
	// Use this for initialization
	void Start () {
        _size_to_reach = _camera.GetComponent<CameraController>()._currentTargetSize;
        Color c = _text.color;
        c.a = 0.0f;
        _text.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        float size = _camera.orthographicSize;

        if (size == _size_to_reach)
        {
            Color c = _text.color;
            Color c_image = _image.color;
            c.a = 1.0f;
            _text.color = c;
            c_image.a = 0.0f;
            _image.color = c_image;
        }
	}
}
