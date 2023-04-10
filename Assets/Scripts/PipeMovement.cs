using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    float moveSpeed = 10;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * moveSpeed;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 60)
        {
            moveSpeed++;
            time = 0;
        }
    }
}
