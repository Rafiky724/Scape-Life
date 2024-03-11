using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;

    private Animator enemyAnimator;

    

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        enemyAnimator.SetFloat("Horizontal", direction.x);
        enemyAnimator.SetFloat("Vertical", direction.y);
        enemyAnimator.SetFloat("Speed", direction.magnitude);

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        
    }

   


}
