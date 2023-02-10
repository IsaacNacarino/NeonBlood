using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTakashi : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    public bool estoyAtancando;

    public BoxCollider espada;

    public float danioArma = 5.0f;
    public static bool muerto;
    public GameObject panelGameOver;
    public GameObject panelPause;


    //Vida
    public LogicaBarraVida logicaBarraVidaPlayer;
   

    public float daño = 2.0f;
     //


    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        muerto = false;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("estado", 2);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("estado", 1);
            }
            else
            {
                anim.SetInteger("estado", 0);
            }
            //************************************************
            if (!PauseScript.GameIsPaused)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    panelPause.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            anim.SetFloat("velX", x);
            anim.SetFloat("velY", y);
            if (puedoSaltar)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("suelo", false);
                    anim.SetBool("saltando", true);
                    rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
                }
                anim.SetBool("cayendo", true);
            }
            else
            {
                estoyCayendo();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !estoyAtancando)
            {
                anim.SetTrigger("ataque");
                estoyAtancando = true;
                puedoSaltar = false;
            }
            espada.enabled = true;
        }
    }
    public void estoyCayendo()
    {
        anim.SetBool("suelo", true);
        anim.SetBool("saltando", false);
    }

    public void pararAtaque()
    {
        estoyAtancando = false;
    }
    //Aqui takashi recibe daño!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
    private void OnTriggerEnter(Collider coll)
    {
        //SI NO ESTA MUERTO
        if (!muerto)
        {
            //SI RECIBE DAÑO DEL ZOMBI
            if (coll.CompareTag("arma"))
            {
                print("Daño");
                logicaBarraVidaPlayer.vidaAcual -= daño;

            }
            //SI RECIBE DAÑO DE HIROSHI
            if (coll.CompareTag("armaHiroshi"))
            {
                Debug.Log("tocado takashi");
                logicaBarraVidaPlayer.vidaAcual -= danioArma;

            }
        }
        if (logicaBarraVidaPlayer.vidaAcual <= 0)
        {
            muerto = true;
            anim.Play("Muerte");
            panelGameOver.SetActive(true);
        }
        
    }
}
