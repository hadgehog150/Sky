using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float jump_force;
    public float distance;

    private float period = 0.5f;
    private float nextActionTime = 0.0f;

    private bool movingRight = true;

    public Transform graundDetection;

    private bool isGrounded;

    public LayerMask whatIsGraund;

    public DropItem[] dropList;

    Rigidbody2D rigidbody2D;
    Collider2D collider2D;

    ScoreManager scoreManager;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * jump_force * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(graundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        isGrounded = Physics2D.IsTouchingLayers(collider2D, whatIsGraund);

        if (isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump_force);
        }
    }

    public void Attacked()
    {
        if (Time.time > nextActionTime)
        {
            CheckDrop();
            scoreManager.score++;
            Destroy(gameObject);
            jump_force = 0;
            nextActionTime += period;
        }
        
        
    }

    public void CheckDrop()
    {
        if (dropList.Length > 0)
        {
            int rnd = (int)Random.Range(0, 100);

            foreach (var item in dropList)
            {
                if (item.chance < rnd)
                {
                    item.CreateDropItem(gameObject.transform.position);
                    return;
                }
            }
        }
    }
}
