using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string username;
    public bool human;

    public bool GalaxyView=true;
    public Star StarSystemViewed=null;

    public GameObject Cursor;
    public UserInput userinput;

    // Use this for initialization
    void Start()
    {
        Cursor = GameObject.Instantiate(Cursor);
       // GameManager = new GameManager();
        //GameManager.player = this;
        //GameManager.BuildGalaxy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
