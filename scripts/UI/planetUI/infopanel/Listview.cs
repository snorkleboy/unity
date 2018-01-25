using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using RTS;
using UnityEngine.UI;

public class Listview : MonoBehaviour
{
    public Text text;
    public Text temp;
    public GameObject Content;

    public void setup(BuyStorageList buylist)
    {
        
        Dictionary<ResourceType, ResourcePurse> BuyStorage = buylist.buystorage;
        foreach (ResourceType type in BuyStorage.Keys)
        {
            temp = Instantiate(text);
            temp.transform.SetParent(Content.transform);
            temp.text = System.Enum.GetName(typeof(ResourceEnum), (int)type.type) +" "+ BuyStorage[type].amount;

        }
        this.gameObject.SetActive(true);
    }
    public void setup(Dictionary<ResourceType, ResourcePurse> BuyStorage)
    {
        foreach (ResourceType type in BuyStorage.Keys)
        {
            temp = Instantiate(text);
            temp.transform.SetParent(Content.transform);
            temp.text = System.Enum.GetName(typeof(ResourceEnum), (int)type.type) + " " + BuyStorage[type].amount;

        }
        this.gameObject.SetActive(true);
    }



    
    public void setup(Pop[] pkist)
    {
        this.gameObject.SetActive(true);
        {
            foreach (Pop pop in pkist)
            {
                if (pop == null)
                {
                    temp = Instantiate(text);
                    temp.transform.SetParent(Content.transform);
                    temp.text = "Availible Housing";
                }
                else
                {
                    temp = Instantiate(text);
                    temp.transform.SetParent(Content.transform); 
                    string jobtxt;
                    if (pop.Myjob == null)
                        jobtxt = "";
                    else
                        jobtxt = pop.Myjob.position;
                    temp.text = pop.name + " " + pop.wealth.amount + " " + jobtxt+" H:"+pop.happiness;
                }
            }
        }

    }

    public void setup(List<Job> jlist)
        {
            foreach (Job job in jlist)
            {
                temp = Instantiate(text);
    temp.transform.SetParent(Content.transform);
                temp.text = job.position + " " + job.worker.name;

            }
        }



    public void setup(TraderStorageUI tsui)
    {
        this.gameObject.SetActive(true);

        TradingPort tradep = tsui.tradingport;
        foreach (ResourceEnum rtye in tradep.storage.Keys)
        {
            temp = Instantiate(text);
            temp.transform.SetParent(Content.transform);
            temp.text = System.Enum.GetName(typeof(ResourceEnum),(int)rtye)+" " + tradep.storage[rtye][0].amount+" " + tradep.prices[tradep.storage[rtye][0].resource];
        }
    }
    public void setup(TradingPort planetport)
    {
        this.gameObject.SetActive(true);
        foreach (ResourceEnum rtye in planetport.storage.Keys)
        {
            temp = Instantiate(text);
            temp.transform.SetParent(Content.transform);
            temp.text = System.Enum.GetName(typeof(ResourceEnum), (int)rtye) + " " + planetport.storage[rtye][0].amount + " " + planetport.prices[planetport.storage[rtye][0].resource];
        }




    }
    public void SetupRequestPanel(TradingPort planetport)
    {
        this.gameObject.SetActive(true);
        GameObject ResourceHolderholder=new GameObject();
        ResourceHolderholder.AddComponent<HorizontalLayoutGroup>();
        ResourceHolderholder.transform.SetParent(Content.transform);

        // foreach (List<RequestResource> reqlist in planetport.RequestsLists)
        for (int i = 0; i < (int)ResourceEnum.last; i++)           
        {
            GameObject resourceholder = new GameObject();
            resourceholder.transform.SetParent(ResourceHolderholder.transform);
            resourceholder.AddComponent<VerticalLayoutGroup>();
            temp = Instantiate(text);
            temp.transform.SetParent(resourceholder.transform);
            temp.text = System.Enum.GetName(typeof(ResourceEnum), i);
            temp = Instantiate(text);
            temp.transform.SetParent(resourceholder.transform);
            temp.text = "";
            foreach (RequestResource request in planetport.RequestsLists[i])
            {
                temp = Instantiate(text);
                temp.transform.SetParent(resourceholder.transform);
                temp.text = request.building.name + " " + request.amount + " " + request.pricefactor;
            }
       }
    }

    public void close()
    {

        Destroy(this.gameObject);
    }

}
