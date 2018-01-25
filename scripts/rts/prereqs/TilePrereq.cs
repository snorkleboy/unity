using System.Collections;
using System.Collections.Generic;
using System;

public abstract class TilePrereq: Prereq
{


    public override bool condition_met<shouldbetile>(shouldbetile ab)
    {
        if (ab is Tile)
        {
            Tile mytile = ab as Tile;
            return Condition_met(mytile);
        }
        else
        {
            //shouldnt happen
            return false;
        }
    }

    public abstract bool Condition_met(Tile tile);

}
