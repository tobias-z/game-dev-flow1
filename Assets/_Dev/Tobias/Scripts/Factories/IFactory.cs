namespace Codergram._Dev.Tobias.Scripts.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}