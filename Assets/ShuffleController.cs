using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleController : MonoBehaviour
{
    /// <summary>���b�œ���̈ʒu�܂œ����̂�</summary>
    [Header("�ړ��̕b��")]
    [SerializeField] float _moveTime = default;
    /// <summary>�񎟈ړ��̎��Ɏg��anchor</summary>
    [Header("���̈ړ��̃A���J�[")]
    [SerializeField] RectTransform _anchor = default;
    /// <summary>x���W�̃����_���̐�Βl</summary>
    [Header("x���W�̃����_���̐�Βl")]
    [SerializeField] float _xRandom = default;
    /// <summary>y���W�̃����_���̐�Βl</summary>
    [Header("y���W�̃����_���̐�Βl")]
    [SerializeField] float _yRanom = default;
    /// <summary>�p�x�����_���̍ō��l</summary>
    [Header("�p�x�����_���̐�Βl")]
    [SerializeField] float _rotationRanom = default;
    /// <summary>ture�̊ԁA�ړ����s����</summary>
    bool _isShuffled1 = false;
    /// <summary>�񎟈ړ����s����</summary>
    bool _isShuffled2 = false;
    /// <summary>�O���ړ����s����</summary>
    bool _isShuffled3 = false;
    /// <summary>�ŏI�I�Ȉʒu</summary>
    Vector3 _targetP = Vector3.zero;
    /// <summary>�ŏI�I�Ȋp�x</summary>
    Vector3 _targetR = Vector3.zero;
    /// <summary>�^�C�}�[</summary>
    float _timer = default;
    /// <summary>���̃I�u�W�F�N�g��RectTracsform</summary>
    RectTransform _rectTransform;
    /// <summary>�ړ��O�̈ʒu</summary>
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
        //���̏�����
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
