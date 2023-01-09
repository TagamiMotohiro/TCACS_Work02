using System.Collections;
using System.Collections.Generic;
using UnityEngine;
static class Score
{
	static List<int> Ranking;
	public static int this_Score { get; private set; } =0;
	public static void SetScore(int score)
	{
		this_Score = score;
	}
	public static void PlusScore(int score)
	{
		this_Score += score;
	}
	public static float GetScore()
	{
		return this_Score;
	}
}
