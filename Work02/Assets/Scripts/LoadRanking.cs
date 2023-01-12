using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class LoadRanking
{
    public List<int> SetRanking(int New_Score)
    {
        //�����L���O���X�V
        List<int> Ranking=new List<int>();
        for (int i = 1; i < 6; i++)
        {
            Ranking.Add(PlayerPrefs.GetInt("Rank"+i.ToString(),0));
        }
        Ranking.Add((int)New_Score);
        //���݂̃X�R�A�����������X�g�ɑ΂��č~���\�[�g
        var result = Ranking.OrderByDescending(x => x).ToList();
        return result;
        //List��Ԃ�
    }
    public void SaveRanking(List<int> list)
    {
        for (int i = 1; i < 6; i++)
        {
            //��ʂT���Z�[�u
            PlayerPrefs.SetInt("Rank" + i.ToString(),list[i-1]);
        }
    }
}
