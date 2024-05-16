using System.Net;

namespace Core.HttpClient
{
    public interface IHttpClient
    {
        public (T, HttpStatusCode) Get<T>(string requestUri);
        public (T, HttpStatusCode) Delete<T>(string requestUri);
        public (T, HttpStatusCode) Put<T>(string requestUri, object body);
        public (T, HttpStatusCode) Post<T>(string requestUri, object body);
        public (T, HttpStatusCode) Post<T>(string requestUri);
        public void CleanUp();
    }
}
