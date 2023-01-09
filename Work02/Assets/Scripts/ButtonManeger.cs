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
		ButtonActive(Button_List[Random.Range((int)0, (int)10), Random.Range((int)0, (int)10)]);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonActive(Button button)
    {
        Debug.Log(button.gameObject.name);
        button.gameObject.GetComponent<Image>().color = Color.red;
        button.OnClickAsObservable().Subscribe(_ => ButtonOnclick(button)).AddTo(disposables);
    }
    void ButtonOnclick(Button button)
    {
        Debug.Log("ƒNƒŠƒbƒN‚³‚ê‚½");
        Score.PlusScore(1);
        button.gameObject.GetComponent<Image>().color = Color.gray;
        disposables.Clear();
        ButtonActive(Button_List[Random.Range((int)0,(int)10),Random.Range((int)0, (int)10)]);
    }
}
