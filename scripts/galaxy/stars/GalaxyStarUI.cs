using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyStarUI : MonoBehaviour {

    public Star stardata;

    public bool mouseover = false;
    public bool opened = false;
    // Use this for initialization

    public void OnMouseEnter()
    {
        mouseover = true;
    }
    public void OnMouseExit()
    {
        mouseover = false;
    }
    public void OnMouseDown()
    {
        opened = true;
    }
    public void OnGUI()
    {
        if (mouseover)
        {
            GUI.BeginGroup(new Rect(10, 10, 300, 100), stardata.starName);
            GUI.Label(new Rect(0, 20, 200, 90),stardata.numberOfPlanets + " planets and of " + stardata.starType + " type");
            int poptotal=0;
            float wealth =0;
            foreach (Planet planet in stardata.planetList.Keys)
            {
                  poptotal+= planet.population;
                  wealth += planet.wealth;
            }
            GUI.Label(new Rect(0, 40, 200, 90),"total population:"+poptotal);
            GUI.Label(new Rect(0, 50, 200, 90), "total wealth:" + wealth);


            GUI.EndGroup();
        }
    }
}
