using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            // if(card != null){
            //     cards.Add(card);
            //     cards.Sort();
            // }
            if (card == null) throw new ArgumentNullException("Cannot add null");
            cards.Add(card);
            cards.Sort();
        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                if (cards == null || cards.Count == 0)
                    throw new InvalidOperationException("No cards in hand.");
                PlayingCard Highest = cards[0];

                foreach (var card in cards)
                {
                    if (card.CompareTo(Highest) > 0)
                    {
                        Highest = card;
                    }
                }

                return Highest;
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                if (cards == null || cards.Count == 0)
                    throw new InvalidOperationException("No cards in hand.");
                PlayingCard lowest = cards[0];

                foreach (var card in cards)
                {
                    if (card.CompareTo(lowest) < 0)
                    {
                        lowest = card;
                    }
                }

                return lowest;
            }
        }
        #endregion
    }
}
