using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;

public class Factory : ResourceBuilding{


    public static Prereq[] prereq = new Prereq[1] { new TileNeighborPrereq(buildingList.mine,1)};
    public static ResourcePurse[] cost = { new ResourcePurse(ResourceEnum.Wealth, 100) };

    public Factory()
    {
        name = "Factory";
        sprite = Resources.Load<Sprite>("Sprites/house_04/house_04_01");
        Workstorage=new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 1000), new ResourcePurse(ResourceEnum.ManuGood, 0) };
        jobs = new List<Job>();
        jobs.Add(new Job("farmer", 10,new ResourcePurse(ResourceEnum.ManuGood, 10) ));
        jobs.Add(new Job("farmer", 10,new ResourcePurse(ResourceEnum.ManuGood, 10) ));
        recipe = new ResourcePurse[] { new ResourcePurse(ResourceEnum.energy, 2) , new ResourcePurse(ResourceEnum.minerals, 2) };

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
