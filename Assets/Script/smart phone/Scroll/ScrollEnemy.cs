using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEnemy : Scroll {
    private float exchangePosition;//この位置についたら敵の位置を切り替える
    private float moveOffset; //切り替えるのオフセット

    // Use this for initialization
    void Start () {
        base.Start();

        float cameraSize = Camera.main.transform.position.y + Camera.main.orthographicSize;
        exchangePosition = cameraSize * 3;
        moveOffset = cameraSize * 6;
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
        ChangePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (transform.parent.tag == "Enemy" || transform.childCount >= 1)
        //    return;

        //Vector3 targetPos = Vector3.zero;
        //if (collision.tag == "UpWall")
        //    targetPos = new Vector3(transform.position.x, transform.position.y - bgHeightOffset, transform.position.z);
        //else if (collision.tag == "DownWall")
        //    targetPos = new Vector3(transform.position.x, transform.position.y + bgHeightOffset, transform.position.z);

        //Instantiate(gameObject, targetPos, Quaternion.identity, transform);
    }

    //切り替える
    private void ChangePosition()
    {
        Vector3 targetPos = transform.position;

        if (transform.position.y >= exchangePosition)
            targetPos = new Vector3(targetPos.x, targetPos.y - moveOffset, targetPos.z);
        else if(transform.position.y <= -exchangePosition)
            targetPos = new Vector3(targetPos.x, targetPos.y + moveOffset, targetPos.z);

        transform.position = targetPos;
    }
}
