using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class ClearingHouse {

    //All lists
    private List<List<Trade>> commodityLists;

    //Incoming trades
    public List<Trade> newTrades;

    //Ask lists
    private List<Trade> foodAsks;
    private List<Trade> woodAsks;
    private List<Trade> oreAsks;
    private List<Trade> metalAsks;
    private List<Trade> toolsAsks;

    //Bid lists
    private List<Trade> foodBids;
    private List<Trade> woodBids;
    private List<Trade> oreBids;
    private List<Trade> metalBids;
    private List<Trade> toolsBids;

    public ClearingHouse()
    {

        commodityLists = new List<List<Trade>>();
        newTrades = new List<Trade>();

        foodAsks = new List<Trade>();
        woodAsks = new List<Trade>();
        oreAsks = new List<Trade>();
        metalAsks = new List<Trade>();
        toolsAsks = new List<Trade>();

        foodBids = new List<Trade>();
        woodBids = new List<Trade>();
        oreBids = new List<Trade>();
        metalBids = new List<Trade>();
        toolsBids = new List<Trade>();

        commodityLists.Add(foodAsks);
        commodityLists.Add(woodAsks);
        commodityLists.Add(oreAsks);
        commodityLists.Add(metalAsks);
        commodityLists.Add(toolsAsks);
        commodityLists.Add(foodBids);
        commodityLists.Add(woodBids);
        commodityLists.Add(oreBids);
        commodityLists.Add(metalBids);
        commodityLists.Add(toolsBids);

    }

    public void ClearLists()
    {
        foreach(List<Trade> list in commodityLists)
        {
            list.Clear();
        }

        newTrades.Clear();
    }

    public void ResolveOffers()
    {

    }
}

public class Trade
{
    string type;
    string commodity;
    int quantity;
    float price;

    public Trade(string type, string commodity, int quantity, float price)
    {
        this.type = type.ToLower();
        this.commodity = commodity.ToLower();
        this.quantity = quantity;
        this.price = price;

        if (!type.Equals("ask") || !type.Equals("bid")) //FIXME: temp check
        {
            throw new NotSupportedException();
        }

        if (!commodity.Equals("food") || !commodity.Equals("wood") || !commodity.Equals("ore") 
            || !commodity.Equals("metal") || !commodity.Equals("tools")) //FIXME: temp check
        {
            throw new NotSupportedException();
        }

    }
}
