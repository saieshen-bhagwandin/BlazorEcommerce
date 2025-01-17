﻿

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly ISyncLocalStorageService _localstorage;

        UserRegisterRequest theuser = new UserRegisterRequest();

        public OrderService( HttpClient http, ISyncLocalStorageService localstorage)
        {

            _http = http;
            _localstorage = localstorage;
        }

        public List<Orders> Orders { get; set; } = new List<Orders>();
        public List<Orders> ROrders { get; set; } = new List<Orders>();

        public event Action OrdersChanged;

        public async Task<string> AddOrderAsync(EmailDTO email)
        {
            var result = await _http.PostAsJsonAsync("api/order/add", email);

            var resultString = await result.Content.ReadAsStringAsync();

            return resultString;
        }

        public async Task GetOrder(string email)
        {

            var user = _localstorage.GetItem<UserRegisterRequest>("userinfo");

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Orders>>>($"api/order/getorders/{user.Email}");


            if (result != null && result.Data != null)
            {
                Orders = result.Data;
                ROrders = result.Data.OrderByDescending(c => c.Id).ToList();
            }

            OrdersChanged.Invoke();

           

        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            var result = await _http.GetFromJsonAsync<Orders>($"api/order/{id}");

            return result;

        }
    }
}
