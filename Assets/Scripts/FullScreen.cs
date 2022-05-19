using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;
        float spriteWidth = sprite.size.x;
        float spriteHeight = sprite.size.y;
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = (screenHeight / Screen.height) * Screen.width;
        tempScale.x = screenWidth / spriteWidth;
        tempScale.y = screenHeight / spriteHeight;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
