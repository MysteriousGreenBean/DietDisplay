namespace DietDisplay.API.Logic.Cache
{
    public class CacheEntry<TCachedObject, TObjectCreationData>
    {
        private readonly Func<TObjectCreationData, bool> evaluateIsCacheValid;
        private TObjectCreationData cachedObjectCreationData;

        public bool IsCacheValid => evaluateIsCacheValid(cachedObjectCreationData);
        public TCachedObject CachedObject { get; init; }

        public CacheEntry(
            TCachedObject cachedObject,
            TObjectCreationData cachedObjectCreationData,
            Func<TObjectCreationData, bool> evaluateIsCacheValid) {
            CachedObject = cachedObject;
            this.cachedObjectCreationData = cachedObjectCreationData;
            this.evaluateIsCacheValid = evaluateIsCacheValid;
        }
    }
}
