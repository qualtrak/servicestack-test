namespace WebApp.Infrastructure
{
    using System;
    using System.Text.RegularExpressions;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface;

    public class CheckAccountFilterAttribute : RequestFilterAttribute
    {
        public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            Match match = Regex.Match(req.PathInfo, @"\/(.*?)\/");

            if (match.Success)
            {
                string account = match.Groups[1].Value;

                if (account != "aeon")
                {
                    throw new Exception(string.Format("Invalid or unknown Account named: {0}", account));
                }
            }
            else
            {
                throw new Exception("Account part of path is mandatory!");
            }
        }
    }
}