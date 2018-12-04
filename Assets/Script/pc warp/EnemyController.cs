using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform front;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform line;

    private const float angleOffset = 90;

    private Vector3 frontDirection;
    public Vector3 FrontDirection { get { return frontDirection; } }

    private void Awake()
    {
        CalcFrontDirection();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.activeSelf || target == null)
            return;

        CalcFrontDirection();
        Rotate();
        AimLineRenderer();
    }

    void Rotate()
    {
        Vector3 positionDiff = target.position - transform.position;
        float angle = Mathf.Atan2(positionDiff.y, positionDiff.x) * Mathf.Rad2Deg;
        Quaternion targetAngle = Quaternion.Euler(new Vector3(0, 0, angle - angleOffset));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, rotateSpeed * Time.fixedDeltaTime);
    }

    void CalcFrontDirection()
    {
        frontDirection = (front.position - transform.position).normalized;
    }

    IEnumerator Dead()
    {
        gameObject.SendMessage("StopShoting");
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

    private void AimLineRenderer()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, line.position);
    }
}
