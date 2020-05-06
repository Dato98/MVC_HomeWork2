using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.ViewComponent
{
    public class SliderViewComponent : ViewComponent
    {
        private ISliderRepository sliderRepository;

        public SliderViewComponent(ISliderRepository sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = sliderRepository.sliderItems;
            return View(model);
        }
    }
}
