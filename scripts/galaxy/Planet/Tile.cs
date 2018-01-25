using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class Tile  {

    public Building building = null;
    public TileResource TileResource = TileResource.nothing;
    public Sprite sprite;
    public int[] position=new int[2];
    public Tile[] neighbors=new Tile[4];



    public Planet planet;

    public Tile()
    {
        sprite = Resources.Load<Sprite>("Sprites/house_04/grasstile");
    }

}
