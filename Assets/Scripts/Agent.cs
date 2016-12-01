using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Agent {


    private Role role;

    private string seed;
    private System.Random pseudoRandom;

    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    public Agent()
    {
        //initialize
        inventory.Add("Coin", 100);
        inventory.Add("Food", 0);
        inventory.Add("Wood", 0);
        inventory.Add("Ore", 0);
        inventory.Add("Metal", 0);
        inventory.Add("Tools", 0);

        seed = Time.time.ToString();
        pseudoRandom = new System.Random(seed.GetHashCode());
    }
    
	public void generateOffers()
    {
        //if low on ingredients, create bid
        //if produced unneeded item, create ask
    }

    public void createAsk()
    {

    }

    public void createBid()
    {

    }

    public void performProduction()
    {
        if (role is Farmer)
            Farm();
        else if (role is Woodcutter)
            CutWood();
        else if (role is Miner)
            Mine();
        else if (role is Refiner)
            Refine();
        else if (role is Blacksmith)
            Forge();
    }


    //FIXME: Actually use role classes...

    private void Farm()
    {
        if (inventory["Wood"] > 0 && inventory["Tools"] > 0)
        {
            inventory["Food"] += 4;
            inventory["Wood"] -= 1;

            if (pseudoRandom.Next(0, 10) < 1)
                inventory["Tools"] -= 1;
        }
        else if (inventory["Wood"] > 0 && inventory["Tools"] == 0)
        {
            inventory["Food"] += 2;
            inventory["Wood"] -= 1;
        }
        else
        {
            inventory["Coin"] -= 2;
        }
    }

    private void CutWood()
    {
        if (inventory["Food"] > 0 && inventory["Tools"] > 0)
        {
            inventory["Wood"] += 2;
            inventory["Food"] -= 1;

            if (pseudoRandom.Next(0, 10) < 1)
                inventory["Tools"] -= 1;
        }
        else if (inventory["Food"] > 0 && inventory["Tools"] == 0)
        {
            inventory["Wood"] += 1;
            inventory["Food"] -= 1;
        }
        else
        {
            inventory["Coin"] -= 2;
        }
    }

    private void Mine()
    {
        if (inventory["Food"] > 0 && inventory["Tools"] > 0)
        {
            inventory["Ore"] += 4;
            inventory["Food"] -= 1;

            if (pseudoRandom.Next(0, 10) < 1)
                inventory["Tools"] -= 1;
        }
        else if (inventory["Food"] > 0 && inventory["Tools"] == 0)
        {
            inventory["Ore"] += 2;
            inventory["Food"] -= 1;
        }
        else
        {
            inventory["Coin"] -= 2;
        }
    }

    private void Refine()
    {
        if (inventory["Food"] > 0 && inventory["Tools"] > 0)
        {
            inventory["Metal"] += inventory["Ore"];
            inventory["Ore"] = 0;
            inventory["Food"] -= 1;

            if (pseudoRandom.Next(0, 10) < 1)
                inventory["Tools"] -= 1;
        }
        else if (inventory["Food"] > 0 && inventory["Tools"] == 0)
        {
            inventory["Metal"] += 2;
            inventory["Ore"] -= 2;
            inventory["Food"] -= 1;
        }
        else
        {
            inventory["Coin"] -= 2;
        }

    }

    private void Forge()
    {
        if (inventory["Food"] > 0)
        {
            inventory["Tools"] += inventory["Metal"];
            inventory["Metal"] = 0;
            inventory["Food"] -= 1;
        }
        else
        {
            inventory["Coin"] -= 2;
        }
    }
       
    public Role Role
    {
        set { role = value; }
        get { return role; }
    }

    
}
