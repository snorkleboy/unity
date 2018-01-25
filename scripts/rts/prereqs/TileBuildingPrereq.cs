using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuildingPrereq : TilePrereq
{
    System.Type prereqBuildingType;

    public TileBuildingPrereq (System.Type prereq)
    {
        prereqBuildingType = prereq;
    }

    public override bool Condition_met(Tile mytile)
    {

        if ( mytile.building != null && BuildingCompare(mytile.building, prereqBuildingType))
            {
                return true;

            }
            else
            {
                return false;
            }
     }
    //public static bool BuildingCompare(Building buildinga, Building buildingb)
    //{
    //    return buildinga.GetType().IsInstanceOfType(buildingb);
   // }

    public static bool BuildingCompare(Building buildinga, Type buildingb)
    {
        Type buildingaType = buildinga.GetType();
        return buildingb==(buildingaType);
            //buildinga.GetType().IsInstanceOfType(buildingb);
    }

}

