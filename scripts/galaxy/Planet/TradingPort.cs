using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RTS;

public class TradingPort
{

    TradingPort[] NeighborPorts;
    Planet planet;
    public List<RequestResource>[] RequestsLists = new List<RequestResource>[(int)ResourceEnum.last];
    float reserve = 0;
    int[] UnfulfilledLastTime = new int[(int)ResourceEnum.last];

    public Dictionary<ResourceEnum, List<ResourcePurse>> storage = new Dictionary<ResourceEnum, List<ResourcePurse>>();
    public int[] Totals = new int[(int)ResourceEnum.last];
    public Dictionary<ResourceType, float> prices = new Dictionary<ResourceType, float>();

    public TradingPort(Planet plan)
    {
        planet = plan;
        for (int i = 0; i < (int)ResourceEnum.last; i++)
        {
            storage[(ResourceEnum)i] = new List<ResourcePurse>() { new ResourcePurse((ResourceEnum)i, 0) };
            RequestsLists[i] = new List<RequestResource>();
            Totals[i] = 0;
            if (i < BasicResourceList.list.Length)
            {
                prices[BasicResourceList.list[i]] = (100);
            }

        }
    }

    public float RecieveRequest(RequestResource request)
    {
        RequestsLists[(int)request.resource.type].Add(request);
        Debug.Log("Requestrecieved-; req orginator:" + request.name + " type" + request.resource.type + " pfac" + request.pricefactor);

        return prices[request.resource] * request.amount;
    }
    public bool RecieveRequest(RequestResource[] requests)
    {
        foreach (RequestResource request in requests)
        {
            RequestsLists[(int)request.resource.type].Add(request);
            Debug.Log("Requestrecieved-; req orginator:" + request.name + " type" + request.resource.type + " pfac" + request.pricefactor);

        }
        return true;

    }



    public void FulfillGeneralRequests()
    {
        //sort by price then fulfill from highest to lowest. if storage of resource runs out set price[] of that resource to lowest price sold
        //if run out of requests set price to first one sold
        foreach (List<RequestResource> templist in RequestsLists)
        {
            //Debug.Log("requestlist.count " + templist.Count + "type: " + (ResourceEnum)count++);
            //sort the resourcetype specific list by price
            if (templist.Count > 0)
            {
                // Debug.Log(System.Enum.GetName(typeof(ResourceEnum), (int)templist[0].resource.type) + " " + templist.Count + "  "+Time.time);

                //make a new sorted list and clear the old one. 
                List<RequestResource> requestlist = templist.OrderByDescending(x => x.pricefactor).ToList();
                templist.Clear();

                //
                //needs to change for high tier 
                //storage[thisRequest.resource][0]should be soething like storage[thisRequest.resource][i] in a while( storage[thisRequest.resource].notempty)
                //
                //
                RequestResource thisRequest = requestlist[0];
                ResourcePurse thisStorage = storage[thisRequest.resource.type][0];

                //sell stuff requested by popping a request off the list and sending that amount to the building
                float LastPricefactorFulfilled = thisRequest.pricefactor;
                float firstPricePointFulfilled = thisRequest.pricefactor;
                float thisprice = prices[thisRequest.resource];

                int whilebreaker = 0;
                Debug.Log("tportprewhile  rcount:" + requestlist.Count + " tstorage.amount:" + thisStorage.amount + " type :" + thisRequest.resource.type+ "price:"+ thisprice);

                while (requestlist.Count > 0 && thisStorage.amount > 0)
                {
                    thisRequest = requestlist[0];
                    thisStorage = storage[thisRequest.resource.type][0];
                    thisStorage = storage[thisRequest.resource.type][0];
                    thisprice = prices[thisRequest.resource];
                    ResourcePurse buystorage = DictionaryExtention.GetValueOrDefault(thisRequest.BuyStorage, thisRequest.resource, new ResourcePurse(thisRequest.resource.type, 0));
                    ResourcePurse buyerwealth = thisRequest.wealthpurse;


                    if (buyerwealth.amount > thisRequest.amount*prices[thisRequest.resource])
                    {
                        buystorage.Recieve(thisStorage.Give(thisRequest.amount));
                        Totals[(int)thisRequest.resource.type] -= thisRequest.amount;
                        reserve += buyerwealth.Give((int)(thisRequest.amount * thisprice));
                        LastPricefactorFulfilled = thisRequest.pricefactor;
                        requestlist.RemoveAt(0);

                    }
                    else
                    {
                        Debug.Log( thisRequest.name + " at " + thisRequest.building.Mytile.position[0] + "," + thisRequest.building.Mytile.position[1] + " tried to buy " + System.Enum.GetName(typeof(ResourceEnum), requestlist[0].resource.type) + "at"+ thisprice+" and atwant "+thisRequest.pricefactor+" but didnt have enough money");

                        requestlist.RemoveAt(0);
                        

                    }
                    // Debug.Log(whilebreaker+"  " + requestlist.Count+"  " + System.Enum.GetName(typeof(ResourceEnum), (int)requestlist[0].resource.type));
                    if (whilebreaker++ > 400)
                    {
                        Debug.Log("while loop in trading port went 400 loops... probably shouldbe be happening");
                        break;
                    }

                }
                //set prices
                //if there are unfilled requests multiply price by last price point fulfilled.
                // if lastrequest is at pricefactor 1 then price stays teh same, if it was a higher demand then the price will change accordingly 

                if (requestlist.Count > 0)
                {
                    if (thisStorage.amount > 100)
                    {
                        Debug.Log("unfilled request but storage not empty");
                    }
                    Debug.Log("regular price change:" + prices[thisRequest.resource] +" * "+ LastPricefactorFulfilled + " being set as price of " + thisRequest.resource.type + " instead of " + prices[thisRequest.resource]);

                    prices[thisRequest.resource] = prices[thisRequest.resource] * LastPricefactorFulfilled;

                }
                //if all requests were filled and some resource in reserve set price to 90% 

                else
                {
                    if (thisStorage.amount > 100)
                    {
                        Debug.Log("reg price change:" + prices[thisRequest.resource] * .9f + "being set as price of " + thisRequest.resource.type + " instead of " + prices[thisRequest.resource]);

                        prices[thisRequest.resource] = prices[thisRequest.resource] * .9f;
                    }
                }
                UnfulfilledLastTime[(int)thisRequest.resource.type] = requestlist.Count;
                requestlist.Clear();
            }


        templist.Clear();
        }
    }

    public ResourcePurse BuyStuff(ResourcePurse stuff, float costofproduction)
    {

        int giveam = stuff.GiveAll();
        DictionaryExtention.GetValueOrDefault(storage, stuff.resource.type, new List<ResourcePurse>() { new ResourcePurse(stuff.resource.type, 0) })[0].Recieve(giveam);

        //storage[stuff.resource.type][0].Recieve(giveam);
        Totals[(int)stuff.resource.type] += giveam;
        if (costofproduction/ giveam > prices[stuff.resource])
        {
            Debug.Log("COP price change:" + costofproduction / giveam + "being set as price of " + stuff.resource.type + " instead of " + prices[stuff.resource]);
            prices[stuff.resource] = costofproduction/ giveam;
        }

        return new ResourcePurse(ResourceEnum.Wealth, (int)(giveam * prices[stuff.resource]));
    }







    public void Giveto(ResourcePurse recieverstorage, int amount)
    {


    }





}
public static class DictionaryExtention
{

    public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key, TValue defaultValue)
    {
        TValue val;
        if (self.TryGetValue(key, out val))
        {
            return val;
        }
        else
        {
            self[key] = defaultValue;
            return defaultValue;
        }
    }
}