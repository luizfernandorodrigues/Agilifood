using AgiliFood.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AgiliFood
{
    /// <summary>
    /// Alteração: Modifica o metodo Application_Start adicionado a inicialização do autoMapper
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </summary>
    /// 
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegistrarMapeamentos();
        }
    }
}
