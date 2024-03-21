using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConversacionController : MonoBehaviour
{
    public GameObject[] pantallasDialogo; // Array que contiene las pantallas de di�logo
    public float tiempoEntreDialogos = 2f; // Tiempo entre cada di�logo

    private int indicePantallaActual = 0;
    private int indiceDialogoActual = 0;

    [SerializeField]
    private AudioClip sonidoTexto;

    void Start()
    {
        // Desactivar todas las pantallas de di�logos excepto la primera
        for (int i = 1; i < pantallasDialogo.Length; i++)
        {
            pantallasDialogo[i].SetActive(false);
        }

        // Iniciar la secuencia de di�logos
        MostrarSiguienteDialogo();
    }

    public void MostrarSiguienteDialogo()
    {
        // Activar el siguiente di�logo en la pantalla actual
        AudioController.Instance.Loop(sonidoTexto, 1f);
        pantallasDialogo[indicePantallaActual].transform.GetChild(indiceDialogoActual).gameObject.SetActive(true);

        if (indiceDialogoActual < 3)
        {

            Invoke("MostrarSiguienteDialogo", tiempoEntreDialogos);
            indiceDialogoActual++;

        }

        // Desactivar el di�logo actual despu�s de unos segundos

    }

    public void SiguientePantalla()
    {

        pantallasDialogo[indicePantallaActual].SetActive(false);

        indicePantallaActual = indicePantallaActual + 1;
        indiceDialogoActual = 0;

        pantallasDialogo[indicePantallaActual].SetActive(true);

        Invoke("MostrarSiguienteDialogo", 0);

    }

    public void IniciarJuego()
    {

        SceneManager.LoadScene("Tutorial");

    }

    public void Creditos()
    {

        SceneManager.LoadScene("Creditos");

    }

}
