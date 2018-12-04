using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームの時間を制御するクラス

public class Pauser : MonoBehaviour {
    TouchManager touchManager;
    public TouchManager GetTouchManager { get { return touchManager; } }

    // Use this for initialization
    void Awake () {
        touchManager = new TouchManager();
    }
	
	// Update is called once per frame
	void Update () {
        touchManager.Update();

        if (touchManager.HasTouch)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    //時間止まってるかどうか
    public static bool IsPause()
    {
        if (Time.timeScale == 1)
            return false;

        return true;
    }
}
