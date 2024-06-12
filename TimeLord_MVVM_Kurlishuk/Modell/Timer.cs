using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TimeLord_MVVM_Kurlishuk.ViewModell;

namespace TimeLord_MVVM_Kurlishuk.Modell
{
    public class Timer : INotifyPropertyChanged
    {
        /// <summary>
        ///  Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            // Если есть изменение свойства
            if (PropertyChanged != null)
                // Сообщаем о том, что произошло изменение свойства
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Таймер [Свойство]
        /// </summary>
        public string Counter
        {
            // Аксессор чтения
            get
            {
                // Получаем часы из переменной Time
                float Hour = (Time / 60f / 60f);
                // Получаем минуты из переменной Time
                float Minute = (Time / 60f) - ((int)Hour * 60f);
                // Получаем секунды из переменной Time
                float Second = Time - (int)Hour * 60f * 60f - (int)Minute * 60f;
                // Преобразовываем время таким образом, что если час, минута, или секунда
                // Меньше 10, добавляем вперёд 0
                string sHour = ((int)Hour).ToString();
                string sMinute = ((int)Minute).ToString();
                string sSecond = ((int)Second).ToString();
                if (Hour < 10) sHour = "0" + ((int)Hour).ToString();
                if (Minute < 10) sMinute = "0" + ((int)Minute).ToString();
                if (Second < 10) sSecond = "0" + ((int)Second).ToString();
                // Возвращаем полученный результат
                return $"{sHour}:{sMinute}:{sSecond}";
            }
            set
            {
                try
                {
                    string[] time = value.Split(':');
                    int Hour = int.Parse(time[0]);
                    int Minute = int.Parse(time[1]);
                    int Second = int.Parse(time[2]);
                    Time = Hour * 60 * 60 + Minute * 60 + Second;
                }
                catch 
                {
                    Time = 0;
                }
            }
        }

        /// <summary>
        /// Прошедшее время
        /// </summary>
        private int time;
        /// <summary>
        /// Прошедшее время [Свойство]
        /// </summary>
        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                // Сообщаем об изменении
                OnPropertyChanged("Counter");
            }
        }

        /// <summary>
        /// Работа таймера
        /// </summary>
        public bool Work;

        /// <summary>
        /// Текст кнопки
        /// </summary>
        private string textButton = "Начать";
        /// <summary>
        /// Текст кнопки [Свойство кнопки]
        /// </summary>
        public string TextButton
        {
            get { return textButton; }
            set
            {
                textButton = value;
                OnPropertyChanged("TextButton");
            }
        }

        /// <summary>
        /// Специальная коллекция, которая уведомляет систему об изменении
        /// </summary>
        public ObservableCollection<string> Interval { get; set; }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Timer()
        {
            // Инициализируем коллекцию
            Interval = new ObservableCollection<string>();
        }

        /// <summary>
        /// Выполнение старта
        /// </summary>
        private RelayCommand startTimer;
        /// <summary>
        /// Выполнение старта [Свойство]
        /// </summary>
        public RelayCommand StartTimer
        {
            // Аксессор чтения
            get
            {
                // Если у нас существует выполнение страта, то выполняем его
                // если не существует
                return startTimer ??
                    // обновляем новую команду
                    (startTimer = new RelayCommand(obj =>
                    {
                        // Если таймер не работает
                        if (Work == false)
                        {
                            // Очищаем интервал
                            Interval.Clear();
                            // Говорим, что таймер работает
                            Work = true;
                            // Изменяем текст кнопки
                            TextButton = "Стоп";
                        }
                        else
                        {
                            // Если таймер работает,
                            // говорим, что таймер не работает
                            Work = false;
                            // Изменяем текст копки
                            TextButton = "Начать";
                        }
                    }));
            }
        }

        /// <summary>
        /// Интервал
        /// </summary>
        private RelayCommand intervalTimer;
        /// <summary>
        /// Интервал [Свойство]
        /// </summary>
        public RelayCommand IntervalTimer
        {
            get
            {
                // Если у нас существует действие интервала, то выполняем его,
                // если не существует
                return intervalTimer ??
                    // Создаём действие
                    (intervalTimer = new RelayCommand(obj =>
                    {
                        // Если таймер в работе
                        if (Work)
                            // Добавляем в коллекцию, значение таймера
                            Interval.Insert(0, Counter);
                    }));
            }
        }
    }
}
