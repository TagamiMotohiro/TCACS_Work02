using System.Collections;
using System.Collections.Generic;
using UnityEngine;
static class Score
{
	public static int now_Score { get; private set; }=0;
	public static void SetScore(int score)
	{
		now_Score = score;
	}
	public static void PlusScore(int score)
	{
		now_Score += score;
	}
	public static float GetScore()
	{
		return now_Score;
	}
}
