# CrazyPandaTestTask
### Оригинально задание(на всякий случай):

Задана 2D сцена с Box2d физикой. На разных концах сцены стоят 2 пушки, который стреляют в центр снарядами с медленной скоростью. В центре экрана находится круглая область, все объекты , которые попали в неё время замедляются в 10 раз. Требуется написать код, который реализует данную область с учетом столкновения снарядов и гравитации.

### Усложнение задания:

Задание в целом не очень сложное так что решил усложнить чтобы выделиться и показать навыки:

- Зоны искажения времни
    - Искажают время не равномерно от центра к краям(настраивается кривой)
    - При пересечении они смешиваются в 2-х режимах: среднее арифметическое и умножение значения искажения времени
    - Можно переключать зоны искажения
- Есть разные типы пуль которые по разному реагируют на эти зоны
    - Обычная пуля
    - Инвертированая пуля - инвертирует значение искажения времени у зон
    - Призрачная пуля - не сталкивается с другими пулями и показывает цветом значение искажения времени
    - Хаотичная пуля - хаотично добавляет импульсы
- Слайдеры искажения времени
    - Можно дополнительно настроить общее искажение времени
    - Можно отдельно настроить искажение времени для каждой пушки

### Управление:

- Стрельба - left mouse/right mouse
- Переключение пули - Ctr + left mouse/right mouse
- Переключение зоны - Ctr + Shift + left mouse/right mouse

### Концепты программирования:

Я быстро напишу что основная логика реализована не в Mono классах, просто фасадный скрипт(Bullet) создает нужные компоненты и обновляет. 

Я это делаю для полного контроля инициализации и порядка обновления, и чтобы классы логики могли наследоваться от классов помимо Mono.

### Road Map:

Можно начать с класса Game, там начинается течение логики, а можно пройтись по интересным вещам, это будет предпочтительнее(об этом ниже).

### Что нужно посмотреть/Самое интересное:

Я сосредоточился именно на механике искажения времени и на инфраструктуре для этой механики. Все остальное сделано просто и сердито.

- Time - для такой механики важно гибко работать с временем и инфраструктура ITimeProvider и TimeProviderDecorator позволяют это делать.
- Engine - это слой который работает с движением в условиях искажения времени, сдесь происходит все самое интересное.
    - Он полностью агрегирует функцию движения предоставляя удобный интерфейс, и пользовательский код использует его.
    - Плюс это абстракция на систему и это позволяет подменять реализации для пользовательского кода что конечно удобно.
    - Я не писал работу с вращениям чтобы сэкономить время, но она была бы аналогична работе с скоростью.
- ChronoSystem - это система отношений зоны(Area) и объекта. В целом тут ничего сложного, но сделано неплохо и позволяет расширяться(я не сделал абстракцию на Area потому что она одна и ее особо никто не использует).
- Взаимодействие модулей: Input, Factory, Gun, Bullet, BulletView, Areas хорошо выстроено. Соблюдается вертикльность зависимостей, выделяются абстракции и т.д. Также можно проследить за всей цепочкой ITimeProvider от Game до Bullet.
- Effect & AnimatorBulletView - там показано то как View часть должна работать с замедлением времени. Я реализовал только Animation, но с Audio и Particles было бы примерно то же самое, класс обертка который работает с временем.

В целом я везде старался хорошо писать код, хоть иногда выбирал костыльные решения. Вот что еще можно посмотреть:

- Factory - там реализовано прикольное обобщение Bullet и ее Data, хотя смысла в этом по итогу не очень много
- TimeScaleSlider - просто небольшой UI класс с правильной ответственостью и интерфейсом 
