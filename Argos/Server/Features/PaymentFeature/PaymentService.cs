using Stripe;
using Stripe.Checkout;

namespace Argos.Server.Features.PaymentFeature
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "mock_key";

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "mock_key";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();

            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = product.Title,
                        Images = new List<string>
                                {
                                    product.ImageUrl,
                                }
                    }
                },
                Quantity = product.Quantity,
            }));
            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string>
                    {
                        "RO"
                    },
                },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                //SuccessUrl = "https://localhost:7017/order-success",
                SuccessUrl = "https://argosserver20230617004559.azurewebsites.net/order-success",
                //CancelUrl = "https://localhost:7017/cart"
                CancelUrl = "https://argosserver20230617004559.azurewebsites.net/cart"

            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    request.Headers["Stripe-Signature"],
                    secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);

                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
