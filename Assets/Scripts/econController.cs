using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class econController : MonoBehaviour {

    public string seed;
    public bool useRandomSeed;

    public int agentCount;
    public bool randomizeAgents;

    private List<Agent> agents = new List<Agent>();
    private int farmers = 0;
    private int miners = 0;
    private int woodcutters = 0;
    private int refiners = 0;
    private int blacksmiths = 0;

    // Use this for initialization
    void Start ()
    {
        if (useRandomSeed)
        {
            seed = System.DateTime.Now.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());


        RandomlyAssignRoles(pseudoRandom); //Allow AssignRoles as an option

        print("Number of farmers: " + farmers);
        print("Number of miners: " + miners);
        print("Number of woodcutters: " + woodcutters);
        print("Number of refiners: " + refiners);        
        print("Number of blacksmiths: " + blacksmiths);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Game 'Loop'
        if (Input.GetMouseButtonUp(0))
        {
            foreach (Agent agent in agents)
            {
                agent.performProduction();
            }
        }
	}



    void RandomlyAssignRoles(System.Random pseudoRandom)
    {
        for (int i = 0; i < agentCount; i++)
        {
            Agent agent = new Agent();

            int roleVar = pseudoRandom.Next(1, 6);
            switch (roleVar)
            {
                case 1:
                    agent.Role = new Farmer(agent);
                    farmers++;
                    break;
                case 2:
                    agent.Role = new Woodcutter(agent);
                    woodcutters++;
                    break;
                case 3:
                    agent.Role = new Miner(agent);
                    miners++;
                    break;
                case 4:
                    agent.Role = new Refiner(agent);
                    refiners++;
                    break;
                case 5:
                    agent.Role = new Blacksmith(agent);
                    blacksmiths++;
                    break;
            }
            agents.Add(agent);
        }
    }



    //FIXME: ALLOW MANUAL ROLE ASSIGNMENT
    void AssignRoles() 
    {
        for (int i = 0; i < agentCount; i++)
        {

        }
    }
    
}
