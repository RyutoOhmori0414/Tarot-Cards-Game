using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleController : MonoBehaviour
{
    /// <summary>何秒で特定の位置まで動くのか</summary>
    [SerializeField] float _moveTime = default;
    /// <summary>tureの間、移動が行われる</summary>
    [SerializeField] bool _isShuffled = false;
    /// <summary>最終的な位置</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>最終的な角度</summary>
    Vector3 _targetR = Vector3.zero;
    //タイマー
    float _timer = default;
    private void OnEnable()
    {
        GameManager.Shuffle += MoveCard;
    }
    void Start()
    {
        this.transform.localScale = Vector3.one;
        _targetP = new Vector3(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(-1.5f, 1.5f), 0);
        _targetR = new Vector3(0, 0, UnityEngine.Random.Range(0.0f, 180.0f));
    }
    // Update is called once per frame
    void Update()
    {
        //下の処理は
        if (_isShuffled)
        {
            _timer += Time.deltaTime;
            this.transform.Translate(_targetP.x / (60 * _moveTime), _targetP.y / (60 * _moveTime), 0, Space.World);
            this.transform.Rotate(0, 0, _targetR.z / (60 * _moveTime));

            if (_timer > _moveTime)
            {
                _isShuffled = false;
                _timer = 0;
            }
        }
    }

    void MoveCard()
    {
        _isShuffled = true;
    }
}
