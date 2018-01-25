using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;

public class Town : Residential {

    public static Prereq[]  prereq = new Prereq[1] { null };
    public static ResourcePurse[]  cost = new ResourcePurse[1] { new ResourcePurse(ResourceEnum.Wealth, 100) };



public Town()
    {
        name = "Town";
        maxpop = 2;
        Poplist = new Pop[maxpop];
        sprite = Resources.Load<Sprite>("Sprites/house_04/house_04_01");
    }


   /* public override bool AddPop(Pop pop)
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

    */

    public override Prereq[] GetPrereqs()
    {
        return prereq;
    }
    public override ResourcePurse[] GetCost()
    {
        return cost;
    }



}
