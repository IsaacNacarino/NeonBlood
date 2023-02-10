using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public int rutina; //rutina del enemigo
    public float crono; //tiempo entre rutinas
    public Animator anim; 
    public Quaternion angulo; //para rotar al enemigo
    public float grado; // rotar grado del angulo

    public GameObject target;
    public Rigidbody rb;
    public bool atacando;



    //vida
    public LogicaBarraVida logicaBarraVidaEnemigo;

    public float daño = 2.0f;
    //

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Comportamiento_Enemigo()
    {

        if (Vector3.Distance(transform.position, target.transform.position)>5)
        {
            anim.SetBool("run", false);
            crono += 1 * Time.deltaTime;
            if (crono >= 4)
            {
                rutina = Random.Range(0, 2); //numero entre cero y uno 
                crono = 0;


            }

            switch (rutina)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position)>1 && !atacando)
            {


                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);


                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                anim.SetBool("attack", false);
            }

            else
            {

                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                anim.SetBool("attack", true);
                atacando = true;


            }
            
        
        }
        

    }


    public void Final_Anim()
    {
        anim.SetBool("attack", false);
        atacando = false;
    }


    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }


    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("armaImpacto"))
        {
            print("DañoDelPlayer");
            logicaBarraVidaEnemigo.vidaAcual -= daño;

        }
        if (logicaBarraVidaEnemigo.vidaAcual <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
