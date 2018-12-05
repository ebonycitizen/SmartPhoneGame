using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OtherPlayerController : MonoBehaviour {

    [SerializeField]
    private Transform moveTransform;

    [SerializeField]
    private Vector3[] vec;

    [SerializeField]
    private float loopSpeed;


    private Sequence sequence;

    // Use this for initialization
    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(
        transform.DOLocalPath(vec, loopSpeed, PathType.Linear)
            .SetOptions(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .OnComplete(() => OnComplete())
            );

        sequence.Play();
    }

    private void OnComplete()
    {
        sequence.Restart();
    }

    public void Play()
    {
        sequence.Play();
    }

    public void Pause()
    {
        sequence.Pause();
    }

    public void Kill()
    {
        sequence.Kill();
    }

    public void Restart()
    {
        sequence.Restart();
    }
}
