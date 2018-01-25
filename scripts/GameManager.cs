using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

using rts;

public class GameManager:MonoBehaviour
{


    public Player player;
    public GalaxyBuilder galaxyBuilder;
    public SolarSystemBuilder solarSystemBuilder;
    public UIManager uimanager;
    public Dictionary<Star, GameObject> starToObject;

    //List <faction> factionlist;

    void Awake()
    {
        starToObject = new Dictionary<Star, GameObject>();
        BuildGalaxy();
        
    }

    public void Update()
    {
        RTS.TimeKeeper.Timer(uimanager);
        if (RTS.TimeKeeper.gametimedelta == 2)
        {
            UpdateTiles();
            RTS.TimeKeeper.gametimedelta = 0;

        }

    }
    void UpdateTiles()
    {
        foreach (Star star in starToObject.Keys)
        {
            foreach (Planet planet in star.planetList.Keys)
            {
                planet.Government.UpdatePlanet();

            }
        }
    }


    public void BuildGalaxy()
    {
        
        galaxyBuilder.Createonestargalaxy(starToObject);
    }
    public void DisplayGalaxy()
    {
        player.GalaxyView = true;

        solarSystemBuilder.DestroySolarSystem();
        galaxyBuilder.DisplayGalaxy(starToObject);
        player.userinput.CameraReset(player.StarSystemViewed);
    }

    public void DisplaySolarSystem(Star star)
    {
        player.GalaxyView = false;
        galaxyBuilder.DestroyGalaxy();
        solarSystemBuilder.DisplaySolarSystem(star);
        player.userinput.CameraReset();
    }

    public void DisplaySolarSystem(GameObject starhopefully)
    {

        if (starToObject.ContainsValue(starhopefully))
        {
            player.GalaxyView = false;

            galaxyBuilder.DestroyGalaxy();
            solarSystemBuilder.DisplaySolarSystem(ObjectToStar(starhopefully));
            player.userinput.CameraReset();
        }
        else
        { Debug.Log("tried to display solar system of something that wasnt a star"); }


        //UImanager.Select(hit);
        //selectOn = true;
        //
        //Star hitstar = Galaxy.ObjectToStar(hit.transform.gameObject);
        //Debug.Log(hitstar.starName + " (" + hitstar.numberOfPlanets.ToString() + " planets)");

        //Galaxy.DestroyGalaxy();
        //solarSystem.CreateSolarSystem(hitstar);
        //Galaxy.StarSystemViewed = hitstar;
        //CameraController.ResetCameraSS();
    }

    void sanity()
    {
        //chekc min and max radius
        if (ResourceManager.maxRad < ResourceManager.minRad) { int temp = ResourceManager.maxRad; ResourceManager.maxRad = ResourceManager.minRad; ResourceManager.minRad = temp; }

    }

    public Star ObjectToStar(GameObject starobj)
    {
        return starToObject.Keys.ToList()[starToObject.Values.ToList().IndexOf(starobj)];
    }





}