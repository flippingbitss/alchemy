public interface IPotion
{
    string Name { get; set; }
    void Consume(PlayerController pc);
}
