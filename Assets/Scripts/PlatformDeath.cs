using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeath : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
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
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(1.0f, 2.0f);
        PlatformPositionControl();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }
    void PlatformPositionControl()
    {
        float halfObjeWidth = boxCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0)
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
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Feet")
        {
            FindObjectOfType<GameControler>().GameFinish();
        }
    }
    public void GameOver()
    {
        Movement = false;
    }
}
