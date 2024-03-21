using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGeneral : MonoBehaviour
{

  
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();

    }

    public void Pausar()
    {
        music.Stop();
    }
}
