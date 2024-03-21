using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurarseController : MonoBehaviour
{

    public int costoMejora = 10;
    public string messageToShow;
    public TextMeshProUGUI messageText;

    public GameObject Background;

    private bool isInsideZone = false;
    public PlayerController player;
    public HealthManager playerLife;

    [SerializeField]
    private AudioClip sonidoEntrar;
    [SerializeField]
    private AudioClip sonidoComprar;
    [SerializeField]
    private AudioClip sonidoRechazo;

    // Start is called before the first frame update
    void Start()
    {

        messageToShow = "Presiona [Espacio] para curarte por " + costoMejora.ToString() + " monedas";

    }

    // Update is called once per frame
    void Update()
    {

        if (isInsideZone && Input.GetKeyDown(KeyCode.Space))
        {

            AttemptPurchase();

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioController.Instance.EjecutarSonido(sonidoEntrar);

            Background.SetActive(true);
            isInsideZone = true;
            messageText.text = messageToShow;
            messageText.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Background.SetActive(false);
            isInsideZone = false;
            messageText.gameObject.SetActive(false);

        }
    }


    private void AttemptPurchase()
    {

        if (player != null && player.coins >= costoMejora)
        {
            AudioController.Instance.EjecutarSonido(sonidoComprar);

            player.coins -= costoMejora;
            player.MonedasActualizar();

            playerLife.currentHealth = playerLife.maxHealth;
            playerLife.actualizarVida();

        }
        else
        {
            AudioController.Instance.EjecutarSonido(sonidoRechazo);
            messageText.text = "No tienes suficientes monedas para comprar la mejora de recolección.";
        }
    }

    public void ActualizarCosto()
    {

        costoMejora = 5 * player.potenciaMonedas;
        messageToShow = "Presiona [Espacio] para curarte por " + costoMejora.ToString() + " monedas";

    }

}
