using System.Reflection;
using System.Windows;

namespace Paint_Lab
{
    public static class AssemblyClass
    {
        public static Assembly ConnectAsm(string path)
        {
            var assembly = Assembly.LoadFrom("BaseClassesPlugin.dll");
            MessageBox.Show($"{assembly.FullName}");
            var types = assembly.GetTypes();
            foreach (var t in types)
            {
                MessageBox.Show($"{t.Name}");
            }

            return assembly;
        }
    }
}