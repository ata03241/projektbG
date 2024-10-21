using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);


        public PlayingCard this[int idx] => null;
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            string srt = "";
            int count = 0;

            foreach (var item in cards)
            {
                
                srt += $"{item,-12}"; //each card will have 12 character 
                count++;

                
                if (count % 13 == 0)
                {
                    srt += "\n";
                }
                else
                {
                    srt += " "; 
                }
            }

            return srt;
        }



        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int Shuffle = 0; Shuffle < 1000; Shuffle++)
            {
                for (int i = 0; i < MaxNrOfCards; i++)
                {
                    int secondIndex = rnd.Next(13);
                    var temp = cards[i];
                    cards[i] = cards[secondIndex];
                    cards[secondIndex] = temp;

                }
            }
        }
        public void Sort()
        {   
            cards.Sort();
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            cards.Clear();
            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)
            {
                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)
                {
                    cards.Add(new PlayingCard(color, value)); //skicka båda arguments till constructor
                }
            }
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck.");
            }

            var Tcard = cards[0];
            cards.RemoveAt(0);
            return Tcard;

        }
        #endregion
    }
}
