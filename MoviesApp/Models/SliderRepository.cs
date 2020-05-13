using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public interface ISliderRepository
    {
        IEnumerable<SliderItem> sliderItems { get; }
    }

    public class SliderRepository : ISliderRepository
    {
        private List<SliderItem> Data = new List<SliderItem>()
        {
            new SliderItem(){Id = 1,Src = "https://images7.alphacoders.com/434/thumb-1920-434813.jpg"},
            new SliderItem(){Id = 2,Src = "https://wallpaperaccess.com/full/1103973.jpg"},
            new SliderItem(){Id = 2,Src = "https://wallpaperaccess.com/full/1103973.jpg"}
        };

        public IEnumerable<SliderItem> sliderItems => Data;
    }
}
