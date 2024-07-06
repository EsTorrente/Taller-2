using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbManager : MonoBehaviour
{
    //cositos para referenciar
    public bool C1Active = true;
    public GameObject environment1;
    public GameObject environment2;

    //hacer que solo spawnee el primer ambiente
    void Start()
    {
        environment1.SetActive(true);
        environment2.SetActive(false);
    }

    //llamar el switch
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AmbSwitch();
        }
    }

    //switchear los escenerario :3
    public void AmbSwitch()
    {
        if(C1Active)
        {
            C1Active = false;

            environment1.SetActive(false);
            environment2.SetActive(true);
        }
        else
        {
            C1Active = true;

            environment1.SetActive(true);
            environment2.SetActive(false);
        }
    }
}
