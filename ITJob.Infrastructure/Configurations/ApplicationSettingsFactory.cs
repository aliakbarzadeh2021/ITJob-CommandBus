using ITJob.Infrastructure.Configurations;

namespace ITJob.Infrastructure.Configurations
{
    public static class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingsFactory(
            IApplicationSettings settings)
        {
            _applicationSettings = settings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSettings;
        }
    }
}