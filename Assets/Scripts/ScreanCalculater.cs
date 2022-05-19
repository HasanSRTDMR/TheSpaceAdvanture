using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanCalculater : MonoBehaviour
{
    public static ScreanCalculater instance;
    float height;
    public float Height
    { get { return height; } }

    float width;
    public float Width
    { get { return width; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
