using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConversacionController : MonoBehaviour
{
    public GameObject[] pantallasDialogo; // Array que contiene las pantallas de diálogo
    public float tiempoEntreDialogos = 2f; // Tiempo entre cada diálogo

    private int indicePantallaActual = 0;
    private int indiceDialogoActual = 0;

    void Start()
    {
        // Desactivar todas las pantallas de diálogos excepto la primera
        for (int i = 1; i < pantallasDialogo.Length; i++)
        {
            pantallasDialogo[i].SetActive(false);
        }

        // Iniciar la secuencia de diálogos
        MostrarSiguienteDialogo();
    }

    public void MostrarSiguienteDialogo()
    {
        // Activar el siguiente diálogo en la pantalla actual
        pantallasDialogo[indicePantallaActual].transform.GetChild(indiceDialogoActual).gameObject.SetActive(true);

        if (indiceDialogoActual < 3)
        {

            Invoke("MostrarSiguienteDialogo", tiempoEntreDialogos);
            indiceDialogoActual++;

        }

        // Desactivar el diálogo actual después de unos segundos

    }

    /*

    void DesactivarDialogoActual()
    {
        // Desactivar el diálogo actual
        //pantallasDialogo[indicePantallaActual].transform.GetChild(indiceDialogoActual).gameObject.SetActive(false);

        // Pasar al siguiente diálogo
        indiceDialogoActual++;

        // Verificar si se ha mostrado todos los diálogos en la pantalla actual
        if (indiceDialogoActual >= pantallasDialogo[indicePantallaActual].transform.childCount)
        {
            Debug.Log("A");

            // Pasar a la siguiente pantalla de diálogos si existe
            if (indicePantallaActual < pantallasDialogo.Length - 1)
            {

                Debug.Log("B");

                // Desactivar la pantalla de diálogos actual
                //pantallasDialogo[indicePantallaActual].SetActive(false);

                // Incrementar el índice de la pantalla actual
                indicePantallaActual++;

                // Activar la siguiente pantalla de diálogos
                //pantallasDialogo[indicePantallaActual].SetActive(true);

                // Reiniciar el índice del diálogo actual
                indiceDialogoActual = 0;
            }
            else
            {
                Debug.Log("Fin de la conversación"); // Aquí puedes agregar cualquier acción adicional al final de la conversación
            }
        }
        else
        {
            Debug.Log("C");

            // Mostrar el siguiente diálogo
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
