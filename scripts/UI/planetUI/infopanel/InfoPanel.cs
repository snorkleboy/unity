using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using RTS;

using System;

public class InfoPanel : MonoBehaviour {

    public PlanetInfo planetinfo;
    public TileInspector inspector;

    public void setup(Planet planett)
    {
        planetinfo.setup(planett);
    }
    public void setup(Tile tilee)
    {
        inspector.gameObject.SetActive(true);
        inspector.Setup(tilee);
    }

}
