using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalotController : MonoBehaviour
{
    /// <summary>�J�[�h�̃X�v���C�g�������Ă��郊�X�g</summary>
    [Header("�J�[�h�̃X�v���C�g")]
    [SerializeField] List<Sprite> _cardSprites = new List<Sprite>();
    /// <summary>�X�v���C�g��ύX����I�u�W�F�N�g</summary>
    [Tooltip("�X�v���C�g��ύX����J�[�h")]
    [SerializeField] GameObject _cardObject;
    /// <summary>��ނƈʒu���o�͂���e�L�X�g</summary>
    [Tooltip("��ނƈʒu���o�͂���e�L�X�g")]
    [SerializeField] Text _cardStatusText;
    /// <summary>�R�����g���o�͂���e�L�X�g</summary>
    [Tooltip("�R�����g���o�͂���e�L�X�g")]
    [SerializeField] Text _commentText;
    /// <summary>���ʒu�̎��̃R�����g�̃��X�g</summary>
    [Header("���ʒu�̎��̃R�����g")]
    [SerializeField] List<string> _turePosition = new List<string>();
    /// <summary>�t�ʒu�̎��̃R�����g�̃��X�g</summary>
    [Header("�t�ʒu�̎��̃R�����g")]
    [SerializeField] List<string> _falsePosition = new List<string>();
    
    public void ChangeSprite()
    {
        Image CardImage = _cardObject.GetComponent<Image>();
        CardImage.sprite = _cardSprites[Random.Range(0, _cardSprites.Count - 1)];
        int Check = Random.Range(0, 2);
        _cardObject.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, Check * 180, 0);

        if (Check == 0)
        {
            _cardStatusText.text = $"{CardImage.sprite.name.Remove(0, 3)}�E���ʒu";
            _commentText.text = _turePosition[int.Parse(CardImage.sprite.name.Remove(2, CardImage.sprite.name.Length - 2))];
        }
        else if (Check == 1)
        {
            _cardStatusText.text = $"{CardImage.sprite.name.Remove(0, 3)}�E�t�ʒu";
            _commentText.text = _falsePosition[int.Parse(CardImage.sprite.name.Remove(2, CardImage.sprite.name.Length - 2))];
        }
    }
}