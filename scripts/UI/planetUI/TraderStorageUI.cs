using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraderStorageUI : MonoBehaviour {

    public TradingPort tradingport;
    public GameObject ListviewPrefab;
    public GameObject Planetpanel;
    public GameObject Holder;
    public void makewindow()
    {
        GameObject holder = Instantiate(Holder);
        holder.transform.SetParent(Planetpanel.transform, false);

        GameObject temp =Instantiate(ListviewPrefab);
        temp.SetActive(true);
        temp.transform.SetParent(holder.transform, false);
        temp.GetComponent<Listview>().setup(tradingport);


        GameObject pricepanel = Instantiate(ListviewPrefab);
        pricepanel.transform.SetParent(holder.transform);
        pricepanel.SetActive(true);
        pricepanel.GetComponent<Listview>().SetupRequestPanel(tradingport);

    }
}
