using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;


public abstract class Residential : Building {

    protected int maxpop;
    protected Pop[] Poplist;

    public static int GetPopWealth(Residential building)
    {
        if (building.Poplist[0] == null)
        {
            return 0;
        }
        int amount=0;
        foreach(Pop pop in building.Poplist)
        {
            if (pop == null)
                continue;
            amount += pop.wealth.amount;
        }
        return amount;
    }

    public override Pop[] GetPops()
    {
        return Poplist;
    }
    public override void UpdateThis()
    {
        foreach (Pop pop in Poplist)
        {
            if (pop == null) {
                continue; }
            else { pop.UpdatePop(); }
            
        }
    }

    public override void UpgradeTo(Building buildingupgradingto)
    {
        throw new NotImplementedException();
    }

    public override bool AddPop(Pop pop)
    {
        int first_open_spot = System.Array.IndexOf(Poplist, null);
        if (first_open_spot >= 0)
        {
            Poplist[first_open_spot] = pop;
            popnumber++;

            return true;
        }
        else
        {
            Debug.Log("tried to add pop to building thats full");
            return false;
        }
    }


}
