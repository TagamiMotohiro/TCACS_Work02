using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using JetBrains.Annotations;

public class ButtonManeger : MonoBehaviour
{
    Button[,] Button_List = new Button[10, 10];
    GameObject[] Button_Allay_List=new GameObject[10];
    CompositeDisposable disposables= new CompositeDisposable();
    // Start is called before the first frame update
    void Start()
    {
        //Static�ő��݂���X�R�A��0�Ƀ��Z�b�g
        Score.SetScore(0);
        for (int i = 0; i < 10; i++)
        {
            Button_Allay_List[i]=GameObject.Find("Button_Allay ("+i.ToString()+")");
        }
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Button_List[y, x] = Button_Allay_List[y].transform.GetChild(x).GetComponent<Button>();
            }
        }
        //�{�^�����ꗗ�Ŏ擾
        //�ǂ�������̃{�^�����������Ԃ�
		ButtonActive(Button_List[Random.Range((int)0, (int)10), Random.Range((int)0, (int)10)]);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonActive(Button button)
    {
        //�������ԂɂȂ�����ԐF�ɂȂ�
        Debug.Log(button.gameObject.name);
        button.gameObject.GetComponent<Image>().color = Color.red;
        //�{�^���̃N���b�N�C�x���g��ݒ�
        button.OnClickAsObservable().Subscribe(_ => ButtonOnclick(button)).AddTo(disposables);
    }
    void ButtonOnclick(Button button)
    {
        //�Ԃ��{�^������������
        Debug.Log("�N���b�N���ꂽ");
        //�X�R�A��1�v���X
        Score.PlusScore(1);
        //�{�^���̐F��߂�
        button.gameObject.GetComponent<Image>().color = Color.gray;
        //�N���b�N�C�x���g�̍w�ǂ�����
        disposables.Clear();
        //�Ō�ɂǂ�������̃{�^�����������Ԃɂ��邱�ƂŃ��[�v������
        ButtonActive(Button_List[Random.Range((int)0,(int)10),Random.Range((int)0, (int)10)]);
    }
}
