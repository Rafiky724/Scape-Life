using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    // Start is called before the first frame update

    public int costoMejora = 20000;
    public string messageToShow;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI Ganaste;

    private bool isInsideZone = false;

    void Start()
    {
        messageToShow = "Presiona [Espacio] para esconderte y ganar por " + costoMejora.ToString() + " monedas";
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

        PlayerController player = FindObjectOfType<PlayerController>(); // Otra opci�n es almacenar una referencia al jugador en lugar de buscarlo cada vez.
        if (player != null && player.coins >= costoMejora)
        {
            player.coins -= costoMejora;
            player.MonedasActualizar();

            Ganaste.text = "�GANASTE!";

        }
        else
        {
            messageText.text = "No tienes suficientes monedas para comprar la mejora de vida.";
        }
    }


}