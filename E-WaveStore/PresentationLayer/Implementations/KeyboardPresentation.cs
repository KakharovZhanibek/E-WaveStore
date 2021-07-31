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
    public class KeyboardPresentation : IKeyboardPresentation
    {
        private IKeyboardRepository _keyboardRepository;
   
        private IMapper _mapper;

        public const int PageSize = 3;

        public KeyboardPresentation(IKeyboardRepository keyboardRepository, IMapper mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;            
        }

        public PagingList<KeyboardVM> GetKeyboardList(int page)
        {
            var keyboards = _keyboardRepository
               .GetAll()
               .Select(x => _mapper.Map<KeyboardVM>(x))
               .OrderByDescending(x => x.BrandName)
               .ToList();
            var model = PagingList.Create(keyboards, PageSize, page);

            model.Action = "KeyboardList";
            return model;
        }
    }
}
