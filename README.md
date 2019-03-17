# Задание
  Разработать клиентское приложение, взаимодействующее с сервисом сети интернет на основе SOAP-протокола. В качестве сервера можно использовать любой сервис сети интернет, реализующий протокол SOAP для использования его функциональности (сервисы РЖД, Аэрофлота, сервисы погоды, банковские сервисы и т.п.)
Приложение получает информацио о погоде с помощью веб сервиса gismeteo (http://ws.gismeteo.ru)
### Запрос информации о погоде:

1. Выполнить регистрацию приложения с использованием метода RegisterHHUser, веб-сервис http://ws.gismeteo.ru/Registration/Register.asmx
Полученный ключ использовать в дальнейшем при выполнении запросов (значение поля key)
2. Выполнить запрос для кода региона с использованием метода FindByNameFull, веб-сервис http://ws.gismeteo.ru/Locations/Locations.asmx (параметры запроса: serial - значение, полученное на шаге 2, name – название города, count – количество результатов в ответе, language – значение «RU»);
3. Взять первый блок подходящий по названию страны блок data/LocationInfoFull, получить значение поля id
4. Выполнить запрос для получения информации о погоде с использованием метода GetHHForecast, веб-сервис http://ws.gismeteo.ru/Weather/Weather.asmx (параметры запроса: serial - значение, полученное на шаге 2, location – значение поля id, полученное на шаге 4)
5. Забрать значение блока data в ответ.