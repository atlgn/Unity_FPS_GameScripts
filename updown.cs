using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class updown : MonoBehaviour
{
    public void Updown(){
 transform.DOLocalMoveY(-6f, 5f).SetEase(Ease.OutQuad).SetRelative(true).OnComplete( () => transform.DOLocalMoveY(8f, 5f).SetEase(Ease.OutQuad).SetRelative(true) );
    }

}
