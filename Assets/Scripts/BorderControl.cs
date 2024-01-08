using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("pipe"))
        {
            Transform pipe = collision.transform.parent.transform;
            pipe.position = new Vector3(75, Random.Range(-9, 10), pipe.position.z);
            pipe.GetComponent<PipeMovement>().RandomCoin();
        }
    }
}
