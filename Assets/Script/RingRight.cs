using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RingRight : MonoBehaviour
{
    [SerializeField] GameObject spawnTransform;
    [SerializeField] GameObject rings;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            Instantiate(rings, spawnTransform.transform.position,Quaternion.identity);
        }
    }
}
