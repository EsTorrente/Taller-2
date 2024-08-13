using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
[SerializeField] private AudioClip checkpointSound; //sonidito pa cuando coja un nuevo checkpoint
private Transform currentCheckpoint; //pa que guarde el último checkpoint
private Health playerHealth;
private UIManager uiManager;

private void Awake()
{
    playerHealth = GetComponent<Health>();
    uiManager = FindObjectOfType<UIManager>();  
}

public void CheckRespawn()
{
    //ver si hay un checkpoint
    if(currentCheckpoint == null)
    {
        //pantallita game over
        uiManager.GameOver();

        return; //que no ejecuta el resto de la función
    }

    transform.position = currentCheckpoint.position; //le hace tp al jugador al último checkpoint que cogío
    playerHealth.Respawn(); //devolverle la vida y resetear la animación    
}

//activa el checkpoint actual
private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.transform.tag == "Checkpoint")
    {
        currentCheckpoint = collision.transform; //guarda el último checkpoint
        collision.GetComponent<Collider2D>().enabled = false; //desactiva el collider del checkpoint 
        collision.GetComponent<Animator>().SetTrigger("appear"); //activa la animación
    }
}
}
