using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class botones : MonoBehaviour
{

 

    [SerializeField]
    private GameObject ImagenIA;

    bandit algbandit;
    

    // Start is called before the first frame update
    void Start()
    {
  
        algbandit = this.GetComponent<bandit>();
        
        // ImagenIA.GetComponent<algbandit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulsarPiedra() {
        algbandit.GetNextActionUCB1();

    }
    public void PulsarPapel() {

        algbandit.GetNextActionUCB1();
    }
    public void PulsarTijera() {

        algbandit.GetNextActionUCB1();
    }
    public void PulsarLagarto() {

        algbandit.GetNextActionUCB1();
    }
    public void PulsarSpock() {
        algbandit.GetNextActionUCB1();
    }
}
