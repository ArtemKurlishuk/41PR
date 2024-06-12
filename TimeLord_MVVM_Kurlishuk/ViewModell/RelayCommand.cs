using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TimeLord_MVVM_Kurlishuk.ViewModell
{
    public class RelayCommand : ICommand
    {
        // Метод, который будет выполняться
        private Action<object> execute;
        // Возмодность выполнения метода
        private Func<object, bool> canExecute;
        // Событие, которое добавляет и удаляет метод на выполнение
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        // Конструктор для регистрации выполняемого метода
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        // Проверяем может ли выполниться метод
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        // Выполняем метод
        public void Execute(object parameter) =>
            this.execute(parameter);

    }
}
