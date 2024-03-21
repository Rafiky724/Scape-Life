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
        pantallasDialogo[indicePantallaActual].transform.GetChild(indiceDialogoActual).gameObject.SetActive(true);

        if (indiceDialogoActual < 3)
        {

            Invoke("MostrarSiguienteDialogo", tiempoEntreDialogos);
            indiceDialogoActual++;

        }

        // Desactivar el di�logo actual despu�s de unos segundos

    }

    /*

    void DesactivarDialogoActual()
    {
        // Desactivar el di�logo actual
        //pantallasDialogo[indicePantallaActual].transform.GetChild(indiceDialogoActual).gameObject.SetActive(false);

        // Pasar al siguiente di�logo
        indiceDialogoActual++;

        // Verificar si se ha mostrado todos los di�logos en la pantalla actual
        if (indiceDialogoActual >= pantallasDialogo[indicePantallaActual].transform.childCount)
        {
            Debug.Log("A");

            // Pasar a la siguiente pantalla de di�logos si existe
            if (indicePantallaActual < pantallasDialogo.Length - 1)
            {

                Debug.Log("B");

                // Desactivar la pantalla de di�logos actual
                //pantallasDialogo[indicePantallaActual].SetActive(false);

                // Incrementar el �ndice de la pantalla actual
                indicePantallaActual++;

                // Activar la siguiente pantalla de di�logos
                //pantallasDialogo[indicePantallaActual].SetActive(true);

                // Reiniciar el �ndice del di�logo actual
                indiceDialogoActual = 0;
            }
            else
            {
                Debug.Log("Fin de la conversaci�n"); // Aqu� puedes agregar cualquier acci�n adicional al final de la conversaci�n
            }
        }
        else
        {
            Debug.Log("C");

            // Mostrar el siguiente di�logo
            MostrarSiguienteDialogo();
        }
    }*/

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
 
    /*
    public void SiguientePantalla2()
    {

        pantallasDialogo[indicePantallaActual].SetActive(false);

        indicePantallaActual = indicePantallaActual + 1;
        indiceDialogoActual = 0;

        pantallasDialogo[2].SetActive(true);
        pantallasDialogo[2].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarDialogoActual", tiempoEntreDialogos);

    }*/

}
