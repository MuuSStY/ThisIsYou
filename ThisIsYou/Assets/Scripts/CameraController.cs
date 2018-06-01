using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera _camera;
    private Transform playerTransform;
    public float _currentTargetSize = 5.0f;

    public float _zoomVelocity = 0.4f;

    void Awake ()
    {
        _camera = GetComponent<Camera>();
        playerTransform = FindObjectOfType<PlayerModel>().GetComponent<Transform>();
    }
	
	void Update ()
    {
        ChangeCameraOffset();

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

    void ChangeCameraOffset(){
        float playerHeight = Mathf.Clamp(playerTransform.position.y, 0, 5.5f);
        float ratio = 1 - playerHeight / 5.5f;
        transform.localPosition =  new Vector3(0, Mathf.Lerp(-1.5f, 4f, ratio), -10);
    }

    public void ChangeCameraTargetSize(int powerLevel)
    {
        _currentTargetSize = powerLevel;
    }
}
