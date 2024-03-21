using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    // Start is called before the first frame update

    public int costoMejora = 100000;
    public string messageToShow;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI Ganaste;

    public GameObject Background;

    [SerializeField]
    private AudioClip sonidoEntrar;
    [SerializeField]
    private AudioClip sonidoRechazo;

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

        PlayerController player = FindObjectOfType<PlayerController>(); // Otra opción es almacenar una referencia al jugador en lugar de buscarlo cada vez.
        if (player != null && player.coins >= costoMejora)
        {
            player.coins -= costoMejora;
            player.MonedasActualizar();

            SceneManager.LoadScene("Victoria");

        }
        else
        {
            AudioController.Instance.EjecutarSonido(sonidoRechazo);
            messageText.text = "No tienes suficientes monedas para comprar la mejora de vida.";
        }
    }


}
