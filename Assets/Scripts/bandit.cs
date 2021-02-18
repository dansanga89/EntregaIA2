using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandit : MonoBehaviour
{
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



    public enum RPSAction
    {
        Rock, Paper, Scissors
    }

    public class Bandit : MonoBehaviour
    {
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
                    action = RPSAction.Scissors;
                    ImagenIA.GetComponent<Image>().sprite = SCISSORS;
                    break;
                case RPSAction.Rock:
                    action = RPSAction.Paper;
                    ImagenIA.GetComponent<Image>().sprite = PAPER;
                    break;
                case RPSAction.Scissors:
                    action = RPSAction.Rock;
                    ImagenIA.GetComponent<Image>().sprite = ROCK;
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
                else if (myAction == RPSAction.Scissors)
                    utility = 1f;
            }
            else if (opponents == RPSAction.Rock)
            {
                if (myAction == RPSAction.Paper)
                    utility = 1f;
                else if (myAction == RPSAction.Scissors)
                    utility = -1f;
            }
            else
            {
                if (myAction == RPSAction.Rock)
                    utility = -1f;
                else if (myAction == RPSAction.Paper)
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
        }




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
