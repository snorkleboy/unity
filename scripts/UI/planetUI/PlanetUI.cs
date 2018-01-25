using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlanetUI : MonoBehaviour {
    public Planet planetdata;


    public GameObject Planetpanel;
    public GameObject Currentcopypanel;
    private planetPanel PlanetPanelController;
    bool mouseover = false;
    bool opened = false;

    public void OnMouseEnter() {
        mouseover = true;
    }
    public void OnMouseExit()
    {
        mouseover = false;
    }
    public void OnMouseDown()
    {
        //Planetpanel.SetActive(true);
        if (Currentcopypanel == null)
        {
            Currentcopypanel = Instantiate(Planetpanel, GameObject.Find("Canvas").transform, false);
            PlanetPanelController = Currentcopypanel.GetComponent<planetPanel>();
            PlanetPanelController.InitialSetup(planetdata);

        }
    }
    public void OnGUI()
    {
        if (mouseover && !opened)
        {
            GUI.BeginGroup(new Rect(10, 10, 300, 100), planetdata.planetName);
            GUI.Label(new Rect(0, 20, 200, 90),"population:"+planetdata.population + " and of " + planetdata.planetType + " type");
            GUI.Label(new Rect(0, 50, 200, 90), "total wealth:" + planetdata.wealth);            
            GUI.EndGroup();
        }
        else if (opened)
        {
            /*
            //first child is info second is tile third is action

            //info panel
            RectTransform panelrect = Planetpanel.GetComponent<RectTransform>();// Planetpanel.transform.GetChild(0).GetComponent<RectTransform>();
            //GUI.BeginGroup(panelrect.rect, planetdata.planetName);
            GUI.Label(panelrect.rect, "population:" + planetdata.population + " and of " + planetdata.planetType + " type");
            //GUI.Label(new Rect(, "population:" + planetdata.population + " and of " + planetdata.planetType + " type");

            //GUI.Label(panelrect.rect, "total wealth:" + planetdata.wealth);
            // GUI.EndGroup();

            //tile panel
            panelrect = Planetpanel.transform.GetChild(1).GetComponent<RectTransform>();
            GUI.BeginGroup(panelrect.rect, planetdata.planetName);
            GUI.Label(new Rect(0, 20, 200, 90), "tiles");
            GUI.EndGroup();

            //action panel
            panelrect = Planetpanel.transform.GetChild(2).GetComponent<RectTransform>();
            GUI.BeginGroup(panelrect.rect, planetdata.planetName);
            GUI.Label(new Rect(0, 20, 200, 90), "action");
            GUI.EndGroup();
            */
        }


    }


}
