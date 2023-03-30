namespace Services.Persistente
{
    public interface IPersistenceService
    {
        void Bootstrap();
        void Save();
        PersistenceData Data { get;}
    }
}