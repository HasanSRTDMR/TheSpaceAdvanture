using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygon;
    float randomSpeed;
    bool movement;
    float min, max;
    public bool Movement
    {
        get { return movement; }
        set { movement = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        polygon = GetComponent<PolygonCollider2D>();
        
        if (Preferences.EasyReadValue() == 1)
        {
            randomSpeed = Random.Range(1.0f, 2.0f);
        }
        if (Preferences.MediumReadValue() == 1)
        {
            randomSpeed = Random.Range(1.5f, 2.5f);
        }
        if (Preferences.HardReadValue() == 1)
        {
            randomSpeed = Random.Range(2.0f, 3.0f);
        }
        PlatformPositionControl();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }
    void PlatformPositionControl()
    {
        float halfObjeWidth = polygon.bounds.size.x / 2;
        if (transform.position.x>0)
        {
            min = halfObjeWidth;
            max = ScreanCalculater.instance.Width - halfObjeWidth;
        }
        else
        {
            min = -ScreanCalculater.instance.Width + halfObjeWidth;
            max = -halfObjeWidth;
        }
    }
    void PlatformMove()
    {
        if (movement)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max-min)+min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Feet")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().RestartJump();
        }
    }
    public void GameOver()
    {
        Movement = false;
    }

}
