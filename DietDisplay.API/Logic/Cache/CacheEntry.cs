namespace DietDisplay.API.Logic.Cache
{
    public class CacheEntry<TCachedObject, TObjectCreationData>
    {
        private readonly Func<TObjectCreationData, bool> evaluateIsCacheValid;
        private TObjectCreationData cachedObjectCreationData;

        /// <summary>
        /// True if cache is still valid, false otherwise.
        /// </summary>
        public bool IsCacheValid => evaluateIsCacheValid(cachedObjectCreationData);
        /// <summary>
        /// Cached object.
        /// </summary>
        public TCachedObject CachedObject { get; init; }

        /// <summary>
        /// Creates cache entry.
        /// </summary>
        /// <param name="cachedObject">Object to be cached.</param>
        /// <param name="cachedObjectCreationData">Data associated with object creation.</param>
        /// <param name="evaluateIsCacheValid">Function evaluating if the cached value is still valid.</param>
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
