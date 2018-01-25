using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class buildingList {



    public static System.Type town =typeof( Town);
    public static System.Type city = typeof(City);

    public static System.Type mine = typeof(Mine);
    public static System.Type factory = typeof(Factory);
    public static System.Type farm = typeof(Farm);
    public static System.Type PowerPlant = typeof(PowerPlant);

    public static Building[] list = new Building[6] { new Town(), new City(),new Mine(),new Factory(),new Farm(), new PowerPlant()};


    // };
    //public static Town town= new Town();
}


