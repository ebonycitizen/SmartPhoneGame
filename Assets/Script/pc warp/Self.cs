using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour {
    [SerializeField]
    private GameObject selfPrefab;
    [SerializeField]
    private CapsuleCollider2D capsuleCollider;

    [SerializeField]
    private float moveSpeed;

    private GameObject self;
    private float radius;
    private Transform target;
    private bool isMoving;

    // Use this for initialization
    void Start () {
        capsuleCollider.enabled = false;
        radius = capsuleCollider.size.y / 2;
        target = capsuleCollider.gameObject.transform;
        isMoving = false;
    }
	
	// Update is called once per frame
	void Update () {
		//if (GameObject.FindWithTag("Self") == null)
  //          StopAllCoroutines();
	}

    public void Create()
    {
        if (GameObject.FindWithTag("Self") != null)
            return;

        self = Instantiate(selfPrefab, transform.position, Quaternion.identity);
    }

    public void ExchangePos()
    {
        if (isMoving || GameObject.FindWithTag("Self") == null)
            return;

        isMoving = true;
        ChangeAttackArea();
        StartCoroutine(Move(transform.position));
        //self.transform.position = transform.position;
    }

    private void ChangeAttackArea()
    {
        Vector3 dir = transform.position - self.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

        float size = Vector2.Distance(transform.position,self.transform.position) - radius * 2;
        target.localScale = new Vector3(1, size, 1);

        target.position = (transform.position + self.transform.position) / 2;
    }

    IEnumerator Move(Vector3 targetPos)
    {
        float x = Mathf.Abs(self.transform.position.x - targetPos.x);
        float y = Mathf.Abs(self.transform.position.y - targetPos.y);
        float times;

        if (x > y)
            times = x;
        else
            times = y;

        for (float t=0;t <times;t += moveSpeed * Time.fixedDeltaTime)
        {
            //self.transform.position = Vector3.Lerp(self.transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
            self.transform.position = Vector3.MoveTowards(self.transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        Destroy(GameObject.FindWithTag("Self"));
        isMoving = false;
    }
}
