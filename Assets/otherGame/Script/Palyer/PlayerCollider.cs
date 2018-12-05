using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    [SerializeField]
    private GameObject particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particle,gameObject.transform);
    }
}
