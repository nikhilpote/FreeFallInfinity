using UnityEngine;
using System.Collections;

public class ScoreManager  {

	// Use this for initialization
	private static int score;

	public static void increaseScore() {
		score += 1;
		UIController.setScore (score);
	}
	public static void increaseScoreBy(int _score) {
		score += _score;
		UIController.setScore (score);
	}
	public static void resetScore() {
		score = 0;
		UIController.setScore (score);
	}

	public static int getScore() {
		return score;
	}
}
