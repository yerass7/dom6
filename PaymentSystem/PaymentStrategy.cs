using System;

namespace PaymentSystem
{
    // ===== STRATEGY INTERFACE =====
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // ===== CARD PAYMENT =====
    public class CardPaymentStrategy : IPaymentStrategy
    {
        private readonly string _cardNumber;
        public CardPaymentStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount}₸ банковской картой {_cardNumber} успешно выполнена.");
        }
    }

    // ===== PAYPAL PAYMENT =====
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        private readonly string _email;
        public PayPalPaymentStrategy(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount}₸ через PayPal аккаунт {_email} успешно выполнена.");
        }
    }

    // ===== CRYPTO PAYMENT =====
    public class CryptoPaymentStrategy : IPaymentStrategy
    {
        private readonly string _walletAddress;
        public CryptoPaymentStrategy(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount}₸ криптовалютой на кошелек {_walletAddress} успешно выполнена.");
        }
    }

    // ===== CONTEXT =====
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException("Strategy not set");
        }

        public void PayAmount(decimal amount)
        {
            if (_strategy == null)
                throw new InvalidOperationException("Payment strategy not selected");

            _strategy.Pay(amount);
        }
    }
}
