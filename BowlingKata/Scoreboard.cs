using System.Collections.Generic;

namespace BowlingKata
{
    public class Scoreboard
    {
        private const int NumberOfFrames = 10;
        private const int MaximumScoreForFrame = 10;
        private readonly IList<int> _pins = new List<int>();
                private int _currentRoll;

        public void Roll(int pins)
        {
            _pins.Add(pins);
        }

        public int CalculateScore()
        {
            var score = 0;
            _currentRoll = 0;
            for (var frame = 0; frame < NumberOfFrames; frame++)
            {
                if (RolledAStrike())
                    score = ScoreStrikeForFrame(score);
                else if (RolledASpare())
                    score = ScoreSpareForFrame(score);
                else
                    score = ScorePinsForFrame(score);
            }
            return score;  
        }

        private bool RolledAStrike()
        {
            return _pins[_currentRoll] == MaximumScoreForFrame;
        }

        private int ScoreStrikeForFrame(int score)
        {
            score += _pins[_currentRoll] + _pins[_currentRoll + 1] + _pins[_currentRoll + 2];
            _currentRoll++;
            return score;
        }

        private bool RolledASpare()
        {
            return _pins[_currentRoll] + _pins[_currentRoll + 1] == MaximumScoreForFrame;
        }

        private int ScoreSpareForFrame(int score)
        {
            score += _pins[_currentRoll] + _pins[_currentRoll + 1] + _pins[_currentRoll + 2];
            _currentRoll += 2;
            return score;
        }

        private int ScorePinsForFrame(int score)
        {
            score += _pins[_currentRoll] + _pins[_currentRoll + 1];
            _currentRoll += 2;
            return score;
        }
    }
}