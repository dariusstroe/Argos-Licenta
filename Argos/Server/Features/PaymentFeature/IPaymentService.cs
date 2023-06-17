using Stripe.Checkout;

namespace Argos.Server.Features.PaymentFeature
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}
