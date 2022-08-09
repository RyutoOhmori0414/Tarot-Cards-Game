using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleController : MonoBehaviour
{
    /// <summary>���b�œ���̈ʒu�܂œ����̂�</summary>
    [SerializeField] float _moveTime = default;
    /// <summary>ture�̊ԁA�ړ����s����</summary>
    [SerializeField] bool _isShuffled = false;
    /// <summary>�ŏI�I�Ȉʒu</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>�ŏI�I�Ȋp�x</summary>
    Vector3 _targetR = Vector3.zero;
    //�^�C�}�[
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
        //���̏�����
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
