using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class DotweenController : MonoBehaviour
{


    AnimationCurve holi;
   

    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;
   

    [Range(1.0f, 10.0f), SerializeField]
    private float _moveDuration = 1.0f;

    [SerializeField]
    private Ease _moveEease = Ease.InOutElastic;

 

    // Start is called before the first frame update
    void Start()
    {
       

        transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEease).SetLoops(-1, LoopType.Yoyo);
 
    }

   

}
