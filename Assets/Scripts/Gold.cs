using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
   [SerializeField] GameObject gold;

    public void ShowGold()
    {
        gold.SetActive(true);
    }
    public void HideGold()
    {
        gold.SetActive(false);
    }
   
}
