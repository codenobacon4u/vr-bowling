using System.Collections;
using System.Collections.Generic;

namespace bowlingscoring
{
	// To use the scoring system, you have to createa new ScoreManager, most likely to be placed in the GameManager.
	class ScoreManager
	{
		private List<Frame> frames;
		private int lastBall;

		//We need to create a new ScoreManager for every game that is played.
		public ScoreManager()
		{
			frames = new List<Frame>(10);
		}

		//Gets the scores of the frame at the specified index
		public int[] GetScore(int index)
		{
			return frames[index].scores;
		}

		//Call this method after the player rolls the two throws for that frame. Adds frame to list and sets the scores.
		public void SetFrame(int index, int roll1, int roll2)
		{
			Frame curr = new Frame();
			frames.Add(curr);
			curr.SetScore(roll1, roll2);
			if (index == 9)
			{
				if (curr.isSpare || curr.isStrike)
				{
					curr.SetLastFrame(roll1, roll2, lastBall);
				}
			}

			Update();
		}

		//Updates scores for each frame
		private void Update()
		{
			for (int i = 1; i < frames.Count; i++)
			{
				CalculateBonuses(i);
			}
		}

		//Calculates the bonuses for strikes and spares based on the scores of the previous frames
		private void CalculateBonuses(int i)
		{
			Frame curr = frames[i];
			Frame prev = frames[i - 1];
			if (prev.isStrike)
			{
				int score1 = curr.scores[1] + curr.scores[0];
				prev.AddScore(10, score1);
				if (i > 1 && frames[i - 2].isStrike)
				{
					Frame prev2 = frames[i - 2];
					int score3 = curr.isSpare ? 10 + curr.scores[1] : 10 + curr.scores[0];
					prev2.AddScore(10, score3);
				}
			}
			else if (prev.isSpare)
			{
				prev.AddScore(curr.scores[0], 10);
				if (i > 1 && frames[i - 2].isStrike)
				{
					Frame prev2 = frames[i - 2];
					int score2 = curr.isSpare ? 10 + curr.scores[1] : 10 + curr.scores[0];
					if (i - 2 == 0)
					{
						score2 -= curr.scores[0];
					}
					prev2.AddScore(10, score2);
				}
			}
		}

		//Gets the total points for the game at that time.
		public int TotalPoints()
		{
			int total = 0;
			for (int i = 0; i < frames.Count; i++)
			{
				total += frames[i].total;
			}
			return total;
		}

		/* Prints a scoreboard style representation of the scores in each frame as they would appear on screen.
		 * TODO: This is where we update the score on screen after each frame.
		 * NOTE: Where there is a commented out Console.Write(... we need to put the code to update the on screen score.
		 * (Don't worry about Console.WriteLine(), that was just a formatting thing while I was testing.
		 */
		public void PrintScoreboard()
		{
			for (int i = 0; i < frames.Count; i++)
			{
				if (frames[i].isStrike)
				{
					if (i < frames.Count - 1 && frames[i + 1].scores[1] == 0)
					{
						//Console.Write("[ ]");
						continue;
					}
					else if (frames[i].scores[1] == 0)
					{
						//Console.Write("[ ]");
						continue;
					}
				}
				else if (frames[i].isSpare && i == frames.Count - 1)
				{
					//Console.Write("[ ]");
					continue;
				}
				//Console.Write("[" + ScoreFromRange(i) + "]");

			}
			//Console.WriteLine();
		}

		// Gets the current score from the first frame to the specified frame.
		private int ScoreFromRange(int index)
		{
			int sum = 0;
			for (int i = 0; i <= frames.IndexOf(frames[index]); i++)
			{
				sum += frames[i].total;
			}
			return sum;
		}

		/* Prints the total scores of each frame. I used this to debug my code and make sure the math was right, 
		 * but it does not print out correctly for scoring.
		 */
		public void PrintScores()
		{
			for (int i = 0; i < frames.Count; i++)
			{
				//Console.Write("[" + frames[i].ToString() + "]");
			}
			//Console.WriteLine();
		}

		/* Used to add the score of the third roll in the last frame if applicable.
		 * Only needs to be used and only works if there is a strike or spare in the last frame.
		 */
		public void SetLastBall(int score)
		{
			lastBall = score;
			int score1 = frames[9].scores[0];
			int score2 = frames[9].scores[1];
			if (frames[9].isSpare || frames[9].isStrike)
			{
				frames[9].SetLastFrame(score1, score2, score);
			}

			Update();
		}
	}
}
