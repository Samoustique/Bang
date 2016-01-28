
using System;
using System.Collections.Generic;

namespace GameData
{
    public class Player : Target
    {
        Role role;
        Hero hero;
        int range;
        public int Range { get { return range; } }
        List<Card> hand;
        List<Card> board;
        int health;

        public override TargetType Type { get { return Target.TargetType.PLAYER; } }

        internal void RemoveCard(Card card)
        {
            throw new NotImplementedException();
        }

        public override Player GetPlayer()
        {
            return this;
        }

        public bool hasCardWithId(int id)
        {
            return (hand.Find(item => item.Id == id) != null) ||
                  (board.Find(item => item.Id == id) != null);
        }
    }
}
