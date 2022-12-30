using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmpPostsService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private static void ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (mode, ea) => {
                var contextOptions = new DbContextOptionsBuilder<BatchDBContext>().UseNpgsql(@"Server=localhost; Database=BatchDB; user id=postgres; password=senpai").Options;
                var dbContext = new BatchDBContext(contextOptions);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                if (type == "course.add")
                {
                    dbContext.Courses.Add(new Course() { CourseId = data["CourseId"].Value<string>() });
                    dbContext.SaveChanges();
                }
            };
            channel.BasicConsume(queue: "course.batchsvc", autoAck: true, consumer: consumer);
        }
    }
}
