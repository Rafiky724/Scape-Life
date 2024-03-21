using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTimer : MonoBehaviour
{
    private HealthManager healthMan;
    private float tiempoTranscurrido = 0f;
    public TextMeshProUGUI textoTiempo;
    public float tiempoLimite = 1f;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindAnyObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        tiempoTranscurrido += Time.deltaTime;

        // Mostrar el tiempo en formato legible
        MostrarTiempo();

        //Debug.Log(tiempoLimite);

        if (tiempoTranscurrido >= tiempoLimite)
        {
            Debug.Log("Muerto");
            healthMan.HurtPlayer(healthMan.currentHealth);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    void MostrarTiempo()
    {
        // Calcular los minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

        // Actualizar el texto para mostrar el tiempo
        textoTiempo.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);
    }

}
