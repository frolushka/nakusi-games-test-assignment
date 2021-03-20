namespace NakusiGames.Character
{
    public interface IUnitHealth
    {
        delegate void DeathHandler();

        event DeathHandler OnDeath;
        void TakeDamage(float value);
    }
}