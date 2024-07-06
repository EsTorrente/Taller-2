using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    //cositos para referenciar
    public C1Movement Character1;
    public C2Movement Character2;
    public GameObject char1;
    public GameObject char2;
    public bool C1Active = true;
    
    //hacer que solo spawnee el primer sprite 
    void Start()
    {
        Character1.enabled = true;
        char2.SetActive(false);
        char1.SetActive(true);
    }

    //llamar el switch
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerSwitch();
        }
    }

    //switchear los personajes
    public void PlayerSwitch()
    {
        if(C1Active)
        {
            Character1.enabled = false;
            char1.SetActive(false);
            char2.SetActive(true);
            char2.transform.position = char1.transform.position;
            Character2.enabled = true;
            C1Active = false;
        }
        else
        {
            Character1.enabled = true;
            char2.SetActive(false);
            char1.SetActive(true);
            char1.transform.position = char2.transform.position;
            Character2.enabled = false;
            C1Active = true;
        }
    }
}
