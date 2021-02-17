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
        ImagenIA.GetComponent<Image>().color = new Color32(54, 32, 75, 100);

    }
    public void PulsarPapel() {
        Option = 1;
        ImagenIA.GetComponent<Image>().color = new Color32(2, 42, 78, 100);
    }
    public void PulsarTijera() {
        Option = 2;
        ImagenIA.GetComponent<Image>().color = new Color32(99, 36, 4, 100);
    }
    public void PulsarLagarto() {
        Option = 3;
        ImagenIA.GetComponent<Image>().color = new Color32(124, 167, 3, 100);
    }
    public void PulsarSpock() {
        Option = 4;
        ImagenIA.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
}
