using Microsoft.AspNetCore.Identity;
using WEBApiREST.Interfaces;

namespace WEBApiREST.Middleware
{
    public class TokenServiceMiddleware: IMiddleware
    {
        public TokenServiceMiddleware()
        {
           
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine(context.Request);
            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(accessToken))
            {
                if (accessToken.Contains("Bearer"))
                {
                    accessToken = accessToken.Split(" ").Last();
                    //var storage = context.RequestServices.GetRequiredService<IUserStorage>();
                    //storage.SetUser(user);
                }
            }

            await next(context);
        }
    }
}
