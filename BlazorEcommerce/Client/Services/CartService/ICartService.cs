﻿namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {

        event Action OnChange;

        Task AddToCart(CartItem cartItem);

        Task<List<CartItem>> GetCartItems();

        Task DeleteItem(CartItem item);

        Task EmptyCart();

        Task purchaseAsync(EmailDTO emaildto);



    }
}
