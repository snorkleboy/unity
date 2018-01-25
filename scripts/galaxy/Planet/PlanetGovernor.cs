using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class PlanetGovernor  {

    Planet planet;
    public ResourcePurse Tax = new ResourcePurse(ResourceEnum.Wealth, 100);

    public Queue<Job> UnfilledJobs = new Queue<Job>();
    public int totalvacancies = 0;
    public List<Residential> BuildingVacancies = new List<Residential>();
    public Queue<Pop> Unemployed = new Queue<Pop>();
    public Queue<Pop> Homeless = new Queue<Pop>();


    public PlanetGovernor(Planet plan)
    {
        planet = plan;

    }
    public void UpdatePlanet()
        {
        //temp add pop to empty residential buildings
        foreach (Building Building in planet.PlanetBuildings)
        {
            if (Building.GetType().IsSubclassOf(typeof(Residential)))
            {
                Pop[] poplist = Building.GetPops();
                if (poplist[0] == null)
                {
                    AddPop(Building.Mytile);
                }
            }
            //update each building
            Building.UpdateThis();
        }

        //balance jobs 
        int whilerelease = 0;
        while (Unemployed.Count>0 && UnfilledJobs.Count > 0)
        {
            UnfilledJobs.Dequeue().Fill(Unemployed.Dequeue());
            if (whilerelease++ > 10) break;
        }

        //check if there are homelss and vacancies

        //attempt to fulfill requests
        if (planet.PlanetBuildings.Count>0)
        planet.Trader.FulfillGeneralRequests();
    }


    public void AddPop(Tile tile)
    {
        if (tile.building == null || !(tile.building.GetType().IsSubclassOf(typeof(Residential))))
        {
            Debug.Log("tried to add pop to tile with no building or a nonresidential building");
            return;
        }
        planet.population += 1;
        Pop pop = new Pop(tile.building, (Mathf.FloorToInt(Random.value*10)).ToString());
        //
        //
        //
        //

        tile.building.AddPop(pop);
        Unemployed.Enqueue(pop);
        planet.wealth += pop.wealth.amount;
    }
    public void ReplaceBuilding(Tile tile, Building buildingtobuild)
    {
        Building Builtbuilding = (Building)System.Activator.CreateInstance(buildingtobuild.GetType());
        tile.building.UpgradeTo(Builtbuilding);
    }
    public void AddBuilding(Tile tile, Building building)
    {
        if (tile.building != null)
        {
            ReplaceBuilding(tile, building);
        }
        else
        {
            tile.building = (Building)System.Activator.CreateInstance(building.GetType());
            tile.building.Mytile = tile;
            planet.PlanetBuildings.Add(tile.building);
            //if residential add to vacanies, if reourcetype add jobs to unfilled quououe
            if (tile.building.GetType().IsSubclassOf(typeof(Residential)))
            {
                totalvacancies += tile.building.GetPops().Length;
                BuildingVacancies.Add(tile.building as Residential);
            }
            else if (tile.building.GetType().IsSubclassOf(typeof(ResourceBuilding)))
            {
                foreach (Job job in tile.building.jobs)
                {
                    if (!job.IsFilled())
                    {
                        UnfilledJobs.Enqueue(job);
                    }
                }
            }
        }


    }
}
