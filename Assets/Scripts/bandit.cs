using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bandit : MonoBehaviour
{




    public enum RPSAction
    {
        Rock, Paper, Scissors, Lizzard, Spok
    }


    [SerializeField]
    private GameObject ImagenIA;
    [SerializeField]
    private Sprite ROCK;

    [SerializeField]
    private Sprite PAPER;

    [SerializeField]
    private Sprite SCISSORS;

    [SerializeField]
    private Sprite LIZARD;

    [SerializeField]
    private Sprite SPOCK;


    bool init;
        int totalActions;
        int[] count;
        float[] score;
        int numActions;
        RPSAction lastAction;
        int lastStrategy;

        public void InitUCB1()
        {
            if (init)
            return;
        
            totalActions = 0;
            numActions = System.Enum.GetNames(typeof(RPSAction)).Length;
            count = new int[numActions];
            score = new float[numActions];
            int i;
            for (i = 0; i < numActions; i++)
            {
                count[i] = 0;
                score[i] = 0f;
            }
            init = true;

        }


        public RPSAction GetNextActionUCB1()
        {
            int i, best;
            float bestScore;
            float tempScore;
       
        InitUCB1();
        
        for (i = 0; i < numActions; i++)
        {
            if (count[i] == 0)
            {
                lastStrategy = i;
                Debug.Log(lastStrategy);
                lastAction = GetActionForStrategy((RPSAction)i);
                return lastAction;
            }
        }

        best = 0;
            bestScore = score[best] / (float)count[best];
            float input = Mathf.Log(totalActions / (float)count[best]);
            input *= 2f;
            bestScore += Mathf.Sqrt(input);
            
            
            for (i = 0; i < numActions; i++)
            {
                tempScore = score[i] / (float)count[i];
                input = Mathf.Log(totalActions / (float)count[best]);
                input *= 2f;
                tempScore = Mathf.Sqrt(input);
                if (tempScore > bestScore)
                {
                    best = i;
                    bestScore = tempScore;
                }
            }

            lastStrategy = best;
     
            lastAction = GetActionForStrategy((RPSAction)best);
            return lastAction;

        }


    public RPSAction GetActionForStrategy(RPSAction strategy)
    {
        RPSAction action;
        switch (strategy)
        {
            default:
            case RPSAction.Paper:
                action = RPSAction.Spok;
                ImagenIA.GetComponent<Image>().sprite = SPOCK;
                TellOpponentAction(action);
                break;

            case RPSAction.Rock:
                action = RPSAction.Paper;
                ImagenIA.GetComponent<Image>().sprite = PAPER;
                TellOpponentAction(action);
                break;

            case RPSAction.Scissors:
                action = RPSAction.Rock;
                ImagenIA.GetComponent<Image>().sprite = ROCK;
                TellOpponentAction(action);
                break;

            case RPSAction.Lizzard:
                action = RPSAction.Scissors;
                ImagenIA.GetComponent<Image>().sprite = SCISSORS;
                TellOpponentAction(action);
                break;

            case RPSAction.Spok:
                action = RPSAction.Lizzard;
                ImagenIA.GetComponent<Image>().sprite = LIZARD;
                TellOpponentAction(action);
                break;
        }

        return action;
    }

    public float GetUtility(RPSAction myAction, RPSAction opponents)
    {
        float utility = 0f;

        if (opponents == RPSAction.Paper)
        {
            if (myAction == RPSAction.Rock) 
                utility = -1f;
             if(myAction == RPSAction.Spok)
                      utility = -1f;
             if (myAction == RPSAction.Scissors)
                utility = 1f;
             if(myAction == RPSAction.Lizzard)
                utility = 1f;
        }

        else if (opponents == RPSAction.Rock)
        {
            if (myAction == RPSAction.Paper)  
                utility = 1f;
            if (myAction == RPSAction.Spok)
                utility = 1f;

            if (myAction == RPSAction.Scissors) 
                utility = -1f;
            if(myAction == RPSAction.Lizzard)
                utility = -1f;
        }

        else if (opponents == RPSAction.Scissors)
        {
            if (myAction == RPSAction.Rock)
                utility = -1f;
              if (myAction == RPSAction.Spok)
                utility = -1f;
            if (myAction == RPSAction.Paper) 
                utility = 1f;
             if(myAction == RPSAction.Lizzard)
                utility = 1f;
        }

        else if (opponents == RPSAction.Lizzard)
        {
            if (myAction == RPSAction.Rock)
                utility = -1f;
            if (myAction == RPSAction.Scissors)
                utility = -1f;
            if (myAction == RPSAction.Paper)
                utility = 1f;
            if(myAction == RPSAction.Spok)
                utility = 1f;
        }

        else
        {
            if (myAction == RPSAction.Paper)
                utility = -1f;
            if (myAction == RPSAction.Lizzard)
                utility = -1f;
            if (myAction == RPSAction.Scissors)
                utility = 1f;
            if(myAction == RPSAction.Rock)
                utility = 1f;
        }

        return utility;
    }

    public void TellOpponentAction(RPSAction action)
        {
       
            totalActions++;
      
     
        float utility;
            utility = GetUtility(lastAction, action);
     
            score[(int)lastAction] += utility;
            count[(int)lastAction] += 1;
        Debug.Log("Score: Piedra " + score[0] + " Papel " + score[1] + " Tijera " + score[2] + " Lagarto " + score[3] + " Spock " + score[4]);
        Debug.Log("Count: Piedra " + count[0] + " Papel " + count[1] + " Tijera " + count[2] + " Lagarto " + count[3] + " Spock " + count[4]);
        

    }




    







    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
