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
        role.performProduction(pseudoRandom);
    }
       
    public Role Role
    {
        set { role = value; }
        get { return role; }
    }

    
}
