<?php
include "dbConnection.php";
//$userName=!isset($_POST['userName'])?"":$_POST['userName'];
//$password=!isset($_POST['password'])?"":hash("sha256", $_POST['password']);
$userName=!isset($_POST['userName'])?"":$_POST['userName'];
$apellido=!isset($_POST['apellido'])?"":$_POST['apellido'];
$carrera=!isset($_POST['carrera'])?"":$_POST['carrera'];
$correo=!isset($_POST['correo'])?"":$_POST['correo'];
$password=!isset($_POST['password'])?"":hash("sha256", $_POST['password']);

$holi="Usuario ya existente";
$holi2="EXITOOO";
$sql="SELECT nombre_usuario FROM usuario WHERE 	nombre_usuario='$userName'";
$result=$pdo->query($sql);
if($result->rowCount()>0){
    $data=array('done'=>false, 'message'=>$holi);
    Header('Content-Type: application/json');
    json_encode($data);
    exit();
}else{
     $sql="INSERT INTO usuario SET nombre_usuario='$userName', apellido='$apellido', carrera='$carrera', correo='$correo', password='$password'";
    $pdo->query($sql);
    $data=array('done'=>true, 'message'=>$holi);
    Header('Content-Type: application/json');
    json_encode($data);
    exit();
}
  

?>