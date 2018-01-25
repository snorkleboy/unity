using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour {

    public Tile tile;
    public Building building;
    public ActionPanel actpanel;
    public TilePanel tilepanel;

    public void Addbuilding()

    {
        tile.planet.Government.AddBuilding(tile, building);
        tilepanel.ResetTileToggle(this);
        actpanel.Setup(tile);
    }
}
