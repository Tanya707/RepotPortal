using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Contexts;
using Framework.Core.Pages;
using Framework.Core.Utilities;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Reqnroll;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    public class AllDashboardsSteps
    {
        private AllDashboardsPage allDashboardsPage = new AllDashboardsPage();
        private ConsoleLogger logger = new ConsoleLogger();

        public bool CheckLaunchesButton()
        {
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "3. Check Page"));
            return allDashboardsPage.LaunchesButton.Displayed;
        }
    }
}