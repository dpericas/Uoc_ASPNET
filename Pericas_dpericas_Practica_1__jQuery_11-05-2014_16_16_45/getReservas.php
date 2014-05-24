<?php
//*******************  MAIN ******************************
header('Content-Type: text/html; charset=ISO-8859-1');
$database = 'restaurantuoc';
//S'obté l'identificador de reserva i acció en el cas de que n' hi hagi del paràmetre en l'URL
if ( isset($_GET["id"]) ) $idReserva = $_GET["id"];
if ( isset($_GET["actionDb"]) ) $actionRes = $_GET["actionDb"];
// Obtenim les variables del formulari si existeigen
if ( isset($_GET["newname"]) ) $nameToInsert = $_GET["newname"];
if ( isset($_GET["newCognom"]) ) $cognomToInsert = $_GET["newCognom"];
if ( isset($_GET["newTelf"]) ) $telfToInsert = $_GET["newTelf"];
if ( isset($_GET["anys"]) ) $anyToInsert = $_GET["anys"];
if ( isset($_GET["mesos"]) ) $mesToInsert = $_GET["mesos"];
	if ( $mesToInsert < 10 ) $mesToInsert="0".$mesToInsert;
if ( isset($_GET["dies"]) ) $diaToInsert = $_GET["dies"];
if ( isset($_GET["hores"]) ) $horaToInsert = $_GET["hores"];
if ( isset($_GET["minuts"]) ) $minutToInsert = $_GET["minuts"];
if ( isset($_GET["newComensal"]) ) $comensalToInsert = $_GET["newComensal"];
if ( isset($_GET["newComent"]) ) $comentToInsert = $_GET["newComent"];
if ( isset($_GET["newid"]) ) $idToModif = $_GET["newid"];
if ( !isset($idReserva) ){
	if ( $actionRes == "24h" || $actionRes == "24hcheck") $sqlQuery = "SELECT * FROM reserves WHERE data BETWEEN now() and (now() + interval 1 day) order by data;";//Consulta per al llistat de reserves de próximes 24 hores.
	else $sqlQuery = "Select * from reserves where data > now() order by data"; //Consulta del llistat de reserves principal.
}
else {
	if ( $actionRes == "deleteRes" ) $sqlQuery = "delete from reserves where id=\"".$idReserva."\""; //Consulta per eliminar el id seleccionat de la base de dades.
	else if ( $actionRes == "sendPost" ) $sqlQuery = "INSERT into restaurantuoc.reserves (nom,cognoms,telefon,data,comensals,comentaris) VALUES (\"".$nameToInsert."\",\"".$cognomToInsert."\",".$telfToInsert.",\"".$anyToInsert."-".$mesToInsert."-".$diaToInsert." ".$horaToInsert.":".$minutToInsert.":00\",".$comensalToInsert.",\"".$comentToInsert."\")";
	else if ( $actionRes == "updatePost" ) $sqlQuery = "UPDATE restaurantuoc.reserves SET nom=\"".$nameToInsert."\",cognoms=\"".$cognomToInsert."\",telefon=".$telfToInsert.",data=\"".$anyToInsert."-".$mesToInsert."-".$diaToInsert." ".$horaToInsert.":".$minutToInsert.":00\",comensals=".$comensalToInsert.",comentaris=\"".$comentToInsert."\" WHERE id=".$idToModif;
	else if ( $idReserva != "new" )$sqlQuery = "Select * from reserves where id=\"".$idReserva."\""; //Consulta per els casos de Detall i Modifica.
}
$link = mysql_connect('localhost','root','uoc') or die('Could not connect ' . mysql_errno());
mysql_select_db($database ,$link) or die("Error selecting db.");
//Si hi ha resultats en la consulta SQL procedim.
if($result = mysql_query($sqlQuery)){
	$total_rows = mysql_num_rows($result);
	//es torna la informació en una taula segons opcions.
	if($total_rows >= 1){
		if ( !isset($idReserva) ) { //Html sortint en els casos de llistats de reserves / 24h.
			if ( $actionRes == "24hcheck" ) {
				echo '<a href="#" class="show24h" id="24hlink">HI HA RESERVES A LES PROXIMES 24 HORES.</a>';
			}
			else {
					?><div id="if24h"><?php if ( $actionRes != "24h" ) {}?></div>
				<table id="tableReservasA">
					<tr bgcolor="#A4A4A4">
						<td><strong>Nom</strong></td>
						<td><strong>Cognoms</strong></td>
						<td><strong>Telefon</strong></td>
						<td><strong>Data</strong></td>
						<td><strong>Comensals</strong></td>
					</tr>
				</table>
				<div id="updatableContent">
				<table id="tableReservas"><?php
				while ($row = mysql_fetch_assoc($result)){
				?>
				<tr class="treservas">
					<td><?php echo $row["nom"]?></td>
					<td><?php echo $row["cognoms"]?></td>
					<td><?php echo $row["telefon"]?></td>
					<td><?php echo $row["data"]?></td>
					<td><?php echo $row["comensals"]?></td>
					<td>
						<form id="idform" class="reservaRegForm">
							<input type="button" name="idform" id="detailid<?php echo $row["id"]?>" value="Detall" class="detailres"></input>
							<input type="button" name="idform" id="modid<?php echo $row["id"]?>" value="Modificar" class="novamodif"></input>
							<input type="button" name="idform" id="delid<?php echo $row["id"]?>" value="Eliminar" class="delRes"></input>
						</form>
					</td>
				</tr><?php
				}
				?></table></div><?php
			}
		}
		else { //Html sortint per als casos de Detall i Modifica.
			if ( $actionRes == "detailRes" ) {
				while ($row = mysql_fetch_assoc($result)){
				?><div id="updatableContent"><table id="tabledetail">
					<tr>
						<td bgcolor="#A4A4A4"><strong>Nom: </strong></td>
						<td><?php echo $row["nom"]?></td>
					</tr>
					<tr>
						<td bgcolor="#A4A4A4"><strong>Cognoms: </strong></td>
						<td><?php echo $row["cognoms"]?></td>
					</tr>
					<tr>
						<td bgcolor="#A4A4A4"><strong>Telefon: </strong></td>
						<td><?php echo $row["telefon"]?></td>
					</tr>
					<tr>
						<td bgcolor="#A4A4A4"><strong>Data: </strong></td>
						<td><?php echo $row["data"]?></td>
					</tr>
					<tr>
						<td bgcolor="#A4A4A4"><strong>Comensals: </strong></td>
						<td><?php echo $row["comensals"]?></td>
					</tr>
					<tr>
						<td bgcolor="#A4A4A4"><strong>Comentaris: </strong></td>
						<td><?php echo $row["comentaris"]?></td>
					</tr>
				</table></div>
				<form id="idform" class="reservaRegForm2">
					<input type="button" name="idform" id="modid<?php echo $row["id"]?>" value="Modificar" class="novamodif"></input>
					<input type="button" name="idform" id="delid<?php echo $row["id"]?>" value="Eliminar" class="delRes"></input>
				</form>
				<?php
				}
			}
			else { //Cas Modifiquem Reserva
				while ($row = mysql_fetch_assoc($result)){
					formBuilder($row["id"],$row["nom"],$row["cognoms"],$row["telefon"],$row["data"],$row["comensals"],$row["comentaris"]);
				}
			}
		}
	}
	else{
		 //Quan eliminem ens retorna 0 rows, però també passa si no tenim dades disponibles a la base de dades, o quan modifiquem el contingut. Per tant mostrem text de taula buida.
		if ( $actionRes == "24h" ){
			?><div id="updatableContent"><table id="tableReservas"><tr><td><strong>NO HI HA RESERVES PREVISTES PER LES PROXIMES 24 HORES.</strong></td></tr></table></div><?php 
		}
		else if ( $actionRes == "sendPost" ) {
			echo "sent";
		}
		else if ( $actionRes == "updatePost" ) {
			echo "updated";
		}
		else if ( !isset($actionRes) ){
			?><div id="updatableContent"><table id="tableReservas"><tr><td><strong>NO HI HA RESERVES PREVISTES.</strong></td></tr></table></div><?php 
		}
	}
	if ( !isset($idReserva) ) { //Només mostrem el botó de nova reserva per als casos de llistat de reserva / 24h.
		if ( !isset($actionRes) || $actionRes != "24hcheck" ) {
			?><form id="novaReservaForm" class="novamodif"><input type="button" id="novaresbutton" value="Nova Reserva"></input></form><?php
		}
	}
}
else{ //Cas de nova reserva.
	formBuilder();
}
mysql_close($link);

//*************** FINAL MAIN ************************

//**************** FUNCIÓ FORMULARI NOVA/MODIFICA RESERVA ***********************
function formBuilder($idtoEdit,$nom,$cognom,$telefon,$data,$comensals,$comentari){
	$monthsArray=array('Gener','Febrer','Març','Abril','Maig','Juny','Juliol','Agost','Setembre','Octubre','Novembre','Decembre');
	
	$formText='<div id="infoBox"></div>';
	$formText=$formText.'<form id="reservaForm" method="POST"><label for="newname">Nom: </label></br><input type="text" name="newname" id="nomForm" ';
	if ( isset($nom) ) $formText=$formText.'value="'.$nom.'"';
	$formText=$formText.' class="fieldsVal"></input></br>';
	$formText=$formText.'<label for="newCognom">Cognoms: </label></br><input type="text" name="newCognom" id="cognomForm" ';
	if ( isset($cognom) ) $formText=$formText.'value="'.$cognom.'"';
	$formText=$formText.' class="fieldsVal"></input></br>';
	$formText=$formText.'<label for="newTelf">Telefon: </label></br><input type="text" name="newTelf" id="telfForm" ';
	if ( isset($telefon) ) $formText=$formText.'value="'.$telefon.'"';
	$formText=$formText.' class="fieldsVal"></input></br>';
	$formText=$formText.'<label for="newData">Data: </label></br>';
	$formText=$formText.'<div id="divTime" name="divTime" class="fieldsVal">';
	if ( isset($data) ) {$data=date_create($data);}
	else {$data=date('Y-m-d H:i:s');$data = date('Y-m-d H:i:s', strtotime($data . ' + 1 day'));$data = date('Y-m-d H:i:s', strtotime($data . ' + 1 hour'));$data=date_create($data);}
	$formText=$formText.'<select id="dies" name="dies" class="fieldTime">';
	$diaSelected=date_format($data,'d');
	for($i=1;$i <= 31;$i++){
		if ( $i < 10 ) $i="0".$i;
		if ( $i == $diaSelected ) $formText=$formText.'<option value="'.$i.'" selected>'.$i.'</option>';
		else $formText=$formText.'<option value="'.$i.'">'.$i.'</option>';
	}
	$formText=$formText.'</select>';
	$formText=$formText.'<select id="mesos" name="mesos" class="fieldTime">';
	$mesSelected=date_format($data,'n');
	for($i=0;$i < count($monthsArray);$i++){
		if ( $i == ( $mesSelected-1 ) ) $formText=$formText.'<option value="'.($i+1).'" selected>'.$monthsArray[$i].'</option>';
		else $formText=$formText.'<option value="'.($i+1).'">'.$monthsArray[$i].'</option>';
	}
	$formText=$formText.'</select>';
	$formText=$formText.'<select id="anys" name="anys" class="fieldTime">';
	$anySelected=date_format($data,'Y');
	for($i=2014;$i <= 2020;$i++){
		if ( $i == $anySelected ) $formText=$formText.'<option value="'.$i.'" selected>'.$i.'</option>';
		else $formText=$formText.'<option value="'.$i.'">'.$i.'</option>';
	}
	$formText=$formText.'</select>';
	$formText=$formText.'<select id="hores" name="hores" class="fieldTime">';
	$horaSelected=date_format($data,'H');
	for($i=0;$i < 24;$i++){   // En aquest cas em posat les 24h però hauríem d'acotar els options al horari del restaurant.
		if ( $i < 10 ) $i="0".$i;
		if ( $i == $horaSelected ) $formText=$formText.'<option value="'.$i.'" selected>'.$i.'</option>';
		else $formText=$formText.'<option value="'.$i.'">'.$i.'</option>';
	}
	$formText=$formText.'</select>';
	$formText=$formText.'<select id="minuts" name="minuts" class="fieldTime">';
	$minutSelected=date_format($data,'i');
	for($i=0;$i < 60;$i++){
		if ( $i < 10 ) $i="0".$i;
		if ( $i == $minutSelected ) $formText=$formText.'<option value="'.$i.'" selected>'.$i.'</option>';
		else $formText=$formText.'<option value="'.$i.'">'.$i.'</option>';
	}
	$formText=$formText.'</select></div>';
	$formText=$formText.'</br><label for="newComensal">Comensals: </label></br><input type="text" name="newComensal" id="comensalForm" ';
	if ( isset($comensals) ) $formText=$formText.'value="'.$comensals.'"';
	$formText=$formText.' class="fieldsVal"></input></br>';
	$formText=$formText.'<label for="newComent">Comentaris: </label></br><textarea cols="50" rows="5" name="newComent" id="comentForm"  class="fieldsVal">';
	if ( isset($comentari) ) $formText=$formText.$comentari;
	$formText=$formText.'</textarea></br></br></br>';
	if ( isset($idtoEdit) ) $formText=$formText.'<input type="hidden" name="newid" id="idForm" value="'.$idtoEdit.'"></input>';
	$formText=$formText.'<input type="submit" value="GUARDAR" id="saveForm"></input></form>';
	echo $formText;
}
?>