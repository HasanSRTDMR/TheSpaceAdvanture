using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject platformDeathPrefab;
    [SerializeField] GameObject playerPrefab;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPos;
    Vector2 playerPos;

    [SerializeField] float distanceBetweenPlatfroms;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreanCalculater.instance.Height)
        {
            PlacePlatform();
        }
    }
    void CreatePlatform()
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NewPlatformPosition();
        firstPlatform.GetComponent<Platform>().Movement = true;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Movement = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().ShowGold();
            }
            NewPlatformPosition();
        }
        GameObject platformDeath = Instantiate(platformDeathPrefab, platformPos, Quaternion.identity);
        platformDeath.GetComponent<PlatformDeath>().Movement = true;
        platforms.Add(platformDeath);
        NewPlatformPosition();

    }
    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPos;
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Gold>().HideGold();
                float rnd = Random.Range(0.0f, 1.0f);
                if (rnd > 0.7f)
                {
                    platforms[i + 5].GetComponent<Gold>().ShowGold();
                }
            }
            NewPlatformPosition();
        }
    }
    void NewPlatformPosition()
    {
        platformPos.y += distanceBetweenPlatfroms;
        if (FindObjectOfType<ScoreManager>().score < 100)
        {
            SerialPosition();
        }
        else
        {
            RandomPosition();
        }


    }
    void RandomPosition()
    {
        float rnd = Random.Range(0.0f, 1.0f);
        if (rnd < 0.5f)
        {
            platformPos.x = ScreanCalculater.instance.Width / 2;
        }
        else
        {
            platformPos.x = -ScreanCalculater.instance.Width / 2;
        }
    }
    bool direct = true;
    void SerialPosition()
    {
        if (direct)
        {
            platformPos.x = ScreanCalculater.instance.Width / 2;
            direct = false;
        }
        else
        {
            platformPos.x = -ScreanCalculater.instance.Width / 2;
            direct = true;
        }
    }
}
