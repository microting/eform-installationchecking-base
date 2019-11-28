namespace Microting.InstallationCheckingBase.Infrastructure.Models
{
    public class InstallationCheckingBaseSettings
    {
        public string MaxNumberOfWorkers { get; set; }
        public string MaxParallelism { get; set; }
        public string SdkConnectionString { get; set; }
        public string InstallationFormId { get; set; }
    }
}