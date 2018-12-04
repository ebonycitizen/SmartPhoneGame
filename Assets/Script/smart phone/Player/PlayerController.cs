using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float length;

    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Pauser.IsPause())
            return;

        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.timeSinceLevelLoad * speed) * length, transform.position.z);
	}
}
