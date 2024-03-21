using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive = 2;

    [SerializeField]
    private AudioClip sonidoDañoEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            AudioController.Instance.EjecutarSonido(sonidoDañoEnemigo);
            EnemyController enemy;
            enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.HurtEnemy(damageToGive);

        }

    }

}
