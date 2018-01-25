using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;

public class Mine: ResourceBuilding{

    public static Prereq[] prereq = new Prereq[1] { new TileResourcePrereq(TileResource.Rawmats) };
    public static ResourcePurse[] cost = new ResourcePurse[] { new ResourcePurse(ResourceEnum.Wealth, 100) };
    public Mine()
    {

        name = "mine";
        sprite = Resources.Load<Sprite>("Sprites/house_04/house_04_01");
        Workstorage= new ResourcePurse[2] { new ResourcePurse(ResourceEnum.Wealth, 1000), new ResourcePurse(ResourceEnum.minerals, 0) };
        jobs.Add(new Job("miner", 10,  new ResourcePurse(ResourceEnum.minerals, 10) ));
        jobs.Add(new Job("miner", 10,  new ResourcePurse(ResourceEnum.minerals, 10) ));
        //BuyStorage[BasicResourceList.list[(int)ResourceEnum.energy]] = new ResourcePurse(ResourceEnum.energy, 1);

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
    public void sell()
    {

    }

}
