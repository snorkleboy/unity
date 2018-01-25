using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star
{
    public string starType;
    public string starName { get; protected set; }
    public int numberOfPlanets { get; protected set; }
    public int size { get { return 6000; } }
    public Vector3 position { get; protected set; }
    public Dictionary<Planet, GameObject> planetList=new Dictionary<Planet, GameObject>();

    public Star(int numplanets, string name, Vector3 setposition)
    {
        starName = name;
        numberOfPlanets = numplanets;
        position = setposition;

    }
    public Star(int numplanets, string name, string[] typeList, Vector3 setposition)
    {
        starName = name;
        numberOfPlanets = numplanets;
        position = setposition;
    }


}
