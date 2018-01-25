using System;
using System.Collections;
using System.Collections.Generic;
using RTS;
using UnityEngine;

public class PowerPlant :  ResourceBuilding{
    public static ResourcePurse[] cost = new ResourcePurse[] { new ResourcePurse(ResourceEnum.Wealth, 100) };
    public static Prereq[] prereq = new Prereq[1] { new TileResourcePrereq(TileResource.EnergySource) };
    public PowerPlant()
    {

        name = "PowerPlant";
        sprite = Resources.Load<Sprite>("Sprites/house_04/house_04_01");
        //Workstorage = new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 100), new ResourcePurse(ResourceEnum.energy, 0) };
        Workstorage= new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 1000), new ResourcePurse(ResourceEnum.energy, 0) };
        jobs = new List<Job>();
        jobs.Add(new Job("Electrical Engineer", 20,  new ResourcePurse(ResourceEnum.energy, 15) ));
        jobs.Add(new Job("Technician", 10,  new ResourcePurse(ResourceEnum.energy, 10) ));
        recipe = new ResourcePurse[] { null};

    }


    public override Prereq[] GetPrereqs()
    {
        return prereq;
    }

    public override ResourcePurse[] GetCost()
    {
        return cost;
    }

}
