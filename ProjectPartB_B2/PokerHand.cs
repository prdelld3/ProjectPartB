using System;
using System.Collections.Generic;

namespace ProjectPartB_B2
{
    class PokerHand : HandOfCards
    {
        #region Clear
        public override void Clear()
        { }
        #endregion

        #region Remove and Add related
        public override void Add(PlayingCard card)
        { }
        #endregion

        #region Poker Rank related
        //https://www.poker.org/poker-hands-ranking-chart/

        //Hint: using backing fields
        private PokerRank _rank = PokerRank.Unknown;
        private PlayingCard _rankHigh = null;
        private PlayingCard _rankHighPair1 = null;
        private PlayingCard _rankHighPair2 = null;

        public PokerRank Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;
        public PlayingCard RankHiCardPair1 => _rankHighPair1;
        public PlayingCard RankHiCardPair2 => _rankHighPair2;

        //Hint: Somer Helpers to examine a sorted hand
        private bool IsSameColor(out PlayingCard HighCard)
        {
            if (Count <= 0)
            {
                HighCard = null;
                return false;
            }

            //every item must have same as Highest cards
            HighCard = this.Highest;
            foreach (var item in cards)
            {
                if (item.Color != HighCard.Color)
                {
                    HighCard = null;
                    return false;
                }
            }

            return true;
        }
        private bool IsConsecutive(out PlayingCard HighCard)
        {
            if (Count <= 0)
            {
                HighCard = null;
                return false;
            }

            PlayingCardValue prevValue = cards[0].Value;
            for (int i = 1; i < Count; i++)
            {
                if (cards[i].Value == prevValue + 1)
                    prevValue = cards[i].Value;
                else
                {
                    HighCard = null;
                    return false;
                }
            }

            HighCard = Highest;
            return true;
        }
        private int NrSameValue(int firstValueIdx, out int lastValueIdx, out PlayingCard HighCard)
        {
            if (Count <= 0)
            {
                HighCard = null;
                firstValueIdx = lastValueIdx = 0;
                return 0;
            }

            int maxNrSameValue = 0;
            int nrConsecutiveValues = 0;

            HighCard = cards[0];
            lastValueIdx = 0;

            for (int i = firstValueIdx; i < Count; i++)
            {
                if (cards[i].Value == HighCard.Value)
                {
                    nrConsecutiveValues++;
                    if (nrConsecutiveValues > maxNrSameValue)
                    {
                        HighCard = cards[i];
                        maxNrSameValue = nrConsecutiveValues;
                        lastValueIdx = i;
                    }
                }
                else if (nrConsecutiveValues <= 1)
                {
                    //Shift Value one card and check for new sequence
                    HighCard = cards[i];
                    firstValueIdx = i;
                    nrConsecutiveValues = 1;
                }
                else
                {
                    //found a sequence
                    return maxNrSameValue;
                }
            }
            return maxNrSameValue;
        }


        //Hint: Somer Helpers to examine a hand for color and value occurances
        private Dictionary<PlayingCardValue, int> NrOfValueOccurances()
        {
            //Check number of occurnaces of a value in the pokerhand
            Dictionary<PlayingCardValue, int> occurances = new Dictionary<PlayingCardValue, int>();
            foreach (var item in cards)
            {
                //try to see if it can be added, only the first time works
                if (!occurances.TryAdd(item.Value, 1))
                {
                    //already exists, simply imcrement the value
                    occurances[item.Value]++;
                }
            }
            return occurances;
        }
        private Dictionary<PlayingCardColor, int> NrOfColorOccurances()
        {
            //Check number of occurnaces of a value in the pokerhand
            Dictionary<PlayingCardColor, int> occurances = new Dictionary<PlayingCardColor, int>();
            foreach (var item in cards)
            {
                //try to see if it can be added, only the first time works
                if (!occurances.TryAdd(item.Color, 1))
                {
                    //already exists, simply imcrement the value
                    occurances[item.Color]++;
                }
            }
            return occurances;
        }


        //Hint: Worker Properties to examine each rank
        private bool IsRoyalFlush => false;
        private bool IsStraightFlush => false;
        private bool IsFourOfAKind => false;
        private bool IsFullHouse => false;
        private bool IsFlush => IsSameColor(out _rankHigh);
        private bool IsStraight => IsConsecutive(out _rankHigh);
        private bool IsThreeOfAKind => false;
        private bool IsTwoPair
        {
            get
            {
                var _valuecount = NrOfValueOccurances();
                var _colorcount = NrOfColorOccurances();
                return false;
            }
        }
        private bool IsPair
        {
            get
            {
                var _valuecount = NrOfValueOccurances();
                var _colorcount = NrOfColorOccurances();
                return false;
            }
        }

        public PokerRank DetermineRank()
        {
            var _valuecount = NrOfValueOccurances();
            var _colorcount = NrOfColorOccurances();

            return PokerRank.Unknown;
        }

        //Hint: Clear rank
        private void ClearRank()
        {
            _rankHigh = null;
            _rankHighPair1 = null;
            _rankHighPair2 = null;
            _rank = PokerRank.Unknown;
        }
        #endregion
    }
}
