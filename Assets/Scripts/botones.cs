using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botones : MonoBehaviour
{
    [SerializeField]
    private GameObject ImagenIA;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulsarPiedra() {
        //Si booleando jugando = true, se hace lo siguiente
        //Añadir piedra a variable pulsada
        //Ejecutar IA y dejar true el booleano jugando

        ImagenIA.GetComponent<Image>().color = new Color32(54, 32, 75, 100);

    }
    public void PulsarPapel() {

        ImagenIA.GetComponent<Image>().color = new Color32(2, 42, 78, 100);
    }
    public void PulsarTijera() {

        ImagenIA.GetComponent<Image>().color = new Color32(99, 36, 4, 100);
    }
    public void PulsarLagarto() {

        ImagenIA.GetComponent<Image>().color = new Color32(124, 167, 3, 100);
    }
    public void PulsarSpock() {

        ImagenIA.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
}
