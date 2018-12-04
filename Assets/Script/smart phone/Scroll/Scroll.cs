using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private TouchManager.Side side;

    private Pauser pauser;
    private TouchManager touchManager;
    private int index;

    public TouchManager GetTouchManager()
    {
        return touchManager;
    }
    public int GetIndex()
    {
        return index;
    }
    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }

    // Use this for initialization
    public void Start () {
        pauser = GameObject.Find("Pauser").GetComponent<Pauser>();
        touchManager = pauser.GetTouchManager;
    }
	
	// Update is called once per frame
	public void Update () {
		if (touchManager == null)
            return;

        ScrollUpDown();
    }

    private void ScrollUpDown()
    {
        if (touchManager.HasTouch)
        {
            for (int i = 0; i < touchManager.TouchCount; i++)
            {
                if (touchManager.side[i] == side)
                {
                    index = i;
                    break;
                }
                if (i == touchManager.TouchCount - 1)
                    return;
            }
            transform.position += new Vector3(0, touchManager.Direction[index].y * scrollSpeed * Time.fixedDeltaTime, 0);
        }
    }
}
