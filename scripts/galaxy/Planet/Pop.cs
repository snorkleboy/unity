using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using RTS;
public class Pop  {
    public int happiness = 100;
    public float development = 1;
    public string name = "pop";
    public Job Myjob=null;
    public Building Home = null;
    public Planet Homeplanet = null;
    public float basicsCost;

    public Dictionary<ResourceEnum, Want> matWants = new Dictionary<ResourceEnum, Want>() {
        {ResourceEnum.food, new Want(ResourceEnum.food, 50, 2) } ,
        { ResourceEnum.energy, new Want(ResourceEnum.energy, 30, 3f) },
        {ResourceEnum.ManuGood,new Want(ResourceEnum.ManuGood,10,1.25f) }
    };

    public Dictionary<ResourceType, ResourcePurse> BuyStorage = new Dictionary<ResourceType, ResourcePurse>();
    public ResourcePurse wealth = new ResourcePurse(ResourceEnum.Wealth, 0);




    //public List<pop> neighbors;
    public Pop(Building Homee, string name1)
    {

        Home = Homee;
        Homeplanet = Home.Mytile.planet;
        name = name1;

    }
    public Pop(Planet planet)
    {
        Homeplanet= planet;

    }
    public void UpdatePop()
    {
        if (Myjob == null && !(Homeplanet.Government.Unemployed.Contains( this)) )
        {
            Homeplanet.Government.Unemployed.Enqueue(this);
        }
       // SendNeedsToTrader();
        UseResources();
        SpendMoney();


    }
    public void UseResources()
    {
        float temphap = 0;

        foreach (Want want in matWants.Values)
        {
            //goes through all items in storage that are of the same type as the current want, takes one away and uses
            //afterward the happiness from using the stored resources is averaged with the current happiness
            while (DictionaryExtention.GetValueOrDefault(BuyStorage, BasicResourceList.list[(int)want.type], new ResourcePurse(want.type, 0)).amount > 0)
            {
                BuyStorage[BasicResourceList.list[(int)want.type]].amount--;
                temphap += want.usewant();

            }
        }
        happiness = (int)(temphap+happiness)/2;
    }
    public void SpendMoney()
    {
        var temppricedict = Homeplanet.Trader.prices;
        float tempwealth = wealth.amount;
        float expHapp = 0f;
        float pricefactor = 1.1f;
        //buy basics 2of matwants[0] and 1 of matwants[1];

        Debug.Log("pre reqpop;" + name + " wealth;" + wealth.amount + " tempwealth:" + tempwealth + " expHapp:" + expHapp + " pricefactor:" + pricefactor);

        MakeRequest(new RequestResource(new ResourcePurse(matWants[ResourceEnum.food].type,2), this, pricefactor));
        tempwealth -= (int)(temppricedict[BasicResourceList.list[(int)matWants[ResourceEnum.food].type]] *2);
        pricefactor = 1.05f;
        MakeRequest(new RequestResource(new ResourcePurse(matWants[ResourceEnum.energy].type, 1), this, pricefactor));
        tempwealth -= (int)(temppricedict[BasicResourceList.list[(int)matWants[ResourceEnum.energy].type]]  );
        pricefactor = 1.03f;

        basicsCost = wealth.amount-tempwealth;
        expHapp += matWants[ResourceEnum.food].usewant()+ matWants[ResourceEnum.food].usewant()+ matWants[ResourceEnum.energy].usewant();

        
        //buyuntil save

        //set prices for wants, then buy wants by value at 1.05 demand until run out of mone//
        //save some money into long term wealth if can afford to buy basics and get to exp happiness of 75
        if (tempwealth > 0)
        {
            //set prices of wants to later get values (want/price)
              foreach (Want want in matWants.Values)
            {
                want.price =temppricedict[BasicResourceList.list[(int)want.type]];
            }
            int whilebreaker = 0;
            //spend/save money until no more money
            while (tempwealth >0)
            {
                if (expHapp > 50)
                    pricefactor = 1.001f;
                Want maxwant = matWants[ResourceEnum.food];

                //find max value want
                 foreach (Want want in matWants.Values)
                 {
                    if (want.getvalue() > maxwant.getvalue())
                        maxwant = want;
                 }

                //request that want, incriment amount spent and expected happiness, as well as the value in teh want (want.usewant() does it automatically)
                if (tempwealth > (int)temppricedict[BasicResourceList.list[(int)maxwant.type]] * pricefactor)
                {
                    MakeRequest(new RequestResource(new ResourcePurse(maxwant.type, 1), this, pricefactor));
                    tempwealth -= (int)temppricedict[BasicResourceList.list[(int)maxwant.type]] * pricefactor;

                    expHapp += maxwant.usewant();
                }
                else
                {
                    tempwealth = 0;
                }

                if (expHapp > 75)
                {
                    break;

                }
                /*
                if ( expHapp > 75)
                {
                    pricefactor = 1;
                    if (tempwealth / basicsCost >= 1)
                    {
                        longTermWealth.Recieve(wealth.Give((int)basicsCost));
                        tempwealth -= (int)basicsCost;
                    }
                    else if (tempwealth / basicsCost >= 4)
                    {
                        longTermWealth.Recieve(wealth.Give((int)basicsCost)*2);
                        tempwealth -= (int)basicsCost;
                    }
                    else
                    {
                        longTermWealth.Recieve(wealth.Give(wealth.amount-(int)tempwealth));
                        tempwealth = wealth.amount;
                    }

                }
                */
                if ( whilebreaker++ > 100)
                     break;
             }
            //reset
            foreach (Want want in matWants.Values)
            {
                want.reset();
            }
            Debug.Log("end reqpop;" + name + " wealth;" + wealth.amount + " tempwealth:" + tempwealth + " expHapp:" + expHapp + " pricefactor:" + pricefactor);

        }
    }
    public void MakeRequest(RequestResource req)
    {
       
            Homeplanet.Trader.RecieveRequest(req);


    }


}
