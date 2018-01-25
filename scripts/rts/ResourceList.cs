using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class SpacePortRequestResource: RequestResource
    {
    public int time;
    public SpacePortRequestResource(ResourcePurse purse, float pricee, Building buildingg, bool timestamp):base(purse, buildingg, pricee)
    {
            resource = purse.resource;
            amount = purse.amount;
            building = buildingg;
            pricefactor = pricee;
            time = RTS.TimeKeeper.gametime;
    }



}
    public class RequestResource
    {
        public string name;
        public float pricefactor;
        public Building building;
        public ResourceType resource;
        public int amount;
        public Dictionary<ResourceType, ResourcePurse> BuyStorage;
        public ResourcePurse wealthpurse;
        
        public RequestResource(ResourcePurse purse, Building buildingg, float pricee)
        {
            name = buildingg.name;
            resource = purse.resource;
            amount = purse.amount;
            building = buildingg;
            pricefactor = pricee;
            BuyStorage = buildingg.BuyStorage;
            wealthpurse = building.wealth;


        }
        public RequestResource(ResourceType typee, int amountt,  Building buildingg, float pricee)
        {
            resource = typee;
            amount = amountt;
            building = buildingg;
            pricefactor = pricee;
            BuyStorage = buildingg.BuyStorage;
            wealthpurse = building.wealth;
            name = buildingg.name+" "+(building.jobs[0].IsFilled()?building.jobs[0].worker.name+" "+ building.jobs[0].worker.Home.Mytile.position: "") ;


        }
        public RequestResource(ResourcePurse purse, Pop pop, float pricee)
        {
            name = pop.name+ " " +(pop.Myjob==null?"unemployed ":pop.Myjob.position);

            resource = purse.resource;
            amount = purse.amount;
            building = pop.Home;
            pricefactor = pricee;
            BuyStorage = pop.BuyStorage;
            wealthpurse = pop.wealth;
        }
    }

    public class ResourcePurse
    {
        public ResourceType resource;
        public int amount;
        //if basuc resource (wealth, food, energy, etc) sets resoruce equal to static list of basic resources
        //if highertier makes new resource class
        public ResourcePurse(ResourceEnum rt, int amountt)
        {
            if ((int)rt > 10)
            {
                throw new System.Exception("resource purse constructor: tried to make low tech resource purse with hitech resource enum");
            }
            resource = BasicResourceList.list[(int)rt];
            amount = amountt;
            //type = rt;
        }
        public ResourcePurse(ResourcePurse last, int change)
        {
            
                amount = last.amount + change;
                resource = last.resource;
                //type = last.type;
            


        }
        public ResourcePurse(ResourceEnum rt, string namee, int amountt, Building buildingg)
        {
            if ((int)rt < 10)
            {
                throw new System.Exception("resource purse constructor: tried to make hi tech resource purse with non hitech resource enum");
            }
            resource = new HiTierResource(rt, buildingg, namee);
            resource.name = namee;
            amount = amountt;
            //type = rt;
            
        }

        public void Recieve(int recieveam)
        {
            amount += recieveam;
        }
        public int GivebyFactor(float factor)
        {
            int giveam = Mathf.FloorToInt(amount * factor);
            amount -= giveam;
            return giveam;
        }
        public int Give(int giveamount)
        {
            amount -= giveamount;
            return giveamount;
        }
        public int GiveAll()
        {
            int giveamount = amount;
            amount = 0;
            return giveamount;
        }
        public void Give(int giveamount, ResourcePurse reciever)
        {
            if (reciever.resource.type != resource.type)
            {
                Debug.Log("tried to give resource of one type into a ResourceAmount of the wrong type");
                return;
            }
            else
            {
                reciever.amount += giveamount;
                amount -= giveamount;
            }
        }
        public void multiply(int am)
        {
            amount = amount * am;
        }
    }
    public class ResourceType
    {
        public ResourceEnum type;
        public string name;

        public ResourceType(ResourceEnum typee)
        {
            type = typee;
            name = System.Enum.GetName(typeof(ResourceEnum), (int)typee);
        }
    }
    public class HiTierResource : ResourceType
    {

        Building origin;
        //affects
        public HiTierResource(ResourceEnum typee, Building originn, string namee) :base(typee)
        {
            type = typee;
            name = namee;
            origin = originn;
        }

    }

    public enum ResourceEnum { Wealth, energy, minerals, food, ManuGood, last }
    public enum TileResource { nothing, Farmland, EnergySource, Rawmats, KyberCrystals, ArgonCone }
    public enum StrategicResource {  }

    public static class BasicResourceList
    {

        //public static ResourceType wealth = new ResourceType(ResourceEnum.Wealth);
        //public static ResourceType wealth = new ResourceType(ResourceEnum.energy),
        //public static ResourceType wealth = new ResourceType(ResourceEnum.minerals),
        //public static ResourceType wealth = new ResourceType(ResourceEnum.food),
        //public static ResourceType wealth = new ResourceType(ResourceEnum.ManuGood)
        public static ResourceType[] list = new ResourceType[] {
        new ResourceType(ResourceEnum.Wealth),
        new ResourceType(ResourceEnum.energy),
        new ResourceType(ResourceEnum.minerals),
        new ResourceType(ResourceEnum.food),
        new ResourceType(ResourceEnum.ManuGood)
    };
    }
}
