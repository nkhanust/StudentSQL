using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace StudentSQL
{
    public class Service : IService
    {
        private readonly ILogger<Service> log;
        private readonly IConfiguration _config;


        public Service(ILogger<Service> log, IConfiguration config)
        {
            this.log = log;
            _config = config;
        }


        public void Run()
        {

        }

    }
}