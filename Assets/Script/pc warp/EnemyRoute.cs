using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRoute : MonoBehaviour {
    [SerializeField]
    private Vector3[] pointer;

    [SerializeField]
    private float interval;

	// Use this for initialization
	void Start () {
        transform.DOLocalPath(pointer, interval, PathType.CatmullRom)
            .SetOptions(true)
            .SetLoops(-1)
            .SetEase(Ease.Linear)
            .SetLookAt(0.01f,transform.right);
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator Dead()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem.Play();

        yield return new WaitForSeconds(particleSystem.main.duration);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(Dead());
    }
}
