using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera _camera;

    private float _currentTargetSize;

    public float _zoomVelocity = 0.4f;

    void Awake ()
    {
        _camera = GetComponent<Camera>();
        _currentTargetSize = 6f;
	}
	
	void Update ()
    {
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

    public void ChangeCameraTargetSize(int powerLevel)
    {
        _currentTargetSize = powerLevel;
    }
}
