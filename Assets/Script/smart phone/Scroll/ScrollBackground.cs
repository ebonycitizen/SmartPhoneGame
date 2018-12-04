using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : Scroll{

    private float bgHeight;

    // Use this for initialization
    void Start () {
        base.Start();
        bgHeight = GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();

        ChangePosition();
    }

    //端に行ったら、背景の位置を変える
    private void ChangePosition()
    {
        if (base.GetTouchManager().Direction[base.GetIndex()].y == 0)
            return;

        if(base.GetTouchManager().Direction[base.GetIndex()].y > 0)
        {
            if (transform.position.y >= bgHeight)
                transform.position = new Vector3(transform.position.x, -bgHeight, transform.position.z);
        }
        else
        {
            if (transform.position.y <= -bgHeight)
                transform.position = new Vector3(transform.position.x, bgHeight, transform.position.z);
        }
    }
}
