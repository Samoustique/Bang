using UnityEngine;

namespace GameData
{
    public class Card : Target {
        int id;

        public override Player GetPlayer()
        {
            return Game.GetPlayerOfCard(this.owner);
        }

        public void PlayCard(Player source, Target target)
        {
            CardPlayedResult res = Game.PlayCard(this.id, source, target);

            if (res != Game.CARD_PLAYED)
                HandleCardNotPlayable(res);
        }

        private void HandleCardNotPlayable(Game.CardPlayedResult res)
        {
            Debug.Log("Illegal move : " + res);
        }
    }
}
