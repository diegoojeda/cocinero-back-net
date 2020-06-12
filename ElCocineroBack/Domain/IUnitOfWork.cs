using System.Threading.Tasks;

namespace ElCocineroBack.Domain
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}