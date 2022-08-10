using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleController : MonoBehaviour
{
    /// <summary>���b�œ���̈ʒu�܂œ����̂�</summary>
    [Header("�ŏ��̈ړ��̕b��")]
    [SerializeField] float _moveTime = default;
    /// <summary>�񎟈ړ��̎��Ɏg��anchor</summary>
    [Header("���̈ړ��̃A���J�[")]
    [SerializeField] Transform _anchor = default;
    /// <summary>ture�̊ԁA�ړ����s����</summary>
    bool _isShuffled1 = false;
    /// <summary>�񎟈ړ����s����</summary>
    bool _isShuffled2 = false;
    /// <summary>�ŏI�I�Ȉʒu</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>�ŏI�I�Ȋp�x</summary>
    Vector3 _targetR = Vector3.zero;
    /// <summary>�񎟈ړ��̍ۂ̃x�N�g��</summary>
    Vector3 _secondMove = Vector3.zero;
    //�^�C�}�[
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
        //���̏�����
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
