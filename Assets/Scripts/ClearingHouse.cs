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
        SortOffers();

    }

    public void SortOffers()
    {
        foreach (Trade trade in newTrades)
        {
            switch (trade.type)
            {
                case "ask":
                    switch (trade.commodity)
                    {
                        case "food":
                            foodAsks.Add(trade);
                            break;
                        case "wood":
                            woodAsks.Add(trade);
                            break;
                        case "ore":
                            oreAsks.Add(trade);
                            break;
                        case "metal":
                            metalAsks.Add(trade);
                            break;
                        case "tools":
                            toolsAsks.Add(trade);
                            break;
                    }
                    break;
                case "bid":
                    switch (trade.commodity)
                    {
                        case "food":
                            foodBids.Add(trade);
                            break;
                        case "wood":
                            woodBids.Add(trade);
                            break;
                        case "ore":
                            oreBids.Add(trade);
                            break;
                        case "metal":
                            metalBids.Add(trade);
                            break;
                        case "tools":
                            toolsBids.Add(trade);
                            break;
                    }
                    break;
            }
        }
    }
}

public class Trade
{
    public string type;
    public string commodity;
    public int quantity;
    public float price;

    public Trade(string type, string commodity, int quantity, int price)
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
