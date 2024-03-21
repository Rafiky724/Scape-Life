using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoreLifeController : MonoBehaviour
{

    public int costoMejora = 10;
    public string messageToShow;
    public TextMeshProUGUI messageText;

    public GameObject Background;

    private bool isInsideZone = false;
    private int nivelMejora = 0;

    public HealthManager playerLife;

    // Start is called before the first frame update
    void Start()
    {
        messageToShow = "Presiona [Espacio] para aumentar tu vida por " + costoMejora.ToString() + " monedas";
    }

    // Update is called once per frame
    void Update()
    {

        if (isInsideZone && Input.GetKeyDown(KeyCode.Space))
        {

            if (costoMejora != -1)
            {

                AttemptPurchase();

            }
            else
            {

                messageText.text = "Haz llegado al máximo de mejora";
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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

        PlayerController player = FindObjectOfType<PlayerController>(); // Otra opción es almacenar una referencia al jugador en lugar de buscarlo cada vez.
        if (player != null && player.coins >= costoMejora)
        {
            player.coins -= costoMejora;
            player.MonedasActualizar();
            nivelMejora++;

            if (nivelMejora == 1)
            {

                playerLife.maxHealth = 60;
                costoMejora = 100;

            }
            if (nivelMejora == 2)
            {

                playerLife.maxHealth = 70;
                costoMejora = 500;


            }
            if (nivelMejora == 3)
            {

                playerLife.maxHealth = 80;
                costoMejora = 1500;


            }
            if (nivelMejora == 4)
            {

                playerLife.maxHealth = 90;
                costoMejora = 5000;


            }
            if (nivelMejora == 5)
            {

                playerLife.maxHealth = 100;
                costoMejora = -1;

            }
            //PRUEBA
            playerLife.actualizarVida();

            ActualizarMensaje();
        }
        else
        {
            messageText.text = "No tienes suficientes monedas para comprar la mejora de vida.";
        }
    }

    public void ActualizarMensaje()
    {

        if (costoMejora != -1)
        {
            messageToShow = "Presiona [Espacio] para aumentar tu vida por " + costoMejora.ToString() + " monedas";

        }
        else
        {

            messageToShow = "Haz llegado al máximo de mejora";

        }

        messageText.text = messageToShow;

    }

}
