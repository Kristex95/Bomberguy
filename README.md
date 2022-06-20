# Bomberguy
2D Local multiplayer game
При реалізації ми використовували мультипоточність та патерни.
Гру розроблено в середовищі Unity.
Ми використали наступні патерни:
1. Command
Уся ідея цього шаблона основана на двух елементах:
Command - щось схоже на запит. Цей елемент зберігає інформацію, яка буде виконуватись ініціатором команди.
Command Invoker - зберігає всі команди, очікуючи виконання в потрібний час. Invoker також можне одразу оброблювати команди, якщо ми того захочемо.
Ми використовували його для керування гравцем задопомогою зовнішніх пристроїв.(Bomber_Movement_Script)

2. Prototype
Основна ідея цього шаблому полягає в тому, що об'єкт може породжувати ішні, схожі на нього.
Використовуєтся при створені об'єкта "вибух" та породження наступних "вибухів" після початкового. Також застосовуєтся для створеня гравця. (Tilemap_Destuction)

3. State 
Це поведінковий патерн проектування, який дозволяє об'єктам змінювати поведінку в залежності від стану.
Ми використовували його для збільшення радіуса вибуху бомби при підбиранні бонусу та фокусу контролера з гравцями на кнопки коли активована пауза, та навпаки.(Player_Bomb_Placement)

4.Observer
Це поведінковий патерн проектування, який створює механізм підписки, що дає змогу одним об’єктам стежити й реагувати на події, які відбуваються в інших об’єктах.
Використовуєтся при перевірці чи всі гравці живі в менеджері гри. (GameControler)

Мультипоточність ми робили з використанням Coroutine
Coroutine - це функція, яка дозволяє призупинити її використання та відновити з тієї ж точки після виконання умови. 
Ми можемо сказати, що це особоливий тип функції, яка використовується в unity, щоб зупинити виконання до тих пір, поки не буде виконана певна умова і прродовжиться з того місця, де вона була зупинена.
Coroutine можна використовувати з двох причин: асинхронного коду та коду, який потребую обчислення для кількох кадрів.
Ми ж використовували його при запуску таймера бомби, після чого вона вибухала. (Bomb_Script)
