using Microsoft.EntityFrameworkCore;

namespace RecruitmentSITHEC.Helpers.Pagination
{
    public static class HttpContextExtensions
    {
        public async static Task PaginationOnHeader<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double totalRecords = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalRecords", totalRecords.ToString());
        }
    }
}
