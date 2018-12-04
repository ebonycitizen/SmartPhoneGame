using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMovement : MonoBehaviour {
    private float waitInterval;
    private SelfRecord selfRecord;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(float time,SelfRecord self)
    {
        waitInterval = time;
        selfRecord = self;
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(waitInterval);

        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        while (true)
        {
            bool canMove = selfRecord.Reappear(ref pos, ref rot);
            if (!canMove)
                break;

            transform.position = pos;
            transform.rotation = rot;
            yield return null;
        }
    }
}
