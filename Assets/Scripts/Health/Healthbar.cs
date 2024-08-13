using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = health.startingHealth / 10;
    }
    public void UpdateHealthBar()
    {
        currenthealthBar.fillAmount = health.currentHealth / 10;
    }
}