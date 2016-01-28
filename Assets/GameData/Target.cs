
namespace GameData
{
    public abstract class Target
    {
        public enum TargetType
        {
            PLAYER,
            CARD
        }

        public abstract TargetType Type { get; }
        public abstract Player GetPlayer();
    }
}