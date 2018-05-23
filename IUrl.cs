namespace UrlBuilder
{
    public interface IUrl
    {
        /// <summary>
        /// Returns the full url
        /// </summary>
        /// <returns></returns>
        string GetUrl();
        
        /// <summary>
        /// Add a parameter 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        void AddParam(string name, object value);
        /// <summary>
        /// Add any parameters to the url dynamically
        /// </summary>
        /// <param name="parameters"></param>
        void AddParams(object parameters);
    }
}