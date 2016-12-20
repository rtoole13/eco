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

        //ADDME: logic determining price and quantity of ask
        foreach (KeyValuePair<string, int> kvp in auctionLists.excessList)
        {
            //FIXME: currently placing an ask for exactly the excess amount and a random price. no logic applied
            int cost = pseudoRandom.Next(2, 6);
            int quant = kvp.Value;
            Trade newAsk = new Trade("ask", kvp.Key, quant, cost); 
            tradeList.Add(newAsk);
        }


        foreach (KeyValuePair<string, int> kvp in auctionLists.deficitList)
        {
            //FIXME: currently trying to place a bid for exactly the deficit amount and a random price.
            int cost = pseudoRandom.Next(2, 6);
            int quant = kvp.Value;
            if (cost * quant > inventory["coin"])
            {
                //cant afford at cost specified. do nothing if broke, otherwise ask at price of 1;
                if (inventory["coin"] < 1)
                {
                    return;
                }
                cost = 1;
                quant = inventory["coin"] / cost;
            }
            Trade newBid = new Trade("bid", kvp.Key, quant, cost);
            tradeList.Add(newBid);
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
