using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheCamera : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxSpeed;
    bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
        if (Preferences.EasyReadValue()==1)
        {
            speed = 0.05f;
            acceleration = 0.001f;
            maxSpeed = 1.0f;
        }
        if (Preferences.MediumReadValue() == 1)
        {
            speed = 0.1f;
            acceleration = 0.01f;
            maxSpeed = 2.0f;
        }
        if (Preferences.HardReadValue() == 1)
        {
            speed = 0.5f;
            acceleration = 0.01f;
            maxSpeed = 2.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            MoveTheCamere();
        }
        
    }
    void MoveTheCamere()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        speed += acceleration;
        if (speed>=maxSpeed)
        {
            speed = maxSpeed;
        }

    }
    public void GameOver()
    {
        move = false;
    }
 
}
