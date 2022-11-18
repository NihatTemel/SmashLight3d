using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextSizeAnim : MonoBehaviour
{
    [SerializeField] Vector3 StartScaleSize;
    [SerializeField] float TargetSize;
    Vector3 TargetScaleSize;

    void Start()
    {
        TargetScaleSize = new Vector3(TargetSize, TargetSize, TargetSize);
        StartScaleSize = GetComponent<RectTransform>().localScale;

        transform.DOScale(TargetScaleSize, 0.9f).SetLoops(999, LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
