using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] float jumpForce;
    public int score;

    public static BirdManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIManager.instance.uiActive)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Contains("Border") || collision.transform.tag.Contains("pipe"))
        {
            UIManager.instance.GameOver();
        }

        if (collision.transform.tag.Contains("Way"))
        {
            score++;
            UIManager.instance.score.text = "Score: " + score.ToString();
        }
    }

    

    IEnumerator StopPhysics()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0.0f;
    }
}
