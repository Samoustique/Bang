
using System.Collections.Generic;

namespace GameData
{
    public class Game {
        Dictionary<int, Player> players = new Dictionary<int, Player>();
        LinkedList<Card> drawableCards = new LinkedList<Card>();
        LinkedList<Card> droppedOfCards = new LinkedList<Card>();
    }
}
