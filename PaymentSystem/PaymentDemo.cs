using System;
using PaymentSystem;

class PaymentDemo
{
    static void Main()
    {
        var context = new PaymentContext();

        context.SetStrategy(new CardPaymentStrategy("1234-5678-9012-3456"));
        context.PayAmount(5000);

        context.SetStrategy(new PayPalPaymentStrategy("user@example.com"));
        context.PayAmount(12000);

        context.SetStrategy(new CryptoPaymentStrategy("0xABCDEF1234567890"));
        context.PayAmount(3000);
    }
}
