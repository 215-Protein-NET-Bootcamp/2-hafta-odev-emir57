using _3_hafta.Business.Abstract;
using _3_hafta.Business.Concrete;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.DataAccess.Concrete.Dapper;
using _3_hafta.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;

namespace _3_hafta.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            #region DataAccess
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();
            builder.RegisterType<EfFolderDal>().As<IFolderDal>();
            builder.RegisterType<DpCountryDal>().As<ICountryDal>();
            builder.RegisterType<DpDepartmentDal>().As<IDepartmentDal>();
            #endregion

            #region Business
            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<FolderManager>().As<IFolderService>();
            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
