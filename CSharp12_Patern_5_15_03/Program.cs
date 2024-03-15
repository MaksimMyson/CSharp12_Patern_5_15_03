namespace CSharp12_Patern_5_15_03
{
    class VendingMachine
    {
        private IState currentState;

        public VendingMachine()
        {
            // Початковий стан - автомат вимкнений
            currentState = new OffState();
        }

        public void SetState(IState state)
        {
            currentState = state;
        }

        public void InsertCoin()
        {
            currentState.InsertCoin(this);
        }

        public void PressButton()
        {
            currentState.PressButton(this);
        }

        public void Dispense()
        {
            currentState.Dispense(this);
        }
    }

    
    interface IState
    {
        void InsertCoin(VendingMachine machine);
        void PressButton(VendingMachine machine);
        void Dispense(VendingMachine machine);
    }

    //  Стан: автомат вимкнений
    class OffState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("Cannot insert coin. Vending machine is off.");
        }

        public void PressButton(VendingMachine machine)
        {
            Console.WriteLine("Cannot press button. Vending machine is off.");
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("Cannot dispense. Vending machine is off.");
        }
    }

    // Стан: автомат включений
    class OnState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("Coin inserted.");
            machine.SetState(new CoinInsertedState());
        }

        public void PressButton(VendingMachine machine)
        {
            Console.WriteLine("Cannot press button. Coin is not inserted.");
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("Cannot dispense. Coin is not inserted.");
        }
    }

    //  Стан: монета вставлена
    class CoinInsertedState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("Coin already inserted.");
        }

        public void PressButton(VendingMachine machine)
        {
            Console.WriteLine("Button pressed. Dispensing product.");
            machine.SetState(new OnState());
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("Cannot dispense. Button is not pressed.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine();

            // Спроба натиснути кнопку при вимкненому автоматі
            machine.PressButton();

            // Включаємо автомат
            machine.SetState(new OnState());

            // Спроба натиснути кнопку без вставленої монети
            machine.PressButton();

            // Вставляємо монету
            machine.InsertCoin();

            // Спроба вставити монету, коли вона вже вставлена
            machine.InsertCoin();

            // Натискаємо кнопку
            machine.PressButton();
        }
    }
}
