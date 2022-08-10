using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    static public event Action Shuffle;
    static public event Action Shuffle2;
    /// <summary>タロットカードのPrefab</summary>
    [SerializeField] Image _cardPrefab;
    /// <summary>タロットカードのSprite</summary>
    [SerializeField] List<Sprite> _cardSprite;
    //キャンバス
    [SerializeField] RectTransform _canvasTransform;
    // カードの親
    [SerializeField] Transform _cardParent;

    public void ShuffleP1()
    {
        foreach(var CardSprite in _cardSprite)
        {
            var card = Instantiate(_cardPrefab);
            //card.rectTransform.SetParent(_canvasTransform);
            card.transform.SetParent(_cardParent);
            card.transform.localScale = Vector3.one;
            card.transform.position = new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(-4, 4), 0);
            card.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)));

            card.GetComponent<Image>().sprite = CardSprite;

        }
    }

    public void ShuffleP2()
    {
        Shuffle.Invoke();
    }

    public void ShuffleP3()
    {
        Shuffle2.Invoke();
    }
}
