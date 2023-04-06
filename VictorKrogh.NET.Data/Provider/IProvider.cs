namespace VictorKrogh.NET.Data.Provider;

public interface IProvider
{
    void Complete();
    void Rollback();
}
