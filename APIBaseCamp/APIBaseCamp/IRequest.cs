using System.Threading.Tasks;

namespace APIBaseCamp
{
    /// <summary>
    /// Common interface for all request types.
    /// </summary>
    public interface IRequest
    {
        void Make();
        Task MakeAsync();
    }
}
