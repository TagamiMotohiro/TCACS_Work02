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
        //ランキングを更新
        List<int> Ranking=new List<int>();
        for (int i = 1; i < 6; i++)
        {
            Ranking.Add(PlayerPrefs.GetInt("Rank"+i.ToString(),0));
        }
        Ranking.Add((int)New_Score);
        //現在のスコアを加えたリストに対して降順ソート
        var result = Ranking.OrderByDescending(x => x).ToList();
        return result;
        //Listを返す
    }
    public void SaveRanking(List<int> list)
    {
        for (int i = 1; i < 6; i++)
        {
            //上位５つをセーブ
            PlayerPrefs.SetInt("Rank" + i.ToString(),list[i-1]);
        }
    }
}
