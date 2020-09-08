using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class DotweenAxeRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetRotation = new Vector3(0, 0, 10);

    [Range(1.0f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEease = Ease.InOutElastic;



    // Start is called before the first frame update
    void Start()
    {


        transform.DOLocalRotate(_targetRotation, _moveDuration).SetEase(_moveEease).SetLoops(-1, LoopType.Yoyo);

    }
}
   