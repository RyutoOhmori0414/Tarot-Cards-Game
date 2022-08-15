using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleController : MonoBehaviour
{
    /// <summary>何秒で特定の位置まで動くのか</summary>
    [Header("移動の秒数")]
    [SerializeField] float _moveTime = default;
    /// <summary>二次移動の時に使うanchor</summary>
    [Header("次の移動のアンカー")]
    [SerializeField] RectTransform _anchor = default;
    /// <summary>x座標のランダムの絶対値</summary>
    [Header("x座標のランダムの絶対値")]
    [SerializeField] float _xRandom = default;
    /// <summary>y座標のランダムの絶対値</summary>
    [Header("y座標のランダムの絶対値")]
    [SerializeField] float _yRanom = default;
    /// <summary>角度ランダムの最高値</summary>
    [Header("角度ランダムの絶対値")]
    [SerializeField] float _rotationRanom = default;
    /// <summary>tureの間、移動が行われる</summary>
    bool _isShuffled1 = false;
    /// <summary>二次移動が行われる</summary>
    bool _isShuffled2 = false;
    /// <summary>三次移動が行われる</summary>
    bool _isShuffled3 = false;
    /// <summary>最終的な位置</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>最終的な角度</summary>
    Vector3 _targetR = Vector3.zero;
    /// <summary>タイマー</summary>
    float _timer = default;
    /// <summary>このオブジェクトのRectTracsform</summary>
    RectTransform _rectTransform;
    /// <summary>移動前の位置</summary>
    Vector3 _before;
    private void OnEnable()
    {
        GameManager.Shuffle += MoveCard1;
        GameManager.Shuffle2 += MoveCard2;
    }
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _before = _rectTransform.position;
        this.transform.localScale = Vector3.one;
        _targetP = new Vector3(UnityEngine.Random.Range(-_xRandom * 1.0f, _xRandom * 1.0f), UnityEngine.Random.Range(-_yRanom * 1.0f, _yRanom * 1.0f), 0f);
        _targetR = new Vector3(0, 0, UnityEngine.Random.Range(0.0f, UnityEngine.Random.Range(0.0f, _rotationRanom) * 1.0f));
    }
    // Update is called once per frame
    void Update()
    {
        //下の処理は
        if (_isShuffled1)
        {
            _timer += Time.deltaTime;
            
            if (_timer <= _moveTime)
            {
                float rate = Mathf.Clamp01(_timer / _moveTime);
                _rectTransform.position = Vector3.Lerp(_before, _targetP, rate);
            }
            else
            {
                _rectTransform.position = _targetP;
                _before = _rectTransform.position;
                _isShuffled1 = false;
                _timer = 0;
                _isShuffled2 = true;
            }
        }
        else if (_isShuffled2)
        {
            _timer += Time.deltaTime;

            if (_timer <= _moveTime)
            {
                float rate = Mathf.Clamp01(_timer / _moveTime);
                _rectTransform.position = Vector3.Lerp(_before, _anchor.position, rate);
            }
            else
            {
                _rectTransform.position = _anchor.position;
                _before = _rectTransform.position;
                _isShuffled2 = false;
                _timer = 0;
                _isShuffled3 = true;
            }
        }
        else if (_isShuffled3)
        {
            _timer += Time.deltaTime;

            if (_timer <= _moveTime)
            {
                float rate = Mathf.Clamp01(_timer / _moveTime);
                _rectTransform.position = Vector3.Lerp(_before, Vector3.zero, rate);
            }
            else
            {
                _rectTransform.position = Vector3.zero;
                _before = _rectTransform.position;
                _isShuffled3 = false;
                _timer = 0;
            }
        }

    }

    void MoveCard1()
    {
        _isShuffled1 = true;
    }

    void MoveCard2()
    {
        _isShuffled2 = true;
    }
}
