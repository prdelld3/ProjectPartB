using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    interface IHandOfCards : IDeckOfCards
    {
        public void Add(PlayingCard card);
        public PlayingCard Highest { get; }
        public PlayingCard Lowest { get; }
    }
}
