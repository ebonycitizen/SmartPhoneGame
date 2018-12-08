using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SilentEnemy : EnemyBase
{

    [SerializeField]
    private Transform moveTransform;

    [SerializeField]
    private float[] vec;

    [SerializeField]
    private float loopSpeed;


    private Sequence sequence;

    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        sequence.Append(transform.DOMoveX(vec[0], 1));
        sequence.Append(transform.DORotate(new Vector3(0,0,0),1));
        sequence.Append
            (
                transform.DOMoveX(vec[1], 1)
                .OnComplete(() => OnComplete())
            );

        sequence.Play();
    }

    private void OnComplete()
    {
        OnRestart();
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
