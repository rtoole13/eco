using UnityEngine;
using System.Collections;

public class Blacksmith : Role {

    private Agent agent;

    //When to buy
    private int foodThreshold = 3;
    private int metalThreshold = 3;

    //When to sell
    private int toolThreshold = 1;

    public Blacksmith(Agent agent)
    {
        this.agent = agent;

        this.agent.inventory["Food"] = 5;
        this.agent.inventory["Metal"] = 2;
    }
    public override void performProduction()
    {
        //implement
    }

    public override void checkStock()
    {

    }
}
