using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using RTS;
public class ActionPanel : MonoBehaviour {

    public GameObject Content;
    public Button Buildbutton;
	// Use this for initialization
	public void Setup(Tile tile)
    {
        Button currentbtb;
        Cleanup();
        foreach (Building building in buildingList.list)
        {

            //if building has prereqs check them all
            //, then make buton for ones that pass, 
            //else if no prereqs and the tile has no buildings (and/or) the tile building isnt of the same type as the building button we are considering,
            //, make the button. THis is done becuase gettype of null throws exception, so we chck that first then check if the building is already on the tile.
            if (tile.building != null && building.GetType()== tile.building.GetType()) { continue; }
            if (building.GetPrereqs()[0] != null)
            {

                bool prereqsmet = true;

                foreach (TilePrereq prereq in building.GetPrereqs())
                {
                    if (prereq.condition_met(tile) == false) { prereqsmet = false; }
                }
                if (prereqsmet)
                {
                    currentbtb = Instantiate(Buildbutton, Content.transform);
                    currentbtb.gameObject.SetActive(true);
                    currentbtb.GetComponent<BuildButton>().building = building;
                    currentbtb.GetComponent<BuildButton>().tile = tile;
                    currentbtb.GetComponentInChildren<Text>().text = building.name;
                }
            }
            else 
            {
                currentbtb = Instantiate(Buildbutton, Content.transform);
                currentbtb.gameObject.SetActive(true);
                currentbtb.GetComponent<BuildButton>().building = building;
                currentbtb.GetComponent<BuildButton>().tile = tile;
                currentbtb.GetComponentInChildren<Text>().text = building.name;

            }
        }
    }

    public void Setup(BuildButton bbutton)
    {
        Cleanup();

        Button currentbtb;

        Tile tile = bbutton.tile;
        foreach (Building building in buildingList.list)
        {
            if (building.GetPrereqs()[0] != null)
            {

                bool prereqsmet = true;

                foreach (TileBuildingPrereq prereq in building.GetPrereqs())
                {
                    if (prereq.condition_met(tile) == false) { prereqsmet = false; }
                }
                if (prereqsmet)
                {
                    currentbtb = Instantiate(Buildbutton, Content.transform);
                    currentbtb.gameObject.SetActive(true);
                    currentbtb.GetComponent<BuildButton>().building = building;
                    currentbtb.GetComponent<BuildButton>().tile = tile;
                }
            }
            else
            {
                currentbtb = Instantiate(Buildbutton, Content.transform);
                currentbtb.gameObject.SetActive(true);
                currentbtb.GetComponent<BuildButton>().building = building;
                currentbtb.GetComponent<BuildButton>().tile = tile;
            }
        }
    }

    public void Cleanup()
    {
        foreach (Transform child in Content.transform)
        {
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }
    }


}
