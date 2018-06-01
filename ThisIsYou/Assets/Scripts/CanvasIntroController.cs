using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasIntroController : MonoBehaviour {
    public Camera _camera;
    public Text _text;
    public Image _image;

    private bool _opacity_done;
    private float _size_to_reach;
	// Use this for initialization
	void Awake () {
        _size_to_reach = _camera.GetComponent<CameraController>()._currentTargetSize;
        Color c = _text.color;
        c.a = 0.0f;
        _text.color = c;
        _opacity_done = false;
    }
	
	// Update is called once per frame
	void Update () {
        float size = _camera.orthographicSize;

        if (size == _size_to_reach)
        {        
            //if (!_opacity_done)
            //{
            //    Color c = _text.color;
            //    Color c_image = _image.color;
            //
            //    if (c.a == 1.0f)
            //    {
            //        _opacity_done = true;
            //    }
            //    else
            //    {
            //        c.a += 0.01f;
            //        c_image.a -= 0.01f;
            //
            //        _text.color = c;
            //        _image.color = c_image;
            //    }
            //}
        }
	}
}
