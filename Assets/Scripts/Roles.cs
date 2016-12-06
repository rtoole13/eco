using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public abstract class Role
{
    

    public virtual AuctionLists checkStock()
    {
        throw new NotImplementedException();
    }

    public virtual void performProduction(System.Random pseudoRandom)
    {
        throw new NotImplementedException();
    }
}

public class Blacksmith : Role
{

    private Agent agent;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    //When to buy
    private int foodThreshold = 3;
    private int metalThreshold = 3;

    //When to sell
    private int toolThreshold = 1;

    public Blacksmith(Agent agent)
    {
        this.agent = agent;
        inventory = agent.inventory;

        inventory["Food"] = 5;
        inventory["Metal"] = 2;
    }
    public override void performProduction(System.Random pseudoRandom)
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

    public override AuctionLists checkStock()
    {
        var excess = new Dictionary<string, int>();
        var deficit = new Dictionary<string, int>();

        if (inventory["Tools"] > toolThreshold)
        {
            excess.Add("Tools", inventory["Tools"] - toolThreshold);
        }
        if (inventory["Food"] < foodThreshold)
        {
            deficit.Add("Food", foodThreshold - inventory["Food"]);
        }
        if (inventory["Metal"] < metalThreshold)
        {
            deficit.Add("Metal", metalThreshold - inventory["Metal"]);
        }

        var auctions = new AuctionLists
        {
            excessList = excess,
            deficitList = deficit
        };
        return auctions;
    }
}

public class Farmer : Role
{
    private Agent agent;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    //When to buy
    private int toolThreshold = 1;
    private int woodThreshold = 3;

    //When to sell
    private int foodThreshold = 1;

    public Farmer(Agent agent)
    {
        this.agent = agent;
        inventory = agent.inventory;

        inventory["Wood"] = 5;
        inventory["Tools"] = 2;
    }

    public override void performProduction(System.Random pseudoRandom)
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

    public override AuctionLists checkStock()
    {
        var excess = new Dictionary<string, int>();
        var deficit = new Dictionary<string, int>();

        if (inventory["Food"] > foodThreshold)
        {
            excess.Add("Food", inventory["Food"] - foodThreshold);
        }
        if (inventory["Tools"] < toolThreshold)
        {
            deficit.Add("Tools", toolThreshold - inventory["Tools"]);
        }
        if (inventory["Wood"] < woodThreshold)
        {
            deficit.Add("Wood", woodThreshold - inventory["Wood"]);
        }

        var auctions = new AuctionLists
        {
            excessList = excess,
            deficitList = deficit
        };
        return auctions;
    }
}

public class Miner : Role
{
    private Agent agent;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    //When to buy
    private int toolThreshold = 1;
    private int foodThreshold = 3;

    //When to sell
    private int oreThreshold = 1;

    public Miner(Agent agent)
    {
        this.agent = agent;
        inventory = agent.inventory;

        inventory["Food"] = 5;
        inventory["Tools"] = 2;
    }

    public override void performProduction(System.Random pseudoRandom)
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

    public override AuctionLists checkStock()
    {
        var excess = new Dictionary<string, int>();
        var deficit = new Dictionary<string, int>();

        if (inventory["Ore"] > oreThreshold)
        {
            excess.Add("Ore", inventory["Ore"] - oreThreshold);
        }
        if (inventory["Tools"] < toolThreshold)
        {
            deficit.Add("Tools", toolThreshold - inventory["Tools"]);
        }
        if (inventory["Food"] < foodThreshold)
        {
            deficit.Add("Food", foodThreshold - inventory["Food"]);
        }

        var auctions = new AuctionLists
        {
            excessList = excess,
            deficitList = deficit
        };
        return auctions;
    }
}

public class Refiner : Role
{
    private Agent agent;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    //When to buy
    private int toolThreshold = 1;
    private int foodThreshold = 3;

    //When to sell
    private int metalThreshold = 1;

    public Refiner(Agent agent)
    {
        this.agent = agent;
        inventory = agent.inventory;

        inventory["Food"] = 5;
        inventory["Tools"] = 2;
    }

    public override void performProduction(System.Random pseudoRandom)
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

    public override AuctionLists checkStock()
    {
        var excess = new Dictionary<string, int>();
        var deficit = new Dictionary<string, int>();

        if (inventory["Metal"] > metalThreshold)
        {
            excess.Add("Metal", inventory["Metal"] - metalThreshold);
        }
        if (inventory["Tools"] < toolThreshold)
        {
            deficit.Add("Tools", toolThreshold - inventory["Tools"]);
        }
        if (inventory["Food"] < foodThreshold)
        {
            deficit.Add("Food", foodThreshold - inventory["Food"]);
        }

        var auctions = new AuctionLists
        {
            excessList = excess,
            deficitList = deficit
        };
        return auctions;
    }
}

public class Woodcutter : Role
{
    private Agent agent;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    //When to buy
    private int toolThreshold = 1;
    private int foodThreshold = 3;

    //When to sell
    private int woodThreshold = 1;

    public Woodcutter(Agent agent)
    {
        this.agent = agent;
        inventory = agent.inventory;

        inventory["Food"] = 5;
        inventory["Tools"] = 2;
    }

    public override void performProduction(System.Random pseudoRandom)
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

    public override AuctionLists checkStock()
    {
        var excess = new Dictionary<string, int>();
        var deficit = new Dictionary<string, int>();

        if (inventory["Wood"] > woodThreshold)
        {
            excess.Add("Wood", inventory["Wood"] - woodThreshold);
        }
        if (inventory["Tools"] < toolThreshold)
        {
            deficit.Add("Tools", toolThreshold - inventory["Tools"]);
        }
        if (inventory["Food"] < foodThreshold)
        {
            deficit.Add("Food", foodThreshold - inventory["Food"]);
        }

        var auctions = new AuctionLists
        {
            excessList = excess,
            deficitList = deficit
        };
        return auctions;
    }
}