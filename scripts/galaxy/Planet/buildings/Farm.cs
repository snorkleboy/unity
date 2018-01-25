using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;

public class Farm : ResourceBuilding{
    public static Prereq[] prereq = new Prereq[1] { new TileResourcePrereq(TileResource.Farmland) };
    public static ResourcePurse[] cost = new ResourcePurse[1] { new ResourcePurse(ResourceEnum.Wealth, 100) };
    public Farm()
    {

        name = "Farm";
        sprite = Resources.Load<Sprite>("Sprites/house_04/house_04_01");
        //Workstorage = new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 100), new ResourcePurse(ResourceEnum.food, 0) };
        Workstorage=new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 1000), new ResourcePurse(ResourceEnum.food, 0) };

        jobs = new List<Job>();
        jobs.Add(new Job("farmer", 10, new ResourcePurse(ResourceEnum.food, 10) ));
        jobs.Add(new Job("farmer", 10,  new ResourcePurse(ResourceEnum.food, 10) ));
        recipe = new ResourcePurse[] { new ResourcePurse(ResourceEnum.energy, 1) };

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
