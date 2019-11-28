<?php
$kasutajad = simplexml_load_file("inimesed.xml");
echo $kasutajad -> kasutaja[0] -> attributes() -> id;
$counter = 0;

function searchKasutajadByName($query){
    global $kasutajad;
    $result = array();
    foreach ($kasutajad -> kasutaja as $kasutaja){
        if (substr(strtolower($kasutaja -> nimi), 0, strlen($query))==strtolower($query))
            array_push($result, $kasutaja);
    }
    return $result;

}
?>
<!DOCTYPE html>
<html>
    <head>
        <title>Клиенты</title>
        <meta charset="utf-8">
        
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
   </head>
    <body style="background-color: white;">
        <div class="container">
            <h1 style="text-align: center;">Салон красоты "Екасосинка<i class="fa fa-cut" aria-hidden="true"></i>"</h1>
            <br>
            <h3 style="text-align: center;">Все клиенты с XML файла</h3>
            <table id="myTable" border="0" class="table table-responsive-md">
                <thead class="thead-light">
                    <tr>
                        <th scope="col" onclick="sortTable(0)">Имя</th>
                        <th scope="col" onclick="sortTable(1)">Номер телефона</th>
                        <th scope="col" onclick="sortTable(2)">Услуга</th>
                        <th scope="col" onclick="sortTable(3)">Оплачено</th>
                        <th scope="col" onclick="sortTable(4)">Дата приема</th>
                    </tr>
                </thead>
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
            </table>        
            <br />
            <h3 style="text-align: center;">Поиск по имени</h3>
            <form action="?" method="post">
                Поиск по имени: <input style="border-radius: 7px; height: 35px;" type="text" name="searchName" placeholder="имя"/>
                <input class="btn btn-primary mb-2" type="submit" value="Найти" />
            </form>
            <table border="0" class="table table-responsive-lg">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Имя</th>
                        <th scope="col">Номер телефона</th>
                        <th scope="col">Услуга</th>
                        <th scope="col">Оплачено</th>
                        <th scope="col">Дата приема</th>
                    </tr>
                </thead>
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
            </table>
        </div>

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
    </body>
</html>