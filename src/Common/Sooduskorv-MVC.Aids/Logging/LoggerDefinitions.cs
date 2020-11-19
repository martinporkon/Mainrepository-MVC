using System;
using Microsoft.Extensions.Logging;
using Sooduskorv_MVC.Aids.Events;

namespace Sooduskorv_MVC.Aids.Logging
{
    public static class LoggerDefinitions
    {
        private static readonly Action<ILogger, Exception> _repoRepoAction;
        private static readonly Action<ILogger, string, Exception> _repoCallGetManyRepo;
        private static readonly Func<ILogger, string, IDisposable> _apiGetAllBasketsScope;

        static LoggerDefinitions()
        {
            _repoRepoAction = LoggerMessage.Define(LogLevel.Information, 0,
                $"Inside the repository about to call GetUserBaskets.");

            _repoCallGetManyRepo = LoggerMessage.Define<string>(LogLevel.Debug, DataEvents.GetMany,
                "Debugging information for user: {UserId}");

            _apiGetAllBasketsScope = LoggerMessage.DefineScope<string>(
                "Constructing basket response for {UserId}");
        }

        public static void RepoGetBaskets(this ILogger logger)
        {
            _repoRepoAction(logger, null);
        }

        public static void RepoCallGetMany(this ILogger logger, string repo)
        {
            _repoCallGetManyRepo(logger, repo, null);
        }

        public static IDisposable ApiGetAllBasketsScope(this ILogger logger, string userId)
        {
            return _apiGetAllBasketsScope(logger, userId);
        }
    }
}