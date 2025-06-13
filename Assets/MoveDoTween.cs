using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveDoTween : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sprite;
    void Start()
    {
        DOTween.Init();
        Agrandar();
    }

    public void Agrandar()
    {
        sprite.transform.DOScale(1.2f, 0.2f).OnComplete(()=> Achicar(1f)).SetEase(Ease.Linear);
    }
    public void Achicar(float tamaño)
    {
        sprite.transform.DOScale(tamaño, 0.2f).OnComplete(Agrandar).SetEase(Ease.Linear);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
