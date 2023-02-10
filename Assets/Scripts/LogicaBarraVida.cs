using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVida : MonoBehaviour
{

    public int vidaMax;
    public float vidaAcual;
    public Image imagenBarraVida;

    // Start is called before the first frame update
    void Start()
    {
        vidaAcual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

    }

    public void RevisarVida()
    {

        imagenBarraVida.fillAmount = vidaAcual / vidaMax;
    }
}
