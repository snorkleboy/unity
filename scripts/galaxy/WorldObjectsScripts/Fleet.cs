using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet {

    public string name;


    public List<Ship> shipList;
    public Vector3 position;


    public void addship(Ship shipToAdd)
    {
        shipList.Add(shipToAdd);
    }

    public void removeShip(Ship shipToRemove)
    {
        shipList.Remove(shipToRemove);

    }

    
}
