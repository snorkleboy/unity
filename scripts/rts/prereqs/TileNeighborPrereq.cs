using System.Collections;
using System.Collections.Generic;

public class TileNeighborPrereq : TilePrereq
{
    //Building prereqbuilding;
    System.Type prereqNeighbbuildingType;
    int num = 0;
    public TileNeighborPrereq(System.Type buildinga, int howmany)
    {
        //prereqbuilding = buildinga;
        prereqNeighbbuildingType = buildinga;
        num = howmany;
    }
    //counts the number of times a neighbor tile has the prereq building type on it, returns true if its more than or equal to num 
    public override bool Condition_met(Tile tile)
    {
        int count = 0;
        foreach (Tile tilen in tile.neighbors)
        {
            if (tilen == null || tilen.building==null)
            { continue; }
            if(TileBuildingPrereq.BuildingCompare(tilen.building, prereqNeighbbuildingType))
            {
                count++;
            }
        }
        return count>=num? true:false;
    }

}
