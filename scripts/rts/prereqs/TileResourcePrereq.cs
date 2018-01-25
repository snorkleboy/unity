using System.Collections;
using System.Collections.Generic;
using RTS;
public class TileResourcePrereq : TilePrereq
{
    TileResource Resourceprereq;

    public TileResourcePrereq(TileResource type)
    {
        Resourceprereq = type;
    }

    public override bool Condition_met(Tile mytile)
    {
        if (mytile.TileResource == Resourceprereq)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
