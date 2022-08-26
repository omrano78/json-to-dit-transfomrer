using System.Threading.Tasks;

namespace Dita.Web.Services
{
    public interface IContentfulService
    {
        Task<string> Fetch(string query);
        Task<string> FetchQueryFromArticleDita();
    }
}
