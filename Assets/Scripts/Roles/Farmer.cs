using UnityEngine;
using System.Collections;

public class Farmer : Role
{
    private Agent agent;

    //When to buy
    private int toolThreshold = 1;
    private int woodThreshold = 3;

    //When to sell
    private int foodThreshold = 1;

    public Farmer(Agent agent)
    {
        this.agent = agent;

        this.agent.inventory["Wood"] = 5;
        this.agent.inventory["Tools"] = 2;
    }

    public override void performProduction()
    {
        //implement
    }

    public override void checkStock()
    {

    }
}
