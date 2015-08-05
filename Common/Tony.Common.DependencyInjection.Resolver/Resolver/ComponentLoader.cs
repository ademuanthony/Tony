using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity;
using Tony.Common.DependencyInjection.Locator;

namespace Tony.Common.DependencyInjection.Resolver
{
    public static class ComponentLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        var exports = componsitionContainer.GetExports(importDef);

                        var modules =
                            exports.Select(export => export.Value as IComponent).Where(m => m != null);

                        // register service locator
                        container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();

                        var registerComponent = new RegisterComponent(container);
                        foreach (var module in modules)
                        {
                            module.SetUp(registerComponent);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (var loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IComponent).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    internal class RegisterComponent : IRegisterComponent
    {
        private readonly IUnityContainer _container;

        public RegisterComponent(IUnityContainer container)
        {
            _container = container;
            //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception
            }
            else
            {
                _container.RegisterType<TFrom, TTo>();
            }
        }


        public void RegisterType(Type fromType, Type toType, bool withInterception = false)
        {
            if (withInterception)
            {
                //register with interception
            }
            else
            {
                _container.RegisterType(fromType, toType);
            }
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }

        public void RegisterTypeWithControlledLifeTime(Type fromType, Type toType, bool withInterception = false)
        {
            if (withInterception)
            {
                //register with interception
            }
            else
            {
                _container.RegisterType(fromType, toType, new ContainerControlledLifetimeManager());
            }
        }


    }
}
