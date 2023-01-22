using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    TimeManeger Timer = new TimeManeger();
    [SerializeField]
    ButtonManeger ButtonManeger;

    [SerializeField]
    TextMeshProUGUI score_Text;
    [SerializeField]
    TextMeshProUGUI count_Text;
    [SerializeField]
    TextMeshProUGUI timer_Text;
    [SerializeField]
    TextMeshProUGUI finish_Text;

    [SerializeField]
    int CountMax=3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
        //�R���[�`���ŃJ�E���g�_�E�����N��
    }

    // Update is called once per frame
    void Update()
    {
        if (!Timer.timerStart) { return; }
        Timer.TimerCount();
        //�ʃN���X�Ɏ��Ԃ��J�E���g������
        timer_Text.text = Timer.time.ToString("F3");
        //�X�R�A�\�����X�V
        score_Text.text = Score.GetScore().ToString();
        if (Timer.time <= 0)
        {
            //���Ԑ؂ꂵ����^�C�}�[���}�C�i�X�̐��E�ɍs���̂�0��
            timer_Text.text = "0";
            //�Q�[���I�������m
            finish_Text.gameObject.SetActive(true);
            //3�b��Ƀ��U���g�֑J��
            Invoke("LoadResult", 3);
        }
    }
    IEnumerator CountDown()
    {
        for (int i = 0; i < CountMax; i++)
        {
            //1�b���҂��ăJ�E���g����
            count_Text.text = (CountMax - i).ToString();
            yield return new WaitForSeconds(1);
        }
        //�^�C�}�[�̃J�E���g���J�n
        Timer.SetStart();
        //�J�E���g�p�̃e�L�X�g�͎ז��Ȃ̂ŏ���
        count_Text.gameObject.SetActive(false);
        //�{�^���Ǘ��̃X�N���v�g���g�p�\��
        ButtonManeger.enabled = true;
        yield break;
    }
    void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }
    public void PlusTime(float input)
    {
        Timer.PlusTime(input);
    }
}
