<?php
include "dbConnection.php";
$userName=$_POST['userName'];
$password=hash("sha256", $_POST['password']);

$holi="BIENVENIDO";
$holi2="nombre de usuario y contraseña incorrectos";
$sql="SELECT nombre_usuario FROM usuario WHERE nombre_usuario='$userName' AND password='$password'";

$resulta=$pdo->query($sql);
if($resulta->rowCount()>0){
    $data=array('done'=>true, 'message'=>$holi);
    Header('Content-Type: application/json');
    echo error_log(json_encode($data));
    exit();
    echo "FUNCIONÓ";
}
else{
    $data=array('done'=>false, 'message'=>$holi2);
    Header('Content-Type: application/json');
    echo error_log(json_encode($data));
    exit();
    echo "Did not work!";
}

?>