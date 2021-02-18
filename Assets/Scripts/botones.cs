using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class botones : MonoBehaviour
{
   
    private bool Jugando;
    private int Option;


   
   
    // Start is called before the first frame update
    void Start()
    {
        Jugando = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulsarPiedra() {
        //Si booleando jugando = true, se hace lo siguiente
        //Añadir piedra a variable pulsada
        //Ejecutar IA y dejar true el booleano jugando
        Option = 0;
     
   
    }
    public void PulsarPapel() {
        Option = 1;
    
    }
    public void PulsarTijera() {
        Option = 2;
    }
    public void PulsarLagarto() {
        Option = 3;
    }
    public void PulsarSpock() {
        Option = 4;
    }
}
