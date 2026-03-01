using System;
using System.Threading.Tasks;
using CurrencyExchangeSystem;

class CurrencyDemo
{
    static async Task Main()
    {
        var exchange = new CurrencyExchange();

        var sms = new SmsNotifier("+77001234567");
        var email = new EmailNotifier("user@example.com");
        var app = new MobileAppNotifier();

        exchange.Subscribe("USD", sms);
        exchange.Subscribe("USD", email);
        exchange.Subscribe("EUR", app);

        await exchange.SetRate("USD", 480);
        await exchange.SetRate("EUR", 510);

        // Динамическое удаление подписчика
        exchange.Unsubscribe("USD", email);
        await exchange.SetRate("USD", 485);
    }
}
