using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GalaxyBuilder :MonoBehaviour
{



    public  int numberOfStars = 300;
    public  int maxRad = 200;
    public  int minRad = 10;
    public  int minStarDis = 100;

    public SolarSystemBuilder solarSystemBuilder;
    public TextAsset StarNamesList;

    public GameObject star;


    public void DisplayGalaxy(Dictionary<Star, GameObject> starToObject)
    {
        foreach (Star stardata in starToObject.Keys.ToList())
        {
            starToObject[stardata]= createStar(stardata);
        }

    }

    public void CreateSpiralGalaxy(int numArms, Dictionary<Star, GameObject> starToObject)
    {
        // dictioanry should be empty
        if (!(starToObject.Keys.Count == 0))
        {
            Debug.Log("creating galaxy even though galaxybuilders CreateSpiralGalaxy took in StarToObject dictionary that doesnt have 0 members");
        }

        //int failcount = 0;
        int numcreate = 0;

        //create names dictionary to keep track of star names
        Dictionary<string, int> namesdictionary = new Dictionary<string, int>();

        //loop for every spiral arm
        for (int i = 1; i <= numArms; i++)
        {
            //set start angle of every arm
            float armAngle = 360 * i / numArms;
            float starAngle = (armAngle * 2 * Mathf.PI) / 360;

            //every arm gets numberofstars/num arms stars
            for (int j = 1; j <= numberOfStars / numArms; j++)
            {
                //find vector 3 position for star
                float dist = 20 + j;
                if (dist > 30)
                {
                    starAngle += 25 * ((1 / (2 * Mathf.PI)) / dist);
                }
                else
                {
                    starAngle += ((1 / (2 * Mathf.PI)));
                }

                Vector3 position = new Vector3(Mathf.Cos(starAngle) * (dist + Random.Range(-2 - (dist / 6), 2 + (dist / 6))), Random.Range(-2, 2), (Mathf.Sin(starAngle) * (dist + Random.Range(-2 - (dist / 6), 2 + (dist / 6)))));

                //find name for star
                string name = TextAssetManager.TextToList(StarNamesList)[Random.Range(0, 300)];
                if (namesdictionary.ContainsKey(name))
                {
                    namesdictionary[name] = namesdictionary[name] + 1;
                    name = name + " " + namesdictionary[name].ToString();
                }
                else
                {
                    namesdictionary.Add(name, 0);
                }
                //create star
                createStar(position, name, starToObject);
                numcreate++;

            }
        }
    }

    public void Createonestargalaxy(Dictionary<Star, GameObject> starToObject)
    {
        createStar(Vector3.zero, "this is a star", starToObject);

    }

    void sanity()
    {
        //chekc min and max radius
        if (maxRad < minRad) { int temp = maxRad; maxRad = minRad; minRad = temp; }

    }
    Vector3 getRandomPosition()
    {
        float dist = Random.Range(minRad, maxRad);
        float angle = Random.Range(0, 2 * Mathf.PI);
        return new Vector3(Mathf.Cos(angle) * dist, 0, Mathf.Sin(angle) * dist);
    }
    void createStar(Vector3 position, string name, Dictionary<Star, GameObject> starToObject)
    {
        //  create new star as child of galaxy manager,
        //create new Star script and make the name of the star equal to the name of the Star.name
        // add both to given dictionary

        GameObject starcurr = GameObject.Instantiate(star, position, Quaternion.identity, this.transform);
        Star stardata = solarSystemBuilder.CreateSolarSystem(name, starcurr.transform.position);
        starcurr.name = stardata.starName;
        starcurr.tag = "galaxyStar";

        starToObject.Add(stardata, starcurr);
        starcurr.GetComponent<GalaxyStarUI>().stardata = stardata;

    }
    public GameObject createStar(Star stardata)
    {
        GameObject starcurr = GameObject.Instantiate(star, stardata.position, Quaternion.identity, this.transform);
        starcurr.name = stardata.starName;
        starcurr.tag = "galaxyStar";
        starcurr.GetComponent<GalaxyStarUI>().stardata = stardata;

        return starcurr;
    }

    public void DestroyGalaxy()
    {
        while (transform.childCount > 0)
        {
            Transform temp = transform.GetChild(0);
            temp.SetParent(null);
            Destroy(temp.gameObject);
        }
    }

}
