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
    private void OnEnable()
    {
        GameManager.Shuffle += MoveCard;
    }
    void Start()
    {
        this.transform.localScale = Vector3.one;
        _targetP = new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(-4, 4), 0);
        _targetR = new Vector3(0, 0, UnityEngine.Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        if (_isShuffled)
        {
            this.transform.Translate(_targetP.x / (60 * _moveTime), _targetP.y / (60 * _moveTime), 0);

            if (this.transform.position == _targetP)
            {
                _isShuffled = false;
            }
        }
    }

    void MoveCard()
    {
        _isShuffled = true;
    }
}
