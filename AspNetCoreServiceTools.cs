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
    /// <param name="dllName">实现接口项目名称</param>
    /// <param name="transientNamespace">transient命名空间名称</param>
    /// <param name="scopedNamespace">scoped命名空间名称</param>
    /// <param name="singletonNamespace">singleton命名空间名称</param>
    /// <returns></returns>
    public static IServiceCollection RegisterServices(this IServiceCollection services, string dllName, string transientNamespace, string scopedNamespace, string singletonNamespace)
    {
        if (!string.IsNullOrEmpty(dllName))
        {
            //获取dll
            var types = Assembly.Load(new AssemblyName(dllName)).GetTypes().ToList();

            //获取dll下所有类型
            foreach (var item in types)
            {
                //类型必须是类 并且实现的接口大于0
                if (item.IsClass && item.GetInterfaces().Length > 0)
                {
                    //注入
                    foreach (var iSer in item.GetInterfaces())
                    {
                        if (item.Namespace.Contains(transientNamespace))
                        {
                            services.AddTransient(iSer, item);
                        }
                        else if (item.Namespace.Contains(scopedNamespace))
                        {
                            services.AddScoped(iSer, item);
                        }
                        else if (item.Namespace.Contains(singletonNamespace))
                        {
                            services.AddSingleton(iSer, item);
                        }
                    }
                }
            }
        }

        return services;
    }
}

