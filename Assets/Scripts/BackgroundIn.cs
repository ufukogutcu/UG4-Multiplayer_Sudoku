using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BackgroundIn : MonoBehaviour
{

    [SerializeField]
    Vector2 target_position,target_scale;
    [SerializeField]
    float target_z,rate;
    [SerializeField]
    int speed;
    [SerializeField]
    string scene;

    Vector2 position_step,scale_step;
    float rotation_step;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform picture = GetComponent<RectTransform>();
        position_step = (target_position-picture.anchoredPosition)/speed;
        scale_step = (target_scale-picture.sizeDelta)/speed;
        rotation_step = (target_z-transform.rotation.eulerAngles.z)/speed;
        InvokeRepeating("Move", 0.0f, rate);
    }

    // Update is called once per frame
    void Move()
    {
        RectTransform picture = GetComponent<RectTransform>();

        Vector2 position_left = picture.anchoredPosition-target_position;
        Vector2 scale_left = picture.sizeDelta-target_scale;
        float rotation_left = transform.rotation.eulerAngles.z-target_z;

        if(position_left.magnitude<0.001 && scale_left.magnitude<0.001 && Math.Abs(rotation_left)<0.001){
            SceneManager.LoadScene(scene);
        }
        if(position_left.magnitude>0.001){
        picture.anchoredPosition += (position_step);
        }
        if(scale_left.magnitude>0.001){
        picture.sizeDelta += scale_step;
        }
        if(Math.Abs(rotation_left)>0.001){
        transform.Rotate(0, 0, rotation_step, Space.Self);
        }
    }
}
