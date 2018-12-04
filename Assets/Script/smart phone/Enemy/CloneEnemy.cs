using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneEnemy : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;

    private float cloneOffset; //敵の複製の位置オフセット

    // Use this for initialization
    void Start () {
        cloneOffset = (Camera.main.transform.position.y + Camera.main.orthographicSize) * 2;
        CloneSelf();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //自分を複製する
    private void CloneSelf()
    {
        //ゲームオブジェクトを作る
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y - cloneOffset, transform.position.z);
        GameObject cloneOne = Instantiate(enemyPrefab, targetPos, transform.rotation, transform);

        targetPos = new Vector3(transform.position.x, transform.position.y + cloneOffset, transform.position.z);
        GameObject cloneTwo = Instantiate(enemyPrefab, targetPos, transform.rotation, transform);
    }
}
