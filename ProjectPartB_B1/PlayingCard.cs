using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project

		public PlayingCard(PlayingCardColor color, PlayingCardValue value)
		{
			Color = color;
			Value = value;
		}

		public int CompareTo(PlayingCard card1)
		{
			if (Value != card1.Value)
			{
				return Value.CompareTo(card1.Value);
			}
			else
			{
				return Color.CompareTo(card1.Color);
			}
		}
		#endregion

		#region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression

			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode

			get
			{
				// Use switch expression to get the correct suit symbol
				string suitSymbol = Color switch
				{
					PlayingCardColor.Clubs => "\u2663",
					PlayingCardColor.Diamonds => "\u2666",
					PlayingCardColor.Hearts => "\u2665",
					PlayingCardColor.Spades => "\u2660",
					_ => ""
				};

				return $"{suitSymbol} {Value,2}";
			}
		}

		public override string ToString() => ShortDescription;
		#endregion
	}
}
