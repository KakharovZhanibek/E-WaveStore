using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class OrderPresentation : IOrderPresentation
    {
        private IOrderRepository _orderRepository;
        private IPaymentTypeRepository _paymentTypeRepository;
        private IMapper _mapper;

        public const int PageSize = 5;

        public OrderPresentation(IOrderRepository orderRepository, IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;            
        }
        public void AddOrder(OrderVM orderVM)
        {
            var order = _mapper.Map<Order>(orderVM);
            _orderRepository.Save(order);
        }

        public bool RemoveOrder(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            if (order == null)
            {
                return false;
            }

            _orderRepository.Remove(order);

            return true;
        }

        public List<string> GetAllPaymentTypeNames()
        {            
            return _paymentTypeRepository.GetAll().Select(x => x.Name).ToList();
        }


    }
}
