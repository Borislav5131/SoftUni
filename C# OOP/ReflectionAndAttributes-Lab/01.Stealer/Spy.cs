using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass,params string[] namesOfFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(nameOfClass);
            FieldInfo[] classFieldInfos = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classType.GetType().Namespace}");

            foreach (var field in classFieldInfos)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType($"Stealer.{className}");
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            publicMethodInfo = publicMethodInfo.Where(x => x.Name.StartsWith("get")).ToArray();
            nonPublicMethodInfo = nonPublicMethodInfo.Where(x => x.Name.StartsWith("set")).ToArray();

            foreach (var field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in nonPublicMethodInfo)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in publicMethodInfo)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classsType = Type.GetType(className);

            MethodInfo[] methods =
                classsType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var methodInfo in methods.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
            }

            foreach (var methodInfo in methods.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
