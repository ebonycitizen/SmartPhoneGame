using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float shotInterval;
    [SerializeField]
    private float shotSpeed;
    [SerializeField]
    private float disappearTime;
    [SerializeField]
    private EnemyController enemyController;

    [SerializeField]
    private Sprite normalSprite;
    [SerializeField]
    private Sprite attackSprite;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShotBullet());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void StopShoting()
    {
        StopAllCoroutines();
    }

    IEnumerator ShotBullet()
    {
        while (gameObject.activeSelf)
        {
            spriteRenderer.sprite = normalSprite;
            yield return new WaitForSeconds(shotInterval / 2);

            spriteRenderer.sprite = attackSprite;
            yield return new WaitForSeconds(shotInterval / 4);

            GameObject shot = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = shot.GetComponent<Bullet>();
            bullet.Init(enemyController.FrontDirection, shotSpeed);
            yield return new WaitForSeconds(shotInterval / 4);
        }
    }
}
