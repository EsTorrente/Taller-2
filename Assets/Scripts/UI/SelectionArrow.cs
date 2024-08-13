using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options; 
    [SerializeField]private AudioClip changeSound;
    [SerializeField]private AudioClip interactSound;
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
         rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //cambia la posicion de la cadenita

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        //pa interactuar con las opciones
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();



    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if(currentPosition < 0)
             currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;
        //le asigna la posición en y de la opción actual a la "flechita"
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        //acceder al componente de boton en cada cosito y llamar la funcion
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }

}
