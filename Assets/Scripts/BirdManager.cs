using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] float jumpForce;
    float score;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Contains("Border") || collision.transform.tag.Contains("pipe"))
        {
            GameOver();
        }

        if (collision.transform.tag.Contains("Way"))
        {
            score++;
            UIManager.instance.score.text = "Score: " + score.ToString();
        }
    }

    void GameOver()
    {
        UIManager.instance.finalScore.text = "Final Score: " + score.ToString();
        UIManager.instance.gameOverScreen.SetActive(true);
        StartCoroutine(StopPhysics());
    }

    IEnumerator StopPhysics()
    {
        yield return new WaitForSeconds(1.1f);
        Time.timeScale = 0.0f;
    }
}
