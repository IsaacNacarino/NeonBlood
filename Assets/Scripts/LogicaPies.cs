using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaTakashi logicaTakashi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!logicaTakashi.puedoSaltar)
            {
                logicaTakashi.puedoSaltar = true;
            }
            else
            {
                logicaTakashi.puedoSaltar = false;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        logicaTakashi.puedoSaltar = true;
    }
    private void OnTriggerExit(Collider other)
    {
        logicaTakashi.puedoSaltar = false;
    }
}
