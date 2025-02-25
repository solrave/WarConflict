namespace WarConflict.UNITS.Interfaces;

public interface IHittable
{
    public event Action<int>? OnHit;
    public void TakeHit(int damageValue);
}