using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeekPoint : MonoBehaviour
{
    public GameObject object_to_seek;
    public Image image_to_change;
    public bool active;
    public bool replace_object_to_seek;
    public float _velocity;
    public float time_to_start;
    private bool cromosoma_activated;

    private Vector2 _position_to_seek;
    // Use this for initialization
    void Wake()
    {
        _position_to_seek = object_to_seek.transform.position;
        cromosoma_activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (time_to_start > 0.0f)
            {
                time_to_start -= Time.deltaTime;
            }
            else
            {
                _position_to_seek = object_to_seek.transform.position;
            
                if (object_to_seek.GetComponent<CircularPatternController>())
                {
                    _velocity = object_to_seek.GetComponent<CircularPatternController>().GetRotateSpeed();
                }

                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), _position_to_seek, 15 * Time.deltaTime);

            
                if (Vector2.Equals(new Vector2(transform.position.x, transform.position.y), _position_to_seek))
                {
                    
                    if (replace_object_to_seek)
                    {
                        object_to_seek.SetActive(false);
                        if (image_to_change && !cromosoma_activated)
                        {
                            cromosoma_activated = true;
                        }
                        if (cromosoma_activated && image_to_change.color.a > 0.0f)
                        {
                            Color c = image_to_change.color;
                            c.a -= 0.01f;
                            image_to_change.color = c;
                        }else if (image_to_change.color.a <= 0.0f)
                        {
                            //Change scene
                            StartCoroutine(StartNewLevel());
                        }
                    }
                }
            }
        }
    }
    IEnumerator StartNewLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Escuela");
    }
}

