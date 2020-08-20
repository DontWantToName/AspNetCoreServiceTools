using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


public static class AspNetCoreServiceTools
{
        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="dllName">注入项目名称</param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services, string dllName)
        {
            if (!string.IsNullOrEmpty(dllName))
            {
                //获取dll
                var types = Assembly.Load(new AssemblyName(dllName)).GetTypes().ToList();
                //获取dll下所有类型
                foreach (var item in types)
                {
                    //类型必须是类  实现接口必须大于0
                    if (item.IsClass && item.GetInterfaces().Length > 0)
                    {
                        foreach (var iSer in item.GetInterfaces())
                        {
                            DI(services, item, iSer);
                        }
                    }
                    else if (item.IsClass && item.GetInterfaces().Length <= 0)
                    {
                        DI(services,item);
                    }
                }
            }
            return services;
        }

        private static void DI(IServiceCollection services,Type item,Type interFace=null)
        {
            var attribute = (IdentifyingAttribute) item.GetCustomAttributes(typeof(IdentifyingAttribute), false)[0];
            if (attribute != null)
            {
                switch (attribute.ServiceLifeTime.ToString())
                {
                    case "Transient" when interFace!=null:
                        services.AddTransient(interFace, item);
                        break;
                    case "Scoped" when interFace != null:
                        services.AddScoped(interFace,item);
                        break;
                    case "Singleton" when interFace != null:
                        services.AddSingleton(interFace, item);
                        break;
                    case "Transient":
                        services.AddTransient(item);
                        break;
                    case "Scoped":
                        services.AddScoped(item);
                        break;
                    case "Singleton":
                        services.AddSingleton(item);
                        break;
                }
            }
        }
}

