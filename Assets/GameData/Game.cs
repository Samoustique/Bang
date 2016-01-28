
using System;
using System.Collections.Generic;

namespace GameData
{
    public class Game {
        public static Game Instance { get; protected set; }

        public enum CardPlayedResult
        {
            CARD_PLAYED,
            TARGET_TOO_FAR,
            INVALID_TARGET,
        }

        LinkedList<Player> players = new LinkedList<Player>();
        LinkedList<Card> drawableCards = new LinkedList<Card>();
        LinkedList<Card> droppedOfCards = new LinkedList<Card>();

        public Player GetPlayerOfCard(int id)
        {
            foreach(Player player in players)
            {
                if (player.hasCardWithId(id))
                    return player;
            }

            return null;
        }

        public CardPlayedResult PlayCard(Card card, Player source, Target target)
        {
            CardPlayedResult res = IsCardPlayable(card, source, target);

            if (res == CardPlayedResult.CARD_PLAYED)
                EventManager.Instance.onCardPlayed(card, source, target);

            return res;
        }

        private CardPlayedResult IsCardPlayable(Card card, Player source, Target target)
        {
            CardPlayedResult result = CardPlayedResult.CARD_PLAYED;
            int dist = CalculateDistanceBetweenPlayers(source, target.GetPlayer());

            if (!IsCorrectTarget(card, target))
            {
                result = CardPlayedResult.INVALID_TARGET;
            }
            else if (IsSourceOrCardInRange(source, card, dist))
            {
                result = CardPlayedResult.TARGET_TOO_FAR;
            }

            return result;
        }

        private bool IsCorrectTarget(Card card, Target target)
        {
            throw new NotImplementedException();
        }

        private bool IsSourceOrCardInRange(Player source, Card card, int dist)
        {
            return source.Range < dist && (card.Range != -1 || card.Range < dist);
        }

        private int CalculateDistanceBetweenPlayers(Player source, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
