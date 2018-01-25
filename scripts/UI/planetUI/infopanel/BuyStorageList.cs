using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
public class BuyStorageList : MonoBehaviour {
    public Dictionary<ResourceType, ResourcePurse> buystorage;
    public GameObject ListviewPrefab;
    public GameObject Planetpanel;
    public void makestoragewindow()
    {
        GameObject temp = Instantiate(ListviewPrefab);
        temp.SetActive(true);
        temp.transform.SetParent(Planetpanel.transform, false);
        if (buystorage != null)
            temp.GetComponent<Listview>().setup(buystorage);
    }

}

