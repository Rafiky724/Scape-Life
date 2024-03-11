using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRb;

    public float delay = 0.3f;
    private bool attackBlocked;

    public Transform circleOrigin;
    public float circleRadius;

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
            Attack();
            
        }
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;

        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
        
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        playerAnimator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, circleRadius);

    }

    public void DetectColliders()
    {

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, circleRadius))
        {
            EnemyHearth health;
            if (health = collider.GetComponent<EnemyHearth>())
            {
                health.GetHit(1, transform.parent.gameObject);
            }
        }
    }

}
