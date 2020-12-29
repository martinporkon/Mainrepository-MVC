using System;
using Microsoft.Extensions.Logging;
using Sooduskorv_MVC.Aids.Events;

namespace Sooduskorv_MVC.Aids.Logging
{
    public static class LoggerExtensions
    {
        private static readonly Action<ILogger, Exception> RepoRepoAction;
        private static readonly Action<ILogger, string, Exception> RepoCallGetManyRepo;
        private static readonly Func<ILogger, string, IDisposable> _apiGetAllBasketsScope;

        static LoggerExtensions()
        {
            RepoRepoAction = LoggerMessage.Define(LogLevel.Information, 0,
                $"Inside the repository about to call GetUserBaskets.");

            RepoCallGetManyRepo = LoggerMessage.Define<string>(LogLevel.Debug, DataEvents.GetMany,
                "Debugging information for user: {UserId}");

            _apiGetAllBasketsScope = LoggerMessage.DefineScope<string>(
                "Constructing basket response for {UserId}");
        }

        public static void RepoGetBaskets(this ILogger logger)
        {
            RepoRepoAction(logger, null);
        }

        public static void RepoCallGetMany(this ILogger logger, string repo)
        {
            RepoCallGetManyRepo(logger, repo, null);
        }

        public static IDisposable ApiGetAllBasketsScope(this ILogger logger, string userId)
        {
            return _apiGetAllBasketsScope(logger, userId);
        }
    }
}