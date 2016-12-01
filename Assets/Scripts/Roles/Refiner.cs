using UnityEngine;
using System.Collections;

public class Refiner : Role
{
    private Agent agent;

    //When to buy
    private int toolThreshold = 1;
    private int foodThreshold = 3;

    //When to sell
    private int metalThreshold = 1;

    public Refiner(Agent agent)
    {
        this.agent = agent;

        this.agent.inventory["Food"] = 5;
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
