using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace gama_aec.Helpers
{
  public class LogadoAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if( string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["Cadastro de curriculo"]) )
      {
          filterContext.HttpContext.Response.Redirect("/login");
          return;
      }

      if (filterContext.Controller != null)
      {
         string usuarioLogado = filterContext.HttpContext.Request.Cookies["Cadastro de curriculo"];
         ((Controller)filterContext.Controller).TempData["usuarioLogado"] = usuarioLogado;
      }

      base.OnActionExecuting(filterContext);
    }
  }
}