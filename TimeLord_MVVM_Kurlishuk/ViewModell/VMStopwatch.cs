using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;
using TimeLord_MVVM_Kurlishuk.Modell;

namespace TimeLord_MVVM_Kurlishuk.ViewModell
{
    public class VMStopwatch : INotifyPropertyChanged
    {
        /// <summary>
        /// Модель данных таймера
        /// </summary>
        public Stopwatch Stopwatch { get; set; }
        private DispatcherTimer Timer = new DispatcherTimer() {
            // Интервал таймера 1 секунда
            Interval = new TimeSpan(0,0,1)
        };

        /// <summary>
        /// Конструктор таймера
        /// </summary>
        public VMStopwatch() 
        {
            // Инициализируем таймер
            Stopwatch = new Stopwatch() { Work = false, Time = 0 };
            // Подписываемся на метод выполнения таймера
            Timer.Tick += Timer_Tick;
            // Запускаем таймер
            Timer.Start();
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
            if (Stopwatch.Work)
                // Увеличиваем время
                Stopwatch.Time++;
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
