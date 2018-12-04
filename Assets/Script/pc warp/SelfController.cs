using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfController : MonoBehaviour {
    [SerializeField]
    private GameObject selfPrefab;

    [SerializeField]
    private float waitInterval;

    private SelfRecord selfRecord;
    private GameObject self;


    // Use this for initialization
    void Start () {
        selfRecord = new SelfRecord();
        self = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create()
    {
        self = Instantiate(selfPrefab, transform.position, Quaternion.identity);
        self.GetComponent<SelfMovement>().Init(waitInterval, selfRecord);
        selfRecord.currentPos = transform.position;
    }
    public void Record()
    {
        selfRecord.Record(transform.position, transform.rotation);
    }

    public void ClearRecord()
    {
        ExchangePos();
        selfRecord.ClearAll();

        if (GameObject.FindWithTag("Self") == null)
            return;
        Destroy(GameObject.FindWithTag("Self"));
    }

    private void ExchangePos()
    {
        transform.position = selfRecord.currentPos;
    }
}
