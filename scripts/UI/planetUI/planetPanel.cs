using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetPanel : MonoBehaviour {

    public Planet thisplanet;
    public TilePanel tilepanel;
    public InfoPanel infoPanel;
    public TraderStorageUI tsui;

    public ActionPanel actionpanel;
    public void InitialSetup(Planet planet)
    {
        thisplanet = planet;

        tilepanel.setup(planet.TileList);
        infoPanel.setup(planet);
        tsui.tradingport = planet.Trader;

    }

    public void TileToggleClicked(TileToggle tiletoggle)
    {
        Tile tile = tiletoggle.tile;
        actionpanel.Setup(tile);
        infoPanel.setup(tile);
    }




    public void close()
    {
        Destroy(this.gameObject);
    }


}
