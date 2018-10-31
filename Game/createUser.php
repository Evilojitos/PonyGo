<?php
include "dbConnection.php";

$userName=$_POST['userName'];
$apellido=$_POST['apellido'];
$carrera=$_POST['carrera'];
$correo=$_POST['correo'];
$password=hash("sha256", $_POST['password']);

echo $userName;

$holi="Usuario ya existente";
$holi2="EXITOOO";
$sql="SELECT nombre_usuario FROM usuario WHERE 	nombre_usuario='$userName'";
$result=$pdo->query($sql);
if($result->rowCount()>0){
    $data=array('done'=>false, 'message'=>$holi);
    Header('Content-Type: application/json');
    echo error_log(json_encode($data));
    exit();
}
else{
    $sql="SELECT correo FROM usuario WHERE correo='$correo'";
$result=$pdo->query($sql);
if($result->rowCount()>0){
    $data=array('done'=>false, 'message'=>$holi);
    Header('Content-Type: application/json');
    error_log(json_encode($data));
    exit();
}else{
     $sql="INSERT INTO usuario SET nombre_usuario='$userName', apellido='$apellido', carrera='$carrera', correo='$correo', password='$password'";
    $pdo->query($sql);
    $data=array('done'=>true, 'message'=>$holi2);
    Header('Content-Type: application/json');
    error_log(json_encode($data));
    exit();
}
  }

?>