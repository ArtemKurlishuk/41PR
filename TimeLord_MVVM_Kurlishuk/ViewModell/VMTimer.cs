using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;
using TimeLord_MVVM_Kurlishuk.Modell;

namespace TimeLord_MVVM_Kurlishuk.ViewModell
{
    public class VMTimer : INotifyPropertyChanged
    {
        /// <summary>
        /// Модель данных таймера
        /// </summary>
        public Timer Timer { get; set; }
        private DispatcherTimer TimerStep = new DispatcherTimer()
        {
            // Интервал таймера 1 секунда
            Interval = new TimeSpan(0, 0, 1)
        };

        /// <summary>
        /// Конструктор таймера
        /// </summary>
        public VMTimer()
        {
            // Инициализируем таймер
            Timer = new Timer() { Work = false, Time =  5};
            // Подписываемся на метод выполнения таймера
            TimerStep.Tick += Timer_Tick;
            // Запускаем таймер
            TimerStep.Start();
        }

        /// <summary>
        /// Метод выполнения таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Если таймер запущен 
            if (Timer.Work && Timer.Time > 0)
                // Увеличиваем время
                Timer.Time--;
            else
            {
                Timer.Work = false;
                Timer.TextButton = "Начать";
            }
        }

        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            // Если есть изменение свойства
            if (PropertyChanged != null)
                // Сообщаем о том, что произошло изменение свойства
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
