using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalotController : MonoBehaviour
{
    /// <summary>カードのスプライトが入っているリスト</summary>
    [Header("カードのスプライト")]
    [SerializeField] List<Sprite> _cardSprites = new List<Sprite>();
    /// <summary>スプライトを変更するオブジェクト</summary>
    [Tooltip("スプライトを変更するカード")]
    [SerializeField] GameObject _cardObject;
    /// <summary>種類と位置を出力するテキスト</summary>
    [Tooltip("種類と位置を出力するテキスト")]
    [SerializeField] Text _cardStatusText;
    /// <summary>コメントを出力するテキスト</summary>
    [Tooltip("コメントを出力するテキスト")]
    [SerializeField] Text _commentText;
    /// <summary>正位置の時のコメントのリスト</summary>
    [Header("正位置の時のコメント")]
    [SerializeField] List<string> _turePosition = new List<string>();
    /// <summary>逆位置の時のコメントのリスト</summary>
    [Header("逆位置の時のコメント")]
    [SerializeField] List<string> _falsePosition = new List<string>();
    
    public void ChangeSprite()
    {
        Image CardImage = _cardObject.GetComponent<Image>();
        CardImage.sprite = _cardSprites[Random.Range(0, _cardSprites.Count - 1)];
        int Check = Random.Range(0, 2);
        _cardObject.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, Check * 180, 0);

        if (Check == 0)
        {
            _cardStatusText.text = $"{CardImage.sprite.name.Remove(0, 3)}・正位置";
            _commentText.text = _turePosition[int.Parse(CardImage.sprite.name.Remove(2, CardImage.sprite.name.Length - 2))];
        }
        else if (Check == 1)
        {
            _cardStatusText.text = $"{CardImage.sprite.name.Remove(0, 3)}・逆位置";
            _commentText.text = _falsePosition[int.Parse(CardImage.sprite.name.Remove(2, CardImage.sprite.name.Length - 2))];
        }
    }
}