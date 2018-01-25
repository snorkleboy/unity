using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour {

    Planet planet;

    public Text namee;
    public Text PaBcounts;
    public Text UnemUnfill;
    public Text PaBwealth;

    public void Update()
    {
        if (planet != null)
        {
            namee.text = planet.planetName;
            PaBcounts.text = "Population:" + planet.population + " buildings:" + planet.PlanetBuildings.Count;

            int wealthbuilds = 0;
            int wealthpops = 0;
            foreach (Building building in planet.PlanetBuildings)
            {
                wealthbuilds += building.wealth.amount;
                if (building.GetType().IsSubclassOf(typeof(Residential)))
                    wealthpops += Residential.GetPopWealth((Residential)building);

            }
            PaBwealth.text = "pop wealth:" + wealthpops + " Building wealth:" + wealthbuilds;
            UnemUnfill.text = "unemployed:" + planet.Government.Unemployed.Count + " unfilled:" + planet.Government.UnfilledJobs.Count;
        }
    }

    public void setup(Planet Planett)
    {
        planet = Planett;
    }

}
