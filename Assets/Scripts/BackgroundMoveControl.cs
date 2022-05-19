using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveControl : MonoBehaviour
{
    float moveCamera;
    float mypos;
    float height;
    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<Planets>().PlacePlanet(transform.position.y);
        height = Camera.main.orthographicSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveConrtrol();
    }
    void MoveConrtrol()
    {
        mypos = transform.position.y;
        moveCamera = Camera.main.transform.position.y;
        if ((moveCamera - mypos) > height)
        {
            transform.position = new Vector3(0, mypos + (2 * height), 0);
            FindObjectOfType<Planets>().PlacePlanet(mypos + (2 * height));
        }

    }
}
