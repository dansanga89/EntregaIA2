using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class botones : MonoBehaviour
{
    [SerializeField]
    private GameObject ImagenIA;
    private bool Jugando;
    private int Option;

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
     
        ImagenIA.GetComponent<Image>().sprite = ROCK;
    }
    public void PulsarPapel() {
        Option = 1;
    
        ImagenIA.GetComponent<Image>().sprite = PAPER;
    }
    public void PulsarTijera() {
        Option = 2;
        ImagenIA.GetComponent<Image>().sprite = SCISSORS;
    }
    public void PulsarLagarto() {
        Option = 3;
        ImagenIA.GetComponent<Image>().sprite = LIZARD;
    }
    public void PulsarSpock() {
        Option = 4;
      //  ImagenIA.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        ImagenIA.GetComponent<Image>().sprite = SPOCK;
    }
}
