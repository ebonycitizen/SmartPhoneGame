using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StraightEnemy : EnemyBase
{
    [SerializeField]
    private Transform moveTransform;

    [SerializeField]
    private float startTargetX; //最初のターゲット位置

    [SerializeField]
    private float targetX;//２回目のターゲット位置

    [SerializeField]
    private float startDuration;//最初の再生時間の長さ

    [SerializeField]
    private float duration;//２回目の再生時間の長さ

    [SerializeField]
    private float delayInterval; //待機時間

    private Sequence sequence;

    private void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveX(startTargetX, startDuration));
        sequence.AppendInterval(delayInterval);
        sequence.Append
            (
                transform.DOMoveX(targetX, duration)
                .OnComplete(() => OnComplete())
            );

        sequence.Play();
    }

    private void OnComplete()
    {
        sequence.Kill();
        Destroy(gameObject);
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
