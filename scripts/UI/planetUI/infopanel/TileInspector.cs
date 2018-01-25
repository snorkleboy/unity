using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class TileInspector : MonoBehaviour {

    Tile tile;
    public Text location;
    public Text resources;
    public Text buildingTaN;
    public Text BaPwealth;
    public BuyStorageList storagelist;
    public PopList poplist;


    // Use this for initialization
    public void Setup(Tile tilee)
    {
        tile = tilee;
    }

    // Update is called once per frame
    void Update()
    {
        if (tile != null)
        {
            location.text = "location:"+tile.position[0] + " " + tile.position[1];
            resources.text = System.Enum.GetName(typeof(TileResource), (int)tile.TileResource);
            if (tile.building != null)
            {
                poplist.gameObject.SetActive(true);
                storagelist.gameObject.SetActive(true);
                buildingTaN.text = tile.building.name;
                int wealthpops = 0;
                string BAPwealth = tile.building.wealth.amount.ToString();
                if (tile.building.GetType().IsSubclassOf(typeof(Residential)))
                {
                    wealthpops += Residential.GetPopWealth((Residential)tile.building);
                    poplist.poplist = tile.building.GetPops();
                    poplist.JobList = null;
                    BAPwealth += " Pop Wealth:" + wealthpops;

                }
                else
                {
                    poplist.poplist = null;
                    poplist.JobList = tile.building.jobs;
                }
                BaPwealth.text = "Building Wealth" + BAPwealth;
                storagelist.buystorage = tile.building.BuyStorage;

            }
            else
            {
                buildingTaN.text= "Building Space Availible";
                BaPwealth.text = "";
                poplist.gameObject.SetActive(false);
                storagelist.gameObject.SetActive(false);
            }

        }
        else
        {
            this.gameObject.SetActive(false);

        }
    }
}
