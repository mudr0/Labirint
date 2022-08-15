namespace Labirint
{
    public interface ISaveData
    {
        void SaveData(SObject gameObject);

        SObject LoadData(SObject gameObject);
    }
}
