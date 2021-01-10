using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Options.Installers
{
    interface Installer
    {
        void InstallServices(IConfiguration configuration, IServiceCollection services);
    }
}