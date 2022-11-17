using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed;
    int horizontal = 1;

    public int hp;
    public int maxHp;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite zeroHeart;

    public GameObject losePanel;

    private bool ficing_rignt = true;//смотрит в право

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    void Update()
    {
        rigidbody.velocity = new Vector3(speed * horizontal, 0);

        if (ficing_rignt == false && horizontal > 0) {
            Flip();
        }
        else if (ficing_rignt == true && horizontal < 0) {
            Flip();
        }

        if (hp > maxHp) {
            hp = maxHp;
        }

        for (int i = 0; i < hearts.Length; i++) {
            if (i < hp) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = zeroHeart;
            } 
            if (i < maxHp) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        if (hp<=0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Move(int input)
    {
        horizontal = input;
    }

    void Flip()
    {
        ficing_rignt = !ficing_rignt;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            Destroy(collision.gameObject);
            --hp;
        }

        if (collision.tag == "HP") {
            Destroy(collision.gameObject);
            ++hp;
        }
    }
}
