using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class SolarSystemBuilder : MonoBehaviour {
    
    public int maxRad = 100;
    public int minRad = 10;

    public GameObject planetprefab;
    public GameObject starprefab;
    public Button galaxyviewbutton;
    public Star StarbeingViewed;

    public GameObject OrbitSprite;


    public void DestroySolarSystem()
    {
        galaxyviewbutton.gameObject.SetActive(false);
        while (transform.childCount > 0)
        {
            Transform temp = transform.GetChild(0);
            temp.SetParent(null);
            Destroy(temp.gameObject);
            
        }
    }
    public Star CreateSolarSystem(string name, Vector3 position)
    {
        Star star = new Star(Random.Range(1, 10), name, position);


        for(int i = 0; i < star.numberOfPlanets; i++)
        {
            int angle = 0;
            int dist = (i) * (star.size / (star.planetList.Count + 2)) +Random.Range(-500,500)+500;
            Vector3 cartpos= new Vector3(Mathf.Cos(angle) * dist, 0, Mathf.Sin(angle) * dist);


            Planet newplanet = new Planet(star.starName + " " + i, "type", cartpos);
            star.planetList.Add(newplanet,null);


        }

        return star;

    }

    public void DisplaySolarSystem(Star star)
    {
        galaxyviewbutton.gameObject.SetActive(true);

        GameObject centralstar = Instantiate(starprefab, Vector3.zero, Quaternion.identity, this.transform);
        centralstar.transform.localScale = new Vector3(100, 100, 100);
        centralstar.name = star.starName;


        foreach (Planet planet in star.planetList.Keys.ToList())
        {

            GameObject planetfab = GameObject.Instantiate(planetprefab, this.transform);
            planetfab.GetComponent<PlanetUI>().planetdata = planet;

            planetfab.transform.position = planet.position;
            planetfab.name = planet.planetName;
            star.planetList[planet] = planetfab;

        }
    }


    Vector3 getRandomPosition()
    {
        float dist = Random.Range(minRad, maxRad);
        float angle = Random.Range(0, 2 * Mathf.PI);
        return new Vector3(Mathf.Cos(angle) * dist, 0, Mathf.Sin(angle) * dist);
    }
}
