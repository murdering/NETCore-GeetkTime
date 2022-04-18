using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DependencyInjectionDemo.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyInjectionDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ע�����ͬ�������ڵķ���
            services.AddSingleton<IMySingletonService, MySingletonService>();

            services.AddScoped<IMyScopedService, MyScopedService>();

            services.AddTransient<IMyTransientService, MyTransientService>();

            #endregion

            #region ��ʽע��
            services.AddSingleton<IOrderService>(new OrderService());  //ֱ��ע��ʵ��
            services.AddSingleton<IOrderService, OrderServiceEx>();
            //services.AddSingleton<IOrderService, OrderService>();
            //services.AddSingleton<IOrderService, OrderService>();
            //services.AddSingleton<IOrderService>(serviceProvider =>
            //{
            //    return new OrderServiceEx();
            //});

            //services.AddScoped<IOrderService>(serviceProvider =>
            //{

            //    return new OrderServiceEx();
            //});

            #endregion

            #region ����ע��
            //services.TryAddSingleton<IOrderService, OrderServiceEx>();

            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService>(new OrderServiceEx()));

            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService>(p =>
            //{
            //    return new OrderServiceEx();
            //}));
            #endregion

            #region �Ƴ����滻ע��
            //services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());
            //services.RemoveAll<IOrderService>();
            
            #endregion




            #region ע�᷺��ģ��
            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
