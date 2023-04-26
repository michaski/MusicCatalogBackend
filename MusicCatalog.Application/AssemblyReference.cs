using System.Reflection;

namespace MusicCatalog.Application
{
    public static class AssemblyReference
    {
        public static Assembly ApplicationAssembly => typeof(AssemblyReference).Assembly;
    }
}
