
namespace GameData
{
    public class Player : Target
    {
        Role role;
        List<Card> hand;
        List<Card> board;

        public override Player GetPlayer()
        {
            return this;
        }
    }
}
