using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreDamageController : MonoBehaviour
{

    public int costoMejora = 10;
    public string messageToShow;
    public TextMeshProUGUI messageText;

    private bool isInsideZone = false;
    private int nivelMejora = 0;

    public HurtEnemy hurt1;
    public HurtEnemy hurt2;     
    public HurtEnemy hurt3;
    public HurtEnemy hurt4;

    // Start is called before the first frame update
    void Start()
    {
        messageToShow = "Presiona [Espacio] para comprar la mejora de arma por " + costoMejora.ToString() + " monedas";
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

    public void ActualizarMensaje()
    {

        if (costoMejora != -1)
        {
            messageToShow = "Presiona [Espacio] para comprar la mejora de arma por " + costoMejora.ToString() + " monedas";

        }
        else
        {

            messageToShow = "Haz llegado al máximo de mejora";

        }

        messageText.text = messageToShow;

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

                hurt1.damageToGive = 4;
                hurt2.damageToGive = 4;
                hurt3.damageToGive = 4;
                hurt4.damageToGive = 4;
                costoMejora = 100;

            }
            if (nivelMejora == 2)
            {

                hurt1.damageToGive = 7;
                hurt2.damageToGive = 7;
                hurt3.damageToGive = 7;
                hurt4.damageToGive = 7;
                costoMejora = 500;


            }
            if (nivelMejora == 3)
            {

                hurt1.damageToGive = 10;
                hurt2.damageToGive = 10;
                hurt3.damageToGive = 10;
                hurt4.damageToGive = 10;
                costoMejora = 1500;


            }
            if (nivelMejora == 4)
            {

                hurt1.damageToGive = 15;
                hurt2.damageToGive = 15;
                hurt3.damageToGive = 15;
                hurt4.damageToGive = 15;
                costoMejora = 5000;


            }
            if (nivelMejora == 5)
            {

                hurt1.damageToGive = 20;
                hurt2.damageToGive = 20;
                hurt3.damageToGive = 20;
                hurt4.damageToGive = 20;
                costoMejora = -1;

            }
            ActualizarMensaje();
        }
        else
        {
            messageText.text = "No tienes suficientes monedas para comprar la mejora del arma.";
        }
    }

}
