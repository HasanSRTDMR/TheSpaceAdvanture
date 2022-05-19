using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGame : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<-ScreanCalculater.instance.Width)
        {
            KeepPos(-ScreanCalculater.instance.Width);
        }
        if (transform.position.x >ScreanCalculater.instance.Width)
        {
            KeepPos(ScreanCalculater.instance.Width);
        }
    }
    void KeepPos(float width)
    {
        Vector2 temp = transform.position;
        temp.x = -width;
        transform.position = temp;
    }
}
