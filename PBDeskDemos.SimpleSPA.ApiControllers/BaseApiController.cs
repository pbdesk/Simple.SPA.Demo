using PBDeskDemos.SimpleSPA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PBDeskDemos.SimpleSPA.ApiControllers
{
    public class BaseApiController : ApiController
    {
        protected RepoHelper Repo = new RepoHelper();

        protected void Log(Exception ex)
        {
            if (ex != null)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }

        protected void Log(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Log(new Exception(message));
            }
        }

        protected void Log(string message, Exception ex)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Log(ex);
            }
            else
            {
                Log(new Exception(message, ex));
            }
        }
    }
}
