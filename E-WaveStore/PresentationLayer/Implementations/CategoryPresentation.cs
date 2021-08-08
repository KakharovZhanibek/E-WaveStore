using AutoMapper;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class CategoryPresentation : ICategoryPresentation
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryPresentation(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryVM GetByCategoryName(string categoryName)
        {
            var model = _categoryRepository.GetByCategoryName(categoryName);
            return _mapper.Map<CategoryVM>(model);
        }
    }
}
