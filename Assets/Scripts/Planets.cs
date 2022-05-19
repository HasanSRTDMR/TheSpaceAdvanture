using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets=new List<GameObject>();

    List<GameObject> usedPlanets = new List<GameObject>();


    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");

        for (int i=1;i<17;i++)
        {

            GameObject planet = new GameObject();
            SpriteRenderer spriteRenderer = planet.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)sprites[i];
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0.7f;
            planet.name = sprites[i].name;
            spriteRenderer.sortingLayerName = "Planets";
            Vector2 pos = planet.transform.position;
            pos.x = -10;
            planet.transform.position = pos;
            planets.Add(planet);
        }

    }
    public void PlacePlanet(float refY)
    {
        float height = ScreanCalculater.instance.Height;
        float width = ScreanCalculater.instance.Width;

        //Top Left
        float xValue1 = Random.Range(-width,0.0f);
        float yValue1 = Random.Range(refY, refY + height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);
        //Top Right
        float xValue2 = Random.Range(0.0f, width);
        float yValue2 = Random.Range(refY, refY + height);
        GameObject planet2 = RandomPlanet();
        planet2.transform.position = new Vector2(xValue2, yValue2);
        //Bottom Left
        float xValue3 = Random.Range(-width, 0.0f);
        float yValue3 = Random.Range(refY - height,refY);
        GameObject planet3 = RandomPlanet();
        planet3.transform.position = new Vector2(xValue3, yValue3);
        //Bottom Right
        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY, refY + height);
        GameObject planet4 = RandomPlanet();
        planet4.transform.position = new Vector2(xValue4, yValue4);
    }
    GameObject RandomPlanet()
    {
        int rnd;
        if (planets.Count>0)
        {
            rnd = Random.Range(0, planets.Count);            
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(usedPlanets[i]);
            }
            usedPlanets.RemoveRange(0, 8);
            rnd = Random.Range(0, 8);  
        }
        GameObject planet = planets[rnd];
        planets.Remove(planet);
        usedPlanets.Add(planet);
        return planet;
    }
 
}
