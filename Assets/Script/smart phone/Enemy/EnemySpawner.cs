using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : EnemyBase {

    [SerializeField]
    private Transform spawnTransform;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnAngleZ; //スポーン角度z

    [SerializeField]
    private float spawnTimeRangeMax;//スポーンdelay最大

    [SerializeField]
    private float spawnTimeRangeMin;//スポーンdelay最小

    [SerializeField]
    private float spawnPosYRangeMax;//スポーン位置y最大

    [SerializeField]
    private float spawnPosYRangeMin;//スポーン位置y最小

    [SerializeField]
    private float spawnPosX; //スポーン位置x

    private Sequence sequence;

    // Use this for initialization
    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append
            (
                DOVirtual.DelayedCall(Random.Range(spawnTimeRangeMin, spawnTimeRangeMax), () =>
                {
                    EnemySpawn();
                    OnComplete();
                })
            );

        sequence.Play();
    }

    private void EnemySpawn()
    {
        Vector3 position = new Vector3(spawnPosX, Random.Range(spawnPosYRangeMin, spawnPosYRangeMax));
        Instantiate(enemyPrefab, position, Quaternion.Euler(0,0, spawnAngleZ), transform);
    }

    private void OnComplete()
    {
        sequence.Restart();
    }

    public override void OnPlay()
    {
        sequence.Play();
    }

    public override void OnPause()
    {
        sequence.Pause();
    }

    public override void OnKill()
    {
        sequence.Kill();
    }

    public override void OnRestart()
    {
        sequence.Restart();
    }
}
