using System;
using System.Windows.Forms;
using Autofac;
using AutoMapper;
using DataObject;

namespace TestProject.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.RegisterMappings();
            Register.Ioc();
            Application.Run(new Form1());
        }
    }



    public static class AutoMapperConfig
    {
        public static void RegisterMappings() => Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<TestProject.Model.Products, Dto.ProductDto>()
                .ReverseMap();
        });
    }

    public static class Register
    {
        public static IContainer Container { get; set; }
        public static void Ioc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataObject.Dapper.Product>().As<IProduct>();
            Container = builder.Build();
        }
    }


}
