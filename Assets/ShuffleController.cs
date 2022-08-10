using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleController : MonoBehaviour
{
    /// <summary>何秒で特定の位置まで動くのか</summary>
    [Header("最初の移動の秒数")]
    [SerializeField] float _moveTime = default;
    /// <summary>二次移動の時に使うanchor</summary>
    [Header("次の移動のアンカー")]
    [SerializeField] Transform _anchor = default;
    /// <summary>tureの間、移動が行われる</summary>
    bool _isShuffled1 = false;
    /// <summary>二次移動が行われる</summary>
    bool _isShuffled2 = false;
    /// <summary>最終的な位置</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>最終的な角度</summary>
    Vector3 _targetR = Vector3.zero;
    /// <summary>二次移動の際のベクトル</summary>
    Vector3 _secondMove = Vector3.zero;
    //タイマー
    float _timer = default;
    private void OnEnable()
    {
        GameManager.Shuffle += MoveCard1;
        GameManager.Shuffle2 += MoveCard2;
    }
    void Start()
    {
        this.transform.localScale = Vector3.one;
        _targetP = new Vector3(UnityEngine.Random.Range(-6.0f, 6.0f), UnityEngine.Random.Range(-2.5f, 2.5f), 0);
        _targetR = new Vector3(0, 0, UnityEngine.Random.Range(0.0f, 90.0f));
    }
    // Update is called once per frame
    void Update()
    {
        //下の処理は
        if (_isShuffled1)
        {
            _timer += Time.deltaTime;
            this.transform.Translate(_targetP.x / (60 * _moveTime), _targetP.y / (60 * _moveTime), 0, Space.World);
            this.transform.Rotate(0, 0, _targetR.z / (60 * _moveTime));

            if (_timer > _moveTime)
            {
                _isShuffled1 = false;
                _timer = 0;
                _secondMove = _anchor.position - this.transform.position;
            }
        }
        if (_isShuffled2)
        {
            _timer += Time.deltaTime;
            this.transform.Translate(_secondMove.x / (60 * _moveTime), _secondMove.y / (60 * _moveTime), 0, Space.World);

            if (_timer > _moveTime)
            {
                _isShuffled2 = false;
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
