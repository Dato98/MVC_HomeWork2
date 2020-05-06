using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.ViewComponent
{
    public class AddViewComponent
    {
        private IAddRepository addRepository;

        public AddViewComponent(IAddRepository _addRepository)
        {
            addRepository = _addRepository;
        }

        public IViewComponentResult Invoke()
        {
            AddModel add = addRepository.Adds.FirstOrDefault();
            return new HtmlContentViewComponentResult(new HtmlString($"<iframe src='{add.Url}' frameborder='0' scrolling='no' width='100%' height='100%'></iframe>"));
        }
    }
}
