# Документация по первому заданию

## Задание

+ Создать файл XML для произвольной передачи данных
+ XML-файл должен содержать:
  + telefoninr
  + nimi
  + kellaaeg
  + teenus
  + makstud
+ Отображение данных в виде таблицы HTML с использованием различных функций в XSLT и PHP 
+ Придумать хотя бы 3 функции
  + Поиск по имени
  + Вывод количества всех данных в таблице
  + Сортировка по всем столбцам
  
### Вид сайта

![View](https://i.imgur.com/51P2Iun.png)
  
### XML файл
```
<kasutajad>
    <kasutaja>
        <nimi>Рита</nimi>
        <telefoninr>3725512588</telefoninr>
        <teenus>
            <nimetus>Стрижка</nimetus>
            <makstud>Нет</makstud>
            <kellaaeg>24.12.2019</kellaaeg>
        </teenus>
    </kasutaja>

    <kasutaja>
        <nimi>Карина</nimi>
        <telefoninr>3725552558</telefoninr>
        <teenus>
            <nimetus>Стрижка</nimetus>
            <makstud>Да</makstud>
            <kellaaeg>24.12.2019</kellaaeg>
        </teenus>
    </kasutaja>

        <kasutaja>
        <nimi>Жрина</nimi>
        <telefoninr>37256789123</telefoninr>
        <teenus>
            <nimetus>Покраска</nimetus>
            <makstud>Да</makstud>
            <kellaaeg>20.12.2019</kellaaeg>
        </teenus>
    </kasutaja>

        <kasutaja>
        <nimi>Кира</nimi>
        <telefoninr>3725252788</telefoninr>
        <teenus>
            <nimetus>Покраска</nimetus>
            <makstud>Нет</makstud>
            <kellaaeg>26.12.2019</kellaaeg>
        </teenus>
    </kasutaja>

        <kasutaja>
        <nimi>Брина</nimi>
        <telefoninr>3725561118</telefoninr>
        <teenus>
            <nimetus>Стрижка</nimetus>
            <makstud>Да</makstud>
            <kellaaeg>27.12.2019</kellaaeg>
        </teenus>
    </kasutaja>
</kasutajad>
```

## Документация кода PHP

### Для дизайна страницы использовались Bootstrap 4.3.1 и FontAwesome 4.7.0

### Запрос XML файла
```
$kasutajad = simplexml_load_file("inimesed.xml");
```
### Функция поиска по имени
```
function searchKasutajadByName($query){
    global $kasutajad;
    $result = array();
    foreach ($kasutajad -> kasutaja as $kasutaja){
        if (substr(strtolower($kasutaja -> nimi), 0, strlen($query))==strtolower($query))
            array_push($result, $kasutaja);
    }
    return $result;
}
```
### Вывод данных в талицу
```
<?php
            
foreach($kasutajad -> kasutaja as $kasutaja) {
    $counter++;
    echo "<tr>";
    echo "<td>".($kasutaja -> nimi)."</td>";
    echo "<td>".($kasutaja -> telefoninr)."</td>";
    echo "<td>".($kasutaja -> teenus -> nimetus)."</td>";
    echo "<td>".($kasutaja -> teenus -> makstud)."</td>";
    echo "<td>".($kasutaja -> teenus -> kellaaeg)."</td>";
    echo "</tr>";
    }
    echo "Всего заказов ".($counter);

?>
```
### Вывод данных в таблицу при поиске
```
<?php
    if(!empty($_POST["searchName"])){
    $result = searchKasutajadByName($_POST["searchName"]);
    foreach($result as $kasutaja) {
        echo "<tr>";
        echo "<td>".($kasutaja -> nimi)."</td>";
        echo "<td>".($kasutaja -> telefoninr)."</td>";
        echo "<td>".($kasutaja -> teenus -> nimetus)."</td>";
        echo "<td>".($kasutaja -> teenus -> makstud)."</td>";
        echo "<td>".($kasutaja -> teenus -> kellaaeg)."</td>";
        echo "</tr>";
        }
    }
?>
```
### Скрипт сортировки данных
```
<script>
  function sortTable(n) {
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById("myTable");
  switching = true;
  //Set the sorting direction to ascending:
  dir = "asc"; 
  /*Make a loop that will continue until
  no switching has been done:*/
  while (switching) {
      //start by saying: no switching is done:
      switching = false;
      rows = table.rows;
      /*Loop through all table rows (except the
      first, which contains table headers):*/
      for (i = 1; i < (rows.length - 1); i++) {
      //start by saying there should be no switching:
      shouldSwitch = false;
      /*Get the two elements you want to compare,
      one from current row and one from the next:*/
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      /*check if the two rows should switch place,
      based on the direction, asc or desc:*/
      if (dir == "asc") {
          if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          //if so, mark as a switch and break the loop:
          shouldSwitch= true;
          break;
          }
      } else if (dir == "desc") {
          if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          //if so, mark as a switch and break the loop:
          shouldSwitch = true;
          break;
          }
      }
      }
      if (shouldSwitch) {
      /*If a switch has been marked, make the switch
      and mark that a switch has been done:*/
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      //Each time a switch is done, increase this count by 1:
      switchcount ++;      
      } else {
      /*If no switching has been done AND the direction is "asc",
      set the direction to "desc" and run the while loop again.*/
      if (switchcount == 0 && dir == "asc") {
          dir = "desc";
          switching = true;
      }
      }
  }
  }
</script>
```
# Документация по второму заданию
## Задание
Создать сайт на ASP.NET MVC WEB API. 
+ Сервис позволяет пользователю войти в веб-приложение, используя адрес электронной почты и пароль
+ В базе данных хранятся бронирования (номер телефона, имя, время, услуга, платная), предлагаемые услуги и пароли пользователей / электронные письма (администраторы).
+ Веб-сервис обеспечивает связь между веб-приложением и базой данных, возвращая и изменяя информацию об услугах / бронированиях и пользовательских данных.

+ Функциональность приложения как сотрудника:
  + Существующие бронирования могут быть просмотрены.
  + Бронирование может быть отменено.
  + Добавление новых услуг (с ценой, описанием и продолжительностью)

+ Функциональность приложения как обычного пользователя (как клиента салона красоты):
  + Бронирование может быть сделано и отменено за 24 часа до начала бронирования.
  + Свободное время можно увидеть.
  + предоставляемые услуги (цена, продолжительность, описание) можно увидеть.
  + Можно получить напоминание за 24 часа до начала бронирования
  
## В итоге что реализовано
### Гость
Обычный гость может:
  + Просмотреть услуги 
  + Зарегистрироваться 
  + Залогиниться
![Просмотреть товар](https://i.imgur.com/5YoaET1.png)
![Залогиниться](https://i.imgur.com/IbQ6okJ.png)
![Зарегистрироваться](https://i.imgur.com/69OucaZ.png)

### Пользователь
Пользователь может:
  + Просмотреть услуги 
  + Зарегистрироваться 
  + Залогиниться
  + Забронировать услугу со свободным временем и датой
  + Имеет свой личный профиль на котором
  отображаются его личные данные и заказы
  + Отменить услугу и изменить время
![Забронировать услугу со свободным временем и датой](https://i.imgur.com/IPdMn1z.png)
![Забронировать услугу со свободным временем и датой](https://i.imgur.com/OPO89qh.png)
![Имеет свой личный профиль на котором отображаются его личные данные и заказы](https://i.imgur.com/TDgygep.png)
  
### Администратор
Администратор может:
  + Просмотреть услуги 
  + Зарегистрироваться 
  + Залогиниться
  + Забронировать услугу со свободным временем и датой
  + Имеет свой личный профиль на котором
  отображаются его личные данные и заказы
  + Отменить услугу и изменить время
  + Просматривать, сортировать все заказанные услуги, редактировать и удалять их
  + Просматривать, сортировать, добавлять услуги, редактировать и удалять их
  + Просматривать, сортировать, добавлять рабочие дни, редактировать и удалять их
![Просмотреть услуги](https://i.imgur.com/6jyRbWs.png)
![Просматривать все заказанные услуги, редактировать и удалять их](https://i.imgur.com/5hiE0Ab.png)
![Просматривать, добавлять рабочие дни, редактировать и удалять их](https://i.imgur.com/AeLr3Mz.png)
