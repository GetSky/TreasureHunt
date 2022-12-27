# Treasure Hunt

## Elevator Pitch
- Пазл-игра на поиск по подсказкам. Это как классический сапер, но с инверсией задачи.
- Карточная пошаговая пазл-игра инверсный сапер в сеттинге недалекого бедующего.

## Общая информация
|||
| ---------------------- |:-------------------------------------|
| Жанр                   | Сапер (инверсивный)                  |
| Сеттинг                | Различные биомы в недалёком будущем. |
| Камера                 | Изометрия, 3D                        |
| Модель распространения | Free-to-play                         |
| Платформа              | Mobile, browser                      |

## USP
- Сапёр наоборот: нужно найти спрятанный клад на поле с клетками по подсказкам находящимся в клетках.
- Подсказки это колода карт, которую игрок собирает. Разные карты представляют собой разные типы подсказок. 
  Игрок имеет возможность прокачивать свои карты и составлять колоду под себя и уровни.
- Ненавязчивый сюжет, который раскрывается постепенно, затягивая игрока в мир параллельной реальности.

## Игровой мир и сюжет
Главный герой искатель, который с помощью дрона занимается поисковыми работами в «новом» мире.
Игрок по мере игры получает новые крупицы информации об этом мире и меняет мнение о мире, в котором он оказался. 

## Игровой процесс

Игра разделена на 3 фазы:
- Выбор локации для прохождения.
- Поиск клада на уровне и сбор монет и карт с подсказками.
- Прокачка колоды подсказок.

При запуске игры появляется карта на которой отмечены локации доступные игроку для прохождения.
После прохождения локации, открываются новые локации, таким образом у игрока всегда есть выбор.

Предлагаемые локации отличаются сложностью на которую ориентируется игрок при выборе.
Более сложные локации дают большую награду, но и требуют более сильную колоду подсказок.

После выбора происходит переход с карты на локацию.
Игроку дается определенное количество ходов за которые он должен найти клад.
На локации есть игровое поле состоящее из клеток.
Чем сложнее уровень, тем меньше запас ходов и тем больше клеток на игровом поле.

![scene.png](scene.png)

Игрок открывает клетку, после чего показывается содержимое.
Клетка может содержать в себе клад, подсказку о месторасположении клада, монеты или карты.
После того как игрок найдет клад, игрок получает вознаграждение и возвращается на карту.

С помощью монет игрок покупает новые подсказки.
Через объединение одинаковых карт усиливает карту.

### Типы карт
- Дистанция до клада — показывает расстояние до клада и подсвечивает клетки на этой дистанции на пару секунд.
- Направление до клада
- Дополнительная энергия — запас дополнительных ходовходов на текущий уровень.
- Случайное открытие нескольких ячеек
- Сканер расположения карт
- Монета — внутриигровая валюта. 
- Бомбочка

## Аналоги на рынке
- ["Finders Sweepers Treasure Hunt"](https://play.google.com/store/apps/details?id=com.exceptionullgames.finders.sweepers) — Так же нужно искать определённое количество «мин», а не открывать всю территорию. Все остальное как в классическом сапере. 
