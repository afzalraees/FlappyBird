using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] float jumpForce;
    private void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Contains("Border") || collision.transform.tag.Contains("pipe"))
        {
            GameManager.instance.uiManager.GameOver();
        }

        if (collision.transform.tag.Contains("Way"))
        {
            GameManager.instance.score++;
            GameManager.instance.uiManager.score.text = GameManager.instance.score.ToString();
        }

        if (collision.transform.tag.Contains("Coin"))
        {
            GameManager.instance.storeManager.coins++;
            collision.gameObject.SetActive(false);
        }
    }
}
