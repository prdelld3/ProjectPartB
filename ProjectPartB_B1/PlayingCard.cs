using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
        {
			return 0;
        }
		#endregion
		public PlayingCard(PlayingCardColor color, PlayingCardValue value)
		{
			Color = color;
			Value = value;
		}

        #region ToString() related
		string ShortDescription
		{
			get
			{ 
				string symbol = Color switch 
				{ 
					 PlayingCardColor.Clubs => "♣ ",
					 PlayingCardColor.Diamonds => "♦ ",
					 PlayingCardColor.Hearts => "♥ ",
					 PlayingCardColor.Spades => "♠ ",
					_ => throw new NotImplementedException() 
				}; 
				
				return $"{symbol}";
			}
		}

		public override string ToString() => $"{ShortDescription} {Value} ";
        #endregion

	
    }
}
