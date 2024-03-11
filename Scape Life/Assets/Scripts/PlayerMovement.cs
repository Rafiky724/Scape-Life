using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private float damage;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;

    private Animator playerAnimator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

   
        Vector3 mousePosition = Input.mousePosition;
      
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float mouseX = mousePosition.x - transform.position.x;
        float mouseY = mousePosition.y - transform.position.y;

        playerAnimator.SetFloat("Horizontal", mouseX);
        playerAnimator.SetFloat("Vertical", mouseY);

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimator.SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;

        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
        
    }

}
