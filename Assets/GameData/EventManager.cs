
using System;

namespace GameData
{
    public class EventManager
    {
        public static EventManager Instance { get; protected set; }

        internal void onCardPlayed(Card card, Player source, Target target)
        {
            card.ApplyEffect(target);
            source.RemoveCard(card);
        }
    }
}