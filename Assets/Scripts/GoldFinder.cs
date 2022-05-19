using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFinder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Feet")
        {
            GetComponentInParent<Gold>().HideGold();
            FindObjectOfType<ScoreManager>().GetGold();
        }
    }
}
