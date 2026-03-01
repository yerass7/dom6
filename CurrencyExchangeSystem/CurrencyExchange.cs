using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeSystem
{
    // ===== OBSERVER =====
    public interface IObserver
    {
        Task Update(string currency, decimal rate);
    }

    // ===== SUBJECT =====
    public interface ISubject
    {
        void Subscribe(string currency, IObserver observer);
        void Unsubscribe(string currency, IObserver observer);
        Task Notify(string currency, decimal rate);
    }

    // ===== CURRENCY EXCHANGE =====
    public class CurrencyExchange : ISubject
    {
        private readonly Dictionary<string, List<IObserver>> _subscribers = new();
        private readonly Dictionary<string, decimal> _rates = new();

        public void Subscribe(string currency, IObserver observer)
        {
            if (!_subscribers.ContainsKey(currency))
                _subscribers[currency] = new List<IObserver>();

            _subscribers[currency].Add(observer);
            Console.WriteLine($"Подписка: {observer.GetType().Name} на {currency}");
        }

        public void Unsubscribe(string currency, IObserver observer)
        {
            if (_subscribers.ContainsKey(currency))
                _subscribers[currency].Remove(observer);
        }

        public async Task SetRate(string currency, decimal rate)
        {
            _rates[currency] = rate;
            Console.WriteLine($"Курс {currency} = {rate}");
            await Notify(currency, rate);
        }

        public async Task Notify(string currency, decimal rate)
        {
            if (!_subscribers.ContainsKey(currency)) return;

            var tasks = _subscribers[currency].Select(o => o.Update(currency, rate));
            await Task.WhenAll(tasks);
        }
    }

    // ===== OBSERVERS =====

    public class SmsNotifier : IObserver
    {
        private readonly string _phone;
        public SmsNotifier(string phone) { _phone = phone; }

        public Task Update(string currency, decimal rate)
        {
            Console.WriteLine($"SMS на {_phone}: курс {currency} обновлен на {rate}");
            return Task.CompletedTask;
        }
    }

    public class EmailNotifier : IObserver
    {
        private readonly string _email;
        public EmailNotifier(string email) { _email = email; }

        public Task Update(string currency, decimal rate)
        {
            Console.WriteLine($"Email на {_email}: курс {currency} обновлен на {rate}");
            return Task.CompletedTask;
        }
    }

    public class MobileAppNotifier : IObserver
    {
        public Task Update(string currency, decimal rate)
        {
            Console.WriteLine($"Приложение: курс {currency} обновлен на {rate}");
            return Task.CompletedTask;
        }
    }
}
