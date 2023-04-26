using System.Reflection;

namespace MusicCatalog.Infrastructure
{
    public static class AssemblyReference
    {
        public static Assembly InfrastructureAssembly => typeof(AssemblyReference).Assembly;
    }
}
