using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;
using System.Linq;
public abstract class ResourceBuilding : Building
{

    public ResourcePurse[] Workstorage;
    float costofproduction=1;
    int totproduced = 0;
    float paypoints = 0;
    float NonPayroll = .2f;
    public int filledpos;
    ResourcePurse tempreserve =new ResourcePurse(ResourceEnum.Wealth, 1000);
    public override void UpgradeTo(Building building)
    {
        throw new NotImplementedException();
    }
    public override void UpdateThis()
    {
        //send requests
        if (recipe[0] != null)
        {
            costofproduction=SendBasicRequests(recipe);
        }

        //production
        //goes through al filed jobs and fills in correspdonging stuff into storage then sells it to planet storage
        //sets the cost of production to the current price of the resources in recipe for each job
        Produce();
        totproduced = Workstorage[1].amount;
        //sell to planet
        //workstaorage[0]is wealth, it will hold the purchase amount. workstorage[1]holds whatever is prudced at this building
        Debug.Log("res building-; " + name +  "cop=" + costofproduction + " ws[0],[1]:" + Workstorage[0].amount + "," + Workstorage[1].amount + " wealth:"+wealth.amount);

        if (Workstorage[1].amount>0)
        Workstorage[0]=Mytile.planet.Trader.BuyStuff(Workstorage[1], costofproduction * (1 + NonPayroll));
        Debug.Log("res building-;" + name + " cop=" + costofproduction + " ws[0],[1]:" + Workstorage[0].amount + "," + Workstorage[1].amount + " wealth:" + wealth.amount + " reserve:" + tempreserve.amount);
        filledpos = jobs.Count(x => x.IsFilled());
        //set aside money to buy more resources 
        if (Workstorage[0].amount >filledpos*costofproduction*1.125f)
            wealth.Recieve(Workstorage[0].Give((int)(costofproduction * 1.125f)));
        else
            wealth.Recieve(tempreserve.Give((int)(costofproduction * 1.125f)));

        Debug.Log("res building-;" + name + " cop=" + costofproduction + " ws[0],[1]:" + Workstorage[0].amount + "," + Workstorage[1].amount + " wealth:" + wealth.amount+" reserve:"+ tempreserve.amount);

        //pay workers
        //expand paypoints to keep some and pay tax;
        paypoints = (paypoints * (1+NonPayroll));
        foreach (Job job in jobs)
        {
            if (job.IsFilled())
            {
                job.worker.wealth.Recieve(Workstorage[0].GivebyFactor(job.pay / paypoints));
                Debug.Log("res building worker pay" + "name:" + job.worker.name + "workerwealth:" + job.worker.wealth.amount + " paypnts/ttl=:" + job.pay / paypoints+" ws[0],[1]:" + Workstorage[0].amount + "," + Workstorage[1].amount + " wealth:" + wealth.amount);
            }
        }
        //reset paypoints
        paypoints = 0;

        //taxes
        //keep the rest
        wealth.Recieve( Workstorage[0].GiveAll());
        Debug.Log("res building-;" + name + " cop=" + costofproduction + " ws[0],[1]:" + Workstorage[0].amount + "," + Workstorage[1].amount + " wealth:" + wealth.amount);

    }
    public void ReceiveStuff()
    {

    }
    public float SendBasicRequests(ResourcePurse[] recipe)
    {
        float cost = 0;
        float pricefactor = 1.20f;
        float mult = 1;
            mult = 1.5f;
            foreach (ResourcePurse resourcerequirement in recipe)
        {
            RequestResource thisreq = new RequestResource(resourcerequirement.resource, (int)(resourcerequirement.amount *filledpos), this, pricefactor);
            cost += Mytile.planet.Trader.prices[resourcerequirement.resource] * resourcerequirement.amount * filledpos;
            Mytile.planet.Trader.RecieveRequest(thisreq);
            pricefactor -= (pricefactor - 1) * .7f;
        }



            return cost;
    }
    public virtual void Produce()
    {

        foreach (Job job in jobs)
        {
            if (job.IsFilled())
            {
                //UseResource an add produced resoure. also incriment paypoints

                Workstorage[1].amount += UseResource() ? job.Production.amount : 0;
                paypoints += job.pay;

            }
        }

        if (BuyStorage[recipe[0].resource].amount > 0)
        {
            Workstorage[1].amount = UseResource() ? (int)(Workstorage[1].amount * 1.2f) : (int)(Workstorage[1].amount*1.1);
        }
    }
    public bool UseResource()
    {
        bool completerecipe = true;
        if (recipe[0] != null)
        {
            foreach (ResourcePurse purse in recipe)
            {
                if (DictionaryExtention.GetValueOrDefault(BuyStorage, purse.resource, new ResourcePurse(purse.resource.type, 0)).amount > purse.amount)
                {

                    BuyStorage[purse.resource].amount -= purse.amount;
                }
                else
                    completerecipe = false;
            }
        }
        else
        {
            return true;
        }
        return completerecipe;
    }

}
