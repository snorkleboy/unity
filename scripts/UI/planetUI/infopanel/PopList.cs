using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
public class PopList : MonoBehaviour {

    public Pop[] poplist;
    public List<Job> JobList;
    public GameObject ListviewPrefab;
    public GameObject Planetpanel;
    public void makepopwindow()
    {
        GameObject temp = Instantiate(ListviewPrefab);
        temp.transform.SetParent(Planetpanel.transform, false);
        temp.SetActive(true);

        if (poplist!=null)
        temp.GetComponent<Listview>().setup(poplist);
    }
    public void makejobwindow()
    {
        GameObject temp = Instantiate(ListviewPrefab);
        temp.transform.SetParent(Planetpanel.transform, false);
        temp.SetActive(true);

        if (JobList != null)
            temp.GetComponent<Listview>().setup(JobList);
    }
    public void makewindosendthis()
    {
        GameObject temp = Instantiate(ListviewPrefab);
        temp.SetActive(true);

        temp.transform.SetParent(Planetpanel.transform, false);
        if (JobList != null)
            temp.GetComponent<Listview>().setup(JobList);
        else if (poplist!=null)
            temp.GetComponent<Listview>().setup(poplist);

    }
}
