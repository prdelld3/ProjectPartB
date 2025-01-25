using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        public List<PlayingCard> playersHand = new List<PlayingCard>();
        public int score{get; set;}

        #region Pick and Add related
        public void Add(PlayingCard card)
        { 
            playersHand.Add(card);
        }

        public void Score()
        {
            score++;
        
        }
        #endregion
         public IEnumerable<PlayingCard> Hand => playersHand.AsReadOnly();
        #region Highest Card related
        public PlayingCard Highest
        {
            get
            { 
                if(playersHand.Count == 0)
                    return null;

                PlayingCard first = null;
                
                foreach (var playingCard in playersHand.OrderBy(card => card.Value))
                {
                    first = playingCard;
                   
                }
                return first;
                
            }
         }
        public PlayingCard Lowest
        {
            get
            { 
                if(playersHand.Count == 0)
                    return null;

                PlayingCard first = null;
                
                foreach (var playingCard in playersHand.OrderByDescending(card => card.Value))
                {
                    first = playingCard;
                   
                }
                return first;
                
            }
        }
        #endregion
    }
}
