using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDanio : MonoBehaviour
{

    public LogicaBarraVida logicaBarraVidaPlayer;
    public LogicaBarraVida logicaBarraVidaEnemigo;

    public float daño = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            logicaBarraVidaPlayer.vidaAcual -= daño;
            logicaBarraVidaEnemigo.vidaAcual -= daño;
        }
    }
}
