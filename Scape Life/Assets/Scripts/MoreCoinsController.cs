using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoreCoinsController : MonoBehaviour
{

    public int costoMejora = 20;
    public string messageToShow;
    public TextMeshProUGUI messageText;
    public CurarseController curar;

    private bool isInsideZone = false;
    private int nivelMejora = 0;

    // Start is called before the first frame update
    void Start()
    {
        messageToShow = "Presiona [Espacio] para aumentar la recolección de monedas por " + costoMejora.ToString() + " monedas";
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
            isInsideZone = true;
            messageText.text = messageToShow;
            messageText.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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

                player.potenciaMonedas = 3;
                costoMejora = 150;

            }
            if (nivelMejora == 2)
            {

                player.potenciaMonedas = 10;
                costoMejora = 500;


            }
            if (nivelMejora == 3)
            {

                player.potenciaMonedas = 30;
                costoMejora = 2000;


            }
            if (nivelMejora == 4)
            {

                player.potenciaMonedas = 100;
                costoMejora = 8000;


            }
            if (nivelMejora == 5)
            {

                player.potenciaMonedas = 500;
                costoMejora = -1;

            }

            curar.ActualizarCosto();
            ActualizarMensaje();
        }
        else
        {
            messageText.text = "No tienes suficientes monedas para comprar la mejora de recolección.";
        }
    }

    public void ActualizarMensaje()
    {

        if (costoMejora != -1)
        {
            messageToShow = "Presiona [Espacio] para aumentar la recolección de monedas por " + costoMejora.ToString() + " monedas";

        }
        else
        {

            messageToShow = "Haz llegado al máximo de mejora";

        }

        messageText.text = messageToShow;

    }


}
