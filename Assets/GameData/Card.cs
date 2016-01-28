using System;
using UnityEngine;

namespace GameData
{
    public class Card : Target {
        int id;
        int range;

        public int Id { get { return id; } }
        public int Range { get { return range; } }

        public override TargetType Type { get { return TargetType.CARD; } }

        public override Player GetPlayer()
        {
            return Game.Instance.GetPlayerOfCard(this.Id);
        }

        internal void ApplyEffect(Target target)
        {
            throw new NotImplementedException();
        }

        public void PlayCard(Player source, Target target)
        {
            Game.CardPlayedResult res = Game.Instance.PlayCard(this, source, target);

            if (res != Game.CardPlayedResult.CARD_PLAYED)
                HandleCardNotPlayable(res);
        }

        private void HandleCardNotPlayable(Game.CardPlayedResult res)
        {
            Debug.Log("Illegal move : " + res);
        }

        public bool canAffect(Target target)
        {
            return target.Type == TargetType.PLAYER || target.Type == TargetType.CARD;
        }
    }
}
