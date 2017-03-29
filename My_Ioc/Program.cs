using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Ioc
{
    class Program
    {
        static void Main(string[] args)
        {
            //var regionFormat = ConfigUnity<IRegionFormat>("defaultContainer");

            var regionFormat = ServiceLocator.Instance.GetService<IRegionFormat>();

            WirteFormat(regionFormat);
            Console.ReadLine();
        }

        /// <summary>
        /// 通过编码的方式进行注入，无需配置文件进行配置
        /// </summary>
        /// <returns></returns>
        static IUnityContainer GetRegisterContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IRegionFormat, DefaultRegionFormat>();

            return container;
        }

        /// <summary>
        /// 通过配置文件的方式进行注入
        /// 此处修改为使用泛型的方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containerSection"></param>
        /// <returns></returns>
        static T ConfigUnity<T>(string containerSection)
        {
            IUnityContainer container = new UnityContainer();

            UnityConfigurationSection section = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;

            section.Configure(container, containerSection);

            //解决给定名称的请求类型的一个实例的容器。
           return container.Resolve<T>();
        }

        /// <summary>
        /// 日期格式输出
        /// </summary>
        /// <param name="format"></param>
        static void WirteFormat(IRegionFormat format)
        {
            if (format != null)
            {
                Console.WriteLine("格式名称：{0}；当前时间：{1}"
                    , format.FormatName, format.GetShortTimeString(DateTime.Now));
            }
        }
    }
}
