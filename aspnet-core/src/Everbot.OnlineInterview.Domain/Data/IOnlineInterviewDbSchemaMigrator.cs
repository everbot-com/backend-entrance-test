using System.Threading.Tasks;

namespace Everbot.OnlineInterview.Data;

public interface IOnlineInterviewDbSchemaMigrator
{
    Task MigrateAsync();
}
