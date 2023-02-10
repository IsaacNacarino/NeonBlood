using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaHiroshi : MonoBehaviour
{
    public LogicaBarraVida hp;
    public float danioArma = 2.0f;
    private Animator anim;
    public GameObject target;
    //public LogicaTakashi logicaTakashi;
    public GameObject panelHiroshi;
    public static bool ataca;
    public bool muerto;
    public GameObject panelWinner;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ataca = false;
        muerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        dialogo();
        if (ataca)
        {
            if (!LogicaTakashi.muerto)
            {
                ataqueHiroshi();
            }
        }
    }
    //AQUI TAKASHI LE QUITA VIDA A HIROSHI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void OnTriggerEnter(Collider other)
    {
        if (!LogicaTakashi.muerto)
        {
            if (!muerto)
        {
            if (other.gameObject.tag == "armaImpacto")
            {
                anim.Play("Hit");
                hp.vidaAcual -= danioArma;

            }
        }
        }
        if (hp.vidaAcual < 0)
        {
            muerto = true;
            ataca = false;
            anim.SetBool("muerto", true);
            anim.Play("Muerte");
            panelWinner.SetActive(true);
        }
    }
    private void dialogo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 3)
        {
                panelHiroshi.SetActive(true);

        }
    }
    private void ataqueHiroshi()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 2)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

            anim.SetBool("Run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }

        else
        {
            anim.SetBool("Run", false);
            anim.Play("Ataque1");
        }
    }
}
