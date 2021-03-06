using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Composition;
using Cake.Core.Diagnostics;

[assembly: CakeModule(typeof(Cake.TFBuild.Module.TFBuildModule))]

namespace Cake.TFBuild.Module
{
    public class TFBuildModule : ICakeModule
    {
        public void Register(ICakeContainerRegistrar registrar)
        {
            if (!string.IsNullOrWhiteSpace(System.Environment.GetEnvironmentVariable("TF_BUILD")))
            {
                registrar.RegisterType<TFBuildEngine>().As<ICakeEngine>().Singleton();
                registrar.RegisterType<TFBuildLog>().As<ICakeLog>().Singleton();
                registrar.RegisterType<TFBuildReportPrinter>().As<ICakeReportPrinter>().Singleton();
            }
        }
    }
}