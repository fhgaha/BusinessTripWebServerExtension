﻿using Autofac;
using BusinessTripWebServerExtension.Services;
using DocsVision.WebClient.Extensibility;
using DocsVision.WebClient.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace BusinessTripWebServerExtension
{
    /// <summary>
    /// Задаёт описание расширения для WebClient, которое задано в текущей сборке
    /// </summary>
    public class BusinessTripWebServerExtension : WebClientExtension
    {
        /// <summary>
        /// Создаёт новый экземпляр <see cref="BusinessTripWebServerExtension" />
        /// </summary>
        /// <param name="serviceProvider">Сервис-провайдер</param>
        public BusinessTripWebServerExtension(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <summary>
        /// Получить название расширения
        /// </summary>
        public override string ExtensionName
        {
            get { return Assembly.GetAssembly(typeof(BusinessTripWebServerExtension)).GetName().Name; }
        }

        /// <summary>
        /// Получить версию расширения
        /// </summary>
        public override Version ExtensionVersion
        {
            get { return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion); }
        }

        #region WebClientExtension Overrides

        /// <summary>
        /// Регистрация типов в IoC контейнере
        /// </summary>
        /// <param name="containerBuilder"></param>
        public override void InitializeContainer(ContainerBuilder containerBuilder)
        {
            // Теперь регистрация сервисов и других объектов ВК осуществляется в едином методе - InitializeContainer, 
            // примеры регистрации различных типов ВК представлены ниже
            // containerBuilder.RegisterType<YourService>().As<IYourService>().SingleInstance();
            // containerBuilder.RegisterOrderedType<YourBindingConverterType, IBindingConverter>();
            // containerBuilder.RegisterOrderedType<YourBindingResolverType, IBindingResolver>();            
            // containerBuilder.RegisterOrderedType<YourControlResolverType, IControlResolver>();
            // containerBuilder.RegisterOrderedType<YourPropertyResolverType, IPropertyResolver>();  
            // containerBuilder.RegisterType<YourCardLifeCycle>().Keyed<ICardLifeCycle>(CardTypeID).SingleInstance();
            // containerBuilder.RegisterType<YourRowLifeCycle>().Keyed<IRowLifeCycle>(SectionID).SingleInstance(); 

            containerBuilder.RegisterType<CustomEmployeeService>().As<ICustomEmployeeService>().SingleInstance();
            containerBuilder.RegisterType<CustomCityService>().As<ICustomCityService>().SingleInstance();
            containerBuilder.RegisterType<CustomApprovingStageOperationService>().As<ICustomApprovingStageOperationService>().SingleInstance();
        }

        /// <summary>
        /// Gets resource managers for layout extension
        /// </summary>
        /// <returns></returns>
        protected override List<ResourceManager> GetLayoutExtensionResourceManagers()
        {
            return new List<ResourceManager>
            {

            };
        }

        #endregion
    }
}