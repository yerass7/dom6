# dom6: Strategy & Observer Patterns in C#

Этот проект демонстрирует работу двух паттернов проектирования на C#: **Strategy** и **Observer**.

---

##1 Strategy — Payment System

Позволяет пользователю выбрать способ оплаты:

- **Способы оплаты**: Банковская карта, PayPal, Криптовалюта
- **Возможности**:
  - Легко менять стратегию оплаты
  - Легко добавлять новые методы оплаты
  - Минимум три стратегии реализованы

**Файлы:**

- `PaymentSystem/PaymentStrategy.cs` — интерфейс и классы стратегий оплаты
- `PaymentSystem/PaymentDemo.cs` — демонстрация работы паттерна Strategy

**Пример запуска:**

```bash
dotnet run --project PaymentSystem
