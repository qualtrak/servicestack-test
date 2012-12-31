namespace WebApp.Services
{
    using ServiceStack.ServiceInterface;
    using WebApp.Infrastructure;
    using WebApp.Models;

    [CheckAccountFilter]
    public class TagService : ServiceStack.ServiceInterface.Service
    {
        public TagService()
        {
        }

        public object Get(Tags request)
        {
            return null;
        }
    }
}