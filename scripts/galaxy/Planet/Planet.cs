using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class Planet {


    public string planetName;
    public string planetType;
    public Vector3 position;
    public PlanetGovernor Government;
    public TradingPort Trader;

    public int size;
    public Tile[] TileList;
    public List<Building> PlanetBuildings = new List<Building>();

    





    public int population=0;
    public float wealth =0;





    //initialize basic parameters //including size and type!?//
    //intializes tiles based on size

    public Planet(string name, string type, Vector3 positions)
    {
        Government = new PlanetGovernor(this);
        Trader = new TradingPort(this);
        planetName = name;
        planetType = type;
        position = positions;
        size = 36;
        int tilemaplength = (int)Mathf.Sqrt(size);
        //intilze storage and prices;


        TileList = new Tile[size];
        //tile initialization. each tile is given reference to this Planet and is given its position
        //tiles will be in array sorted by those that have buildings with poopulation in them then by building;
        for (int i = 0; i < TileList.Length; i++)
        {

            TileList[i] = new Tile();
            TileList[i].planet = this;



            TileList[i].position[0] = ((i + 1) % tilemaplength == 0) ? tilemaplength : (i + 1) % tilemaplength;
            TileList[i].position[1] = (i) / tilemaplength +1;



        }
        //set neughbors and resource
        float[] neighbresfactor = { 0, 0, 0 };

        for (int i = 0; i < TileList.Length; i++)
        {
            TileList[i].neighbors = Getneighbors(TileList, TileList[i].position);





            foreach (Tile tile in TileList[i].neighbors)
            {
                if (tile == null){
                    continue;
                }
                if (tile.TileResource == RTS.TileResource.Farmland)
                {
                    neighbresfactor[0] += .1f;
                }
                if (tile.TileResource == RTS.TileResource.Rawmats)
                {
                    neighbresfactor[1] += .05f;
                }
                if (tile.TileResource == RTS.TileResource.EnergySource)
                {
                    neighbresfactor[2] += .00f;
                }
            }
            if ((UnityEngine.Random.value + neighbresfactor[0]) > .4)
            {
                TileList[i].TileResource = RTS.TileResource.Farmland;
                neighbresfactor[0] = 0;
            }

            if ((UnityEngine.Random.value + neighbresfactor[1]) > .8f)
        {
            TileList[i].TileResource = RTS.TileResource.Rawmats;
                neighbresfactor[1] = 0;
        }
         else if ((UnityEngine.Random.value + neighbresfactor[2]) > .5f)
        {
            TileList[i].TileResource = RTS.TileResource.EnergySource;
                neighbresfactor[2] = 0;
        }



        }

    }

    Tile[] Getneighbors(Tile[] TileList, int[] position)
    {
        Tile[] nieghbors = new Tile[4];
        foreach (Tile tile in TileList)
        {
            if (tile.position[0]== position[0] + 1 && tile.position[1]== position[1])
            {
                nieghbors[1] =tile;
            }
            if (tile.position[0] == position[0] - 1 && tile.position[1]== position[1])
            {
                nieghbors[3] = tile;

            }
            if (tile.position[1] == position[1] + 1 && tile.position[0]== position[0])
            {
                nieghbors[0] = tile;

            }
            if (tile.position[1] == position[1] - 1 && tile.position[0]== position[0])
            {
                nieghbors[2] = tile;

            }            
        }
        return nieghbors;
    }

    public void UpdatePlanet()
    {
        Government.UpdatePlanet();
    }

}

