using System;

namespace bowlingscoring
{
	class Frame
	{
		public int[] scores = new int[3];
		readonly int[] lastFrame = new int[3];
		public bool isStrike = false;
		public bool isSpare = false;
		public int total;

		public Frame() { }

		public void SetScore(int s1, int s2)
		{
			scores[0] = s1;
			scores[1] = s2;
			if (scores[0] == 10) isStrike = true;
			else if (scores[0] + scores[1] == 10) isSpare = true;
			total = scores[2] = s1 + s2;
		}

		public void AddScore(int s1, int s2)
		{
			scores[0] = s1;
			scores[1] = s2;
			total = scores[2] = s1 + s2;
		}

		public void AddScore(int[] scores)
		{
			this.scores[0] = scores[0];
			this.scores[1] = scores[1];
			total = scores[2] = scores[0] + scores[1];
		}

		public void SetLastFrame(int score1, int score2, int score3)
		{
			lastFrame[0] = score1;
			lastFrame[1] = score2;
			lastFrame[2] = score3;
			total = lastFrame[0] + lastFrame[1] + lastFrame[2];
		}

		public Frame GetFrame()
		{
			return this;
		}

		public override String ToString()
		{
			return total + "";
		}
	}
}
