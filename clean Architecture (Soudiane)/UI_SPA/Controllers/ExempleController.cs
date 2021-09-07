
using Clean_Architecture_Soufiane.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI_SPA.Controllers;

namespace POS_API.Controllers
{
    public class ExempleController : ApiControllerBase
    {
      

        [HttpGet]
        public async void Create()
        {
            await Mediator.Send(new ExempleCommand());
        }

     

     
    }
}
