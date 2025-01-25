using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        Random rnd = new Random();
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);
        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
     

        #region ToString() related
        public override string ToString()
        {
            foreach (PlayingCard card in cards) 
            { 
                Console.WriteLine(card.ToString());
            }
            return "Should be deck of cards in short notation";
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        { 
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                (cards[n], cards[k]) = (cards[k], cards[n]); 
            }
        }
        public void Sort()
        { 
            
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        { 
            cards.Clear();  
        }
        public void CreateFreshDeck()
        { 
            Clear();                                                          
            foreach(PlayingCardColor color in Enum.GetValues(typeof(PlayingCardColor)))       
            {                                                                                 
                foreach (PlayingCardValue value in Enum.GetValues(typeof(PlayingCardValue)))  
                {                                                                             
                    cards.Add(new PlayingCard(color, value));                                 
                }                                                                             
            }           
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard topcard = cards[0];
            cards.RemoveAt(0);
            return topcard;
            
        }
        #endregion
    }
}
