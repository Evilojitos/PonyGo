<?php
include "dbConnection.php";
$userName=!isset($_POST['userName'])?"":$_POST['userName'];
$password=!isset($_POST['password'])?"":hash("sha256", $_POST['password']);

$holi="BIENVENIDO";
$holi2="nombre de usuario y contraseña incorrectos";
$sql="SELECT nombre_usuario FROM usuario WHERE nombre_usuario='$userName' AND password='$password'";

$resulta=$pdo->query($sql);
if($resulta->rowCount()>0){
    $data=array('done'=>true, 'message'=>$holi);
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();

}
else{
    $data=array('done'=>false, 'message'=>$holi2);
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();

}

?>