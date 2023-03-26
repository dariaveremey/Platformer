using Services;

namespace Game
{
    public interface ISaveLoadDataPiece:ILoadDataPiece
    {
        void Save(PersistenceData data);
        //void Load(PersistenceData data);
    }
}