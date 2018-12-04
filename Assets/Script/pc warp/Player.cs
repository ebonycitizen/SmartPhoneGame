using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private Transform front;

    [SerializeField]
    private float moveDistance;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private CapsuleCollider2D capsuleCollider;

    [SerializeField]
    CircleCollider2D circleCollider;

    [SerializeField]
    private Self self;

    private const float angleOffset = 90;

    private Vector3 frontDirection;
    private Vector3 targetPosition;
    private bool canInput;

    private Vector3 exchangePos;

    // Use this for initialization
    void Start () {

        canInput = true;
        capsuleCollider.enabled = false;
        targetPosition = transform.position;
        CalcFrontDirection();
    }
	
	// Update is called once per frame
	void Update () {
        InputHandle();
        CalcFrontDirection();
    }

    void CalcFrontDirection()
    {
        frontDirection = (front.position - transform.position).normalized;
        Rotation(frontDirection);
    }
    void CalcTargetPosition()
    {
        Vector2 direction = frontDirection.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x);
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        transform.position += new Vector3(x, y, 0) * moveDistance;
    }
    void InputHandle()
    {
        if (!canInput)
            return;

        //capsuleCollider.enabled = false;
        circleCollider.enabled = true;

        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        //#region 仮
        //if (Input.GetKeyDown(KeyCode.JoystickButton5))
        //{
        //    Instantiate(selfPrefab, transform.position, Quaternion.identity);
        //    exchangePos = transform.position;
        //}

        //if (Input.GetKeyUp(KeyCode.JoystickButton5))
        //{
        //    transform.position = exchangePos;
        //    Destroy(GameObject.FindWithTag("Self"));
        //}
        //#endregion

        if (Input.GetKeyDown(KeyCode.JoystickButton4))
            self.Create();

        if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            self.ExchangePos();
            capsuleCollider.enabled = true;
        }

        if (input.magnitude <= 0.1f)
            return;

        Rotation(input);

        //if (Input.GetKey(KeyCode.JoystickButton4))
        //    selfController.Record();

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
            Wrap();

        transform.position += new Vector3(input.x * moveSpeed * Time.fixedDeltaTime, input.y * moveSpeed * Time.fixedDeltaTime,0);
    }

    void Rotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetAngle = Quaternion.Euler(new Vector3(0, 0, angle - angleOffset));
        transform.rotation = targetAngle;
    }
    void Wrap()
    {
        circleCollider.enabled = false;
        //capsuleCollider.enabled = true;
        CalcTargetPosition();
    }

    IEnumerator Dead()
    {
        canInput = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem.Play();

        yield return new WaitForSeconds(particleSystem.main.duration);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Dead());
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            //FIXME:斜めの当たり判定

            targetPosition = collision.contacts[0].normal * -collision.contacts[0].separation;
            transform.position += targetPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (circleCollider.enabled && collision.tag == "Enemy")
        //    StartCoroutine(Dead());
    }
}
