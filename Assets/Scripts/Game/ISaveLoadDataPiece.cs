using Services;

namespace Game
{
    public interface ISaveLoadDataPiece
    {
        void Save(PersistenceData data);
        void Load(PersistenceData data);
    }
}