using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntroController : MonoBehaviour {
    public float _zoomVelocity = 0.4f;

    private Camera _camera;
    private float _currentTargetSize;
    // Use this for initialization
    void Awake () {
        _camera = GetComponent<Camera>();
        _currentTargetSize = 6f;
    }
	
	// Update is called once per frame
	void Update () {
        float size = _camera.orthographicSize;

        if (_currentTargetSize - size < 0)
        {
            _camera.orthographicSize -= _zoomVelocity * Time.deltaTime;
        }
        else if (_currentTargetSize - size > 0)
        {
            _camera.orthographicSize += _zoomVelocity * Time.deltaTime;
        }

        if (_currentTargetSize != _camera.orthographicSize && Mathf.Abs(_currentTargetSize - size) < _zoomVelocity / 60)
        {
            _camera.orthographicSize = _currentTargetSize;
        }
    }
}
