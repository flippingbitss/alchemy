public interface IPotion
{
    string Name { get; }
    void Consume(PlayerController pc);
}
