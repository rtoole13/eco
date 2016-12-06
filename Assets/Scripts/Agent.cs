using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public struct AuctionLists
{
    public Dictionary<string, int> excessList;
    public Dictionary<string, int> deficitList;
}

public class Agent {


    private Role role;
    private int historicWindow = 15; //determines how far back in turns the agent can recall 
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
    
	public void generateOffers(List<Trade> tradeList)
    {
        AuctionLists auctionLists = role.checkStock();
        /*
        if (auctionLists.excessList.ContainsKey("Food"))
        {
            Debug.Log(auctionLists.excessList["Food"]);
        }
        */

        for(int i = 0; i < auctionLists.excessList.Count; i++)
        {
            //ADDME: logic determining price and quantity of ask
            //Trade newAsk = new Trade("ask", "food", 5, 5f);
            //tradeList.Add(newAsk)
        }
        for (int i = 0; i < auctionLists.deficitList.Count; i++)
        {
            //ADDME: logic determining price and quantity of bid
            //Trade newBid = new Trade("bid", "food", 5, 5f); 
            //tradeList.Add(newBid)
        }
        

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
