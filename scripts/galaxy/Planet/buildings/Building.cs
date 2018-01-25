using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public abstract class Building {

    public string name;
    public Pop owner;
    public Tile Mytile { get; set; }
    public Dictionary<ResourceType,ResourcePurse> BuyStorage= new Dictionary<ResourceType, ResourcePurse>();
    public ResourcePurse[] recipe;
    public ResourcePurse wealth=new ResourcePurse(ResourceEnum.Wealth,1000);// new ResourceAmount[(int)ResourceType.last];
    public Sprite sprite;
    public List<Job> jobs=new List<Job>();
    public int popnumber = 0;
    protected int pay;
    protected int[] paypositions;

    public virtual bool AddPop(Pop pop)
    {
        return false;
    }
    public abstract void UpgradeTo(Building buildingbeingUpgradedto);
    public abstract Prereq[] GetPrereqs();
    public abstract ResourcePurse[] GetCost();

    public virtual Pop[] GetPops()
    {
        return null;
    }

    public virtual void UpdateThis()
    {

    }



}
