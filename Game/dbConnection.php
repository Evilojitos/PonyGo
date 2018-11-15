<?php
$host = 'host=localhost'; 
$mysql_user = 'root';
$mysql_password = '';
$database = 'ponygo';

try{
$pdo=new PDO("mysql:$host;dbname=$database", $mysql_user, $mysql_password);
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $pdo->exec('SET NAMES "utf8"');
    
}
catch(PDOException $e){
    echo "ERROR CONNECTING DATABASE".$e->getMessage();
    exit();
}


?>