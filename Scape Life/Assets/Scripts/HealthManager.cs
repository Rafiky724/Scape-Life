using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public GameObject pantallaPerder;

    public string messageToShow;
    public TextMeshProUGUI messageText;

    [SerializeField]
    private AudioClip sonidoDaño;

    [SerializeField]
    private AudioClip sonidoMorir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HurtPlayer(int damageToGive)
    {

        AudioController.Instance.EjecutarSonido(sonidoDaño);

        currentHealth -= damageToGive;

        messageToShow = currentHealth.ToString() + "/" + maxHealth.ToString();
        messageText.text = messageToShow;

        if (currentHealth <= 0)
        {
            AudioController.Instance.EjecutarSonido(sonidoMorir);
            gameObject.SetActive(false);
            pantallaPerder.SetActive(true);

        }

    }

    public void actualizarVida()
    {

        messageToShow = currentHealth.ToString() + "/" + maxHealth.ToString();
        messageText.text = messageToShow;

    }

}
